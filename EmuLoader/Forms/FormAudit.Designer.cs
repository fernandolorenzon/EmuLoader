namespace EmuLoader.Forms
{
    partial class FormAudit
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
            this.buttonCleanIncorrectRomPlatform = new System.Windows.Forms.Button();
            this.labelEmulatorFilter = new System.Windows.Forms.Label();
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.buttonUpdateNameFromDBName = new System.Windows.Forms.Button();
            this.buttonUpdateAllRomsNames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCleanIncorrectRomPlatform
            // 
            this.buttonCleanIncorrectRomPlatform.Location = new System.Drawing.Point(12, 74);
            this.buttonCleanIncorrectRomPlatform.Name = "buttonCleanIncorrectRomPlatform";
            this.buttonCleanIncorrectRomPlatform.Size = new System.Drawing.Size(127, 80);
            this.buttonCleanIncorrectRomPlatform.TabIndex = 0;
            this.buttonCleanIncorrectRomPlatform.Text = "Clean Rom Data WIth Incorrect Platform";
            this.buttonCleanIncorrectRomPlatform.UseVisualStyleBackColor = true;
            this.buttonCleanIncorrectRomPlatform.Click += new System.EventHandler(this.buttonCleanIncorrectRomPlatform_Click);
            // 
            // labelEmulatorFilter
            // 
            this.labelEmulatorFilter.AutoSize = true;
            this.labelEmulatorFilter.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmulatorFilter.Location = new System.Drawing.Point(10, 14);
            this.labelEmulatorFilter.Name = "labelEmulatorFilter";
            this.labelEmulatorFilter.Size = new System.Drawing.Size(55, 14);
            this.labelEmulatorFilter.TabIndex = 8;
            this.labelEmulatorFilter.Text = "Platform";
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(12, 30);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(153, 20);
            this.comboBoxPlatform.TabIndex = 7;
            // 
            // buttonUpdateNameFromDBName
            // 
            this.buttonUpdateNameFromDBName.Location = new System.Drawing.Point(13, 246);
            this.buttonUpdateNameFromDBName.Name = "buttonUpdateNameFromDBName";
            this.buttonUpdateNameFromDBName.Size = new System.Drawing.Size(127, 80);
            this.buttonUpdateNameFromDBName.TabIndex = 39;
            this.buttonUpdateNameFromDBName.Text = " Update All Rom Names From DBName";
            this.buttonUpdateNameFromDBName.UseVisualStyleBackColor = true;
            this.buttonUpdateNameFromDBName.Click += new System.EventHandler(this.buttonUpdateNameFromDBName_Click);
            // 
            // buttonUpdateAllRomsNames
            // 
            this.buttonUpdateAllRomsNames.Location = new System.Drawing.Point(12, 160);
            this.buttonUpdateAllRomsNames.Name = "buttonUpdateAllRomsNames";
            this.buttonUpdateAllRomsNames.Size = new System.Drawing.Size(127, 80);
            this.buttonUpdateAllRomsNames.TabIndex = 38;
            this.buttonUpdateAllRomsNames.Text = "Update All Roms MAME Names ";
            this.buttonUpdateAllRomsNames.UseVisualStyleBackColor = true;
            this.buttonUpdateAllRomsNames.Click += new System.EventHandler(this.buttonUpdateAllRomsNames_Click);
            // 
            // FormAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdateNameFromDBName);
            this.Controls.Add(this.buttonUpdateAllRomsNames);
            this.Controls.Add(this.labelEmulatorFilter);
            this.Controls.Add(this.comboBoxPlatform);
            this.Controls.Add(this.buttonCleanIncorrectRomPlatform);
            this.Name = "FormAudit";
            this.Text = "Audit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCleanIncorrectRomPlatform;
        private System.Windows.Forms.Label labelEmulatorFilter;
        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.Button buttonUpdateNameFromDBName;
        private System.Windows.Forms.Button buttonUpdateAllRomsNames;
    }
}