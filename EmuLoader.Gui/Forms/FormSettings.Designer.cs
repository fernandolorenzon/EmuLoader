namespace EmuLoader.Gui.Forms
{
    partial class FormSettings
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
            this.labelMameFolder = new System.Windows.Forms.Label();
            this.textBoxMameFolder = new System.Windows.Forms.TextBox();
            this.buttonMameFolder = new System.Windows.Forms.Button();
            this.buttonRetroarchFolder = new System.Windows.Forms.Button();
            this.textBoxRetroarchFolder = new System.Windows.Forms.TextBox();
            this.labelRetroarchFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMameFolder
            // 
            this.labelMameFolder.AutoSize = true;
            this.labelMameFolder.Location = new System.Drawing.Point(12, 31);
            this.labelMameFolder.Name = "labelMameFolder";
            this.labelMameFolder.Size = new System.Drawing.Size(68, 13);
            this.labelMameFolder.TabIndex = 0;
            this.labelMameFolder.Text = "Mame Folder";
            // 
            // textBoxMameFolder
            // 
            this.textBoxMameFolder.Location = new System.Drawing.Point(15, 47);
            this.textBoxMameFolder.Name = "textBoxMameFolder";
            this.textBoxMameFolder.Size = new System.Drawing.Size(268, 20);
            this.textBoxMameFolder.TabIndex = 50;
            // 
            // buttonMameFolder
            // 
            this.buttonMameFolder.Location = new System.Drawing.Point(290, 47);
            this.buttonMameFolder.Name = "buttonMameFolder";
            this.buttonMameFolder.Size = new System.Drawing.Size(42, 20);
            this.buttonMameFolder.TabIndex = 51;
            this.buttonMameFolder.Text = "...";
            this.buttonMameFolder.UseVisualStyleBackColor = true;
            this.buttonMameFolder.Click += new System.EventHandler(this.buttonMameFolder_Click);
            // 
            // buttonRetroarchFolder
            // 
            this.buttonRetroarchFolder.Location = new System.Drawing.Point(290, 114);
            this.buttonRetroarchFolder.Name = "buttonRetroarchFolder";
            this.buttonRetroarchFolder.Size = new System.Drawing.Size(42, 20);
            this.buttonRetroarchFolder.TabIndex = 54;
            this.buttonRetroarchFolder.Text = "...";
            this.buttonRetroarchFolder.UseVisualStyleBackColor = true;
            this.buttonRetroarchFolder.Click += new System.EventHandler(this.buttonRetroarchFolder_Click);
            // 
            // textBoxRetroarchFolder
            // 
            this.textBoxRetroarchFolder.Location = new System.Drawing.Point(15, 114);
            this.textBoxRetroarchFolder.Name = "textBoxRetroarchFolder";
            this.textBoxRetroarchFolder.Size = new System.Drawing.Size(268, 20);
            this.textBoxRetroarchFolder.TabIndex = 53;
            // 
            // labelRetroarchFolder
            // 
            this.labelRetroarchFolder.AutoSize = true;
            this.labelRetroarchFolder.Location = new System.Drawing.Point(12, 98);
            this.labelRetroarchFolder.Name = "labelRetroarchFolder";
            this.labelRetroarchFolder.Size = new System.Drawing.Size(86, 13);
            this.labelRetroarchFolder.TabIndex = 52;
            this.labelRetroarchFolder.Text = "Retroarch Folder";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 484);
            this.Controls.Add(this.buttonRetroarchFolder);
            this.Controls.Add(this.textBoxRetroarchFolder);
            this.Controls.Add(this.labelRetroarchFolder);
            this.Controls.Add(this.buttonMameFolder);
            this.Controls.Add(this.textBoxMameFolder);
            this.Controls.Add(this.labelMameFolder);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.Controls.SetChildIndex(this.labelMameFolder, 0);
            this.Controls.SetChildIndex(this.textBoxMameFolder, 0);
            this.Controls.SetChildIndex(this.buttonMameFolder, 0);
            this.Controls.SetChildIndex(this.labelRetroarchFolder, 0);
            this.Controls.SetChildIndex(this.textBoxRetroarchFolder, 0);
            this.Controls.SetChildIndex(this.buttonRetroarchFolder, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMameFolder;
        private System.Windows.Forms.TextBox textBoxMameFolder;
        private System.Windows.Forms.Button buttonMameFolder;
        private System.Windows.Forms.Button buttonRetroarchFolder;
        private System.Windows.Forms.TextBox textBoxRetroarchFolder;
        private System.Windows.Forms.Label labelRetroarchFolder;
    }
}