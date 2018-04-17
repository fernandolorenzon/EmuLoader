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
            this.buttonHelp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPlatformsDB = new System.Windows.Forms.ComboBox();
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
            this.dataGridView.Size = new System.Drawing.Size(788, 353);
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
            this.textBoxName.Location = new System.Drawing.Point(15, 106);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(173, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 84);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Platform Name";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(194, 107);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(245, 20);
            this.textBoxPath.TabIndex = 4;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(191, 84);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(69, 13);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Emulator Exe";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(444, 105);
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
            this.buttonColor.Location = new System.Drawing.Point(292, 24);
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
            this.checkBoxShowInLinksList.Location = new System.Drawing.Point(15, 132);
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
            this.checkBoxShowInFilters.Location = new System.Drawing.Point(194, 132);
            this.checkBoxShowInFilters.Name = "checkBoxShowInFilters";
            this.checkBoxShowInFilters.Size = new System.Drawing.Size(95, 17);
            this.checkBoxShowInFilters.TabIndex = 10;
            this.checkBoxShowInFilters.Text = "Show In Filters";
            this.checkBoxShowInFilters.UseVisualStyleBackColor = true;
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(483, 84);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 11;
            this.labelCommand.Text = "Command";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommand.Location = new System.Drawing.Point(486, 107);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(264, 20);
            this.textBoxCommand.TabIndex = 12;
            this.textBoxCommand.Text = "%EMUPATH% %ROMPATH%";
            this.toolTip1.SetToolTip(this.textBoxCommand, resources.GetString("textBoxCommand.ToolTip"));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Platform Icon";
            // 
            // textBoxPlatformIcon
            // 
            this.textBoxPlatformIcon.Location = new System.Drawing.Point(68, 46);
            this.textBoxPlatformIcon.Name = "textBoxPlatformIcon";
            this.textBoxPlatformIcon.Size = new System.Drawing.Size(173, 20);
            this.textBoxPlatformIcon.TabIndex = 13;
            this.textBoxPlatformIcon.TextChanged += new System.EventHandler(this.textBoxEmulatorIcon_TextChanged);
            // 
            // buttonIconPath
            // 
            this.buttonIconPath.Location = new System.Drawing.Point(250, 44);
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
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 24);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // panel1
            // 
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
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 164);
            this.panel1.TabIndex = 17;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonHelp.ForeColor = System.Drawing.Color.Black;
            this.buttonHelp.Location = new System.Drawing.Point(756, 105);
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
            this.label2.Location = new System.Drawing.Point(483, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Platform from TheGamesDB.net";
            // 
            // comboBoxPlatformsDB
            // 
            this.comboBoxPlatformsDB.FormattingEnabled = true;
            this.comboBoxPlatformsDB.Location = new System.Drawing.Point(486, 46);
            this.comboBoxPlatformsDB.Name = "comboBoxPlatformsDB";
            this.comboBoxPlatformsDB.Size = new System.Drawing.Size(290, 21);
            this.comboBoxPlatformsDB.TabIndex = 17;
            // 
            // FormPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 573);
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
    }
}