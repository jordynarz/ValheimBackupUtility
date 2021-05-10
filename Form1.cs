using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Compression;


namespace ValheimBackup
{
    public partial class ValheimBackup : Form
    {
        public ValheimBackup()
        {
            InitializeComponent();



        }


        /*  Create an advanced button that reveals controls to select folder of files to be copied.
         *  Save Settings to remeber previous configuration 
         * 
         */
        private void ValheimBackup_Load(object sender, EventArgs e)
        {

        }

        // check all the user paths for validation.
        private bool chkPaths
        {
            
            get
            {
                
                thePaths(out string worldsPath, out string charsPath, out string valheimPath);
                

                // If the Valheim AppData folder does not exist Show message and "return" to stop the program from trying to execute.
                if (!Directory.Exists(Path.GetFullPath(valheimPath)))
                {
                    MessageBox.Show("Cannot locate Valheim saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.", "Warning");
                    return false;
                }

                if (!Directory.Exists(worldsPath))
                {
                    MessageBox.Show("Cannot locate Valheim world saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.", "Warning");
                    return false;
                }

                if (!Directory.Exists(charsPath))
                {
                    MessageBox.Show("Cannot locate Valheim character saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.", "Warning");
                    return false;
                }
                return true;
            }
        }

        private void thePaths(out string worldsPath, out string charsPath, out string valheimPath)
        {
              // Fetch the current user of the machine to use as the start path to the Valheim files. This grabs the current user profile.
              string theUser = Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

              // Combine the USER path to the path where Valheim files reside.
              valheimPath = Path.Combine(theUser, "AppData/LocalLow/IronGate/Valheim");

              // Full path to the "worlds" folder to grab all the world files from.
              worldsPath = Path.GetFullPath(Path.Combine(valheimPath, "worlds"));

              // Full path to the "characters" folder to grab all the character files from.
              charsPath = Path.GetFullPath(Path.Combine(valheimPath, "characters"));

                        
          }
        
        // method to play an audio file, this is used when backing up the game files.
        private void theAudio(out System.Media.SoundPlayer snd)
        {
            // Play audio?
            System.IO.Stream strm = Properties.Resources.vMusS;
            snd = new System.Media.SoundPlayer(strm);
            snd.Play();
            
        }

        // method to display the progress bar
        private void proGress()
        {
            // set the progress bar to visible min level and max level as well as current value
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 4;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
        }

        // Method to Backup the game files, the main function of this app
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {                
                // if the backup location label is empty display a message.
                if (LblBrowse.Text == "")
                {
                    MessageBox.Show("You have not selected a backup destination.\nPlease browse to desired backup location.", "Warning");
                    return;
                }
                // check to see if the paths to the game folder are valid. If they are not the check returns false. 
                if (chkPaths == false)
                {
                    return;
                }

                // Do the Backup
                else
                {
                    // create folder with current date.
                    string dir = Path.GetFullPath(LblBrowse.Text +@"\" + DateTime.Now.ToString("MM-dd-yy - HH.mm").Insert(11, "h").Replace(".", ""));

                    if (Directory.Exists(Path.GetFullPath(dir)))
                    {
                        MessageBox.Show("Directory Exists\nDuplicate Backup Prevented", "Warning");
                        return;
                    }                    
                    
                    // make visble the progress bar
                    proGress();
                    // step the progress bar
                    progressBar1.PerformStep();

                    // Play the Audio
                    theAudio(out System.Media.SoundPlayer snd);


                    // Step the progress bar manually
                    progressBar1.PerformStep();
                    // run the method that zips and unzips the worlds folder
                    cpWorlds(dir);

                    // step the progress bar to 3 of 4
                    progressBar1.PerformStep();

                    // run the method that zips and unzips the characters folder
                    cpChars(dir);

                    // Step the progress bar manually
                    progressBar1.PerformStep();

                    // The program has successfully finished display a Backup complete box.
                    if (Directory.Exists(Path.GetFullPath(dir)))
                        
                    {
                        snd.Stop();
                        MessageBox.Show("Backup Complete", "Success");
                        progressBar1.Visible = false;
                    }


                }
                
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message);
                
            }
            catch (Exception sys)
            {
                MessageBox.Show(sys.Message);
            }

        }

        // method for zipping and zipping the worlds folder and contents to a new location.
        private void cpWorlds(string dir)
        {
            // call the User path method "_" discarding one argument
            thePaths(out string worldsPath, out _, out _);
            // backup the worlds
            string startPath = worldsPath;
            string zipPath = Path.GetFullPath(LblBrowse.Text + @"\worlds.zip");
            string extractPath = dir + @"\worlds";

            // if the zip file already exists. Delete it so the app can zip it up again.
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            // create a zip folder with the "worlds" folder contents
            ZipFile.CreateFromDirectory(startPath, zipPath);
            // unzip the zip to copy the content of the folder to a new directory
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            // clean up the zip files that were created by deleting them. 
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
        }

        // method for zipping and zipping the characters folder and contents to a new location.
        private void cpChars(string dir)
        {
            // call the User path method "_" discarding one argument
            thePaths(out _, out string charsPath, out _);

            // backup the worlds
            string startPath = charsPath;
            string zipPath = Path.GetFullPath(LblBrowse.Text + @"\characters.zip");
            string extractPath = dir + @"\characters";

            // if the zip file already exists. Delete it so the app can zip it up again.
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            // create a zip folder with the "worlds" folder contents
            ZipFile.CreateFromDirectory(startPath, zipPath);
            // unzip the zip to copy the content of the folder to a new directory
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            // clean up the zip files that were created by deleting them. 
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
        }

        // method to browse and locate a drive location
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                // Browse for a file or folder path to use for Backup location
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    LblBrowse.Text = folderBrowserDialog1.SelectedPath;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

    }

        // method to open the selected browse drive location
        private void BtnOpenDest_Click(object sender, EventArgs e)
        {
            try
            {
                if(LblBrowse.Text == "")
                {
                    MessageBox.Show("You have not selected a backup destination.\nPlease browse to desired backup location.", "Warning");
                }
                else
                {
                // Open the Selected Backup Location
                System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", LblBrowse.Text);
                }

 
            }
            catch (Win32Exception win32Exception)
            {
                MessageBox.Show(win32Exception.Message);
            }



        }



        // clear the selected browse drive location
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Clear the label and selected path
            LblBrowse.Text = "";

        }

        // display information about this app
        private void btnAppInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app copies Valheim worlds and characters.\n" +
                "To a destination of your choice.\nThis allows you to backup your precious creations.\n" +
                "Love&Peace\n- Jordynarz\n\nGitHub - https://github.com/jordynarz/", "Application Information");
        }
    }
    
}
