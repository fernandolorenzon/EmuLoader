﻿namespace EmuLoader.Gui.Forms
{
    partial class FormManageRom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageRom));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.textBoxSeries = new System.Windows.Forms.TextBox();
            this.labelSeries = new System.Windows.Forms.Label();
            this.comboBoxChooseEmulator = new System.Windows.Forms.ComboBox();
            this.labelChooseEmulator = new System.Windows.Forms.Label();
            this.comboBoxChooseStatus = new System.Windows.Forms.ComboBox();
            this.labelChooseStatus = new System.Windows.Forms.Label();
            this.buttonGetMAMEName = new System.Windows.Forms.Button();
            this.checkBoxIdLocked = new System.Windows.Forms.CheckBox();
            this.textBoxRating = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBoxKeepSuffix = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.labelPlatform = new System.Windows.Forms.Label();
            this.buttonOpenInDB = new System.Windows.Forms.Button();
            this.buttonPlatformJson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClean = new System.Windows.Forms.Button();
            this.radioButtonOverwrite = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyMissing = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonShowDBInfo = new System.Windows.Forms.Button();
            this.buttonGetRomData = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCopyDBName = new System.Windows.Forms.Button();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.labelChangeFileName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxRomName = new System.Windows.Forms.TextBox();
            this.labelChangeRomName = new System.Windows.Forms.Label();
            this.textBoxYearReleased = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.textBoxDeveloper = new System.Windows.Forms.TextBox();
            this.checkBoxChangeZippedName = new System.Windows.Forms.CheckBox();
            this.buttonCopyToRom = new System.Windows.Forms.Button();
            this.buttonCopyToFile = new System.Windows.Forms.Button();
            this.labelChooseLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.labelGenre = new System.Windows.Forms.Label();
            this.tabPagePictures = new System.Windows.Forms.TabPage();
            this.checkBoxSaveAsJpg = new System.Windows.Forms.CheckBox();
            this.buttonFindGameplayPicture = new System.Windows.Forms.Button();
            this.textBoxGameplayPicture = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFindTitlePicture = new System.Windows.Forms.Button();
            this.textBoxTitlePicture = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFindBoxartPicture = new System.Windows.Forms.Button();
            this.textBoxBoxartPicture = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxGameplay = new System.Windows.Forms.PictureBox();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.pictureBoxBoxart = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPagePictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPagePictures);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(813, 648);
            this.tabControl.TabIndex = 47;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.textBoxSeries);
            this.tabPageGeneral.Controls.Add(this.labelSeries);
            this.tabPageGeneral.Controls.Add(this.comboBoxChooseEmulator);
            this.tabPageGeneral.Controls.Add(this.labelChooseEmulator);
            this.tabPageGeneral.Controls.Add(this.comboBoxChooseStatus);
            this.tabPageGeneral.Controls.Add(this.labelChooseStatus);
            this.tabPageGeneral.Controls.Add(this.buttonGetMAMEName);
            this.tabPageGeneral.Controls.Add(this.checkBoxIdLocked);
            this.tabPageGeneral.Controls.Add(this.textBoxRating);
            this.tabPageGeneral.Controls.Add(this.label16);
            this.tabPageGeneral.Controls.Add(this.checkBoxKeepSuffix);
            this.tabPageGeneral.Controls.Add(this.panel2);
            this.tabPageGeneral.Controls.Add(this.panel1);
            this.tabPageGeneral.Controls.Add(this.label11);
            this.tabPageGeneral.Controls.Add(this.buttonCopyDBName);
            this.tabPageGeneral.Controls.Add(this.textBoxPublisher);
            this.tabPageGeneral.Controls.Add(this.label8);
            this.tabPageGeneral.Controls.Add(this.textBoxDBName);
            this.tabPageGeneral.Controls.Add(this.textBoxFileName);
            this.tabPageGeneral.Controls.Add(this.labelChangeFileName);
            this.tabPageGeneral.Controls.Add(this.label14);
            this.tabPageGeneral.Controls.Add(this.textBoxRomName);
            this.tabPageGeneral.Controls.Add(this.labelChangeRomName);
            this.tabPageGeneral.Controls.Add(this.textBoxYearReleased);
            this.tabPageGeneral.Controls.Add(this.label12);
            this.tabPageGeneral.Controls.Add(this.textBoxDescription);
            this.tabPageGeneral.Controls.Add(this.Description);
            this.tabPageGeneral.Controls.Add(this.textBoxDeveloper);
            this.tabPageGeneral.Controls.Add(this.checkBoxChangeZippedName);
            this.tabPageGeneral.Controls.Add(this.buttonCopyToRom);
            this.tabPageGeneral.Controls.Add(this.buttonCopyToFile);
            this.tabPageGeneral.Controls.Add(this.labelChooseLabel);
            this.tabPageGeneral.Controls.Add(this.dataGridView);
            this.tabPageGeneral.Controls.Add(this.comboBoxGenre);
            this.tabPageGeneral.Controls.Add(this.labelGenre);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(805, 622);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // textBoxSeries
            // 
            this.textBoxSeries.Location = new System.Drawing.Point(260, 180);
            this.textBoxSeries.Name = "textBoxSeries";
            this.textBoxSeries.Size = new System.Drawing.Size(123, 20);
            this.textBoxSeries.TabIndex = 112;
            // 
            // labelSeries
            // 
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(257, 164);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(36, 13);
            this.labelSeries.TabIndex = 111;
            this.labelSeries.Text = "Series";
            // 
            // comboBoxChooseEmulator
            // 
            this.comboBoxChooseEmulator.FormattingEnabled = true;
            this.comboBoxChooseEmulator.Location = new System.Drawing.Point(11, 538);
            this.comboBoxChooseEmulator.Name = "comboBoxChooseEmulator";
            this.comboBoxChooseEmulator.Size = new System.Drawing.Size(372, 21);
            this.comboBoxChooseEmulator.TabIndex = 110;
            // 
            // labelChooseEmulator
            // 
            this.labelChooseEmulator.AutoSize = true;
            this.labelChooseEmulator.Location = new System.Drawing.Point(8, 522);
            this.labelChooseEmulator.Name = "labelChooseEmulator";
            this.labelChooseEmulator.Size = new System.Drawing.Size(87, 13);
            this.labelChooseEmulator.TabIndex = 109;
            this.labelChooseEmulator.Text = "Choose Emulator";
            // 
            // comboBoxChooseStatus
            // 
            this.comboBoxChooseStatus.FormattingEnabled = true;
            this.comboBoxChooseStatus.Location = new System.Drawing.Point(205, 307);
            this.comboBoxChooseStatus.Name = "comboBoxChooseStatus";
            this.comboBoxChooseStatus.Size = new System.Drawing.Size(178, 21);
            this.comboBoxChooseStatus.TabIndex = 108;
            // 
            // labelChooseStatus
            // 
            this.labelChooseStatus.AutoSize = true;
            this.labelChooseStatus.Location = new System.Drawing.Point(202, 291);
            this.labelChooseStatus.Name = "labelChooseStatus";
            this.labelChooseStatus.Size = new System.Drawing.Size(76, 13);
            this.labelChooseStatus.TabIndex = 107;
            this.labelChooseStatus.Text = "Choose Status";
            // 
            // buttonGetMAMEName
            // 
            this.buttonGetMAMEName.Location = new System.Drawing.Point(6, 238);
            this.buttonGetMAMEName.Name = "buttonGetMAMEName";
            this.buttonGetMAMEName.Size = new System.Drawing.Size(167, 23);
            this.buttonGetMAMEName.TabIndex = 106;
            this.buttonGetMAMEName.Text = "Get MAME Name";
            this.buttonGetMAMEName.UseVisualStyleBackColor = true;
            this.buttonGetMAMEName.Click += new System.EventHandler(this.buttonGetMAMEName_Click);
            // 
            // checkBoxIdLocked
            // 
            this.checkBoxIdLocked.AutoSize = true;
            this.checkBoxIdLocked.Location = new System.Drawing.Point(404, 238);
            this.checkBoxIdLocked.Name = "checkBoxIdLocked";
            this.checkBoxIdLocked.Size = new System.Drawing.Size(74, 17);
            this.checkBoxIdLocked.TabIndex = 105;
            this.checkBoxIdLocked.Text = "Locked Id";
            this.checkBoxIdLocked.UseVisualStyleBackColor = true;
            // 
            // textBoxRating
            // 
            this.textBoxRating.Location = new System.Drawing.Point(596, 317);
            this.textBoxRating.MaxLength = 4;
            this.textBoxRating.Name = "textBoxRating";
            this.textBoxRating.Size = new System.Drawing.Size(201, 20);
            this.textBoxRating.TabIndex = 104;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(593, 301);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 103;
            this.label16.Text = "Rating - 0 to 10";
            // 
            // checkBoxKeepSuffix
            // 
            this.checkBoxKeepSuffix.AutoSize = true;
            this.checkBoxKeepSuffix.Checked = true;
            this.checkBoxKeepSuffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepSuffix.Location = new System.Drawing.Point(482, 206);
            this.checkBoxKeepSuffix.Name = "checkBoxKeepSuffix";
            this.checkBoxKeepSuffix.Size = new System.Drawing.Size(78, 17);
            this.checkBoxKeepSuffix.TabIndex = 102;
            this.checkBoxKeepSuffix.Text = "Keep suffix";
            this.checkBoxKeepSuffix.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.labelPlatform);
            this.panel2.Controls.Add(this.buttonOpenInDB);
            this.panel2.Controls.Add(this.buttonPlatformJson);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelRom);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 150);
            this.panel2.TabIndex = 101;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Platform";
            // 
            // labelPlatform
            // 
            this.labelPlatform.AutoSize = true;
            this.labelPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlatform.Location = new System.Drawing.Point(10, 55);
            this.labelPlatform.Name = "labelPlatform";
            this.labelPlatform.Size = new System.Drawing.Size(52, 17);
            this.labelPlatform.TabIndex = 100;
            this.labelPlatform.Text = "label1";
            // 
            // buttonOpenInDB
            // 
            this.buttonOpenInDB.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenInDB.Image")));
            this.buttonOpenInDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenInDB.Location = new System.Drawing.Point(7, 80);
            this.buttonOpenInDB.Name = "buttonOpenInDB";
            this.buttonOpenInDB.Size = new System.Drawing.Size(138, 61);
            this.buttonOpenInDB.TabIndex = 83;
            this.buttonOpenInDB.Text = "Open TheGamesDB";
            this.buttonOpenInDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenInDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOpenInDB.UseVisualStyleBackColor = true;
            this.buttonOpenInDB.Click += new System.EventHandler(this.buttonSearchInDB_Click);
            // 
            // buttonPlatformJson
            // 
            this.buttonPlatformJson.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlatformJson.Image")));
            this.buttonPlatformJson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlatformJson.Location = new System.Drawing.Point(151, 80);
            this.buttonPlatformJson.Name = "buttonPlatformJson";
            this.buttonPlatformJson.Size = new System.Drawing.Size(128, 61);
            this.buttonPlatformJson.TabIndex = 99;
            this.buttonPlatformJson.Text = "Open Platform json";
            this.buttonPlatformJson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlatformJson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPlatformJson.UseVisualStyleBackColor = true;
            this.buttonPlatformJson.Click += new System.EventHandler(this.buttonCheckList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Rom Name";
            // 
            // labelRom
            // 
            this.labelRom.AutoSize = true;
            this.labelRom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRom.Location = new System.Drawing.Point(10, 22);
            this.labelRom.Name = "labelRom";
            this.labelRom.Size = new System.Drawing.Size(52, 17);
            this.labelRom.TabIndex = 85;
            this.labelRom.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonClean);
            this.panel1.Controls.Add(this.radioButtonOverwrite);
            this.panel1.Controls.Add(this.radioButtonOnlyMissing);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.buttonShowDBInfo);
            this.panel1.Controls.Add(this.buttonGetRomData);
            this.panel1.Location = new System.Drawing.Point(401, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 150);
            this.panel1.TabIndex = 100;
            // 
            // buttonClean
            // 
            this.buttonClean.Image = ((System.Drawing.Image)(resources.GetObject("buttonClean.Image")));
            this.buttonClean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClean.Location = new System.Drawing.Point(255, 80);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(136, 61);
            this.buttonClean.TabIndex = 101;
            this.buttonClean.Text = "Clean Data";
            this.buttonClean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // radioButtonOverwrite
            // 
            this.radioButtonOverwrite.AutoSize = true;
            this.radioButtonOverwrite.Checked = true;
            this.radioButtonOverwrite.Location = new System.Drawing.Point(126, 74);
            this.radioButtonOverwrite.Name = "radioButtonOverwrite";
            this.radioButtonOverwrite.Size = new System.Drawing.Size(96, 17);
            this.radioButtonOverwrite.TabIndex = 100;
            this.radioButtonOverwrite.TabStop = true;
            this.radioButtonOverwrite.Text = "Overwrite Data";
            this.radioButtonOverwrite.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyMissing
            // 
            this.radioButtonOnlyMissing.AutoSize = true;
            this.radioButtonOnlyMissing.Location = new System.Drawing.Point(126, 97);
            this.radioButtonOnlyMissing.Name = "radioButtonOnlyMissing";
            this.radioButtonOnlyMissing.Size = new System.Drawing.Size(110, 17);
            this.radioButtonOnlyMissing.TabIndex = 99;
            this.radioButtonOnlyMissing.Text = "Only Missing Data";
            this.radioButtonOnlyMissing.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "TheGamesDB.net Id";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(6, 35);
            this.textBoxId.MaxLength = 10;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(113, 20);
            this.textBoxId.TabIndex = 81;
            // 
            // buttonShowDBInfo
            // 
            this.buttonShowDBInfo.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowDBInfo.Image")));
            this.buttonShowDBInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonShowDBInfo.Location = new System.Drawing.Point(255, 3);
            this.buttonShowDBInfo.Name = "buttonShowDBInfo";
            this.buttonShowDBInfo.Size = new System.Drawing.Size(136, 65);
            this.buttonShowDBInfo.TabIndex = 82;
            this.buttonShowDBInfo.Text = "Show TheGamesDB Info";
            this.buttonShowDBInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonShowDBInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonShowDBInfo.UseVisualStyleBackColor = true;
            this.buttonShowDBInfo.Click += new System.EventHandler(this.buttonOpenDB_Click);
            // 
            // buttonGetRomData
            // 
            this.buttonGetRomData.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetRomData.Image")));
            this.buttonGetRomData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetRomData.Location = new System.Drawing.Point(126, 3);
            this.buttonGetRomData.Name = "buttonGetRomData";
            this.buttonGetRomData.Size = new System.Drawing.Size(123, 65);
            this.buttonGetRomData.TabIndex = 98;
            this.buttonGetRomData.Text = "Get Rom Data Online";
            this.buttonGetRomData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetRomData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGetRomData.UseVisualStyleBackColor = true;
            this.buttonGetRomData.Click += new System.EventHandler(this.buttonGetRomData_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(401, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "Developer";
            // 
            // buttonCopyDBName
            // 
            this.buttonCopyDBName.Location = new System.Drawing.Point(401, 206);
            this.buttonCopyDBName.Name = "buttonCopyDBName";
            this.buttonCopyDBName.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyDBName.TabIndex = 96;
            this.buttonCopyDBName.Text = "<< Copy";
            this.buttonCopyDBName.UseVisualStyleBackColor = true;
            this.buttonCopyDBName.Click += new System.EventHandler(this.buttonCopyDBName_Click);
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(596, 278);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(201, 20);
            this.textBoxPublisher.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(593, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Publisher";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(401, 180);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.ReadOnly = true;
            this.textBoxDBName.Size = new System.Drawing.Size(396, 20);
            this.textBoxDBName.TabIndex = 95;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(124, 180);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(130, 20);
            this.textBoxFileName.TabIndex = 90;
            // 
            // labelChangeFileName
            // 
            this.labelChangeFileName.AutoSize = true;
            this.labelChangeFileName.Location = new System.Drawing.Point(121, 164);
            this.labelChangeFileName.Name = "labelChangeFileName";
            this.labelChangeFileName.Size = new System.Drawing.Size(54, 13);
            this.labelChangeFileName.TabIndex = 89;
            this.labelChangeFileName.Text = "File Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(398, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "TheGamesDB.net Name";
            // 
            // textBoxRomName
            // 
            this.textBoxRomName.Location = new System.Drawing.Point(6, 180);
            this.textBoxRomName.Name = "textBoxRomName";
            this.textBoxRomName.Size = new System.Drawing.Size(112, 20);
            this.textBoxRomName.TabIndex = 88;
            // 
            // labelChangeRomName
            // 
            this.labelChangeRomName.AutoSize = true;
            this.labelChangeRomName.Location = new System.Drawing.Point(3, 164);
            this.labelChangeRomName.Name = "labelChangeRomName";
            this.labelChangeRomName.Size = new System.Drawing.Size(97, 13);
            this.labelChangeRomName.TabIndex = 87;
            this.labelChangeRomName.Text = "Rom Display Name";
            // 
            // textBoxYearReleased
            // 
            this.textBoxYearReleased.Location = new System.Drawing.Point(401, 317);
            this.textBoxYearReleased.MaxLength = 4;
            this.textBoxYearReleased.Name = "textBoxYearReleased";
            this.textBoxYearReleased.Size = new System.Drawing.Size(189, 20);
            this.textBoxYearReleased.TabIndex = 79;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(401, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Year Released";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(401, 361);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(396, 149);
            this.textBoxDescription.TabIndex = 77;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(401, 345);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 76;
            this.Description.Text = "Description";
            // 
            // textBoxDeveloper
            // 
            this.textBoxDeveloper.Location = new System.Drawing.Point(402, 278);
            this.textBoxDeveloper.Name = "textBoxDeveloper";
            this.textBoxDeveloper.Size = new System.Drawing.Size(188, 20);
            this.textBoxDeveloper.TabIndex = 75;
            // 
            // checkBoxChangeZippedName
            // 
            this.checkBoxChangeZippedName.AutoSize = true;
            this.checkBoxChangeZippedName.Checked = true;
            this.checkBoxChangeZippedName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChangeZippedName.Location = new System.Drawing.Point(225, 212);
            this.checkBoxChangeZippedName.Name = "checkBoxChangeZippedName";
            this.checkBoxChangeZippedName.Size = new System.Drawing.Size(158, 17);
            this.checkBoxChangeZippedName.TabIndex = 73;
            this.checkBoxChangeZippedName.Text = "Change rom name inside zip";
            this.checkBoxChangeZippedName.UseVisualStyleBackColor = true;
            // 
            // buttonCopyToRom
            // 
            this.buttonCopyToRom.Location = new System.Drawing.Point(124, 206);
            this.buttonCopyToRom.Name = "buttonCopyToRom";
            this.buttonCopyToRom.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToRom.TabIndex = 71;
            this.buttonCopyToRom.Text = "<< Copy";
            this.buttonCopyToRom.UseVisualStyleBackColor = true;
            this.buttonCopyToRom.Click += new System.EventHandler(this.buttonCopyToRom_Click);
            // 
            // buttonCopyToFile
            // 
            this.buttonCopyToFile.Location = new System.Drawing.Point(43, 206);
            this.buttonCopyToFile.Name = "buttonCopyToFile";
            this.buttonCopyToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToFile.TabIndex = 70;
            this.buttonCopyToFile.Text = "Copy >>";
            this.buttonCopyToFile.UseVisualStyleBackColor = true;
            this.buttonCopyToFile.Click += new System.EventHandler(this.buttonCopyToFile_Click);
            // 
            // labelChooseLabel
            // 
            this.labelChooseLabel.AutoSize = true;
            this.labelChooseLabel.Location = new System.Drawing.Point(3, 328);
            this.labelChooseLabel.Name = "labelChooseLabel";
            this.labelChooseLabel.Size = new System.Drawing.Size(77, 13);
            this.labelChooseLabel.TabIndex = 53;
            this.labelChooseLabel.Text = "Choose Labels";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCheck,
            this.columnName,
            this.columnColor});
            this.dataGridView.Location = new System.Drawing.Point(6, 351);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(377, 159);
            this.dataGridView.TabIndex = 52;
            // 
            // columnCheck
            // 
            this.columnCheck.HeaderText = "";
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.ThreeState = true;
            this.columnCheck.Width = 20;
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            // 
            // columnColor
            // 
            this.columnColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnColor.FillWeight = 60F;
            this.columnColor.HeaderText = "Color";
            this.columnColor.Name = "columnColor";
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(6, 307);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(193, 21);
            this.comboBoxGenre.TabIndex = 51;
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(3, 288);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(75, 13);
            this.labelGenre.TabIndex = 50;
            this.labelGenre.Text = "Choose Genre";
            // 
            // tabPagePictures
            // 
            this.tabPagePictures.Controls.Add(this.checkBoxSaveAsJpg);
            this.tabPagePictures.Controls.Add(this.buttonFindGameplayPicture);
            this.tabPagePictures.Controls.Add(this.textBoxGameplayPicture);
            this.tabPagePictures.Controls.Add(this.label3);
            this.tabPagePictures.Controls.Add(this.buttonFindTitlePicture);
            this.tabPagePictures.Controls.Add(this.textBoxTitlePicture);
            this.tabPagePictures.Controls.Add(this.label2);
            this.tabPagePictures.Controls.Add(this.buttonFindBoxartPicture);
            this.tabPagePictures.Controls.Add(this.textBoxBoxartPicture);
            this.tabPagePictures.Controls.Add(this.label4);
            this.tabPagePictures.Controls.Add(this.label5);
            this.tabPagePictures.Controls.Add(this.label7);
            this.tabPagePictures.Controls.Add(this.label6);
            this.tabPagePictures.Controls.Add(this.pictureBoxGameplay);
            this.tabPagePictures.Controls.Add(this.pictureBoxTitle);
            this.tabPagePictures.Controls.Add(this.pictureBoxBoxart);
            this.tabPagePictures.Location = new System.Drawing.Point(4, 22);
            this.tabPagePictures.Name = "tabPagePictures";
            this.tabPagePictures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePictures.Size = new System.Drawing.Size(805, 622);
            this.tabPagePictures.TabIndex = 1;
            this.tabPagePictures.Text = "Pictures";
            this.tabPagePictures.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveAsJpg
            // 
            this.checkBoxSaveAsJpg.AutoSize = true;
            this.checkBoxSaveAsJpg.Checked = true;
            this.checkBoxSaveAsJpg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveAsJpg.Location = new System.Drawing.Point(11, 147);
            this.checkBoxSaveAsJpg.Name = "checkBoxSaveAsJpg";
            this.checkBoxSaveAsJpg.Size = new System.Drawing.Size(88, 17);
            this.checkBoxSaveAsJpg.TabIndex = 107;
            this.checkBoxSaveAsJpg.Text = "Save as JPG";
            this.checkBoxSaveAsJpg.UseVisualStyleBackColor = true;
            // 
            // buttonFindGameplayPicture
            // 
            this.buttonFindGameplayPicture.Location = new System.Drawing.Point(367, 107);
            this.buttonFindGameplayPicture.Name = "buttonFindGameplayPicture";
            this.buttonFindGameplayPicture.Size = new System.Drawing.Size(125, 23);
            this.buttonFindGameplayPicture.TabIndex = 106;
            this.buttonFindGameplayPicture.Text = "Find &Gameplay Picture";
            this.buttonFindGameplayPicture.UseVisualStyleBackColor = true;
            this.buttonFindGameplayPicture.Click += new System.EventHandler(this.buttonFindGameplayPicture_Click);
            // 
            // textBoxGameplayPicture
            // 
            this.textBoxGameplayPicture.Location = new System.Drawing.Point(11, 110);
            this.textBoxGameplayPicture.Name = "textBoxGameplayPicture";
            this.textBoxGameplayPicture.Size = new System.Drawing.Size(350, 20);
            this.textBoxGameplayPicture.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Choose Gameplay Picture";
            // 
            // buttonFindTitlePicture
            // 
            this.buttonFindTitlePicture.Location = new System.Drawing.Point(367, 69);
            this.buttonFindTitlePicture.Name = "buttonFindTitlePicture";
            this.buttonFindTitlePicture.Size = new System.Drawing.Size(125, 23);
            this.buttonFindTitlePicture.TabIndex = 103;
            this.buttonFindTitlePicture.Text = "Find &Title Picture";
            this.buttonFindTitlePicture.UseVisualStyleBackColor = true;
            this.buttonFindTitlePicture.Click += new System.EventHandler(this.buttonFindTitlePicture_Click);
            // 
            // textBoxTitlePicture
            // 
            this.textBoxTitlePicture.Location = new System.Drawing.Point(11, 71);
            this.textBoxTitlePicture.Name = "textBoxTitlePicture";
            this.textBoxTitlePicture.Size = new System.Drawing.Size(350, 20);
            this.textBoxTitlePicture.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Choose Title Picture";
            // 
            // buttonFindBoxartPicture
            // 
            this.buttonFindBoxartPicture.Location = new System.Drawing.Point(367, 30);
            this.buttonFindBoxartPicture.Name = "buttonFindBoxartPicture";
            this.buttonFindBoxartPicture.Size = new System.Drawing.Size(125, 23);
            this.buttonFindBoxartPicture.TabIndex = 100;
            this.buttonFindBoxartPicture.Text = "Find &Box Picture";
            this.buttonFindBoxartPicture.UseVisualStyleBackColor = true;
            this.buttonFindBoxartPicture.Click += new System.EventHandler(this.buttonFindBoxartPicture_Click);
            // 
            // textBoxBoxartPicture
            // 
            this.textBoxBoxartPicture.Location = new System.Drawing.Point(11, 32);
            this.textBoxBoxartPicture.Name = "textBoxBoxartPicture";
            this.textBoxBoxartPicture.Size = new System.Drawing.Size(350, 20);
            this.textBoxBoxartPicture.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Choose Box Art Picture";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Box art image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Gameplay image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Title image";
            // 
            // pictureBoxGameplay
            // 
            this.pictureBoxGameplay.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGameplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGameplay.Location = new System.Drawing.Point(527, 212);
            this.pictureBoxGameplay.Name = "pictureBoxGameplay";
            this.pictureBoxGameplay.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxGameplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGameplay.TabIndex = 94;
            this.pictureBoxGameplay.TabStop = false;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitle.Location = new System.Drawing.Point(269, 212);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTitle.TabIndex = 93;
            this.pictureBoxTitle.TabStop = false;
            // 
            // pictureBoxBoxart
            // 
            this.pictureBoxBoxart.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBoxart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBoxart.Location = new System.Drawing.Point(13, 212);
            this.pictureBoxBoxart.Name = "pictureBoxBoxart";
            this.pictureBoxBoxart.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxBoxart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBoxart.TabIndex = 92;
            this.pictureBoxBoxart.TabStop = false;
            // 
            // FormManageRom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "FormManageRom";
            this.ShowInTaskbar = false;
            this.Text = "Manage Rom";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPagePictures.ResumeLayout(false);
            this.tabPagePictures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Button buttonCopyDBName;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelChangeFileName;
        private System.Windows.Forms.TextBox textBoxRomName;
        private System.Windows.Forms.Label labelChangeRomName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRom;
        private System.Windows.Forms.Button buttonOpenInDB;
        private System.Windows.Forms.Button buttonShowDBInfo;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxYearReleased;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox textBoxDeveloper;
        private System.Windows.Forms.CheckBox checkBoxChangeZippedName;
        private System.Windows.Forms.Button buttonCopyToRom;
        private System.Windows.Forms.Button buttonCopyToFile;
        private System.Windows.Forms.Label labelChooseLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.TabPage tabPagePictures;
        private System.Windows.Forms.CheckBox checkBoxSaveAsJpg;
        private System.Windows.Forms.Button buttonFindGameplayPicture;
        private System.Windows.Forms.TextBox textBoxGameplayPicture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFindTitlePicture;
        private System.Windows.Forms.TextBox textBoxTitlePicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFindBoxartPicture;
        private System.Windows.Forms.TextBox textBoxBoxartPicture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxGameplay;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.PictureBox pictureBoxBoxart;
        private System.Windows.Forms.Button buttonGetRomData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonPlatformJson;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonOverwrite;
        private System.Windows.Forms.RadioButton radioButtonOnlyMissing;
        private System.Windows.Forms.CheckBox checkBoxKeepSuffix;
        private System.Windows.Forms.TextBox textBoxRating;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBoxIdLocked;
        private System.Windows.Forms.Button buttonGetMAMEName;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.ComboBox comboBoxChooseStatus;
        private System.Windows.Forms.Label labelChooseStatus;
        private System.Windows.Forms.ComboBox comboBoxChooseEmulator;
        private System.Windows.Forms.Label labelChooseEmulator;
        private System.Windows.Forms.TextBox textBoxSeries;
        private System.Windows.Forms.Label labelSeries;
    }
}