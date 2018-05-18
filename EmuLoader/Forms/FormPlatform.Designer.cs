namespace EmuLoader.Forms
{
    partial class FormPlatform
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlatform));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnExe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnShowInList = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnShowInFilter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBoxShowInLinksList = new System.Windows.Forms.CheckBox();
            this.checkBoxShowInFilters = new System.Windows.Forms.CheckBox();
            this.labelCommand = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlatformIcon = new System.Windows.Forms.TextBox();
            this.buttonIconPath = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDefaultRomExtensions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDefaultRomPath = new System.Windows.Forms.Button();
            this.textBoxDefaultRomPath = new System.Windows.Forms.TextBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPlatformsDB = new System.Windows.Forms.ComboBox();
            this.textBoxAlternatePath = new System.Windows.Forms.TextBox();
            this.textBoxAlternateCommand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAlternatePath = new System.Windows.Forms.Button();
            this.buttonSwap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnExe,
            this.columnShowInList,
            this.columnShowInFilter,
            this.columnColor});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(830, 329);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnName.DataPropertyName = "Namw";
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnExe
            // 
            this.columnExe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnExe.DataPropertyName = "Path";
            this.columnExe.HeaderText = "Exe";
            this.columnExe.Name = "columnExe";
            this.columnExe.ReadOnly = true;
            this.columnExe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnExe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnShowInList
            // 
            this.columnShowInList.DataPropertyName = "ShowList";
            this.columnShowInList.HeaderText = "Show In List";
            this.columnShowInList.Name = "columnShowInList";
            this.columnShowInList.ReadOnly = true;
            this.columnShowInList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnShowInList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnShowInFilter
            // 
            this.columnShowInFilter.DataPropertyName = "ShowFilter";
            this.columnShowInFilter.HeaderText = "Show In Filter";
            this.columnShowInFilter.Name = "columnShowInFilter";
            this.columnShowInFilter.ReadOnly = true;
            this.columnShowInFilter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnShowInFilter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnColor
            // 
            this.columnColor.DataPropertyName = "Color";
            this.columnColor.HeaderText = "Color";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 93);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(173, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 77);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Platform Name";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(16, 144);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(414, 20);
            this.textBoxPath.TabIndex = 4;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 122);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(69, 13);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Emulator Exe";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(436, 142);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(36, 23);
            this.buttonPath.TabIndex = 3;
            this.buttonPath.Text = "...";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.White;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(289, 6);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(50, 50);
            this.buttonColor.TabIndex = 6;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // checkBoxShowInLinksList
            // 
            this.checkBoxShowInLinksList.AutoSize = true;
            this.checkBoxShowInLinksList.Checked = true;
            this.checkBoxShowInLinksList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowInLinksList.Location = new System.Drawing.Point(16, 234);
            this.checkBoxShowInLinksList.Name = "checkBoxShowInLinksList";
            this.checkBoxShowInLinksList.Size = new System.Drawing.Size(112, 17);
            this.checkBoxShowInLinksList.TabIndex = 9;
            this.checkBoxShowInLinksList.Text = "Show In Links List";
            this.checkBoxShowInLinksList.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowInFilters
            // 
            this.checkBoxShowInFilters.AutoSize = true;
            this.checkBoxShowInFilters.Checked = true;
            this.checkBoxShowInFilters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowInFilters.Location = new System.Drawing.Point(195, 234);
            this.checkBoxShowInFilters.Name = "checkBoxShowInFilters";
            this.checkBoxShowInFilters.Size = new System.Drawing.Size(95, 17);
            this.checkBoxShowInFilters.TabIndex = 10;
            this.checkBoxShowInFilters.Text = "Show In Filters";
            this.checkBoxShowInFilters.UseVisualStyleBackColor = true;
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(476, 122);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 11;
            this.labelCommand.Text = "Command";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommand.Location = new System.Drawing.Point(478, 144);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(306, 20);
            this.textBoxCommand.TabIndex = 12;
            this.textBoxCommand.Text = "%EMUPATH% %ROMPATH%";
            this.toolTip1.SetToolTip(this.textBoxCommand, resources.GetString("textBoxCommand.ToolTip"));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Platform Icon";
            // 
            // textBoxPlatformIcon
            // 
            this.textBoxPlatformIcon.Location = new System.Drawing.Point(68, 34);
            this.textBoxPlatformIcon.Name = "textBoxPlatformIcon";
            this.textBoxPlatformIcon.Size = new System.Drawing.Size(173, 20);
            this.textBoxPlatformIcon.TabIndex = 13;
            this.textBoxPlatformIcon.TextChanged += new System.EventHandler(this.textBoxEmulatorIcon_TextChanged);
            // 
            // buttonIconPath
            // 
            this.buttonIconPath.Location = new System.Drawing.Point(247, 31);
            this.buttonIconPath.Name = "buttonIconPath";
            this.buttonIconPath.Size = new System.Drawing.Size(36, 23);
            this.buttonIconPath.TabIndex = 15;
            this.buttonIconPath.Text = "...";
            this.buttonIconPath.UseVisualStyleBackColor = true;
            this.buttonIconPath.Click += new System.EventHandler(this.buttonIconPath_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 6);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSwap);
            this.panel1.Controls.Add(this.textBoxAlternatePath);
            this.panel1.Controls.Add(this.textBoxAlternateCommand);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonAlternatePath);
            this.panel1.Controls.Add(this.textBoxDefaultRomExtensions);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonDefaultRomPath);
            this.panel1.Controls.Add(this.textBoxDefaultRomPath);
            this.panel1.Controls.Add(this.buttonHelp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxPlatformsDB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxIcon);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.buttonIconPath);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.textBoxPlatformIcon);
            this.panel1.Controls.Add(this.textBoxPath);
            this.panel1.Controls.Add(this.textBoxCommand);
            this.panel1.Controls.Add(this.labelPath);
            this.panel1.Controls.Add(this.labelCommand);
            this.panel1.Controls.Add(this.buttonPath);
            this.panel1.Controls.Add(this.checkBoxShowInFilters);
            this.panel1.Controls.Add(this.checkBoxShowInLinksList);
            this.panel1.Controls.Add(this.buttonColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 266);
            this.panel1.TabIndex = 17;
            // 
            // textBoxDefaultRomExtensions
            // 
            this.textBoxDefaultRomExtensions.Location = new System.Drawing.Point(586, 93);
            this.textBoxDefaultRomExtensions.Name = "textBoxDefaultRomExtensions";
            this.textBoxDefaultRomExtensions.Size = new System.Drawing.Size(227, 20);
            this.textBoxDefaultRomExtensions.TabIndex = 31;
            this.textBoxDefaultRomExtensions.Text = "zip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 26);
            this.label4.TabIndex = 32;
            this.label4.Text = "Default Extensions \r\n(separate with comma \",\": zip,rom,smc,gb)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Default Rom Path";
            // 
            // buttonDefaultRomPath
            // 
            this.buttonDefaultRomPath.Location = new System.Drawing.Point(544, 91);
            this.buttonDefaultRomPath.Name = "buttonDefaultRomPath";
            this.buttonDefaultRomPath.Size = new System.Drawing.Size(36, 23);
            this.buttonDefaultRomPath.TabIndex = 30;
            this.buttonDefaultRomPath.Text = "...";
            this.buttonDefaultRomPath.UseVisualStyleBackColor = true;
            this.buttonDefaultRomPath.Click += new System.EventHandler(this.buttonDefaultRomPath_Click);
            // 
            // textBoxDefaultRomPath
            // 
            this.textBoxDefaultRomPath.Location = new System.Drawing.Point(194, 93);
            this.textBoxDefaultRomPath.Name = "textBoxDefaultRomPath";
            this.textBoxDefaultRomPath.Size = new System.Drawing.Size(346, 20);
            this.textBoxDefaultRomPath.TabIndex = 28;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonHelp.ForeColor = System.Drawing.Color.Black;
            this.buttonHelp.Location = new System.Drawing.Point(790, 142);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonHelp.TabIndex = 27;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Platform from TheGamesDB.net";
            // 
            // comboBoxPlatformsDB
            // 
            this.comboBoxPlatformsDB.FormattingEnabled = true;
            this.comboBoxPlatformsDB.Location = new System.Drawing.Point(486, 34);
            this.comboBoxPlatformsDB.Name = "comboBoxPlatformsDB";
            this.comboBoxPlatformsDB.Size = new System.Drawing.Size(327, 21);
            this.comboBoxPlatformsDB.TabIndex = 17;
            // 
            // textBoxAlternatePath
            // 
            this.textBoxAlternatePath.Location = new System.Drawing.Point(15, 196);
            this.textBoxAlternatePath.Name = "textBoxAlternatePath";
            this.textBoxAlternatePath.Size = new System.Drawing.Size(415, 20);
            this.textBoxAlternatePath.TabIndex = 34;
            // 
            // textBoxAlternateCommand
            // 
            this.textBoxAlternateCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlternateCommand.Location = new System.Drawing.Point(479, 197);
            this.textBoxAlternateCommand.Name = "textBoxAlternateCommand";
            this.textBoxAlternateCommand.Size = new System.Drawing.Size(306, 20);
            this.textBoxAlternateCommand.TabIndex = 37;
            this.textBoxAlternateCommand.Text = "%EMUPATH% %ROMPATH%";
            this.toolTip1.SetToolTip(this.textBoxAlternateCommand, resources.GetString("textBoxAlternateCommand.ToolTip"));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Alternate Emulator Exe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Alternate Command";
            // 
            // buttonAlternatePath
            // 
            this.buttonAlternatePath.Location = new System.Drawing.Point(436, 195);
            this.buttonAlternatePath.Name = "buttonAlternatePath";
            this.buttonAlternatePath.Size = new System.Drawing.Size(36, 23);
            this.buttonAlternatePath.TabIndex = 33;
            this.buttonAlternatePath.Text = "...";
            this.buttonAlternatePath.UseVisualStyleBackColor = true;
            this.buttonAlternatePath.Click += new System.EventHandler(this.buttonAlternatePath_Click);
            // 
            // buttonSwap
            // 
            this.buttonSwap.Location = new System.Drawing.Point(479, 230);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(142, 23);
            this.buttonSwap.TabIndex = 38;
            this.buttonSwap.Text = "Swap Exe and Command";
            this.buttonSwap.UseVisualStyleBackColor = true;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            // 
            // FormPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 651);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(481, 486);
            this.Name = "FormPlatform";
            this.ShowInTaskbar = false;
            this.Text = "Platform Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEmulator_FormClosed);
            this.Load += new System.EventHandler(this.FormEmulator_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox checkBoxShowInLinksList;
        private System.Windows.Forms.CheckBox checkBoxShowInFilters;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnShowInList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnShowInFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPlatformIcon;
        private System.Windows.Forms.Button buttonIconPath;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPlatformsDB;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDefaultRomPath;
        private System.Windows.Forms.TextBox textBoxDefaultRomPath;
        private System.Windows.Forms.TextBox textBoxDefaultRomExtensions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.TextBox textBoxAlternatePath;
        private System.Windows.Forms.TextBox textBoxAlternateCommand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAlternatePath;
    }
}