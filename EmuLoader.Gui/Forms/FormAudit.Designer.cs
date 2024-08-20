namespace EmuLoader.Gui.Forms
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
            this.buttonShowMissingRoms = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonConvertRomsXML = new System.Windows.Forms.Button();
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.buttonChangeISOtoCHD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCleanIncorrectRomPlatform
            // 
            this.buttonCleanIncorrectRomPlatform.Location = new System.Drawing.Point(12, 74);
            this.buttonCleanIncorrectRomPlatform.Name = "buttonCleanIncorrectRomPlatform";
            this.buttonCleanIncorrectRomPlatform.Size = new System.Drawing.Size(128, 80);
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
            this.buttonUpdateAllRomsNames.Size = new System.Drawing.Size(128, 80);
            this.buttonUpdateAllRomsNames.TabIndex = 38;
            this.buttonUpdateAllRomsNames.Text = "Update All Roms MAME Names ";
            this.buttonUpdateAllRomsNames.UseVisualStyleBackColor = true;
            this.buttonUpdateAllRomsNames.Click += new System.EventHandler(this.buttonUpdateAllRomsNames_Click);
            // 
            // buttonShowMissingRoms
            // 
            this.buttonShowMissingRoms.Location = new System.Drawing.Point(13, 332);
            this.buttonShowMissingRoms.Name = "buttonShowMissingRoms";
            this.buttonShowMissingRoms.Size = new System.Drawing.Size(127, 80);
            this.buttonShowMissingRoms.TabIndex = 40;
            this.buttonShowMissingRoms.Text = "Show Missing Roms";
            this.buttonShowMissingRoms.UseVisualStyleBackColor = true;
            this.buttonShowMissingRoms.Click += new System.EventHandler(this.buttonShowMissingRoms_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 80);
            this.button1.TabIndex = 41;
            this.button1.Text = "Convert Platform XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonConvertPlatformsXML_Click);
            // 
            // buttonConvertRomsXML
            // 
            this.buttonConvertRomsXML.Location = new System.Drawing.Point(285, 160);
            this.buttonConvertRomsXML.Name = "buttonConvertRomsXML";
            this.buttonConvertRomsXML.Size = new System.Drawing.Size(131, 80);
            this.buttonConvertRomsXML.TabIndex = 42;
            this.buttonConvertRomsXML.Text = "Convert Roms XML";
            this.buttonConvertRomsXML.UseVisualStyleBackColor = true;
            this.buttonConvertRomsXML.Click += new System.EventHandler(this.buttonConvertRomsXML_Click);
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Location = new System.Drawing.Point(285, 246);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(131, 80);
            this.buttonChangePath.TabIndex = 43;
            this.buttonChangePath.Text = "Convert Roms XML Path";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.buttonChangePath_Click);
            // 
            // buttonChangeISOtoCHD
            // 
            this.buttonChangeISOtoCHD.Location = new System.Drawing.Point(513, 74);
            this.buttonChangeISOtoCHD.Name = "buttonChangeISOtoCHD";
            this.buttonChangeISOtoCHD.Size = new System.Drawing.Size(131, 80);
            this.buttonChangeISOtoCHD.TabIndex = 44;
            this.buttonChangeISOtoCHD.Text = "Change ISO to CHD";
            this.buttonChangeISOtoCHD.UseVisualStyleBackColor = true;
            this.buttonChangeISOtoCHD.Click += new System.EventHandler(this.buttonChangeISOtoCHD_Click);
            // 
            // FormAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChangeISOtoCHD);
            this.Controls.Add(this.buttonChangePath);
            this.Controls.Add(this.buttonConvertRomsXML);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonShowMissingRoms);
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
        private System.Windows.Forms.Button buttonShowMissingRoms;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonConvertRomsXML;
        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.Button buttonChangeISOtoCHD;
    }
}