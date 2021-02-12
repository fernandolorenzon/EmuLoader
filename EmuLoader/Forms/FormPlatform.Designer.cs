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
            this.textBoxPlatformName = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBoxShowInLinksList = new System.Windows.Forms.CheckBox();
            this.checkBoxShowInFilters = new System.Windows.Forms.CheckBox();
            this.labelCommand = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonIconPath = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlPlatform = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.textBoxPlatformIcon = new System.Windows.Forms.TextBox();
            this.labelPlatformName = new System.Windows.Forms.Label();
            this.textBoxDefaultRomExtensions = new System.Windows.Forms.TextBox();
            this.labelExtensions = new System.Windows.Forms.Label();
            this.buttonDefaultRomPath = new System.Windows.Forms.Button();
            this.labelPlatformIcon = new System.Windows.Forms.Label();
            this.labelTheGamesDB = new System.Windows.Forms.Label();
            this.labelDefaultRomPath = new System.Windows.Forms.Label();
            this.comboBoxPlatformsDB = new System.Windows.Forms.ComboBox();
            this.textBoxDefaultRomPath = new System.Windows.Forms.TextBox();
            this.tabPageEmulators = new System.Windows.Forms.TabPage();
            this.buttonDeleteEmulator = new System.Windows.Forms.Button();
            this.buttonMakeDefault = new System.Windows.Forms.Button();
            this.buttonAddEmulator = new System.Windows.Forms.Button();
            this.dataGridViewEmulators = new System.Windows.Forms.DataGridView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSelectCore = new System.Windows.Forms.Button();
            this.checkBoxUseRetroarch = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.ColumnEmuDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmuPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmuCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControlPlatform.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageEmulators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmulators)).BeginInit();
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
            this.dataGridView.Size = new System.Drawing.Size(830, 333);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnName.DataPropertyName = "Name";
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
            // textBoxPlatformName
            // 
            this.textBoxPlatformName.Location = new System.Drawing.Point(13, 28);
            this.textBoxPlatformName.Name = "textBoxPlatformName";
            this.textBoxPlatformName.Size = new System.Drawing.Size(339, 20);
            this.textBoxPlatformName.TabIndex = 2;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(143, 25);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(208, 20);
            this.textBoxPath.TabIndex = 4;
            this.textBoxPath.Leave += new System.EventHandler(this.textBoxPath_Leave);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(140, 3);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(69, 13);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Emulator Exe";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(357, 23);
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
            this.buttonColor.Location = new System.Drawing.Point(13, 115);
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
            this.checkBoxShowInLinksList.Location = new System.Drawing.Point(13, 183);
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
            this.checkBoxShowInFilters.Location = new System.Drawing.Point(144, 183);
            this.checkBoxShowInFilters.Name = "checkBoxShowInFilters";
            this.checkBoxShowInFilters.Size = new System.Drawing.Size(95, 17);
            this.checkBoxShowInFilters.TabIndex = 10;
            this.checkBoxShowInFilters.Text = "Show In Filters";
            this.checkBoxShowInFilters.UseVisualStyleBackColor = true;
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(396, 3);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 11;
            this.labelCommand.Text = "Command";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommand.Location = new System.Drawing.Point(399, 25);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(203, 20);
            this.textBoxCommand.TabIndex = 12;
            this.textBoxCommand.Text = "%EMUPATH% %ROMPATH%";
            this.toolTip1.SetToolTip(this.textBoxCommand, resources.GetString("textBoxCommand.ToolTip"));
            // 
            // buttonIconPath
            // 
            this.buttonIconPath.Location = new System.Drawing.Point(248, 84);
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
            this.pictureBoxIcon.Location = new System.Drawing.Point(13, 56);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 16;
            this.pictureBoxIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControlPlatform);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 266);
            this.panel1.TabIndex = 17;
            // 
            // tabControlPlatform
            // 
            this.tabControlPlatform.Controls.Add(this.tabPageMain);
            this.tabControlPlatform.Controls.Add(this.tabPageEmulators);
            this.tabControlPlatform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPlatform.Location = new System.Drawing.Point(0, 0);
            this.tabControlPlatform.Name = "tabControlPlatform";
            this.tabControlPlatform.SelectedIndex = 0;
            this.tabControlPlatform.Size = new System.Drawing.Size(830, 266);
            this.tabControlPlatform.TabIndex = 39;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.checkBoxShowInFilters);
            this.tabPageMain.Controls.Add(this.buttonColor);
            this.tabPageMain.Controls.Add(this.checkBoxShowInLinksList);
            this.tabPageMain.Controls.Add(this.textBoxPlatformIcon);
            this.tabPageMain.Controls.Add(this.buttonIconPath);
            this.tabPageMain.Controls.Add(this.labelPlatformName);
            this.tabPageMain.Controls.Add(this.textBoxPlatformName);
            this.tabPageMain.Controls.Add(this.textBoxDefaultRomExtensions);
            this.tabPageMain.Controls.Add(this.labelExtensions);
            this.tabPageMain.Controls.Add(this.pictureBoxIcon);
            this.tabPageMain.Controls.Add(this.buttonDefaultRomPath);
            this.tabPageMain.Controls.Add(this.labelPlatformIcon);
            this.tabPageMain.Controls.Add(this.labelTheGamesDB);
            this.tabPageMain.Controls.Add(this.labelDefaultRomPath);
            this.tabPageMain.Controls.Add(this.comboBoxPlatformsDB);
            this.tabPageMain.Controls.Add(this.textBoxDefaultRomPath);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(822, 240);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // textBoxPlatformIcon
            // 
            this.textBoxPlatformIcon.Location = new System.Drawing.Point(69, 86);
            this.textBoxPlatformIcon.Name = "textBoxPlatformIcon";
            this.textBoxPlatformIcon.Size = new System.Drawing.Size(173, 20);
            this.textBoxPlatformIcon.TabIndex = 13;
            this.textBoxPlatformIcon.TextChanged += new System.EventHandler(this.textBoxEmulatorIcon_TextChanged);
            // 
            // labelPlatformName
            // 
            this.labelPlatformName.AutoSize = true;
            this.labelPlatformName.Location = new System.Drawing.Point(10, 6);
            this.labelPlatformName.Name = "labelPlatformName";
            this.labelPlatformName.Size = new System.Drawing.Size(76, 13);
            this.labelPlatformName.TabIndex = 4;
            this.labelPlatformName.Text = "Platform Name";
            // 
            // textBoxDefaultRomExtensions
            // 
            this.textBoxDefaultRomExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDefaultRomExtensions.Location = new System.Drawing.Point(404, 86);
            this.textBoxDefaultRomExtensions.Name = "textBoxDefaultRomExtensions";
            this.textBoxDefaultRomExtensions.Size = new System.Drawing.Size(387, 20);
            this.textBoxDefaultRomExtensions.TabIndex = 31;
            this.textBoxDefaultRomExtensions.Text = "zip";
            // 
            // labelExtensions
            // 
            this.labelExtensions.AutoSize = true;
            this.labelExtensions.Location = new System.Drawing.Point(401, 57);
            this.labelExtensions.Name = "labelExtensions";
            this.labelExtensions.Size = new System.Drawing.Size(205, 26);
            this.labelExtensions.TabIndex = 32;
            this.labelExtensions.Text = "Default Extensions \r\n(separate with comma \",\": zip,rom,smc,gb)";
            // 
            // buttonDefaultRomPath
            // 
            this.buttonDefaultRomPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDefaultRomPath.Location = new System.Drawing.Point(756, 130);
            this.buttonDefaultRomPath.Name = "buttonDefaultRomPath";
            this.buttonDefaultRomPath.Size = new System.Drawing.Size(36, 21);
            this.buttonDefaultRomPath.TabIndex = 30;
            this.buttonDefaultRomPath.Text = "...";
            this.buttonDefaultRomPath.UseVisualStyleBackColor = true;
            this.buttonDefaultRomPath.Click += new System.EventHandler(this.buttonDefaultRomPath_Click);
            // 
            // labelPlatformIcon
            // 
            this.labelPlatformIcon.AutoSize = true;
            this.labelPlatformIcon.Location = new System.Drawing.Point(69, 70);
            this.labelPlatformIcon.Name = "labelPlatformIcon";
            this.labelPlatformIcon.Size = new System.Drawing.Size(69, 13);
            this.labelPlatformIcon.TabIndex = 14;
            this.labelPlatformIcon.Text = "Platform Icon";
            // 
            // labelTheGamesDB
            // 
            this.labelTheGamesDB.AutoSize = true;
            this.labelTheGamesDB.Location = new System.Drawing.Point(401, 6);
            this.labelTheGamesDB.Name = "labelTheGamesDB";
            this.labelTheGamesDB.Size = new System.Drawing.Size(156, 13);
            this.labelTheGamesDB.TabIndex = 18;
            this.labelTheGamesDB.Text = "Platform from TheGamesDB.net";
            // 
            // labelDefaultRomPath
            // 
            this.labelDefaultRomPath.AutoSize = true;
            this.labelDefaultRomPath.Location = new System.Drawing.Point(401, 114);
            this.labelDefaultRomPath.Name = "labelDefaultRomPath";
            this.labelDefaultRomPath.Size = new System.Drawing.Size(91, 13);
            this.labelDefaultRomPath.TabIndex = 29;
            this.labelDefaultRomPath.Text = "Default Rom Path";
            // 
            // comboBoxPlatformsDB
            // 
            this.comboBoxPlatformsDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlatformsDB.FormattingEnabled = true;
            this.comboBoxPlatformsDB.Location = new System.Drawing.Point(404, 28);
            this.comboBoxPlatformsDB.Name = "comboBoxPlatformsDB";
            this.comboBoxPlatformsDB.Size = new System.Drawing.Size(387, 21);
            this.comboBoxPlatformsDB.TabIndex = 17;
            // 
            // textBoxDefaultRomPath
            // 
            this.textBoxDefaultRomPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDefaultRomPath.Location = new System.Drawing.Point(404, 130);
            this.textBoxDefaultRomPath.Name = "textBoxDefaultRomPath";
            this.textBoxDefaultRomPath.Size = new System.Drawing.Size(346, 20);
            this.textBoxDefaultRomPath.TabIndex = 28;
            // 
            // tabPageEmulators
            // 
            this.tabPageEmulators.Controls.Add(this.buttonDeleteEmulator);
            this.tabPageEmulators.Controls.Add(this.buttonMakeDefault);
            this.tabPageEmulators.Controls.Add(this.buttonAddEmulator);
            this.tabPageEmulators.Controls.Add(this.dataGridViewEmulators);
            this.tabPageEmulators.Controls.Add(this.textBoxName);
            this.tabPageEmulators.Controls.Add(this.buttonSelectCore);
            this.tabPageEmulators.Controls.Add(this.checkBoxUseRetroarch);
            this.tabPageEmulators.Controls.Add(this.textBoxPath);
            this.tabPageEmulators.Controls.Add(this.buttonPath);
            this.tabPageEmulators.Controls.Add(this.labelCommand);
            this.tabPageEmulators.Controls.Add(this.labelPath);
            this.tabPageEmulators.Controls.Add(this.textBoxCommand);
            this.tabPageEmulators.Controls.Add(this.labelName);
            this.tabPageEmulators.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmulators.Name = "tabPageEmulators";
            this.tabPageEmulators.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmulators.Size = new System.Drawing.Size(822, 240);
            this.tabPageEmulators.TabIndex = 1;
            this.tabPageEmulators.Text = "Emulators";
            this.tabPageEmulators.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteEmulator
            // 
            this.buttonDeleteEmulator.Location = new System.Drawing.Point(608, 119);
            this.buttonDeleteEmulator.Name = "buttonDeleteEmulator";
            this.buttonDeleteEmulator.Size = new System.Drawing.Size(110, 23);
            this.buttonDeleteEmulator.TabIndex = 45;
            this.buttonDeleteEmulator.Text = "Delete";
            this.buttonDeleteEmulator.UseVisualStyleBackColor = true;
            this.buttonDeleteEmulator.Click += new System.EventHandler(this.buttonDeleteEmulator_Click);
            // 
            // buttonMakeDefault
            // 
            this.buttonMakeDefault.Location = new System.Drawing.Point(608, 90);
            this.buttonMakeDefault.Name = "buttonMakeDefault";
            this.buttonMakeDefault.Size = new System.Drawing.Size(110, 23);
            this.buttonMakeDefault.TabIndex = 44;
            this.buttonMakeDefault.Text = "Make Default";
            this.buttonMakeDefault.UseVisualStyleBackColor = true;
            this.buttonMakeDefault.Click += new System.EventHandler(this.buttonMakeDefault_Click);
            // 
            // buttonAddEmulator
            // 
            this.buttonAddEmulator.Location = new System.Drawing.Point(608, 61);
            this.buttonAddEmulator.Name = "buttonAddEmulator";
            this.buttonAddEmulator.Size = new System.Drawing.Size(110, 23);
            this.buttonAddEmulator.TabIndex = 43;
            this.buttonAddEmulator.Text = "Add";
            this.buttonAddEmulator.UseVisualStyleBackColor = true;
            this.buttonAddEmulator.Click += new System.EventHandler(this.buttonAddEmulator_Click);
            // 
            // dataGridViewEmulators
            // 
            this.dataGridViewEmulators.AllowUserToAddRows = false;
            this.dataGridViewEmulators.AllowUserToDeleteRows = false;
            this.dataGridViewEmulators.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmulators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewEmulators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEmuDefault,
            this.ColumnEmuName,
            this.ColumnEmuPath,
            this.ColumnEmuCommand});
            this.dataGridViewEmulators.Location = new System.Drawing.Point(6, 61);
            this.dataGridViewEmulators.MultiSelect = false;
            this.dataGridViewEmulators.Name = "dataGridViewEmulators";
            this.dataGridViewEmulators.ReadOnly = true;
            this.dataGridViewEmulators.Size = new System.Drawing.Size(596, 173);
            this.dataGridViewEmulators.TabIndex = 42;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(131, 20);
            this.textBoxName.TabIndex = 41;
            // 
            // buttonSelectCore
            // 
            this.buttonSelectCore.Enabled = false;
            this.buttonSelectCore.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectCore.Image")));
            this.buttonSelectCore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectCore.Location = new System.Drawing.Point(709, 23);
            this.buttonSelectCore.Name = "buttonSelectCore";
            this.buttonSelectCore.Size = new System.Drawing.Size(94, 23);
            this.buttonSelectCore.TabIndex = 40;
            this.buttonSelectCore.Text = "Select Core";
            this.buttonSelectCore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectCore.UseVisualStyleBackColor = true;
            this.buttonSelectCore.Click += new System.EventHandler(this.buttonSelectCore_Click);
            // 
            // checkBoxUseRetroarch
            // 
            this.checkBoxUseRetroarch.AutoSize = true;
            this.checkBoxUseRetroarch.Location = new System.Drawing.Point(608, 26);
            this.checkBoxUseRetroarch.Name = "checkBoxUseRetroarch";
            this.checkBoxUseRetroarch.Size = new System.Drawing.Size(95, 17);
            this.checkBoxUseRetroarch.TabIndex = 39;
            this.checkBoxUseRetroarch.Text = "Use Retroarch";
            this.checkBoxUseRetroarch.UseVisualStyleBackColor = true;
            this.checkBoxUseRetroarch.Click += new System.EventHandler(this.checkBoxUseRetroarch_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(79, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Emulator Name";
            // 
            // ColumnEmuDefault
            // 
            this.ColumnEmuDefault.DataPropertyName = "Default";
            this.ColumnEmuDefault.Frozen = true;
            this.ColumnEmuDefault.HeaderText = "*";
            this.ColumnEmuDefault.Name = "ColumnEmuDefault";
            this.ColumnEmuDefault.ReadOnly = true;
            this.ColumnEmuDefault.Width = 20;
            // 
            // ColumnEmuName
            // 
            this.ColumnEmuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnEmuName.DataPropertyName = "Name";
            this.ColumnEmuName.FillWeight = 50F;
            this.ColumnEmuName.Frozen = true;
            this.ColumnEmuName.HeaderText = "Name";
            this.ColumnEmuName.MinimumWidth = 50;
            this.ColumnEmuName.Name = "ColumnEmuName";
            this.ColumnEmuName.ReadOnly = true;
            this.ColumnEmuName.Width = 132;
            // 
            // ColumnEmuPath
            // 
            this.ColumnEmuPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmuPath.DataPropertyName = "Path";
            this.ColumnEmuPath.FillWeight = 80F;
            this.ColumnEmuPath.HeaderText = "Path";
            this.ColumnEmuPath.MinimumWidth = 50;
            this.ColumnEmuPath.Name = "ColumnEmuPath";
            this.ColumnEmuPath.ReadOnly = true;
            // 
            // ColumnEmuCommand
            // 
            this.ColumnEmuCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmuCommand.DataPropertyName = "Command";
            this.ColumnEmuCommand.FillWeight = 80F;
            this.ColumnEmuCommand.HeaderText = "Command";
            this.ColumnEmuCommand.MinimumWidth = 50;
            this.ColumnEmuCommand.Name = "ColumnEmuCommand";
            this.ColumnEmuCommand.ReadOnly = true;
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
            this.tabControlPlatform.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageEmulators.ResumeLayout(false);
            this.tabPageEmulators.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmulators)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxPlatformName;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox checkBoxShowInLinksList;
        private System.Windows.Forms.CheckBox checkBoxShowInFilters;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Button buttonIconPath;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTheGamesDB;
        private System.Windows.Forms.ComboBox comboBoxPlatformsDB;
        private System.Windows.Forms.Label labelDefaultRomPath;
        private System.Windows.Forms.Button buttonDefaultRomPath;
        private System.Windows.Forms.TextBox textBoxDefaultRomExtensions;
        private System.Windows.Forms.Label labelExtensions;
        private System.Windows.Forms.TabControl tabControlPlatform;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TextBox textBoxPlatformIcon;
        private System.Windows.Forms.Label labelPlatformName;
        private System.Windows.Forms.Label labelPlatformIcon;
        private System.Windows.Forms.TextBox textBoxDefaultRomPath;
        private System.Windows.Forms.TabPage tabPageEmulators;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox checkBoxUseRetroarch;
        private System.Windows.Forms.Button buttonSelectCore;
        private System.Windows.Forms.Button buttonDeleteEmulator;
        private System.Windows.Forms.Button buttonMakeDefault;
        private System.Windows.Forms.Button buttonAddEmulator;
        private System.Windows.Forms.DataGridView dataGridViewEmulators;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnShowInList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnShowInFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmuDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmuPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmuCommand;
    }
}