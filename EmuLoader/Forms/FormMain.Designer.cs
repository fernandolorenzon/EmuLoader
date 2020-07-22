namespace EmuLoader.Forms
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonRomOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRomRemoveRom = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRomDeleteRomFromDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEditRom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoriteUnfavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePlatformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeGenreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedRomsOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerFilter = new System.Windows.Forms.Timer(this.components);
            this.labelTotalRomsCount = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.romsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRomFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRomDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRomPackInDirectoryStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeInvalidEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchAddPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchRemovePicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.platformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPathColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRomDBNameColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlatformColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGenreColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLabelsColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDeveloperColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPublisherColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showYearReleasedColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRatingColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBoxArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGameplayArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlatformsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFileExistsAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIncorrectPlatformAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMissingPicsAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.romDataOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncRomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeRomDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncUsingRetropieXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.openAppFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewPlatforms = new System.Windows.Forms.DataGridView();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.columnPlatforms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxFavorite = new System.Windows.Forms.CheckBox();
            this.buttonRescan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDeveloper = new System.Windows.Forms.ComboBox();
            this.labelYearReleased = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPublisher = new System.Windows.Forms.ComboBox();
            this.comboBoxYearReleased = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelGenre = new System.Windows.Forms.Label();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.labelFilterRom = new System.Windows.Forms.Label();
            this.labelLabels = new System.Windows.Forms.Label();
            this.labelEmulatorFilter = new System.Windows.Forms.Label();
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.comboBoxLabels = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnIconMain = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnFileExists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIncorrectPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMissingPics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRomDBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRomPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLabels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDeveloper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnYearReleased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelSelectedRoms = new System.Windows.Forms.Label();
            this.labelSelectedRomsCount = new System.Windows.Forms.Label();
            this.flowLayoutPanelPictures = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxBoxart = new System.Windows.Forms.PictureBox();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.pictureBoxGameplay = new System.Windows.Forms.PictureBox();
            this.contextMenuStripEditRom.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatforms)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.flowLayoutPanelPictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRomOpenFolder
            // 
            this.buttonRomOpenFolder.Name = "buttonRomOpenFolder";
            this.buttonRomOpenFolder.Size = new System.Drawing.Size(225, 22);
            this.buttonRomOpenFolder.Text = "Open Folder";
            this.buttonRomOpenFolder.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // buttonRomRemoveRom
            // 
            this.buttonRomRemoveRom.Name = "buttonRomRemoveRom";
            this.buttonRomRemoveRom.Size = new System.Drawing.Size(225, 22);
            this.buttonRomRemoveRom.Text = "Remove Rom Entry";
            this.buttonRomRemoveRom.Click += new System.EventHandler(this.removeRomEntryToolStripMenuItem_Click);
            // 
            // buttonRomDeleteRomFromDisk
            // 
            this.buttonRomDeleteRomFromDisk.Name = "buttonRomDeleteRomFromDisk";
            this.buttonRomDeleteRomFromDisk.Size = new System.Drawing.Size(225, 22);
            this.buttonRomDeleteRomFromDisk.Text = "Delete Rom to Recycle bin";
            this.buttonRomDeleteRomFromDisk.Click += new System.EventHandler(this.deleteRomToolStripMenuItem_Click);
            // 
            // contextMenuStripEditRom
            // 
            this.contextMenuStripEditRom.Font = new System.Drawing.Font("Verdana", 8F);
            this.contextMenuStripEditRom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRomOpenFolder,
            this.favoriteUnfavoriteToolStripMenuItem,
            this.buttonRomRemoveRom,
            this.buttonRomDeleteRomFromDisk,
            this.changePlatformToolStripMenuItem,
            this.changeGenreToolStripMenuItem,
            this.changeLabelsToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.contextMenuStripEditRom.Name = "contextMenuStripEditRom";
            this.contextMenuStripEditRom.OwnerItem = this.selectedRomsOptionsToolStripMenuItem;
            this.contextMenuStripEditRom.Size = new System.Drawing.Size(226, 180);
            // 
            // favoriteUnfavoriteToolStripMenuItem
            // 
            this.favoriteUnfavoriteToolStripMenuItem.Name = "favoriteUnfavoriteToolStripMenuItem";
            this.favoriteUnfavoriteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.favoriteUnfavoriteToolStripMenuItem.Text = "Favorite/Unfavorite";
            this.favoriteUnfavoriteToolStripMenuItem.Click += new System.EventHandler(this.favoriteUnfavoriteToolStripMenuItem_Click);
            // 
            // changePlatformToolStripMenuItem
            // 
            this.changePlatformToolStripMenuItem.Name = "changePlatformToolStripMenuItem";
            this.changePlatformToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changePlatformToolStripMenuItem.Text = "Change Platform";
            this.changePlatformToolStripMenuItem.Click += new System.EventHandler(this.changePlatformToolStripMenuItem_Click);
            // 
            // changeGenreToolStripMenuItem
            // 
            this.changeGenreToolStripMenuItem.Name = "changeGenreToolStripMenuItem";
            this.changeGenreToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changeGenreToolStripMenuItem.Text = "Change Genre";
            this.changeGenreToolStripMenuItem.Click += new System.EventHandler(this.changeGenreToolStripMenuItem_Click);
            // 
            // changeLabelsToolStripMenuItem
            // 
            this.changeLabelsToolStripMenuItem.Name = "changeLabelsToolStripMenuItem";
            this.changeLabelsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changeLabelsToolStripMenuItem.Text = "Change Labels";
            this.changeLabelsToolStripMenuItem.Click += new System.EventHandler(this.changeLabelsToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.openFileToolStripMenuItem.Text = "Open Rom File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // selectedRomsOptionsToolStripMenuItem
            // 
            this.selectedRomsOptionsToolStripMenuItem.DropDown = this.contextMenuStripEditRom;
            this.selectedRomsOptionsToolStripMenuItem.Enabled = false;
            this.selectedRomsOptionsToolStripMenuItem.Name = "selectedRomsOptionsToolStripMenuItem";
            this.selectedRomsOptionsToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.selectedRomsOptionsToolStripMenuItem.Text = "&Quick Actions";
            // 
            // timerFilter
            // 
            this.timerFilter.Interval = 1500;
            this.timerFilter.Tick += new System.EventHandler(this.timerFilter_Tick);
            // 
            // labelTotalRomsCount
            // 
            this.labelTotalRomsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalRomsCount.AutoSize = true;
            this.labelTotalRomsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalRomsCount.Location = new System.Drawing.Point(75, 7);
            this.labelTotalRomsCount.Name = "labelTotalRomsCount";
            this.labelTotalRomsCount.Size = new System.Drawing.Size(14, 13);
            this.labelTotalRomsCount.TabIndex = 15;
            this.labelTotalRomsCount.Text = "0";
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(4, 7);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(75, 13);
            this.labelTotal.TabIndex = 14;
            this.labelTotal.Text = "Total Roms:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.romsToolStripMenuItem,
            this.manageRomToolStripMenuItem,
            this.selectedRomsOptionsToolStripMenuItem,
            this.addEditDeleteToolStripMenuItem,
            this.columnsToolStripMenuItem,
            this.romDataOptionsToolStripMenuItem,
            this.toolStripMenuItemSettings,
            this.openAppFolderToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(638, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // romsToolStripMenuItem
            // 
            this.romsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRomFileToolStripMenuItem,
            this.addRomDirectoryToolStripMenuItem,
            this.addRomPackInDirectoryStructureToolStripMenuItem,
            this.removeInvalidEntriesToolStripMenuItem,
            this.batchAddPicturesToolStripMenuItem,
            this.batchRemovePicturesToolStripMenuItem,
            this.auditToolStripMenuItem});
            this.romsToolStripMenuItem.Name = "romsToolStripMenuItem";
            this.romsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.romsToolStripMenuItem.Text = "&Roms";
            // 
            // addRomFileToolStripMenuItem
            // 
            this.addRomFileToolStripMenuItem.Name = "addRomFileToolStripMenuItem";
            this.addRomFileToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.addRomFileToolStripMenuItem.Text = "Add Rom Files";
            this.addRomFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonAddRom_Click);
            // 
            // addRomDirectoryToolStripMenuItem
            // 
            this.addRomDirectoryToolStripMenuItem.Name = "addRomDirectoryToolStripMenuItem";
            this.addRomDirectoryToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.addRomDirectoryToolStripMenuItem.Text = "Add Rom Directory";
            this.addRomDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addRomDirectoryToolStripMenuItem_Click);
            // 
            // addRomPackInDirectoryStructureToolStripMenuItem
            // 
            this.addRomPackInDirectoryStructureToolStripMenuItem.Name = "addRomPackInDirectoryStructureToolStripMenuItem";
            this.addRomPackInDirectoryStructureToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.addRomPackInDirectoryStructureToolStripMenuItem.Text = "Add RomPack in Directory Structure";
            this.addRomPackInDirectoryStructureToolStripMenuItem.Click += new System.EventHandler(this.addRomPackInDirectoryStructureToolStripMenuItem_Click);
            // 
            // removeInvalidEntriesToolStripMenuItem
            // 
            this.removeInvalidEntriesToolStripMenuItem.Name = "removeInvalidEntriesToolStripMenuItem";
            this.removeInvalidEntriesToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.removeInvalidEntriesToolStripMenuItem.Text = "Remove Invalid Rom Entries";
            this.removeInvalidEntriesToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRemoveInvalid_Click);
            // 
            // batchAddPicturesToolStripMenuItem
            // 
            this.batchAddPicturesToolStripMenuItem.Name = "batchAddPicturesToolStripMenuItem";
            this.batchAddPicturesToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.batchAddPicturesToolStripMenuItem.Text = "Batch Add Pictures";
            this.batchAddPicturesToolStripMenuItem.Click += new System.EventHandler(this.batchAddPicturesToolStripMenuItem_Click);
            // 
            // batchRemovePicturesToolStripMenuItem
            // 
            this.batchRemovePicturesToolStripMenuItem.Name = "batchRemovePicturesToolStripMenuItem";
            this.batchRemovePicturesToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.batchRemovePicturesToolStripMenuItem.Text = "Batch Remove Pictures";
            this.batchRemovePicturesToolStripMenuItem.Click += new System.EventHandler(this.batchRemovePicturesToolStripMenuItem_Click);
            // 
            // auditToolStripMenuItem
            // 
            this.auditToolStripMenuItem.Name = "auditToolStripMenuItem";
            this.auditToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.auditToolStripMenuItem.Text = "Audit";
            this.auditToolStripMenuItem.Click += new System.EventHandler(this.auditToolStripMenuItem_Click);
            // 
            // manageRomToolStripMenuItem
            // 
            this.manageRomToolStripMenuItem.Enabled = false;
            this.manageRomToolStripMenuItem.Name = "manageRomToolStripMenuItem";
            this.manageRomToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.manageRomToolStripMenuItem.Text = "&Edit Rom";
            this.manageRomToolStripMenuItem.Click += new System.EventHandler(this.manageRomToolStripMenuItem_Click);
            // 
            // addEditDeleteToolStripMenuItem
            // 
            this.addEditDeleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.platformsToolStripMenuItem,
            this.genresToolStripMenuItem,
            this.labelsToolStripMenuItem});
            this.addEditDeleteToolStripMenuItem.Name = "addEditDeleteToolStripMenuItem";
            this.addEditDeleteToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.addEditDeleteToolStripMenuItem.Text = "&Add/Edit/Delete";
            // 
            // platformsToolStripMenuItem
            // 
            this.platformsToolStripMenuItem.Name = "platformsToolStripMenuItem";
            this.platformsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.platformsToolStripMenuItem.Text = "Platforms";
            this.platformsToolStripMenuItem.Click += new System.EventHandler(this.managePlatformToolStripButton_Click);
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.genresToolStripMenuItem.Text = "Genres";
            this.genresToolStripMenuItem.Click += new System.EventHandler(this.manageGenreToolStripMenuItem_Click);
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.labelsToolStripMenuItem.Text = "Labels";
            this.labelsToolStripMenuItem.Click += new System.EventHandler(this.manageLabelToolStripButton_Click);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPathColumnToolStripMenuItem,
            this.showFilenameToolStripMenuItem,
            this.showRomDBNameColumnToolStripMenuItem,
            this.showPlatformColumnToolStripMenuItem,
            this.showGenreColumnToolStripMenuItem,
            this.showLabelsColumnToolStripMenuItem,
            this.showDeveloperColumnToolStripMenuItem,
            this.showPublisherColumnToolStripMenuItem,
            this.showYearReleasedColumnToolStripMenuItem,
            this.showRatingColumnToolStripMenuItem,
            this.showBoxArtToolStripMenuItem,
            this.showTitleToolStripMenuItem,
            this.showGameplayArtToolStripMenuItem,
            this.showPlatformsListToolStripMenuItem,
            this.showFileExistsAuditToolStripMenuItem,
            this.showIncorrectPlatformAuditToolStripMenuItem,
            this.showMissingPicsAuditToolStripMenuItem});
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.columnsToolStripMenuItem.Text = "&Visibility";
            // 
            // showPathColumnToolStripMenuItem
            // 
            this.showPathColumnToolStripMenuItem.Checked = true;
            this.showPathColumnToolStripMenuItem.CheckOnClick = true;
            this.showPathColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPathColumnToolStripMenuItem.Name = "showPathColumnToolStripMenuItem";
            this.showPathColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showPathColumnToolStripMenuItem.Text = "Show Path Column";
            this.showPathColumnToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemShowPathColumn_CheckedChanged);
            // 
            // showFilenameToolStripMenuItem
            // 
            this.showFilenameToolStripMenuItem.Checked = true;
            this.showFilenameToolStripMenuItem.CheckOnClick = true;
            this.showFilenameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFilenameToolStripMenuItem.Name = "showFilenameToolStripMenuItem";
            this.showFilenameToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showFilenameToolStripMenuItem.Text = "Show Filename Column";
            this.showFilenameToolStripMenuItem.Click += new System.EventHandler(this.showFilenameToolStripMenuItem_Click);
            // 
            // showRomDBNameColumnToolStripMenuItem
            // 
            this.showRomDBNameColumnToolStripMenuItem.Checked = true;
            this.showRomDBNameColumnToolStripMenuItem.CheckOnClick = true;
            this.showRomDBNameColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRomDBNameColumnToolStripMenuItem.Name = "showRomDBNameColumnToolStripMenuItem";
            this.showRomDBNameColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showRomDBNameColumnToolStripMenuItem.Text = "Show DB Rom Name Column";
            this.showRomDBNameColumnToolStripMenuItem.Click += new System.EventHandler(this.showRomDBNameColumnToolStripMenuItem_Click);
            // 
            // showPlatformColumnToolStripMenuItem
            // 
            this.showPlatformColumnToolStripMenuItem.Checked = true;
            this.showPlatformColumnToolStripMenuItem.CheckOnClick = true;
            this.showPlatformColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPlatformColumnToolStripMenuItem.Name = "showPlatformColumnToolStripMenuItem";
            this.showPlatformColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showPlatformColumnToolStripMenuItem.Text = "Show Emulator Column";
            this.showPlatformColumnToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemShowPlatformColumn_CheckedChanged);
            // 
            // showGenreColumnToolStripMenuItem
            // 
            this.showGenreColumnToolStripMenuItem.Checked = true;
            this.showGenreColumnToolStripMenuItem.CheckOnClick = true;
            this.showGenreColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGenreColumnToolStripMenuItem.Name = "showGenreColumnToolStripMenuItem";
            this.showGenreColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showGenreColumnToolStripMenuItem.Text = "Show Genre Column";
            this.showGenreColumnToolStripMenuItem.Click += new System.EventHandler(this.showGenreColumnToolStripMenuItem_Click);
            // 
            // showLabelsColumnToolStripMenuItem
            // 
            this.showLabelsColumnToolStripMenuItem.Checked = true;
            this.showLabelsColumnToolStripMenuItem.CheckOnClick = true;
            this.showLabelsColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLabelsColumnToolStripMenuItem.Name = "showLabelsColumnToolStripMenuItem";
            this.showLabelsColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showLabelsColumnToolStripMenuItem.Text = "Show Labels Column";
            this.showLabelsColumnToolStripMenuItem.Click += new System.EventHandler(this.showLabelsColumnToolStripMenuItem_Click);
            // 
            // showDeveloperColumnToolStripMenuItem
            // 
            this.showDeveloperColumnToolStripMenuItem.Checked = true;
            this.showDeveloperColumnToolStripMenuItem.CheckOnClick = true;
            this.showDeveloperColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDeveloperColumnToolStripMenuItem.Name = "showDeveloperColumnToolStripMenuItem";
            this.showDeveloperColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showDeveloperColumnToolStripMenuItem.Text = "Show Developer Column";
            this.showDeveloperColumnToolStripMenuItem.Click += new System.EventHandler(this.showDeveloperColumnToolStripMenuItem_Click);
            // 
            // showPublisherColumnToolStripMenuItem
            // 
            this.showPublisherColumnToolStripMenuItem.Checked = true;
            this.showPublisherColumnToolStripMenuItem.CheckOnClick = true;
            this.showPublisherColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPublisherColumnToolStripMenuItem.Name = "showPublisherColumnToolStripMenuItem";
            this.showPublisherColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showPublisherColumnToolStripMenuItem.Text = "Show Publisher Column";
            this.showPublisherColumnToolStripMenuItem.Click += new System.EventHandler(this.showPublisherColumnToolStripMenuItem_Click);
            // 
            // showYearReleasedColumnToolStripMenuItem
            // 
            this.showYearReleasedColumnToolStripMenuItem.Checked = true;
            this.showYearReleasedColumnToolStripMenuItem.CheckOnClick = true;
            this.showYearReleasedColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showYearReleasedColumnToolStripMenuItem.Name = "showYearReleasedColumnToolStripMenuItem";
            this.showYearReleasedColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showYearReleasedColumnToolStripMenuItem.Text = "Show Year Column";
            this.showYearReleasedColumnToolStripMenuItem.Click += new System.EventHandler(this.showYearReleasedColumnToolStripMenuItem_Click);
            // 
            // showRatingColumnToolStripMenuItem
            // 
            this.showRatingColumnToolStripMenuItem.Checked = true;
            this.showRatingColumnToolStripMenuItem.CheckOnClick = true;
            this.showRatingColumnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRatingColumnToolStripMenuItem.Name = "showRatingColumnToolStripMenuItem";
            this.showRatingColumnToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showRatingColumnToolStripMenuItem.Text = "Show Rating Column";
            this.showRatingColumnToolStripMenuItem.Click += new System.EventHandler(this.showRatingColumnToolStripMenuItem_Click);
            // 
            // showBoxArtToolStripMenuItem
            // 
            this.showBoxArtToolStripMenuItem.Checked = true;
            this.showBoxArtToolStripMenuItem.CheckOnClick = true;
            this.showBoxArtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBoxArtToolStripMenuItem.Name = "showBoxArtToolStripMenuItem";
            this.showBoxArtToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showBoxArtToolStripMenuItem.Text = "Show Box Art";
            this.showBoxArtToolStripMenuItem.Click += new System.EventHandler(this.showBoxArtToolStripMenuItem_Click);
            // 
            // showTitleToolStripMenuItem
            // 
            this.showTitleToolStripMenuItem.Checked = true;
            this.showTitleToolStripMenuItem.CheckOnClick = true;
            this.showTitleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTitleToolStripMenuItem.Name = "showTitleToolStripMenuItem";
            this.showTitleToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showTitleToolStripMenuItem.Text = "Show Title Art";
            this.showTitleToolStripMenuItem.Click += new System.EventHandler(this.showTitleToolStripMenuItem_Click);
            // 
            // showGameplayArtToolStripMenuItem
            // 
            this.showGameplayArtToolStripMenuItem.Checked = true;
            this.showGameplayArtToolStripMenuItem.CheckOnClick = true;
            this.showGameplayArtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGameplayArtToolStripMenuItem.Name = "showGameplayArtToolStripMenuItem";
            this.showGameplayArtToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showGameplayArtToolStripMenuItem.Text = "Show Gameplay Art";
            this.showGameplayArtToolStripMenuItem.Click += new System.EventHandler(this.showGameplayArtToolStripMenuItem_Click);
            // 
            // showPlatformsListToolStripMenuItem
            // 
            this.showPlatformsListToolStripMenuItem.Checked = true;
            this.showPlatformsListToolStripMenuItem.CheckOnClick = true;
            this.showPlatformsListToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPlatformsListToolStripMenuItem.Name = "showPlatformsListToolStripMenuItem";
            this.showPlatformsListToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showPlatformsListToolStripMenuItem.Text = "Show Platforms List";
            this.showPlatformsListToolStripMenuItem.Click += new System.EventHandler(this.showPlatformsListToolStripMenuItem_Click);
            // 
            // showFileExistsAuditToolStripMenuItem
            // 
            this.showFileExistsAuditToolStripMenuItem.CheckOnClick = true;
            this.showFileExistsAuditToolStripMenuItem.Name = "showFileExistsAuditToolStripMenuItem";
            this.showFileExistsAuditToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showFileExistsAuditToolStripMenuItem.Text = "Show File Exists (Audit)";
            this.showFileExistsAuditToolStripMenuItem.Click += new System.EventHandler(this.showFileExistsAuditToolStripMenuItem_Click);
            // 
            // showIncorrectPlatformAuditToolStripMenuItem
            // 
            this.showIncorrectPlatformAuditToolStripMenuItem.CheckOnClick = true;
            this.showIncorrectPlatformAuditToolStripMenuItem.Name = "showIncorrectPlatformAuditToolStripMenuItem";
            this.showIncorrectPlatformAuditToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showIncorrectPlatformAuditToolStripMenuItem.Text = "Show Incorrect Platform (Audit)";
            this.showIncorrectPlatformAuditToolStripMenuItem.Click += new System.EventHandler(this.showIncorrectPlatformAuditToolStripMenuItem_Click);
            // 
            // showMissingPicsAuditToolStripMenuItem
            // 
            this.showMissingPicsAuditToolStripMenuItem.CheckOnClick = true;
            this.showMissingPicsAuditToolStripMenuItem.Name = "showMissingPicsAuditToolStripMenuItem";
            this.showMissingPicsAuditToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showMissingPicsAuditToolStripMenuItem.Text = "Show Missing Pics (Audit)";
            this.showMissingPicsAuditToolStripMenuItem.Click += new System.EventHandler(this.showMissingPicsAuditToolStripMenuItem_Click);
            // 
            // romDataOptionsToolStripMenuItem
            // 
            this.romDataOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncRomsToolStripMenuItem,
            this.purgeRomDataToolStripMenuItem,
            this.syncUsingRetropieXMLToolStripMenuItem});
            this.romDataOptionsToolStripMenuItem.Name = "romDataOptionsToolStripMenuItem";
            this.romDataOptionsToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.romDataOptionsToolStripMenuItem.Text = "Rom &Data Options";
            // 
            // syncRomsToolStripMenuItem
            // 
            this.syncRomsToolStripMenuItem.Name = "syncRomsToolStripMenuItem";
            this.syncRomsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.syncRomsToolStripMenuItem.Text = "Sync Rom Data Online";
            this.syncRomsToolStripMenuItem.Click += new System.EventHandler(this.syncRomsToolStripMenuItem_Click);
            // 
            // purgeRomDataToolStripMenuItem
            // 
            this.purgeRomDataToolStripMenuItem.Name = "purgeRomDataToolStripMenuItem";
            this.purgeRomDataToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.purgeRomDataToolStripMenuItem.Text = "Purge Rom Data";
            this.purgeRomDataToolStripMenuItem.Click += new System.EventHandler(this.purgeRomDataToolStripMenuItem_Click);
            // 
            // syncUsingRetropieXMLToolStripMenuItem
            // 
            this.syncUsingRetropieXMLToolStripMenuItem.Name = "syncUsingRetropieXMLToolStripMenuItem";
            this.syncUsingRetropieXMLToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.syncUsingRetropieXMLToolStripMenuItem.Text = "Sync Using Retropie XML";
            this.syncUsingRetropieXMLToolStripMenuItem.Click += new System.EventHandler(this.syncUsingRetropieXMLToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItemSettings.Text = "Settings";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.toolStripMenuItemSettings_Click);
            // 
            // openAppFolderToolStripMenuItem
            // 
            this.openAppFolderToolStripMenuItem.Name = "openAppFolderToolStripMenuItem";
            this.openAppFolderToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.openAppFolderToolStripMenuItem.Text = "&Open App Folder";
            this.openAppFolderToolStripMenuItem.Click += new System.EventHandler(this.openAppFolderToolStripMenuItem_Click);
            // 
            // dataGridViewPlatforms
            // 
            this.dataGridViewPlatforms.AllowUserToAddRows = false;
            this.dataGridViewPlatforms.AllowUserToDeleteRows = false;
            this.dataGridViewPlatforms.AllowUserToResizeColumns = false;
            this.dataGridViewPlatforms.AllowUserToResizeRows = false;
            this.dataGridViewPlatforms.ColumnHeadersHeight = 25;
            this.dataGridViewPlatforms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPlatforms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIcon,
            this.columnPlatforms});
            this.dataGridViewPlatforms.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewPlatforms.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewPlatforms.Location = new System.Drawing.Point(868, 0);
            this.dataGridViewPlatforms.Name = "dataGridViewPlatforms";
            this.dataGridViewPlatforms.ReadOnly = true;
            this.dataGridViewPlatforms.RowHeadersVisible = false;
            this.dataGridViewPlatforms.RowTemplate.Height = 30;
            this.dataGridViewPlatforms.Size = new System.Drawing.Size(133, 687);
            this.dataGridViewPlatforms.TabIndex = 9;
            this.dataGridViewPlatforms.DoubleClick += new System.EventHandler(this.dataGridViewPlatforms_DoubleClick);
            this.dataGridViewPlatforms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewPlatforms_MouseDown);
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnIcon.FillWeight = 139.0863F;
            this.ColumnIcon.HeaderText = "Icon";
            this.ColumnIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.ReadOnly = true;
            this.ColumnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIcon.Width = 40;
            // 
            // columnPlatforms
            // 
            this.columnPlatforms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnPlatforms.FillWeight = 60.9137F;
            this.columnPlatforms.HeaderText = "Platforms";
            this.columnPlatforms.Name = "columnPlatforms";
            this.columnPlatforms.ReadOnly = true;
            this.columnPlatforms.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnPlatforms.Width = 90;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBoxFilter.Controls.Add(this.buttonClear);
            this.groupBoxFilter.Controls.Add(this.checkBoxFavorite);
            this.groupBoxFilter.Controls.Add(this.buttonRescan);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.comboBoxDeveloper);
            this.groupBoxFilter.Controls.Add(this.labelYearReleased);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.comboBoxPublisher);
            this.groupBoxFilter.Controls.Add(this.comboBoxYearReleased);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.labelGenre);
            this.groupBoxFilter.Controls.Add(this.comboBoxGenre);
            this.groupBoxFilter.Controls.Add(this.labelFilterRom);
            this.groupBoxFilter.Controls.Add(this.labelLabels);
            this.groupBoxFilter.Controls.Add(this.labelEmulatorFilter);
            this.groupBoxFilter.Controls.Add(this.comboBoxPlatform);
            this.groupBoxFilter.Controls.Add(this.comboBoxLabels);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxFilter.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 24);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(638, 98);
            this.groupBoxFilter.TabIndex = 8;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClear.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClear.Location = new System.Drawing.Point(537, 17);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(98, 78);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear Filter";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.Location = new System.Drawing.Point(453, 71);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(78, 18);
            this.checkBoxFavorite.TabIndex = 18;
            this.checkBoxFavorite.Text = "Favorites";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            this.checkBoxFavorite.CheckedChanged += new System.EventHandler(this.checkBoxFavorite_CheckedChanged);
            // 
            // buttonRescan
            // 
            this.buttonRescan.Enabled = false;
            this.buttonRescan.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRescan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRescan.Location = new System.Drawing.Point(134, 67);
            this.buttonRescan.Name = "buttonRescan";
            this.buttonRescan.Size = new System.Drawing.Size(120, 23);
            this.buttonRescan.TabIndex = 17;
            this.buttonRescan.Text = "Rescan Roms";
            this.buttonRescan.UseVisualStyleBackColor = true;
            this.buttonRescan.Click += new System.EventHandler(this.buttonRescan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Developer";
            // 
            // comboBoxDeveloper
            // 
            this.comboBoxDeveloper.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDeveloper.FormattingEnabled = true;
            this.comboBoxDeveloper.Location = new System.Drawing.Point(386, 30);
            this.comboBoxDeveloper.Name = "comboBoxDeveloper";
            this.comboBoxDeveloper.Size = new System.Drawing.Size(120, 20);
            this.comboBoxDeveloper.TabIndex = 15;
            this.comboBoxDeveloper.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeveloper_SelectedIndexChanged);
            // 
            // labelYearReleased
            // 
            this.labelYearReleased.AutoSize = true;
            this.labelYearReleased.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYearReleased.Location = new System.Drawing.Point(511, 14);
            this.labelYearReleased.Name = "labelYearReleased";
            this.labelYearReleased.Size = new System.Drawing.Size(84, 14);
            this.labelYearReleased.TabIndex = 14;
            this.labelYearReleased.Text = "Year Released";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Publisher";
            // 
            // comboBoxPublisher
            // 
            this.comboBoxPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPublisher.FormattingEnabled = true;
            this.comboBoxPublisher.Location = new System.Drawing.Point(260, 30);
            this.comboBoxPublisher.Name = "comboBoxPublisher";
            this.comboBoxPublisher.Size = new System.Drawing.Size(120, 20);
            this.comboBoxPublisher.TabIndex = 11;
            this.comboBoxPublisher.SelectedIndexChanged += new System.EventHandler(this.comboBoxPublisher_SelectedIndexChanged);
            // 
            // comboBoxYearReleased
            // 
            this.comboBoxYearReleased.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYearReleased.FormattingEnabled = true;
            this.comboBoxYearReleased.Location = new System.Drawing.Point(513, 30);
            this.comboBoxYearReleased.Name = "comboBoxYearReleased";
            this.comboBoxYearReleased.Size = new System.Drawing.Size(93, 20);
            this.comboBoxYearReleased.TabIndex = 12;
            this.comboBoxYearReleased.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearReleased_SelectedIndexChanged);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(260, 68);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(187, 21);
            this.textBoxFilter.TabIndex = 10;
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilter_KeyPress);
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenre.Location = new System.Drawing.Point(8, 14);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(40, 14);
            this.labelGenre.TabIndex = 9;
            this.labelGenre.Text = "Genre";
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(8, 30);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(120, 20);
            this.comboBoxGenre.TabIndex = 8;
            this.comboBoxGenre.SelectedIndexChanged += new System.EventHandler(this.comboBoxGenre_SelectedIndexChanged);
            // 
            // labelFilterRom
            // 
            this.labelFilterRom.AutoSize = true;
            this.labelFilterRom.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilterRom.Location = new System.Drawing.Point(263, 52);
            this.labelFilterRom.Name = "labelFilterRom";
            this.labelFilterRom.Size = new System.Drawing.Size(65, 14);
            this.labelFilterRom.TabIndex = 5;
            this.labelFilterRom.Text = "Rom Name";
            // 
            // labelLabels
            // 
            this.labelLabels.AutoSize = true;
            this.labelLabels.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabels.Location = new System.Drawing.Point(134, 14);
            this.labelLabels.Name = "labelLabels";
            this.labelLabels.Size = new System.Drawing.Size(36, 14);
            this.labelLabels.TabIndex = 7;
            this.labelLabels.Text = "Label";
            // 
            // labelEmulatorFilter
            // 
            this.labelEmulatorFilter.AutoSize = true;
            this.labelEmulatorFilter.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmulatorFilter.Location = new System.Drawing.Point(6, 52);
            this.labelEmulatorFilter.Name = "labelEmulatorFilter";
            this.labelEmulatorFilter.Size = new System.Drawing.Size(55, 14);
            this.labelEmulatorFilter.TabIndex = 6;
            this.labelEmulatorFilter.Text = "Platform";
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(8, 68);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(120, 20);
            this.comboBoxPlatform.TabIndex = 3;
            this.comboBoxPlatform.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatform_SelectedIndexChanged);
            // 
            // comboBoxLabels
            // 
            this.comboBoxLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLabels.FormattingEnabled = true;
            this.comboBoxLabels.Location = new System.Drawing.Point(134, 30);
            this.comboBoxLabels.Name = "comboBoxLabels";
            this.comboBoxLabels.Size = new System.Drawing.Size(120, 20);
            this.comboBoxLabels.TabIndex = 4;
            this.comboBoxLabels.SelectedIndexChanged += new System.EventHandler(this.comboBoxLabels_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIconMain,
            this.ColumnFileExists,
            this.ColumnIncorrectPlatform,
            this.ColumnMissingPics,
            this.columnRomName,
            this.columnRomDBName,
            this.columnRomPath,
            this.columnFilename,
            this.columnPlatform,
            this.columnGenre,
            this.columnLabels,
            this.columnPublisher,
            this.columnDeveloper,
            this.columnYearReleased,
            this.columnRating});
            this.dataGridView.ContextMenuStrip = this.contextMenuStripEditRom;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 122);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(638, 536);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            this.dataGridView.Enter += new System.EventHandler(this.dataGridView_Enter);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            this.dataGridView.Leave += new System.EventHandler(this.dataGridView_Leave);
            this.dataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            // 
            // columnIconMain
            // 
            this.columnIconMain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnIconMain.FillWeight = 73.09644F;
            this.columnIconMain.Frozen = true;
            this.columnIconMain.HeaderText = "Icon";
            this.columnIconMain.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnIconMain.Name = "columnIconMain";
            this.columnIconMain.ReadOnly = true;
            this.columnIconMain.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnIconMain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnIconMain.Width = 40;
            // 
            // ColumnFileExists
            // 
            this.ColumnFileExists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnFileExists.Frozen = true;
            this.ColumnFileExists.HeaderText = "Exists";
            this.ColumnFileExists.Name = "ColumnFileExists";
            this.ColumnFileExists.ReadOnly = true;
            this.ColumnFileExists.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnFileExists.Visible = false;
            this.ColumnFileExists.Width = 60;
            // 
            // ColumnIncorrectPlatform
            // 
            this.ColumnIncorrectPlatform.FillWeight = 10F;
            this.ColumnIncorrectPlatform.HeaderText = "Incorrect Platform";
            this.ColumnIncorrectPlatform.Name = "ColumnIncorrectPlatform";
            this.ColumnIncorrectPlatform.ReadOnly = true;
            this.ColumnIncorrectPlatform.Visible = false;
            // 
            // ColumnMissingPics
            // 
            this.ColumnMissingPics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMissingPics.HeaderText = "Missing Pics";
            this.ColumnMissingPics.Name = "ColumnMissingPics";
            this.ColumnMissingPics.ReadOnly = true;
            this.ColumnMissingPics.Visible = false;
            // 
            // columnRomName
            // 
            this.columnRomName.FillWeight = 17.78983F;
            this.columnRomName.HeaderText = "Rom Name";
            this.columnRomName.Name = "columnRomName";
            this.columnRomName.ReadOnly = true;
            // 
            // columnRomDBName
            // 
            this.columnRomDBName.FillWeight = 17.78983F;
            this.columnRomDBName.HeaderText = "DB Name";
            this.columnRomDBName.Name = "columnRomDBName";
            this.columnRomDBName.ReadOnly = true;
            // 
            // columnRomPath
            // 
            this.columnRomPath.FillWeight = 10.90591F;
            this.columnRomPath.HeaderText = "Rom Path";
            this.columnRomPath.Name = "columnRomPath";
            this.columnRomPath.ReadOnly = true;
            // 
            // columnFilename
            // 
            this.columnFilename.FillWeight = 5.929944F;
            this.columnFilename.HeaderText = "Filename";
            this.columnFilename.Name = "columnFilename";
            this.columnFilename.ReadOnly = true;
            // 
            // columnPlatform
            // 
            this.columnPlatform.FillWeight = 4.94162F;
            this.columnPlatform.HeaderText = "Platform";
            this.columnPlatform.Name = "columnPlatform";
            this.columnPlatform.ReadOnly = true;
            // 
            // columnGenre
            // 
            this.columnGenre.FillWeight = 3.953296F;
            this.columnGenre.HeaderText = "Genre";
            this.columnGenre.Name = "columnGenre";
            this.columnGenre.ReadOnly = true;
            // 
            // columnLabels
            // 
            this.columnLabels.FillWeight = 7.90659F;
            this.columnLabels.HeaderText = "Labels";
            this.columnLabels.Name = "columnLabels";
            this.columnLabels.ReadOnly = true;
            // 
            // columnPublisher
            // 
            this.columnPublisher.FillWeight = 5.929944F;
            this.columnPublisher.HeaderText = "Publisher";
            this.columnPublisher.Name = "columnPublisher";
            this.columnPublisher.ReadOnly = true;
            // 
            // columnDeveloper
            // 
            this.columnDeveloper.FillWeight = 5.929944F;
            this.columnDeveloper.HeaderText = "Developer";
            this.columnDeveloper.Name = "columnDeveloper";
            this.columnDeveloper.ReadOnly = true;
            // 
            // columnYearReleased
            // 
            this.columnYearReleased.FillWeight = 4.722474F;
            this.columnYearReleased.HeaderText = "Year";
            this.columnYearReleased.Name = "columnYearReleased";
            this.columnYearReleased.ReadOnly = true;
            // 
            // columnRating
            // 
            this.columnRating.FillWeight = 4.722474F;
            this.columnRating.HeaderText = "Rating";
            this.columnRating.Name = "columnRating";
            this.columnRating.ReadOnly = true;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panelBottom.Controls.Add(this.labelSelectedRoms);
            this.panelBottom.Controls.Add(this.labelSelectedRomsCount);
            this.panelBottom.Controls.Add(this.labelTotal);
            this.panelBottom.Controls.Add(this.labelTotalRomsCount);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelBottom.Location = new System.Drawing.Point(0, 658);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(638, 29);
            this.panelBottom.TabIndex = 17;
            // 
            // labelSelectedRoms
            // 
            this.labelSelectedRoms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectedRoms.AutoSize = true;
            this.labelSelectedRoms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedRoms.Location = new System.Drawing.Point(131, 7);
            this.labelSelectedRoms.Name = "labelSelectedRoms";
            this.labelSelectedRoms.Size = new System.Drawing.Size(96, 13);
            this.labelSelectedRoms.TabIndex = 16;
            this.labelSelectedRoms.Text = "Selected Roms:";
            // 
            // labelSelectedRomsCount
            // 
            this.labelSelectedRomsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectedRomsCount.AutoSize = true;
            this.labelSelectedRomsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedRomsCount.Location = new System.Drawing.Point(224, 7);
            this.labelSelectedRomsCount.Name = "labelSelectedRomsCount";
            this.labelSelectedRomsCount.Size = new System.Drawing.Size(14, 13);
            this.labelSelectedRomsCount.TabIndex = 17;
            this.labelSelectedRomsCount.Text = "0";
            // 
            // flowLayoutPanelPictures
            // 
            this.flowLayoutPanelPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelPictures.Controls.Add(this.pictureBoxBoxart);
            this.flowLayoutPanelPictures.Controls.Add(this.pictureBoxTitle);
            this.flowLayoutPanelPictures.Controls.Add(this.pictureBoxGameplay);
            this.flowLayoutPanelPictures.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelPictures.Location = new System.Drawing.Point(638, 0);
            this.flowLayoutPanelPictures.Name = "flowLayoutPanelPictures";
            this.flowLayoutPanelPictures.Size = new System.Drawing.Size(230, 687);
            this.flowLayoutPanelPictures.TabIndex = 16;
            // 
            // pictureBoxBoxart
            // 
            this.pictureBoxBoxart.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBoxart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBoxart.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxBoxart.Name = "pictureBoxBoxart";
            this.pictureBoxBoxart.Size = new System.Drawing.Size(222, 222);
            this.pictureBoxBoxart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBoxart.TabIndex = 11;
            this.pictureBoxBoxart.TabStop = false;
            this.pictureBoxBoxart.DoubleClick += new System.EventHandler(this.pictureBoxBoxart_DoubleClick);
            this.pictureBoxBoxart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoxart_MouseClick);
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTitle.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTitle.Location = new System.Drawing.Point(3, 231);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(222, 222);
            this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTitle.TabIndex = 12;
            this.pictureBoxTitle.TabStop = false;
            this.pictureBoxTitle.DoubleClick += new System.EventHandler(this.pictureBoxTitle_DoubleClick);
            this.pictureBoxTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTitle_MouseClick);
            // 
            // pictureBoxGameplay
            // 
            this.pictureBoxGameplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGameplay.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGameplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGameplay.Location = new System.Drawing.Point(3, 459);
            this.pictureBoxGameplay.Name = "pictureBoxGameplay";
            this.pictureBoxGameplay.Size = new System.Drawing.Size(222, 222);
            this.pictureBoxGameplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGameplay.TabIndex = 13;
            this.pictureBoxGameplay.TabStop = false;
            this.pictureBoxGameplay.DoubleClick += new System.EventHandler(this.pictureBoxGameplay_DoubleClick);
            this.pictureBoxGameplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGameplay_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1001, 687);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.flowLayoutPanelPictures);
            this.Controls.Add(this.dataGridViewPlatforms);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(584, 341);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Emu Loader";
            this.MaximizedBoundsChanged += new System.EventHandler(this.FormMain_ResizeEnd);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_Close);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.contextMenuStripEditRom.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatforms)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.flowLayoutPanelPictures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoxart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditRom;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.ComboBox comboBoxLabels;
        private System.Windows.Forms.Label labelLabels;
        private System.Windows.Forms.Label labelEmulatorFilter;
        private System.Windows.Forms.Label labelFilterRom;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ToolStripMenuItem buttonRomOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem buttonRomRemoveRom;
        private System.Windows.Forms.ToolStripMenuItem buttonRomDeleteRomFromDisk;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.DataGridView dataGridViewPlatforms;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem romsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPathColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPlatformColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGenreColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLabelsColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedRomsOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRomFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRomDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeInvalidEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem platformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.Timer timerFilter;
        private System.Windows.Forms.PictureBox pictureBoxBoxart;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.PictureBox pictureBoxGameplay;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTotalRomsCount;
        private System.Windows.Forms.ToolStripMenuItem batchAddPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePlatformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeGenreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBoxArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGameplayArtToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStripMenuItem batchRemovePicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAppFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPlatforms;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPictures;
        private System.Windows.Forms.ToolStripMenuItem showPlatformsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRomPackInDirectoryStructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDeveloperColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPublisherColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showYearReleasedColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFilenameToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeveloper;
        private System.Windows.Forms.Label labelYearReleased;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPublisher;
        private System.Windows.Forms.ComboBox comboBoxYearReleased;
        private System.Windows.Forms.ToolStripMenuItem showRomDBNameColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem romDataOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncRomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgeRomDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRatingColumnToolStripMenuItem;
        private System.Windows.Forms.Button buttonRescan;
        private System.Windows.Forms.ToolStripMenuItem syncUsingRetropieXMLToolStripMenuItem;
        private System.Windows.Forms.Label labelSelectedRoms;
        private System.Windows.Forms.Label labelSelectedRomsCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem auditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFileExistsAuditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIncorrectPlatformAuditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMissingPicsAuditToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn columnIconMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileExists;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIncorrectPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMissingPics;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRomDBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRomPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLabels;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDeveloper;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnYearReleased;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRating;
        private System.Windows.Forms.ToolStripMenuItem favoriteUnfavoriteToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxFavorite;
    }
}