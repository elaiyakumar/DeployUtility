namespace DeployUtility
{
    partial class Form1
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
            this.btnCopyDirectory = new System.Windows.Forms.Button();
            this.btnCopyFiles = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxDest = new System.Windows.Forms.TextBox();
            this.btnGenerateAP = new System.Windows.Forms.Button();
            this.textBoxOutPut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCopyDirectory
            // 
            this.btnCopyDirectory.Location = new System.Drawing.Point(139, 68);
            this.btnCopyDirectory.Name = "btnCopyDirectory";
            this.btnCopyDirectory.Size = new System.Drawing.Size(122, 45);
            this.btnCopyDirectory.TabIndex = 0;
            this.btnCopyDirectory.Text = "Copy Directory";
            this.btnCopyDirectory.UseVisualStyleBackColor = true;
            this.btnCopyDirectory.Click += new System.EventHandler(this.btnCopyDirectory_Click);
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Location = new System.Drawing.Point(31, 68);
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.Size = new System.Drawing.Size(75, 45);
            this.btnCopyFiles.TabIndex = 0;
            this.btnCopyFiles.Text = "Copy Files";
            this.btnCopyFiles.UseVisualStyleBackColor = true;
            this.btnCopyFiles.Click += new System.EventHandler(this.btnCopyFile_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(31, 22);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(277, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "C:\\Users\\Kumar\\Desktop\\Trial100\\Test";
            // 
            // textBoxDest
            // 
            this.textBoxDest.Location = new System.Drawing.Point(364, 22);
            this.textBoxDest.Name = "textBoxDest";
            this.textBoxDest.Size = new System.Drawing.Size(277, 20);
            this.textBoxDest.TabIndex = 1;
            this.textBoxDest.Text = "C:\\Users\\Kumar\\Desktop\\Trial100\\Target";
            // 
            // btnGenerateAP
            // 
            this.btnGenerateAP.Location = new System.Drawing.Point(206, 234);
            this.btnGenerateAP.Name = "btnGenerateAP";
            this.btnGenerateAP.Size = new System.Drawing.Size(122, 45);
            this.btnGenerateAP.TabIndex = 0;
            this.btnGenerateAP.Text = "Generate AP";
            this.btnGenerateAP.UseVisualStyleBackColor = true;
            this.btnGenerateAP.Click += new System.EventHandler(this.btnGenerateAP_Click);
            // 
            // textBoxOutPut
            // 
            this.textBoxOutPut.Location = new System.Drawing.Point(206, 329);
            this.textBoxOutPut.Multiline = true;
            this.textBoxOutPut.Name = "textBoxOutPut";
            this.textBoxOutPut.Size = new System.Drawing.Size(277, 78);
            this.textBoxOutPut.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutPut);
            this.Controls.Add(this.textBoxDest);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.btnCopyFiles);
            this.Controls.Add(this.btnGenerateAP);
            this.Controls.Add(this.btnCopyDirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopyDirectory;
        private System.Windows.Forms.Button btnCopyFiles;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxDest;
        private System.Windows.Forms.Button btnGenerateAP;
        private System.Windows.Forms.TextBox textBoxOutPut;
        private System.Windows.Forms.Label label1;
    }
}

