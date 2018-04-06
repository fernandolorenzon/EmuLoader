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
            this.buttonGetRomData = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCopyDBName = new System.Windows.Forms.Button();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxChangeFileName = new System.Windows.Forms.TextBox();
            this.labelChangeFileName = new System.Windows.Forms.Label();
            this.textBoxChangeRomName = new System.Windows.Forms.TextBox();
            this.labelChangeRomName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRom = new System.Windows.Forms.Label();
            this.buttonSearchInDB = new System.Windows.Forms.Button();
            this.buttonOpenDB = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxYearReleased = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.textBoxDeveloper = new System.Windows.Forms.TextBox();
            this.checkBoxChangeZippedName = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCommand = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxEmulatorExe = new System.Windows.Forms.TextBox();
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
            this.tabPageImages = new System.Windows.Forms.TabPage();
            this.checkBoxSaveAsJpg = new System.Windows.Forms.CheckBox();
            this.buttonFindGameplayImage = new System.Windows.Forms.Button();
            this.textBoxGameplayImage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFindTitleImage = new System.Windows.Forms.Button();
            this.textBoxTitleImage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFindBoxartImage = new System.Windows.Forms.Button();
            this.textBoxBoxartImage = new System.Windows.Forms.TextBox();
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
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPageImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(354, 40);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(377, 20);
            this.textBoxCommand.TabIndex = 22;
            this.toolTip1.SetToolTip(this.textBoxCommand, resources.GetString("textBoxCommand.ToolTip"));
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageImages);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(813, 704);
            this.tabControl.TabIndex = 47;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.buttonGetRomData);
            this.tabPageGeneral.Controls.Add(this.label11);
            this.tabPageGeneral.Controls.Add(this.buttonCopyDBName);
            this.tabPageGeneral.Controls.Add(this.textBoxDBName);
            this.tabPageGeneral.Controls.Add(this.label14);
            this.tabPageGeneral.Controls.Add(this.textBoxPublisher);
            this.tabPageGeneral.Controls.Add(this.label8);
            this.tabPageGeneral.Controls.Add(this.textBoxChangeFileName);
            this.tabPageGeneral.Controls.Add(this.labelChangeFileName);
            this.tabPageGeneral.Controls.Add(this.textBoxChangeRomName);
            this.tabPageGeneral.Controls.Add(this.labelChangeRomName);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.Controls.Add(this.labelRom);
            this.tabPageGeneral.Controls.Add(this.buttonSearchInDB);
            this.tabPageGeneral.Controls.Add(this.buttonOpenDB);
            this.tabPageGeneral.Controls.Add(this.textBoxId);
            this.tabPageGeneral.Controls.Add(this.label13);
            this.tabPageGeneral.Controls.Add(this.textBoxYearReleased);
            this.tabPageGeneral.Controls.Add(this.label12);
            this.tabPageGeneral.Controls.Add(this.textBoxDescription);
            this.tabPageGeneral.Controls.Add(this.Description);
            this.tabPageGeneral.Controls.Add(this.textBoxDeveloper);
            this.tabPageGeneral.Controls.Add(this.checkBoxChangeZippedName);
            this.tabPageGeneral.Controls.Add(this.groupBox1);
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
            this.tabPageGeneral.Size = new System.Drawing.Size(805, 678);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // buttonGetRomData
            // 
            this.buttonGetRomData.Location = new System.Drawing.Point(253, 362);
            this.buttonGetRomData.Name = "buttonGetRomData";
            this.buttonGetRomData.Size = new System.Drawing.Size(110, 68);
            this.buttonGetRomData.TabIndex = 98;
            this.buttonGetRomData.Text = "Get and Overwrite Rom Data from DB";
            this.buttonGetRomData.UseVisualStyleBackColor = true;
            this.buttonGetRomData.Click += new System.EventHandler(this.buttonGetRomData_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(567, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 97;
            this.label11.Text = "Developer";
            // 
            // buttonCopyDBName
            // 
            this.buttonCopyDBName.Location = new System.Drawing.Point(401, 94);
            this.buttonCopyDBName.Name = "buttonCopyDBName";
            this.buttonCopyDBName.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyDBName.TabIndex = 96;
            this.buttonCopyDBName.Text = "<< Copy";
            this.buttonCopyDBName.UseVisualStyleBackColor = true;
            this.buttonCopyDBName.Click += new System.EventHandler(this.buttonCopyDBName_Click);
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(401, 68);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.ReadOnly = true;
            this.textBoxDBName.Size = new System.Drawing.Size(351, 20);
            this.textBoxDBName.TabIndex = 95;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(398, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "TheGamesDB.net Name";
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(401, 218);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(163, 20);
            this.textBoxPublisher.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Publisher";
            // 
            // textBoxChangeFileName
            // 
            this.textBoxChangeFileName.Location = new System.Drawing.Point(194, 68);
            this.textBoxChangeFileName.Name = "textBoxChangeFileName";
            this.textBoxChangeFileName.Size = new System.Drawing.Size(191, 20);
            this.textBoxChangeFileName.TabIndex = 90;
            // 
            // labelChangeFileName
            // 
            this.labelChangeFileName.AutoSize = true;
            this.labelChangeFileName.Location = new System.Drawing.Point(192, 52);
            this.labelChangeFileName.Name = "labelChangeFileName";
            this.labelChangeFileName.Size = new System.Drawing.Size(94, 13);
            this.labelChangeFileName.TabIndex = 89;
            this.labelChangeFileName.Text = "Change File Name";
            // 
            // textBoxChangeRomName
            // 
            this.textBoxChangeRomName.Location = new System.Drawing.Point(21, 68);
            this.textBoxChangeRomName.Name = "textBoxChangeRomName";
            this.textBoxChangeRomName.Size = new System.Drawing.Size(167, 20);
            this.textBoxChangeRomName.TabIndex = 88;
            // 
            // labelChangeRomName
            // 
            this.labelChangeRomName.AutoSize = true;
            this.labelChangeRomName.Location = new System.Drawing.Point(18, 52);
            this.labelChangeRomName.Name = "labelChangeRomName";
            this.labelChangeRomName.Size = new System.Drawing.Size(137, 13);
            this.labelChangeRomName.TabIndex = 87;
            this.labelChangeRomName.Text = "Change Rom Display Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Rom Name";
            // 
            // labelRom
            // 
            this.labelRom.AutoSize = true;
            this.labelRom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRom.Location = new System.Drawing.Point(18, 23);
            this.labelRom.Name = "labelRom";
            this.labelRom.Size = new System.Drawing.Size(52, 17);
            this.labelRom.TabIndex = 85;
            this.labelRom.Text = "label1";
            // 
            // buttonSearchInDB
            // 
            this.buttonSearchInDB.Location = new System.Drawing.Point(137, 362);
            this.buttonSearchInDB.Name = "buttonSearchInDB";
            this.buttonSearchInDB.Size = new System.Drawing.Size(110, 68);
            this.buttonSearchInDB.TabIndex = 83;
            this.buttonSearchInDB.Text = "Check in TheGamesDB";
            this.buttonSearchInDB.UseVisualStyleBackColor = true;
            this.buttonSearchInDB.Click += new System.EventHandler(this.buttonSearchInDB_Click);
            // 
            // buttonOpenDB
            // 
            this.buttonOpenDB.Location = new System.Drawing.Point(21, 362);
            this.buttonOpenDB.Name = "buttonOpenDB";
            this.buttonOpenDB.Size = new System.Drawing.Size(110, 68);
            this.buttonOpenDB.TabIndex = 82;
            this.buttonOpenDB.Text = "Show TheGamesDB entry";
            this.buttonOpenDB.UseVisualStyleBackColor = true;
            this.buttonOpenDB.Click += new System.EventHandler(this.buttonOpenDB_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(401, 176);
            this.textBoxId.MaxLength = 10;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(163, 20);
            this.textBoxId.TabIndex = 81;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(398, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "TheGamesDB.net Id";
            // 
            // textBoxYearReleased
            // 
            this.textBoxYearReleased.Location = new System.Drawing.Point(570, 176);
            this.textBoxYearReleased.MaxLength = 4;
            this.textBoxYearReleased.Name = "textBoxYearReleased";
            this.textBoxYearReleased.Size = new System.Drawing.Size(189, 20);
            this.textBoxYearReleased.TabIndex = 79;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(567, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Year Released";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(401, 257);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(358, 173);
            this.textBoxDescription.TabIndex = 77;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(398, 241);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 76;
            this.Description.Text = "Description";
            // 
            // textBoxDeveloper
            // 
            this.textBoxDeveloper.Location = new System.Drawing.Point(570, 218);
            this.textBoxDeveloper.Name = "textBoxDeveloper";
            this.textBoxDeveloper.Size = new System.Drawing.Size(189, 20);
            this.textBoxDeveloper.TabIndex = 75;
            // 
            // checkBoxChangeZippedName
            // 
            this.checkBoxChangeZippedName.AutoSize = true;
            this.checkBoxChangeZippedName.Checked = true;
            this.checkBoxChangeZippedName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChangeZippedName.Location = new System.Drawing.Point(195, 123);
            this.checkBoxChangeZippedName.Name = "checkBoxChangeZippedName";
            this.checkBoxChangeZippedName.Size = new System.Drawing.Size(158, 17);
            this.checkBoxChangeZippedName.TabIndex = 73;
            this.checkBoxChangeZippedName.Text = "Change rom name inside zip";
            this.checkBoxChangeZippedName.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxCommand);
            this.groupBox1.Controls.Add(this.labelCommand);
            this.groupBox1.Controls.Add(this.buttonPath);
            this.groupBox1.Controls.Add(this.labelPath);
            this.groupBox1.Controls.Add(this.textBoxEmulatorExe);
            this.groupBox1.Location = new System.Drawing.Point(21, 451);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 108);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Override emulator config";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Both fields need to be filled to override";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "If empty, will use the platform emulator setting";
            // 
            // labelCommand
            // 
            this.labelCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(351, 18);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 21;
            this.labelCommand.Text = "Command";
            // 
            // buttonPath
            // 
            this.buttonPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPath.Location = new System.Drawing.Point(313, 38);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(36, 23);
            this.buttonPath.TabIndex = 18;
            this.buttonPath.Text = "...";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // labelPath
            // 
            this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(6, 18);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(69, 13);
            this.labelPath.TabIndex = 20;
            this.labelPath.Text = "Emulator Exe";
            // 
            // textBoxEmulatorExe
            // 
            this.textBoxEmulatorExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmulatorExe.Location = new System.Drawing.Point(10, 40);
            this.textBoxEmulatorExe.Name = "textBoxEmulatorExe";
            this.textBoxEmulatorExe.Size = new System.Drawing.Size(297, 20);
            this.textBoxEmulatorExe.TabIndex = 19;
            // 
            // buttonCopyToRom
            // 
            this.buttonCopyToRom.Location = new System.Drawing.Point(194, 94);
            this.buttonCopyToRom.Name = "buttonCopyToRom";
            this.buttonCopyToRom.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToRom.TabIndex = 71;
            this.buttonCopyToRom.Text = "<< Copy";
            this.buttonCopyToRom.UseVisualStyleBackColor = true;
            this.buttonCopyToRom.Click += new System.EventHandler(this.buttonCopyToRom_Click);
            // 
            // buttonCopyToFile
            // 
            this.buttonCopyToFile.Location = new System.Drawing.Point(113, 94);
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
            this.labelChooseLabel.Location = new System.Drawing.Point(21, 197);
            this.labelChooseLabel.Name = "labelChooseLabel";
            this.labelChooseLabel.Size = new System.Drawing.Size(77, 13);
            this.labelChooseLabel.TabIndex = 53;
            this.labelChooseLabel.Text = "Choose Labels";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCheck,
            this.columnName,
            this.columnColor});
            this.dataGridView.Location = new System.Drawing.Point(24, 213);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(361, 139);
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
            this.columnName.ReadOnly = true;
            // 
            // columnColor
            // 
            this.columnColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnColor.FillWeight = 60F;
            this.columnColor.HeaderText = "Color";
            this.columnColor.Name = "columnColor";
            this.columnColor.ReadOnly = true;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(195, 171);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(190, 21);
            this.comboBoxGenre.TabIndex = 51;
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(192, 155);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(75, 13);
            this.labelGenre.TabIndex = 50;
            this.labelGenre.Text = "Choose Genre";
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(21, 171);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(167, 21);
            this.comboBoxPlatform.TabIndex = 49;
            // 
            // labelEmulator
            // 
            this.labelEmulator.AutoSize = true;
            this.labelEmulator.Location = new System.Drawing.Point(18, 155);
            this.labelEmulator.Name = "labelEmulator";
            this.labelEmulator.Size = new System.Drawing.Size(87, 13);
            this.labelEmulator.TabIndex = 48;
            this.labelEmulator.Text = "Choose Emulator";
            // 
            // tabPageImages
            // 
            this.tabPageImages.Controls.Add(this.checkBoxSaveAsJpg);
            this.tabPageImages.Controls.Add(this.buttonFindGameplayImage);
            this.tabPageImages.Controls.Add(this.textBoxGameplayImage);
            this.tabPageImages.Controls.Add(this.label3);
            this.tabPageImages.Controls.Add(this.buttonFindTitleImage);
            this.tabPageImages.Controls.Add(this.textBoxTitleImage);
            this.tabPageImages.Controls.Add(this.label2);
            this.tabPageImages.Controls.Add(this.buttonFindBoxartImage);
            this.tabPageImages.Controls.Add(this.textBoxBoxartImage);
            this.tabPageImages.Controls.Add(this.label4);
            this.tabPageImages.Controls.Add(this.label5);
            this.tabPageImages.Controls.Add(this.label7);
            this.tabPageImages.Controls.Add(this.label6);
            this.tabPageImages.Controls.Add(this.pictureBoxGameplay);
            this.tabPageImages.Controls.Add(this.pictureBoxTitle);
            this.tabPageImages.Controls.Add(this.pictureBoxBoxart);
            this.tabPageImages.Location = new System.Drawing.Point(4, 22);
            this.tabPageImages.Name = "tabPageImages";
            this.tabPageImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImages.Size = new System.Drawing.Size(805, 678);
            this.tabPageImages.TabIndex = 1;
            this.tabPageImages.Text = "Images";
            this.tabPageImages.UseVisualStyleBackColor = true;
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
            // buttonFindGameplayImage
            // 
            this.buttonFindGameplayImage.Location = new System.Drawing.Point(367, 107);
            this.buttonFindGameplayImage.Name = "buttonFindGameplayImage";
            this.buttonFindGameplayImage.Size = new System.Drawing.Size(75, 23);
            this.buttonFindGameplayImage.TabIndex = 106;
            this.buttonFindGameplayImage.Text = "Find Image";
            this.buttonFindGameplayImage.UseVisualStyleBackColor = true;
            this.buttonFindGameplayImage.Click += new System.EventHandler(this.buttonFindGameplayImage_Click);
            // 
            // textBoxGameplayImage
            // 
            this.textBoxGameplayImage.Location = new System.Drawing.Point(11, 110);
            this.textBoxGameplayImage.Name = "textBoxGameplayImage";
            this.textBoxGameplayImage.Size = new System.Drawing.Size(350, 20);
            this.textBoxGameplayImage.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Choose Gameplay Image";
            // 
            // buttonFindTitleImage
            // 
            this.buttonFindTitleImage.Location = new System.Drawing.Point(367, 69);
            this.buttonFindTitleImage.Name = "buttonFindTitleImage";
            this.buttonFindTitleImage.Size = new System.Drawing.Size(75, 23);
            this.buttonFindTitleImage.TabIndex = 103;
            this.buttonFindTitleImage.Text = "Find Image";
            this.buttonFindTitleImage.UseVisualStyleBackColor = true;
            this.buttonFindTitleImage.Click += new System.EventHandler(this.buttonFindTitleImage_Click);
            // 
            // textBoxTitleImage
            // 
            this.textBoxTitleImage.Location = new System.Drawing.Point(11, 71);
            this.textBoxTitleImage.Name = "textBoxTitleImage";
            this.textBoxTitleImage.Size = new System.Drawing.Size(350, 20);
            this.textBoxTitleImage.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Choose Title Image";
            // 
            // buttonFindBoxartImage
            // 
            this.buttonFindBoxartImage.Location = new System.Drawing.Point(367, 30);
            this.buttonFindBoxartImage.Name = "buttonFindBoxartImage";
            this.buttonFindBoxartImage.Size = new System.Drawing.Size(75, 23);
            this.buttonFindBoxartImage.TabIndex = 100;
            this.buttonFindBoxartImage.Text = "Find Image";
            this.buttonFindBoxartImage.UseVisualStyleBackColor = true;
            this.buttonFindBoxartImage.Click += new System.EventHandler(this.buttonFindBoxartImage_Click);
            // 
            // textBoxBoxartImage
            // 
            this.textBoxBoxartImage.Location = new System.Drawing.Point(11, 32);
            this.textBoxBoxartImage.Name = "textBoxBoxartImage";
            this.textBoxBoxartImage.Size = new System.Drawing.Size(350, 20);
            this.textBoxBoxartImage.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Choose Box Art Image";
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 649);
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
            // FormManageRom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 704);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl);
            this.Name = "FormManageRom";
            this.ShowInTaskbar = false;
            this.Text = "Manage Rom";
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPageImages.ResumeLayout(false);
            this.tabPageImages.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxChangeFileName;
        private System.Windows.Forms.Label labelChangeFileName;
        private System.Windows.Forms.TextBox textBoxChangeRomName;
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
        private System.Windows.Forms.TabPage tabPageImages;
        private System.Windows.Forms.CheckBox checkBoxSaveAsJpg;
        private System.Windows.Forms.Button buttonFindGameplayImage;
        private System.Windows.Forms.TextBox textBoxGameplayImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFindTitleImage;
        private System.Windows.Forms.TextBox textBoxTitleImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFindBoxartImage;
        private System.Windows.Forms.TextBox textBoxBoxartImage;
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
    }
}