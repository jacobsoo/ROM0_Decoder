namespace Decompress
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblRomFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.grpDecoded = new System.Windows.Forms.GroupBox();
            this.dataBox = new System.Windows.Forms.RichTextBox();
            this.grpDecoded.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRomFile
            // 
            this.lblRomFile.AutoSize = true;
            this.lblRomFile.Location = new System.Drawing.Point(13, 13);
            this.lblRomFile.Name = "lblRomFile";
            this.lblRomFile.Size = new System.Drawing.Size(54, 13);
            this.lblRomFile.TabIndex = 0;
            this.lblRomFile.Text = "ROM-File:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(73, 10);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(272, 20);
            this.txtFile.TabIndex = 1;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(351, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // grpDecoded
            // 
            this.grpDecoded.Controls.Add(this.dataBox);
            this.grpDecoded.Location = new System.Drawing.Point(16, 47);
            this.grpDecoded.Name = "grpDecoded";
            this.grpDecoded.Size = new System.Drawing.Size(410, 249);
            this.grpDecoded.TabIndex = 3;
            this.grpDecoded.TabStop = false;
            this.grpDecoded.Text = "Decoded Data";
            // 
            // dataBox
            // 
            this.dataBox.Location = new System.Drawing.Point(7, 20);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(397, 223);
            this.dataBox.TabIndex = 0;
            this.dataBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 308);
            this.Controls.Add(this.grpDecoded);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblRomFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TP-LINK ROM Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpDecoded.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRomFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox grpDecoded;
        private System.Windows.Forms.RichTextBox dataBox;
    }
}

