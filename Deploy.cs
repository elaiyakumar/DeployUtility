using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeployUtility
{

    public partial class Deploy : Form
    {
        private string appPath = "";
        private string appPathCopy = "";
        private string exePath = "";
        private Color DefaultCellStyleBackColor;        
        private List<string> knownWebAPPFileName = new List<string> { "scope", "insight", "ls", "formistica", "fleetintel" , "apollo", "apollo" , "focalpoint", "scqf", "sruc", "unificence" };

        List<Color> lstColor = new List<Color> {};



        //private bool IsDebug = false;

        //private const int CExt = 1;
        //private const int CPath = 1;
        //private const int CPFilename = 1;

        public Deploy()
        {
            InitializeComponent();
        }

        private void btnSourceSelect_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = (tbSourcePath.Text == "" ? appPath : tbSourcePath.Text);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tbSourcePath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSourceSelectJS_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = (tbSourcePathJS.Text == "" ? appPath : tbSourcePathJS.Text);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tbSourcePathJS.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            try
            {

                lstColor = new List<Color> { Color.Honeydew, Color.LightYellow, Color.LavenderBlush, Color.LightSeaGreen, Color.LightYellow };

                chkALL.Checked = false;
                btnOpenDllPath.Visible = false;
                btnOpenJsPath.Visible = false;

                dataGridView1.DefaultCellStyle.BackColor = DefaultCellStyleBackColor;
                dataGridView1.DataSource = new List<CFile>();

                progressBar1.Value = 0;

                if (tbFilesList.Text == "")
                {
                    return;
                }

                if (Directory.Exists(tbSourcePath.Text) == false && Directory.Exists(tbSourcePathJS.Text) == false)
                {
                    return;
                }

                List<CFile> dllFilesToInclude = new List<CFile>();

                if (chkIncludeDlls.Checked && cmbWebAppDll.SelectedItem == null && cmbLibDll.SelectedItem == null)
                {
                    cmbWebAppDll.Focus();
                    MessageBox.Show("No WebApp dll and Lib dll selected from dropdown.");
                    cmbWebAppDll.Focus();
                    return;
                }

                if (chkIncludeDlls.Checked)
                {
                    if (cmbWebAppDll.SelectedItem != null)
                    {
                        dllFilesToInclude.Add(new CFile { Deploy = false, Name = cmbWebAppDll.SelectedItem.ToString(), Extension = "dll", docType = DocType.File });
                        dllFilesToInclude.Add(new CFile { Deploy = false, Name = cmbWebAppDll.SelectedItem.ToString(), Extension = "pdb", docType = DocType.File });
                    }
                    if (cmbLibDll.SelectedItem != null)
                    {
                        dllFilesToInclude.Add(new CFile { Deploy = false, Name = cmbLibDll.SelectedItem.ToString(), Extension = "dll", docType = DocType.File });
                        dllFilesToInclude.Add(new CFile { Deploy = false, Name = cmbLibDll.SelectedItem.ToString(), Extension = "pdb", docType = DocType.File });
                    }
                }             

                string[] precompiledFiles = new string[] { };
                string[] jsMinifiedFiles = new string[] { };

                if (Directory.Exists(tbSourcePath.Text) == true)
                { 
                    precompiledFiles = Directory.GetFiles(tbSourcePath.Text);
                }
                if (Directory.Exists(tbSourcePathJS.Text) == true)
                {
                    jsMinifiedFiles = Directory.GetFiles(tbSourcePathJS.Text);
                }

                List<string> lstVersion = new List<string>();
                

                List<CFile> lstFilesInBin = getFilesInBin(precompiledFiles, dllFilesToInclude, out lstVersion);

                List<CFile> lstFilesInJSMin = getFilesInJSMin(jsMinifiedFiles);
                 
                List<CFile> listTFSFileList = getModifiedList(tbFilesList.Text);
                 
                List<CFile> lstFilesToDeploy = new List<CFile>();

                lstFilesToDeploy = getFilesToDeploy(listTFSFileList, dllFilesToInclude, lstFilesInJSMin, lstFilesInBin);

                showFilesInGrid(lstFilesToDeploy, lstVersion);                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<CFile> getModifiedList(string files)
        {
            List<CFile> lst = new List<CFile>();
            List<CFile> lstJs = new List<CFile>();

            try
            {

                List<CFile> listFiles = new List<CFile>();

                files.Split('\n').ToList().ForEach(line =>
                {
                    listFiles.Add(new CFile { Deploy = false, Name = "", Path = line, docType = DocType.Unknown });
                });

                foreach (CFile fil in listFiles)
                {
                    ////Directory.CreateDirectory(fil.Path)

                    if (Directory.Exists(fil.Path) == true)
                    {
                        fil.docType = DocType.Directory;
                    }
                    else
                    {
                        fil.docType = DocType.File;

                        string strLastPart = fil.Path.Split('\\').Last();

                        fil.Path = fil.Path.Replace("lock, ", "");
                        fil.Path = fil.Path.Replace("lock,", "");

                        if ((fil.Path.EndsWith("\tedit") == true || fil.Path.EndsWith("\tedit\r") == true) && strLastPart.Contains("."))
                        {
                            fil.Path = fil.Path.Replace("\tedit\r", "");
                            fil.Path = fil.Path.Replace("\tedit", "");
                            fil.docType = DocType.FileEdit;
                        }

                        if ((fil.Path.EndsWith("\tadd") == true || fil.Path.EndsWith("\tadd\r") == true) && strLastPart.Contains("."))
                        {
                            fil.Path = fil.Path.Replace("\tadd\r", "");
                            fil.Path = fil.Path.Replace("\tadd", "");
                            fil.docType = DocType.FileAdd;
                        }

                        fil.Path = fil.Path.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fil.Extension = Path.GetExtension(fil.Path);

                        if (fil.Extension.ToLower() == ".js")
                        {
                            fil.Name = Path.GetFileName(fil.Path).Split('.')[0].ToLower();
                            lst.Add(fil);
                            fil.Extension = "js";
                        }
                        else
                        {
                            string sLPart = fil.Path.Split('\\').Last().ToLower();

                            if (sLPart.Contains(".") == true)
                            {

                                //.Last().Split('.')[0] + "." + fil.Path.Split('\\').Last().Split('.')[1];

                                if (sLPart.Contains(".ascx") || sLPart.Contains(".ascx.")) //|| sLPart.Contains(".ascx.designer")                                    
                                {
                                    fil.Extension = "ascx";
                                }

                                if (sLPart.Contains(".aspx") || sLPart.Contains(".aspx."))
                                {
                                    fil.Extension = "aspx";
                                }

                                if (sLPart.Contains(".svc"))
                                {
                                    fil.Extension = "svc";
                                }

                                fil.Name = Path.GetFileName(fil.Path).Split('.')[0].ToLower();

                                if (lst.Exists(s => s.Extension == fil.Extension && s.Name == fil.Name) == false)
                                {
                                    lst.Add(fil);
                                }


                            }


                        }
                        //.aspx.designer.cs, .aspx.cs                        
                    }

                    //if (Directory.Exists(fil.Path) == false && File.Exists(fil.Path) == false)
                    //{
                    //    MessageBox.Show("File does not exits : " + fil.Path);

                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<CFile>();
            }

            return lst;
        }

        private List<CFile> getFilesInBin(string[] precompiledFiles, List<CFile> dllFilesToInclude, out List<string> lstVersion)
        {
            List<CFile> lstFilesInBin = new List<CFile>();
            lstVersion = new List<string>();
            try
            {
                  

                foreach (string line in precompiledFiles)
                {
                    if (File.Exists(line) == true)
                    {
                        string getFileName = Path.GetFileName(line);
                        DateTime lastModified = System.IO.File.GetLastWriteTime(line);
                        bool requiredFile = dllFilesToInclude.Exists(a => getFileName.Contains(a.Name) && getFileName.Contains(a.Extension) && getFileName.Contains(".dll.config") == false );


                        if (((line.Contains(".ascx.") || line.Contains(".aspx.") || line.Contains(".svc."))
                            &&
                            (getFileName.Contains(".dll") || getFileName.Contains(".compiled")))
                            || requiredFile == true)
                        {
                            string strLastPart = line.Split('\\').Last();


                            string fileName = strLastPart.Split('.')[0].Replace("App_Web_", "").ToLower();
                            string fileExtension = strLastPart.Split('.')[1];

                            //App_Web_companytabs.ascx.cdcab7d2.dll
                            //admincontracts.aspx.cdcab7d2.compiled
                            string version = "";

                            if (requiredFile == false)
                            {
                                version = strLastPart.Split('.')[2];
                                if (lstVersion.Contains(version) == false)
                                {
                                    lstVersion.Add(version);
                                }
                            }

                            lstFilesInBin.Add(new CFile
                            {
                                Deploy = false,
                                Name = fileName,
                                Extension = fileExtension,
                                FileNameWithExtension = getFileName,
                                Path = line,
                                Modified = lastModified.ToString("yyyy/MM/dd HH:mm:ss"),
                                docType = DocType.File,
                                version = version
                            });

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lstFilesInBin;

        }

        private List<CFile> getFilesToDeploy(List<CFile> listTFSFileList, List<CFile> dllFilesToInclude,
                                            List<CFile> lstFilesInJSMin, List<CFile> lstFilesInBin)
        {
            List<CFile> lstFilesToDeploy = new List<CFile>();
            try
            {
                

                int dllFilesCount = 0;
                int aspxFilesCount = 0;
                int jsFilesCount = 0;

                dllFilesToInclude.ForEach(line => lstFilesToDeploy.AddRange(lstFilesInBin.Where(x => x.Name == line.Name.ToLower() && x.Extension == line.Extension)));

                dllFilesCount = lstFilesToDeploy.Count();

                listTFSFileList.ForEach(line => lstFilesToDeploy.AddRange(lstFilesInBin.Where(x => x.Name == line.Name && x.Extension == line.Extension).OrderBy(y => y.version)));

                //listTFSFileList.ForEach(line => lstFilesToDeploy.AddRange(lstFilesInBin.Where(x =>
                //{
                //    if (x.Name == line.Name && x.Extension == line.Extension)
                //    {

                //    }
                //}))); 

                listTFSFileList.ForEach(T => lstFilesToDeploy.ForEach(D => {
                    if (T.Name == D.Name && T.Extension == D.Extension)
                    {
                        D.docType = T.docType;
                    }
                }));

                //lstFilesInBin.ForEach(line => lstFilesToDeploy.AddRange(listFiles.Where(x => x.Name == line.Name && x.Extension == line.Extension)));

                aspxFilesCount = Math.Abs(dllFilesCount - lstFilesToDeploy.Count());

                listTFSFileList.ForEach(line => lstFilesToDeploy.AddRange(lstFilesInJSMin.Where(min => min.Name.ToLower() == line.Name.ToLower() && min.Extension.ToLower() == line.Extension.ToLower())));
                jsFilesCount = Math.Abs((dllFilesCount + aspxFilesCount) - lstFilesToDeploy.Count());

                Status("dll Files = (" + dllFilesCount.ToString() + "),  'aspx', 'ascx', 'svc' = (" + aspxFilesCount.ToString() + "),  Js files = (" + jsFilesCount.ToString() + ")");

                if (lstFilesToDeploy.Count == 0)
                {
                    MessageBox.Show("No Files exits.");
                    return lstFilesToDeploy;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return lstFilesToDeploy;
        }

        private List<CFile> getFilesInJSMin(string[] jsMinFiles)
        {
            List<CFile> lstFilesInBin = new List<CFile>();
            try
            {                
                foreach (string line in jsMinFiles)
                {
                    if (File.Exists(line) == true)
                    {

                        string getExtension = Path.GetExtension(line);
                        string getFileNameWithoutExtension = Path.GetFileNameWithoutExtension(line).ToLower(); ;
                        string getFileName = Path.GetFileName(line).ToLower();

                        DateTime lastModified = System.IO.File.GetLastWriteTime(line);
                         
                        if (getExtension == ".js")
                        {
                            lstFilesInBin.Add(new CFile
                            {
                                Deploy = false,
                                Name = getFileNameWithoutExtension,
                                Extension = "js",
                                FileNameWithExtension = getFileName,
                                Path = line,
                                Modified = lastModified.ToString("yyyy/MM/dd HH:mm:ss"),
                                docType = DocType.File
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lstFilesInBin;

        }

        private bool showFilesInGrid(List<CFile> listFiles, List<string> lstVersion)
        {
            try
            {
                lstVersion.ForEach(a => { Status(a); });

                 
                dataGridView1.DataSource = listFiles;

                bool filesWithSameName = false;

                dataGridView1.Columns[0].Width = 35;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 250;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 470;
                dataGridView1.Columns[6].Width = 70;
                

                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }


                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                { 

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "svc")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Beige;
                    }

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "aspx")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Wheat;
                          

                        if (lstVersion.Count > 1)
                         {
                            var fileNum = listFiles.Where(f => f.Name == dataGridView1.Rows[i].Cells[1].Value.ToString() && f.Extension == dataGridView1.Rows[i].Cells[2].Value.ToString()).Count();

                            if (fileNum >= 3)
                            {
                                filesWithSameName = true;
                            }

                            if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[0]) && filesWithSameName == true)
                            {// Ex : Files from mobile folder. Same file different version.
                                dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[0]; //  Color.LightYellow;

                                dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[0]; //  Color.LightYellow;
                            }
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[1]) && filesWithSameName == true)
                            {// Ex : Files from mobile folder. Same file different version.
                                dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[1]; //  Color.LightSalmon;

                                dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[1]; //   Color.LightSalmon;
                            }
                            if (lstVersion.Count >= 3 && dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[2]) && filesWithSameName == true)
                            {// Ex : Files from mobile folder. Same file different version.
                                dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[2]; //  Color.LightCyan;

                                dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                                dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[2]; //  Color.LightCyan;
                            }

                        }

                    }

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "ascx")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Honeydew;
                    }
                     
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "pdb"
                        || dataGridView1.Rows[i].Cells[2].Value.ToString() == "dll")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = cmbLibDll.BackColor;
                    }

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "js")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = btnCopyJS.BackColor;
                    }

                   
                    //if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[0]))
                    //{// Ex : Files from mobile folder. Same file different version.
                    //    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[0]; //  Color.LightYellow;

                    //    dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[0]; //  Color.LightYellow;
                    //}
                    //if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[1]))
                    //{// Ex : Files from mobile folder. Same file different version.
                    //    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[1]; //  Color.LightSalmon;

                    //    dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[1]; //   Color.LightSalmon;
                    //}
                    //if (lstVersion.Count >= 3 && dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(lstVersion[2]) )
                    //{// Ex : Files from mobile folder. Same file different version.
                    //    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[1].Style.BackColor = lstColor[2]; //  Color.LightCyan;

                    //    dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                    //    dataGridView1.Rows[i].Cells[3].Style.BackColor = lstColor[2]; //  Color.LightCyan;
                    //}

                    if (listFiles.Exists(a => a.docType == DocType.FileAdd && a.Name == dataGridView1.Rows[i].Cells[1].Value.ToString() && a.Extension == dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Beige; //  Color.LightCyan;
                    }


                }

                string anyMessage = "";

                if (listFiles.Exists(a => a.docType == DocType.FileAdd))
                {
                    Status("New File Exists");
                    anyMessage = "'New File' Exists (Displayed in RED color)" + Environment.NewLine + Environment.NewLine;
                }

                if (filesWithSameName == true)
                {
                    Status("File with 'same name' Exists");
                    anyMessage = anyMessage + "File with 'Same Name' Exists. Having differnt versions. (Displayed in BLUE color)" + Environment.NewLine;
                }

                if (anyMessage.Length > 0)
                {
                    MessageBox.Show(anyMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        //private void dataGridView1_CellContentClick(object sender,    DataGridViewCellEventArgs e)
        //{
        //    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //}

        //private void dataGridViewSites_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //UpdateDataGridViewSite();
        //}

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = chkALL.Checked;
            }
        }

        private void Deploy_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Program.commandlineParams != null && Program.commandlineParams.Length > 0)
                //{
                //    if (Program.commandlineParams[0] == "")
                //    {
                //        IsDebug = true;
                //    }
                //}

                dataGridView1.DataSource = new List<CFile>();

                DefaultCellStyleBackColor = dataGridView1.DefaultCellStyle.BackColor;

                Status(DateTime.Now.ToString("yyyy_MM_dd_HH_mmss"));

                exePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                appPath = Path.GetFullPath(Path.Combine(exePath, @"..\"));

                appPathCopy = Directory.Exists(appPath + @"Copy\") == true ? appPath + @"Copy\" : appPath;

                string sourcePrecompiledBin = Path.GetFullPath(Path.Combine(exePath, @"..\precompiled\bin"));

                string sourceJS = Path.GetFullPath(Path.Combine(exePath, @"..\js_min"));

                string deployPathBin = appPath + @"Copy\Deploy_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mmss");
                string deployPathJs = appPath + @"Copy\Deploy_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mmss") + "_JS";

                tbSourcePath.Text = sourcePrecompiledBin;
                tbSourcePathJS.Text = sourceJS;

                tbDestinationPath.Text = deployPathBin;

                tbDestinationPathJS.Text = deployPathJs;

                Status("load 2 "  );

                loadDllDropdown(sourcePrecompiledBin);

                //cmbLibDll.SelectedText = sLibDll;
                //cmbWebAppDll.SelectedText = sWebAppDll;

                //if (lstWebAppDll.Count >0  )
                //{
                //    if(lstLibDll.knownWebAPPFileName
                //}
                //MessageBox.Show(appPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Status(ex.Message);
            }
        }

        private void loadDllDropdown(string sourcePrecompiledBin)
        {
            try
            {
                chkIncludeDlls.Checked = false;

                if (Directory.Exists(sourcePrecompiledBin) == false)
                {
                    return;
                }

                //Get WebApp and LibFile Names
                List<string> precompiledFiles = Directory.GetFiles(sourcePrecompiledBin).ToList<string>();

                Status("load 2 (a) " + precompiledFiles.Count());


                List<string> lstWebAppDll = new List<string>();
                List<string> lstLibDll = new List<string>();

                string sLibDll = "";
                string sWebAppDll = "";

                foreach (string line in precompiledFiles)
                {
                    if (Path.GetExtension(line) == ".pdb")
                    {
                        string fName = Path.GetFileNameWithoutExtension(line);

                        Status("load 2 (a) " + fName);

                        lstWebAppDll.Add(fName);

                        if (knownWebAPPFileName.Exists(s => fName.ToLower().Contains(s.ToLower())) == true)
                        {
                            if (fName.ToLower().Contains("lib"))
                            {
                                sLibDll = fName;
                            }
                        }
                    }
                }

                Status("load 2 (B) " + lstWebAppDll.Count());

                foreach (string line in precompiledFiles)
                {
                    if (Path.GetExtension(line) == ".dll" && lstWebAppDll.Contains(Path.GetFileNameWithoutExtension(line)))
                    {
                        string fName = Path.GetFileNameWithoutExtension(line);
                        lstLibDll.Add(fName);

                        if (knownWebAPPFileName.Exists(s => fName.ToLower().Contains(s.ToLower())) == true)
                        {
                            sWebAppDll = fName;
                        }
                    }
                }

                Status("load 2 (C) " + lstLibDll.Count());

                Status("load 3 ");

                if (lstLibDll.Count() > 0)
                {
                    chkIncludeDlls.Checked = true;
                }

                var dlllist = lstLibDll.Select(a => new ComboboxItem { Text = a, Value = a }).ToList<ComboboxItem>();

                var webApplist = lstWebAppDll.Select(a => new ComboboxItem { Text = a, Value = a }).ToList<ComboboxItem>();


                Status("load 4 ");

                cmbLibDll.DataSource = dlllist;
                cmbWebAppDll.DataSource = webApplist;

                Status("load 5 ");

                cmbLibDll.SelectedItem = dlllist.Where(a => a.Text == sLibDll).FirstOrDefault();
                cmbWebAppDll.SelectedItem = webApplist.Where(a => a.Text == sWebAppDll).FirstOrDefault();

                Status("load 6 ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Status(ex.Message); 
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {

                double count = 0;
                progressBar1.Value = 0;
                bool anyChecked = false;

                //if (Directory.Exists(tbDestinationPath.Text) == false)
                //{
                //    MessageBox.Show("Destination directory not found.", "Directory missing");
                //    tbDestinationPath.Focus();
                //    return;
                //}                            

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "js")
                        {
                            continue;
                        }
                            anyChecked = true;
                    }
                }

                if (anyChecked == false)
                {
                    MessageBox.Show("No 'dll' or 'aspx' or 'ascx' or 'svc' files selcted to copy", "No files selected");
                    return;
                }

                var listPair = new List<KeyVal<string, int>>() { };

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells["Deploy"].Value == true)
                    {
                        if (dataGridView1.Rows[i].Cells["Extension"].Value.ToString() == "aspx" ||
                            dataGridView1.Rows[i].Cells["Extension"].Value.ToString() == "ascx")
                        {
                            string currentFileName = dataGridView1.Rows[i].Cells["Name"].Value.ToString() + ".";
                            currentFileName = currentFileName + dataGridView1.Rows[i].Cells["Extension"].Value.ToString() +".";
                            currentFileName = currentFileName + dataGridView1.Rows[i].Cells["version"].Value.ToString();
                             
                            if (listPair.Exists(x => x.Key == currentFileName))
                            {
                                var kvp = listPair.First(x => x.Key == currentFileName); 
                                if (kvp.Key == currentFileName)
                                {
                                    listPair.Find(x => x.Key == currentFileName).Val = 2;
                                }                               
                            }
                            else
                            {
                                listPair.Add(new KeyVal<string, int>(currentFileName, 1));
                            }

                        } 
                    }
                }
                                 
                string filePairs  = string.Join(Environment.NewLine, listPair.Where(p => p.Val == 1)
                                 .Select(p => p.Key));

                if (filePairs.Length > 0)
                {
                    MessageBox.Show("Select the Pair file also..." + Environment.NewLine + Environment.NewLine + filePairs);
                    return;
                }

                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        if (Directory.Exists(tbDestinationPath.Text) == false)
                        {
                            Directory.CreateDirectory(tbDestinationPath.Text);
                        }

                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "js")
                        {
                            continue;
                        }

                        string currentFile = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        string currentFileName = dataGridView1.Rows[i].Cells[3].Value.ToString();

                        File.Copy(currentFile, tbDestinationPath.Text + @"\" + currentFileName, true);
                        count = count + 1.0;
                        Status("to : " + tbDestinationPath.Text + @"\" + currentFileName);
                        Status("from : " + currentFile);

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;

                        dataGridView1.FirstDisplayedScrollingRowIndex = i;

                        progressBar1.Value = (int)(100.0 * (count / dataGridView1.RowCount));
                        Application.DoEvents();
                        Thread.Sleep(10);

                        btnOpenDllPath.Visible = true;
                    }
                }

                progressBar1.Value = 100;
                MessageBox.Show("Copied " + count.ToString() + " files successfully..", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyJS_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                double count = 0;
                bool anyChecked = false;

                //if (Directory.Exists(tbDestinationPathJS.Text) == false)
                //{
                //    MessageBox.Show("Destination JS directory not found.", "Directory missing");
                //    tbDestinationPathJS.Focus();
                //    return;
                //}


                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "js")
                        {
                            anyChecked = true;
                        } 
                    }
                }

                if (anyChecked == false)
                {
                    MessageBox.Show("No 'js' files selcted to copy");
                    return;
                }


                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].Value == true)
                    {
                        if (Directory.Exists(tbDestinationPathJS.Text) == false)
                        {
                            Directory.CreateDirectory(tbDestinationPathJS.Text);
                        }

                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "js")
                        {
                            continue;
                        }

                        string currentFile = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        string currentFileName = dataGridView1.Rows[i].Cells[3].Value.ToString();

                        File.Copy(currentFile, tbDestinationPathJS.Text + @"\" + currentFileName, true);

                        Status("to : " + tbDestinationPath.Text + @"\" + currentFileName);
                        Status("from : " + currentFile);

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;

                        Application.DoEvents();
                        count = count + 1.0;
                        progressBar1.Value = (int)(100.0 * (count / dataGridView1.RowCount));
                        Thread.Sleep(10);

                        btnOpenJsPath.Visible = true;
                    }
                }

                progressBar1.Value = 100;
                MessageBox.Show("Copied " + count.ToString() + " files successfully..", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddTestFileList_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deploy));
            tbFilesList.Text = txtExampleHidden.Text; //resources.GetString("tbFilesList.Text");
            
        }

        private void btnDestinatonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = (Directory.Exists(tbDestinationPath.Text) == false ? appPathCopy : tbDestinationPath.Text);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tbDestinationPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDestinatonSelectJS_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = (Directory.Exists(tbDestinationPathJS.Text) == false ? appPathCopy : tbDestinationPathJS.Text);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tbDestinationPathJS.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Status(string status)
        {
            //textBoxStatus.Text = textBoxStatus.Text + Environment.NewLine + functionName + " :" + status;
            textBoxStatus.Text = "--> " + status + Environment.NewLine + textBoxStatus.Text;

            textBoxStatus.SelectionStart = textBoxStatus.Text.Length - 1;// add some logic if length is 0
            textBoxStatus.SelectionLength = 0;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            textBoxStatus.Text = "";
        }

        private void btnOpenDllPath_Click(object sender, EventArgs e)
        {
            if (Directory.Exists( tbDestinationPath.Text))
            {
                Process.Start("explorer.exe", tbDestinationPath.Text);
            }
        }

        private void btnOpenJsPath_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbDestinationPathJS.Text))
            {
                Process.Start("explorer.exe", tbDestinationPathJS.Text);
            }
        }

        private void btnLoadDropdowns_Click(object sender, EventArgs e)
        {
            loadDllDropdown(tbSourcePath.Text);
        } 

        private void btnPaste_Click(object sender, EventArgs e)
        {
            tbFilesList.Text = Clipboard.GetText();

        }

      
    }
}
