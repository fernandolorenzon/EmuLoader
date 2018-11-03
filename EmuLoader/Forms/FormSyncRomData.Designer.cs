namespace EmuLoader.Forms
{
    partial class FormSyncRomData
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelDeveloper = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelYearReleased = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSync = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLockIds = new System.Windows.Forms.Button();
            this.buttonUnlockIds = new System.Windows.Forms.Button();
            this.buttonStopProcess = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelBoxart = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelGameplay = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxSaveAsJpg = new System.Windows.Forms.CheckBox();
            this.labelRating = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxBasicSync = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Platform to Sync";
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(15, 52);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(177, 21);
            this.comboBoxPlatform.TabIndex = 1;
            this.comboBoxPlatform.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatform_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Roms with no Genre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Roms with no Publisher";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Roms with no Developer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Roms with no Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Roms with no Year Released";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(211, 110);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(10, 13);
            this.labelGenre.TabIndex = 7;
            this.labelGenre.Text = "-";
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(211, 136);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(10, 13);
            this.labelPublisher.TabIndex = 8;
            this.labelPublisher.Text = "-";
            // 
            // labelDeveloper
            // 
            this.labelDeveloper.AutoSize = true;
            this.labelDeveloper.Location = new System.Drawing.Point(211, 164);
            this.labelDeveloper.Name = "labelDeveloper";
            this.labelDeveloper.Size = new System.Drawing.Size(10, 13);
            this.labelDeveloper.TabIndex = 9;
            this.labelDeveloper.Text = "-";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(211, 188);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(10, 13);
            this.labelDescription.TabIndex = 10;
            this.labelDescription.Text = "-";
            // 
            // labelYearReleased
            // 
            this.labelYearReleased.AutoSize = true;
            this.labelYearReleased.Location = new System.Drawing.Point(211, 214);
            this.labelYearReleased.Name = "labelYearReleased";
            this.labelYearReleased.Size = new System.Drawing.Size(10, 13);
            this.labelYearReleased.TabIndex = 11;
            this.labelYearReleased.Text = "-";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(376, 52);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(414, 388);
            this.textBoxLog.TabIndex = 12;
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(3, 3);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(75, 45);
            this.buttonSync.TabIndex = 13;
            this.buttonSync.Text = "Sync Now";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.buttonSync);
            this.flowLayoutPanel1.Controls.Add(this.buttonLockIds);
            this.flowLayoutPanel1.Controls.Add(this.buttonUnlockIds);
            this.flowLayoutPanel1.Controls.Add(this.buttonStopProcess);
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 446);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(802, 54);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // buttonLockIds
            // 
            this.buttonLockIds.Location = new System.Drawing.Point(84, 3);
            this.buttonLockIds.Name = "buttonLockIds";
            this.buttonLockIds.Size = new System.Drawing.Size(98, 45);
            this.buttonLockIds.TabIndex = 16;
            this.buttonLockIds.Text = "Lock Empty Ids";
            this.buttonLockIds.UseVisualStyleBackColor = true;
            this.buttonLockIds.Click += new System.EventHandler(this.buttonLockIds_Click);
            // 
            // buttonUnlockIds
            // 
            this.buttonUnlockIds.Location = new System.Drawing.Point(188, 3);
            this.buttonUnlockIds.Name = "buttonUnlockIds";
            this.buttonUnlockIds.Size = new System.Drawing.Size(106, 45);
            this.buttonUnlockIds.TabIndex = 17;
            this.buttonUnlockIds.Text = "Unlock Locked Ids";
            this.buttonUnlockIds.UseVisualStyleBackColor = true;
            this.buttonUnlockIds.Click += new System.EventHandler(this.buttonUnlockIds_Click);
            // 
            // buttonStopProcess
            // 
            this.buttonStopProcess.Location = new System.Drawing.Point(300, 3);
            this.buttonStopProcess.Name = "buttonStopProcess";
            this.buttonStopProcess.Size = new System.Drawing.Size(75, 45);
            this.buttonStopProcess.TabIndex = 15;
            this.buttonStopProcess.Text = "Stop Process";
            this.buttonStopProcess.UseVisualStyleBackColor = true;
            this.buttonStopProcess.Click += new System.EventHandler(this.buttonStopProcess_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(381, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 45);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Log";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 417);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(366, 23);
            this.progressBar.TabIndex = 16;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(1, 401);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(11, 13);
            this.labelProgress.TabIndex = 17;
            this.labelProgress.Text = "-";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(211, 88);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(10, 13);
            this.labelId.TabIndex = 19;
            this.labelId.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Roms with no TheGamesDB.net Id";
            // 
            // labelBoxart
            // 
            this.labelBoxart.AutoSize = true;
            this.labelBoxart.Location = new System.Drawing.Point(211, 264);
            this.labelBoxart.Name = "labelBoxart";
            this.labelBoxart.Size = new System.Drawing.Size(10, 13);
            this.labelBoxart.TabIndex = 21;
            this.labelBoxart.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Roms with no Boxart image";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(211, 288);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(10, 13);
            this.labelTitle.TabIndex = 23;
            this.labelTitle.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Roms with no Title image";
            // 
            // labelGameplay
            // 
            this.labelGameplay.AutoSize = true;
            this.labelGameplay.Location = new System.Drawing.Point(211, 312);
            this.labelGameplay.Name = "labelGameplay";
            this.labelGameplay.Size = new System.Drawing.Size(10, 13);
            this.labelGameplay.TabIndex = 25;
            this.labelGameplay.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 312);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Roms with no gameplay image";
            // 
            // checkBoxSaveAsJpg
            // 
            this.checkBoxSaveAsJpg.AutoSize = true;
            this.checkBoxSaveAsJpg.Checked = true;
            this.checkBoxSaveAsJpg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveAsJpg.Location = new System.Drawing.Point(12, 342);
            this.checkBoxSaveAsJpg.Name = "checkBoxSaveAsJpg";
            this.checkBoxSaveAsJpg.Size = new System.Drawing.Size(124, 17);
            this.checkBoxSaveAsJpg.TabIndex = 26;
            this.checkBoxSaveAsJpg.Text = "Save images as JPG";
            this.checkBoxSaveAsJpg.UseVisualStyleBackColor = true;
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Location = new System.Drawing.Point(211, 239);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(10, 13);
            this.labelRating.TabIndex = 28;
            this.labelRating.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(83, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Roms with no rating";
            // 
            // checkBoxBasicSync
            // 
            this.checkBoxBasicSync.AutoSize = true;
            this.checkBoxBasicSync.Checked = true;
            this.checkBoxBasicSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBasicSync.Location = new System.Drawing.Point(12, 365);
            this.checkBoxBasicSync.Name = "checkBoxBasicSync";
            this.checkBoxBasicSync.Size = new System.Drawing.Size(164, 17);
            this.checkBoxBasicSync.TabIndex = 29;
            this.checkBoxBasicSync.Text = "Only sync Id, Name and Year";
            this.checkBoxBasicSync.UseVisualStyleBackColor = true;
            // 
            // FormSyncRomData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 500);
            this.Controls.Add(this.checkBoxBasicSync);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBoxSaveAsJpg);
            this.Controls.Add(this.labelGameplay);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelBoxart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.labelYearReleased);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDeveloper);
            this.Controls.Add(this.labelPublisher);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPlatform);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelProgress);
            this.Name = "FormSyncRomData";
            this.Text = "Sync Rom Data";
            this.Load += new System.EventHandler(this.FormSyncRomData_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelDeveloper;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelYearReleased;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonStopProcess;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelBoxart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelGameplay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxSaveAsJpg;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonLockIds;
        private System.Windows.Forms.Button buttonUnlockIds;
        private System.Windows.Forms.CheckBox checkBoxBasicSync;
    }
}