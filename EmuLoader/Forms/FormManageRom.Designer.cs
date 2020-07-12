namespace EmuLoader.Forms
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
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxIdLocked = new System.Windows.Forms.CheckBox();
            this.textBoxRating = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBoxKeepSuffix = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.labelPlatform = new System.Windows.Forms.Label();
            this.buttonSearchInDB = new System.Windows.Forms.Button();
            this.buttonCheckList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseAlternate = new System.Windows.Forms.CheckBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCommand = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxEmulatorExe = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonOverwrite = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyMissing = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonOpenDB = new System.Windows.Forms.Button();
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
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.labelEmulator = new System.Windows.Forms.Label();
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGetMAMEName = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPagePictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(355, 37);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(377, 20);
            this.textBoxCommand.TabIndex = 22;
            this.toolTip1.SetToolTip(this.textBoxCommand, resources.GetString("textBoxCommand.ToolTip"));
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPagePictures);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(813, 645);
            this.tabControl.TabIndex = 47;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.buttonGetMAMEName);
            this.tabPageGeneral.Controls.Add(this.checkBoxIdLocked);
            this.tabPageGeneral.Controls.Add(this.textBoxRating);
            this.tabPageGeneral.Controls.Add(this.label16);
            this.tabPageGeneral.Controls.Add(this.checkBoxKeepSuffix);
            this.tabPageGeneral.Controls.Add(this.panel2);
            this.tabPageGeneral.Controls.Add(this.groupBox1);
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
            this.tabPageGeneral.Controls.Add(this.comboBoxPlatform);
            this.tabPageGeneral.Controls.Add(this.labelEmulator);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(805, 619);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
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
            this.panel2.Controls.Add(this.buttonSearchInDB);
            this.panel2.Controls.Add(this.buttonCheckList);
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
            // buttonSearchInDB
            // 
            this.buttonSearchInDB.Location = new System.Drawing.Point(7, 80);
            this.buttonSearchInDB.Name = "buttonSearchInDB";
            this.buttonSearchInDB.Size = new System.Drawing.Size(83, 61);
            this.buttonSearchInDB.TabIndex = 83;
            this.buttonSearchInDB.Text = "Check in TheGamesDB";
            this.buttonSearchInDB.UseVisualStyleBackColor = true;
            this.buttonSearchInDB.Click += new System.EventHandler(this.buttonSearchInDB_Click);
            // 
            // buttonCheckList
            // 
            this.buttonCheckList.Location = new System.Drawing.Point(99, 80);
            this.buttonCheckList.Name = "buttonCheckList";
            this.buttonCheckList.Size = new System.Drawing.Size(83, 61);
            this.buttonCheckList.TabIndex = 99;
            this.buttonCheckList.Text = "Check Platform Games List";
            this.buttonCheckList.UseVisualStyleBackColor = true;
            this.buttonCheckList.Click += new System.EventHandler(this.buttonCheckList_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUseAlternate);
            this.groupBox1.Controls.Add(this.buttonHelp);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxCommand);
            this.groupBox1.Controls.Add(this.labelCommand);
            this.groupBox1.Controls.Add(this.buttonPath);
            this.groupBox1.Controls.Add(this.labelPath);
            this.groupBox1.Controls.Add(this.textBoxEmulatorExe);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 512);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 104);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Override emulator config";
            // 
            // checkBoxUseAlternate
            // 
            this.checkBoxUseAlternate.AutoSize = true;
            this.checkBoxUseAlternate.Location = new System.Drawing.Point(355, 70);
            this.checkBoxUseAlternate.Name = "checkBoxUseAlternate";
            this.checkBoxUseAlternate.Size = new System.Drawing.Size(198, 17);
            this.checkBoxUseAlternate.TabIndex = 27;
            this.checkBoxUseAlternate.Text = "Use Alternate Emulator from Platform";
            this.checkBoxUseAlternate.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonHelp.ForeColor = System.Drawing.Color.Black;
            this.buttonHelp.Location = new System.Drawing.Point(738, 35);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonHelp.TabIndex = 26;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Both fields need to be filled to override";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "If empty, will use the platform emulator setting";
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(352, 15);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 21;
            this.labelCommand.Text = "Command";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(313, 35);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(36, 23);
            this.buttonPath.TabIndex = 18;
            this.buttonPath.Text = "...";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(6, 15);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(69, 13);
            this.labelPath.TabIndex = 20;
            this.labelPath.Text = "Emulator Exe";
            // 
            // textBoxEmulatorExe
            // 
            this.textBoxEmulatorExe.Location = new System.Drawing.Point(10, 37);
            this.textBoxEmulatorExe.Name = "textBoxEmulatorExe";
            this.textBoxEmulatorExe.Size = new System.Drawing.Size(297, 20);
            this.textBoxEmulatorExe.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonOverwrite);
            this.panel1.Controls.Add(this.radioButtonOnlyMissing);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.buttonOpenDB);
            this.panel1.Controls.Add(this.buttonGetRomData);
            this.panel1.Location = new System.Drawing.Point(401, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 150);
            this.panel1.TabIndex = 100;
            // 
            // radioButtonOverwrite
            // 
            this.radioButtonOverwrite.AutoSize = true;
            this.radioButtonOverwrite.Checked = true;
            this.radioButtonOverwrite.Location = new System.Drawing.Point(153, 74);
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
            this.radioButtonOnlyMissing.Location = new System.Drawing.Point(153, 97);
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
            this.textBoxId.Size = new System.Drawing.Size(141, 20);
            this.textBoxId.TabIndex = 81;
            // 
            // buttonOpenDB
            // 
            this.buttonOpenDB.Location = new System.Drawing.Point(272, 3);
            this.buttonOpenDB.Name = "buttonOpenDB";
            this.buttonOpenDB.Size = new System.Drawing.Size(103, 65);
            this.buttonOpenDB.TabIndex = 82;
            this.buttonOpenDB.Text = "Show TheGamesDB Info";
            this.buttonOpenDB.UseVisualStyleBackColor = true;
            this.buttonOpenDB.Click += new System.EventHandler(this.buttonOpenDB_Click);
            // 
            // buttonGetRomData
            // 
            this.buttonGetRomData.Location = new System.Drawing.Point(153, 3);
            this.buttonGetRomData.Name = "buttonGetRomData";
            this.buttonGetRomData.Size = new System.Drawing.Size(113, 65);
            this.buttonGetRomData.TabIndex = 98;
            this.buttonGetRomData.Text = "Get  Rom Data Online";
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
            this.textBoxFileName.Location = new System.Drawing.Point(179, 180);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(204, 20);
            this.textBoxFileName.TabIndex = 90;
            // 
            // labelChangeFileName
            // 
            this.labelChangeFileName.AutoSize = true;
            this.labelChangeFileName.Location = new System.Drawing.Point(176, 164);
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
            this.textBoxRomName.Size = new System.Drawing.Size(167, 20);
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
            this.checkBoxChangeZippedName.Location = new System.Drawing.Point(179, 235);
            this.checkBoxChangeZippedName.Name = "checkBoxChangeZippedName";
            this.checkBoxChangeZippedName.Size = new System.Drawing.Size(158, 17);
            this.checkBoxChangeZippedName.TabIndex = 73;
            this.checkBoxChangeZippedName.Text = "Change rom name inside zip";
            this.checkBoxChangeZippedName.UseVisualStyleBackColor = true;
            // 
            // buttonCopyToRom
            // 
            this.buttonCopyToRom.Location = new System.Drawing.Point(179, 206);
            this.buttonCopyToRom.Name = "buttonCopyToRom";
            this.buttonCopyToRom.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToRom.TabIndex = 71;
            this.buttonCopyToRom.Text = "<< Copy";
            this.buttonCopyToRom.UseVisualStyleBackColor = true;
            this.buttonCopyToRom.Click += new System.EventHandler(this.buttonCopyToRom_Click);
            // 
            // buttonCopyToFile
            // 
            this.buttonCopyToFile.Location = new System.Drawing.Point(98, 206);
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
            this.comboBoxGenre.Location = new System.Drawing.Point(179, 304);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(204, 21);
            this.comboBoxGenre.TabIndex = 51;
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(176, 288);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(75, 13);
            this.labelGenre.TabIndex = 50;
            this.labelGenre.Text = "Choose Genre";
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(6, 304);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(167, 21);
            this.comboBoxPlatform.TabIndex = 49;
            // 
            // labelEmulator
            // 
            this.labelEmulator.AutoSize = true;
            this.labelEmulator.Location = new System.Drawing.Point(3, 288);
            this.labelEmulator.Name = "labelEmulator";
            this.labelEmulator.Size = new System.Drawing.Size(87, 13);
            this.labelEmulator.TabIndex = 48;
            this.labelEmulator.Text = "Choose Emulator";
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
            this.tabPagePictures.Size = new System.Drawing.Size(805, 619);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 645);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(813, 55);
            this.flowLayoutPanel1.TabIndex = 48;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 48);
            this.buttonSave.TabIndex = 58;
            this.buttonSave.Text = "Save and Close";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(109, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 48);
            this.buttonCancel.TabIndex = 59;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            // FormManageRom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormManageRom";
            this.ShowInTaskbar = false;
            this.Text = "Manage Rom";
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPagePictures.ResumeLayout(false);
            this.tabPagePictures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonSearchInDB;
        private System.Windows.Forms.Button buttonOpenDB;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxYearReleased;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox textBoxDeveloper;
        private System.Windows.Forms.CheckBox checkBoxChangeZippedName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxEmulatorExe;
        private System.Windows.Forms.Button buttonCopyToRom;
        private System.Windows.Forms.Button buttonCopyToFile;
        private System.Windows.Forms.Label labelChooseLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColor;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.Label labelEmulator;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonGetRomData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonCheckList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonOverwrite;
        private System.Windows.Forms.RadioButton radioButtonOnlyMissing;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.CheckBox checkBoxKeepSuffix;
        private System.Windows.Forms.TextBox textBoxRating;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBoxUseAlternate;
        private System.Windows.Forms.CheckBox checkBoxIdLocked;
        private System.Windows.Forms.Button buttonGetMAMEName;
    }
}