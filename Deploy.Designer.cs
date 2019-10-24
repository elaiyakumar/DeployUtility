namespace DeployUtility
{
    partial class Deploy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deploy));
            this.btnSourceSelect = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbSourcePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSourcePathJS = new System.Windows.Forms.TextBox();
            this.btnSourceSelectJS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilesList = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddTestFileList = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPaste = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkALL = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDestinationPathJS = new System.Windows.Forms.TextBox();
            this.btnDestinatonSelectJS = new System.Windows.Forms.Button();
            this.tbDestinationPath = new System.Windows.Forms.TextBox();
            this.btnDestinatonSelect = new System.Windows.Forms.Button();
            this.btnCopyJS = new System.Windows.Forms.Button();
            this.chkIncludeDlls = new System.Windows.Forms.CheckBox();
            this.cmbWebAppDll = new System.Windows.Forms.ComboBox();
            this.cmbLibDll = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExampleHidden = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnOpenDllPath = new System.Windows.Forms.Button();
            this.btnOpenJsPath = new System.Windows.Forms.Button();
            this.btnLoadDropdowns = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceSelect
            // 
            this.btnSourceSelect.Location = new System.Drawing.Point(869, 11);
            this.btnSourceSelect.Name = "btnSourceSelect";
            this.btnSourceSelect.Size = new System.Drawing.Size(33, 22);
            this.btnSourceSelect.TabIndex = 2;
            this.btnSourceSelect.Text = "..";
            this.btnSourceSelect.UseVisualStyleBackColor = true;
            this.btnSourceSelect.Click += new System.EventHandler(this.btnSourceSelect_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 275);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1053, 249);
            this.dataGridView1.TabIndex = 3;
            // 
            // tbSourcePath
            // 
            this.tbSourcePath.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbSourcePath.Location = new System.Drawing.Point(69, 12);
            this.tbSourcePath.Name = "tbSourcePath";
            this.tbSourcePath.Size = new System.Drawing.Size(794, 21);
            this.tbSourcePath.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbSourcePathJS);
            this.groupBox1.Controls.Add(this.btnSourceSelectJS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSourcePath);
            this.groupBox1.Controls.Add(this.btnSourceSelect);
            this.groupBox1.Location = new System.Drawing.Point(1, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(10, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Source JS";
            // 
            // tbSourcePathJS
            // 
            this.tbSourcePathJS.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbSourcePathJS.Location = new System.Drawing.Point(69, 37);
            this.tbSourcePathJS.Name = "tbSourcePathJS";
            this.tbSourcePathJS.Size = new System.Drawing.Size(794, 21);
            this.tbSourcePathJS.TabIndex = 7;
            // 
            // btnSourceSelectJS
            // 
            this.btnSourceSelectJS.Location = new System.Drawing.Point(869, 36);
            this.btnSourceSelectJS.Name = "btnSourceSelectJS";
            this.btnSourceSelectJS.Size = new System.Drawing.Size(33, 22);
            this.btnSourceSelectJS.TabIndex = 6;
            this.btnSourceSelectJS.Text = "..";
            this.btnSourceSelectJS.UseVisualStyleBackColor = true;
            this.btnSourceSelectJS.Click += new System.EventHandler(this.btnSourceSelectJS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source";
            // 
            // tbFilesList
            // 
            this.tbFilesList.BackColor = System.Drawing.Color.LightYellow;
            this.tbFilesList.Location = new System.Drawing.Point(5, 29);
            this.tbFilesList.Multiline = true;
            this.tbFilesList.Name = "tbFilesList";
            this.tbFilesList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFilesList.Size = new System.Drawing.Size(893, 176);
            this.tbFilesList.TabIndex = 4;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.GreenYellow;
            this.btnCopy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(887, 541);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(143, 26);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Deploy Dlls";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.BackColor = System.Drawing.Color.Orange;
            this.btnGetFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFiles.Location = new System.Drawing.Point(910, 234);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(146, 30);
            this.btnGetFiles.TabIndex = 2;
            this.btnGetFiles.Text = "Get Files";
            this.btnGetFiles.UseVisualStyleBackColor = false;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddTestFileList);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnPaste);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbFilesList);
            this.groupBox2.Location = new System.Drawing.Point(1, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 213);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnAddTestFileList
            // 
            this.btnAddTestFileList.BackColor = System.Drawing.Color.Yellow;
            this.btnAddTestFileList.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTestFileList.Location = new System.Drawing.Point(532, 12);
            this.btnAddTestFileList.Name = "btnAddTestFileList";
            this.btnAddTestFileList.Size = new System.Drawing.Size(22, 17);
            this.btnAddTestFileList.TabIndex = 7;
            this.btnAddTestFileList.Text = "Ex";
            this.btnAddTestFileList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTestFileList.UseVisualStyleBackColor = false;
            this.btnAddTestFileList.Click += new System.EventHandler(this.btnAddTestFileList_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(533, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ex: Copy Check-In files list from TFS and paste to below box";
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaste.Location = new System.Drawing.Point(833, 7);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(66, 22);
            this.btnPaste.TabIndex = 6;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Files to Deploy";
            // 
            // chkALL
            // 
            this.chkALL.AutoSize = true;
            this.chkALL.BackColor = System.Drawing.Color.GreenYellow;
            this.chkALL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkALL.ForeColor = System.Drawing.Color.IndianRed;
            this.chkALL.Location = new System.Drawing.Point(9, 276);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(40, 17);
            this.chkALL.TabIndex = 7;
            this.chkALL.Text = "All";
            this.chkALL.UseVisualStyleBackColor = false;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbDestinationPathJS);
            this.groupBox3.Controls.Add(this.btnDestinatonSelectJS);
            this.groupBox3.Controls.Add(this.tbDestinationPath);
            this.groupBox3.Controls.Add(this.btnDestinatonSelect);
            this.groupBox3.Location = new System.Drawing.Point(5, 533);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(882, 60);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(0, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "DestinationJS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Destination";
            // 
            // tbDestinationPathJS
            // 
            this.tbDestinationPathJS.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbDestinationPathJS.Location = new System.Drawing.Point(75, 35);
            this.tbDestinationPathJS.Name = "tbDestinationPathJS";
            this.tbDestinationPathJS.Size = new System.Drawing.Size(771, 21);
            this.tbDestinationPathJS.TabIndex = 13;
            // 
            // btnDestinatonSelectJS
            // 
            this.btnDestinatonSelectJS.Location = new System.Drawing.Point(848, 34);
            this.btnDestinatonSelectJS.Name = "btnDestinatonSelectJS";
            this.btnDestinatonSelectJS.Size = new System.Drawing.Size(33, 22);
            this.btnDestinatonSelectJS.TabIndex = 12;
            this.btnDestinatonSelectJS.Text = "..";
            this.btnDestinatonSelectJS.UseVisualStyleBackColor = true;
            this.btnDestinatonSelectJS.Click += new System.EventHandler(this.btnDestinatonSelectJS_Click);
            // 
            // tbDestinationPath
            // 
            this.tbDestinationPath.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tbDestinationPath.Location = new System.Drawing.Point(75, 12);
            this.tbDestinationPath.Name = "tbDestinationPath";
            this.tbDestinationPath.Size = new System.Drawing.Size(771, 21);
            this.tbDestinationPath.TabIndex = 13;
            // 
            // btnDestinatonSelect
            // 
            this.btnDestinatonSelect.Location = new System.Drawing.Point(848, 11);
            this.btnDestinatonSelect.Name = "btnDestinatonSelect";
            this.btnDestinatonSelect.Size = new System.Drawing.Size(33, 22);
            this.btnDestinatonSelect.TabIndex = 12;
            this.btnDestinatonSelect.Text = "..";
            this.btnDestinatonSelect.UseVisualStyleBackColor = true;
            this.btnDestinatonSelect.Click += new System.EventHandler(this.btnDestinatonSelect_Click);
            // 
            // btnCopyJS
            // 
            this.btnCopyJS.BackColor = System.Drawing.Color.LightGreen;
            this.btnCopyJS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyJS.Location = new System.Drawing.Point(887, 567);
            this.btnCopyJS.Name = "btnCopyJS";
            this.btnCopyJS.Size = new System.Drawing.Size(143, 26);
            this.btnCopyJS.TabIndex = 13;
            this.btnCopyJS.Text = "Deploy JS";
            this.btnCopyJS.UseVisualStyleBackColor = false;
            this.btnCopyJS.Click += new System.EventHandler(this.btnCopyJS_Click);
            // 
            // chkIncludeDlls
            // 
            this.chkIncludeDlls.AutoSize = true;
            this.chkIncludeDlls.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkIncludeDlls.Checked = true;
            this.chkIncludeDlls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeDlls.Location = new System.Drawing.Point(3, 133);
            this.chkIncludeDlls.Name = "chkIncludeDlls";
            this.chkIncludeDlls.Size = new System.Drawing.Size(146, 31);
            this.chkIncludeDlls.TabIndex = 15;
            this.chkIncludeDlls.Text = "Include Lib and WebApp Dlls";
            this.chkIncludeDlls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIncludeDlls.UseVisualStyleBackColor = true;
            // 
            // cmbWebAppDll
            // 
            this.cmbWebAppDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbWebAppDll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebAppDll.FormattingEnabled = true;
            this.cmbWebAppDll.Location = new System.Drawing.Point(3, 66);
            this.cmbWebAppDll.Name = "cmbWebAppDll";
            this.cmbWebAppDll.Size = new System.Drawing.Size(143, 21);
            this.cmbWebAppDll.TabIndex = 16;
            // 
            // cmbLibDll
            // 
            this.cmbLibDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbLibDll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibDll.FormattingEnabled = true;
            this.cmbLibDll.Location = new System.Drawing.Point(3, 106);
            this.cmbLibDll.Name = "cmbLibDll";
            this.cmbLibDll.Size = new System.Drawing.Size(143, 21);
            this.cmbLibDll.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(3, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Lib DLL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(3, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "WebAPP DLL";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 526);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1053, 12);
            this.progressBar1.TabIndex = 17;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.LightGray;
            this.textBoxStatus.Location = new System.Drawing.Point(79, 596);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStatus.Size = new System.Drawing.Size(979, 46);
            this.textBoxStatus.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(51, 599);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Log";
            // 
            // txtExampleHidden
            // 
            this.txtExampleHidden.Location = new System.Drawing.Point(4, 3);
            this.txtExampleHidden.Multiline = true;
            this.txtExampleHidden.Name = "txtExampleHidden";
            this.txtExampleHidden.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExampleHidden.Size = new System.Drawing.Size(28, 18);
            this.txtExampleHidden.TabIndex = 20;
            this.txtExampleHidden.Text = resources.GetString("txtExampleHidden.Text");
            this.txtExampleHidden.Visible = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Location = new System.Drawing.Point(58, 625);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(21, 17);
            this.btnClearLog.TabIndex = 8;
            this.btnClearLog.Text = "x";
            this.btnClearLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnOpenDllPath
            // 
            this.btnOpenDllPath.Image = global::DeployUtility.Properties.Resources.Ico_Open;
            this.btnOpenDllPath.Location = new System.Drawing.Point(1031, 541);
            this.btnOpenDllPath.Name = "btnOpenDllPath";
            this.btnOpenDllPath.Size = new System.Drawing.Size(32, 26);
            this.btnOpenDllPath.TabIndex = 17;
            this.btnOpenDllPath.UseVisualStyleBackColor = true;
            this.btnOpenDllPath.Visible = false;
            this.btnOpenDllPath.Click += new System.EventHandler(this.btnOpenDllPath_Click);
            // 
            // btnOpenJsPath
            // 
            this.btnOpenJsPath.Image = global::DeployUtility.Properties.Resources.Ico_Open;
            this.btnOpenJsPath.Location = new System.Drawing.Point(1031, 567);
            this.btnOpenJsPath.Name = "btnOpenJsPath";
            this.btnOpenJsPath.Size = new System.Drawing.Size(32, 26);
            this.btnOpenJsPath.TabIndex = 21;
            this.btnOpenJsPath.UseVisualStyleBackColor = true;
            this.btnOpenJsPath.Visible = false;
            this.btnOpenJsPath.Click += new System.EventHandler(this.btnOpenJsPath_Click);
            // 
            // btnLoadDropdowns
            // 
            this.btnLoadDropdowns.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLoadDropdowns.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDropdowns.Location = new System.Drawing.Point(3, 12);
            this.btnLoadDropdowns.Name = "btnLoadDropdowns";
            this.btnLoadDropdowns.Size = new System.Drawing.Size(143, 25);
            this.btnLoadDropdowns.TabIndex = 22;
            this.btnLoadDropdowns.Text = "Load Dropdowns";
            this.btnLoadDropdowns.UseVisualStyleBackColor = false;
            this.btnLoadDropdowns.Click += new System.EventHandler(this.btnLoadDropdowns_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadDropdowns);
            this.groupBox4.Controls.Add(this.cmbWebAppDll);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.chkIncludeDlls);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cmbLibDll);
            this.groupBox4.Location = new System.Drawing.Point(909, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 171);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // Deploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 646);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOpenJsPath);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnOpenDllPath);
            this.Controls.Add(this.txtExampleHidden);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCopyJS);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chkALL);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Deploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deploy Utility 1.0";
            this.Load += new System.EventHandler(this.Deploy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSourceSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbSourcePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilesList;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkALL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDestinationPath;
        private System.Windows.Forms.Button btnDestinatonSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSourcePathJS;
        private System.Windows.Forms.Button btnSourceSelectJS;
        private System.Windows.Forms.TextBox tbDestinationPathJS;
        private System.Windows.Forms.Button btnDestinatonSelectJS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddTestFileList;
        private System.Windows.Forms.Button btnCopyJS;
        private System.Windows.Forms.CheckBox chkIncludeDlls;
        private System.Windows.Forms.ComboBox cmbWebAppDll;
        private System.Windows.Forms.ComboBox cmbLibDll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExampleHidden;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOpenDllPath;
        private System.Windows.Forms.Button btnOpenJsPath;
        private System.Windows.Forms.Button btnLoadDropdowns;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPaste;
    }
}