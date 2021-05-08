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

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {



                // Fetch the current user of the machine to use as the start path to the Valheim files. This grabs the current user profile.
                string theUser = Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            // Combine the USER path to the path where Valheim files reside.
                string valheimPath = Path.Combine(theUser, "AppData/LocalLow/IronGate/Valheim");

            // Full path to the "worlds" folder to grab all the world files from.
                string worldsPath = Path.GetFullPath(Path.Combine(valheimPath, "worlds"));

            // Full path to the "characters" folder to grab all the character files from.
                string charsPath = Path.GetFullPath(Path.Combine(valheimPath, "characters"));


                // If the Valheim AppData folder does not exist Show message and "return" to stop the program from trying to execute.
                if (!Directory.Exists(Path.GetFullPath(valheimPath)))
                {
                    MessageBox.Show("Cannot locate Valheim saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.");
                    return;
                }

                if (!Directory.Exists(worldsPath))
                {
                    MessageBox.Show("Cannot locate Valheim world saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.");
                    return;
                }

                if (!Directory.Exists(charsPath))
                {
                    MessageBox.Show("Cannot locate Valheim character saves.\nPlease ensure Valheim is installed.\nOr run with Admin privileges.");
                    return;
                }

                // if the backup location label is empty display a message.
                if (LblBrowse.Text == "")
                {
                    MessageBox.Show("You have not selected a backup destination. Please browse to desired backup location.");
                }

                // Do the Backup
                else
                {
                    // Play audio?
                    System.IO.Stream strm = Properties.Resources.vMusS;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(strm);
                    snd.Play();



                    // set the progress bar to visible min level and max level as well as current value
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = 4;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    // step the progress bar to 2 of 4
                    progressBar1.PerformStep();

                    // create folder with current date.
                    string dir = Path.GetFullPath(LblBrowse.Text +@"\" + DateTime.Now.ToString("MM-dd-yy - HH.mm").Insert(11, "h").Replace(".", ""));



                    // backup the worlds
                    string startPath = worldsPath;
                    string zipPath = @".\worlds.zip";
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
                    // step the progress bar to 3 of 4
                    progressBar1.PerformStep();


                    // backup the characters
                     startPath = charsPath;
                     zipPath = @".\characters.zip";
                     extractPath = dir + @"\characters";

                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }
                    // create a zip folder with the "characters" folder contents
                    ZipFile.CreateFromDirectory(startPath, zipPath);

                    // step the progress bar to 4 of 4
                    progressBar1.PerformStep();

                    // unzip the zip to copy the content of the folder to a new directory
                    ZipFile.ExtractToDirectory(zipPath, extractPath);



                    // clean up the zip files that were created by deleting them. 
                    // Might be good to save these as zipped in the first place.
                    // Maybe have another button "Backup as ZIP" 
                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }



                    // The program has successfully finished display a Backup complete box.
                    if (Directory.Exists(Path.GetFullPath(extractPath))
                        &&  !File.Exists(zipPath)
                        
                        )
                    {
                        MessageBox.Show("Backup Complete");
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

        private void BtnOpenDest_Click(object sender, EventArgs e)
        {
            try
            {
                if(LblBrowse.Text == "")
                {
                    MessageBox.Show("You have not selected a backup destination. Please browse to desired backup location.");
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Clear the label and selected path
            LblBrowse.Text = "";


        }

        private void btnAppInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app copies Valheim worlds and characters.\n" +
                "To a destination of your choice.\nThis allows you to backup your precious creations.\n" +
                "Love&Peace\n- S0ulL3sS");
        }
    }
    
}
