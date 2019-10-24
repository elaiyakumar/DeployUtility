using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace DeployUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            CopyFiles(textBoxPath.Text, textBoxDest.Text);
        }

        private void btnCopyDirectory_Click(object sender, EventArgs e)
        {
            CopyFolders(textBoxPath.Text, textBoxDest.Text);
        }


        private void btnGenerateAP_Click(object sender, EventArgs e)
        {
            textBoxOutPut.Text = "" ;
            
            int finalRes  = AirthmeticProgression(1, 2);

            textBoxOutPut.Text =  finalRes.ToString();

        }


        private int AirthmeticProgression(int x, int d)
        { 
            int z = 0;

            z = x + d;
            
            //textBoxOutPut.Text = textBoxOutPut.Text + ", " + z.ToString();

            if (z >= 15) 
            {
                return z; 
            }
            else {
                return AirthmeticProgression(z, d);
            }

            return z;
        } 

        private void CopyFiles(string sourcePath, string targetPath)
        {
            string fileName = "";
            string destFile = "";
             
            string[] files = Directory.GetFiles(sourcePath);

            // Copy the files and overwrite destination files if they already exist. 
            foreach (string currentFile in files)
            {
                // Use static Path methods to extract only the file name from the path.
                fileName = Path.GetFileName(currentFile);
                destFile = Path.Combine(targetPath, fileName);

                if (fileName == "Ram.txt")
                {

                }
                else
                {
                    File.Copy(currentFile, destFile, true);
                }
              
            }     

        }
         
        private void CopyFolders(string sourceFolder, string destFolder)
        {
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                Directory.CreateDirectory(dest);
            }
        }
        
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

       



        ////

    }
}

       
