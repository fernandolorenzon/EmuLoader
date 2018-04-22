namespace EmuLoader.Forms
{
    partial class FormPurgeRomData
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
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPurge = new System.Windows.Forms.Button();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxPublisher = new System.Windows.Forms.CheckBox();
            this.checkBoxDeveloper = new System.Windows.Forms.CheckBox();
            this.checkBoxDescription = new System.Windows.Forms.CheckBox();
            this.checkBoxYearReleased = new System.Windows.Forms.CheckBox();
            this.checkBoxDBName = new System.Windows.Forms.CheckBox();
            this.checkBoxGenre = new System.Windows.Forms.CheckBox();
            this.labelGameplay = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelBoxart = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelYearReleased = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDeveloper = new System.Windows.Forms.Label();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxRating = new System.Windows.Forms.CheckBox();
            this.labelRating = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(15, 39);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(177, 21);
            this.comboBoxPlatform.TabIndex = 3;
            this.comboBoxPlatform.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatform_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Platform to Purge";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.buttonPurge);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 448);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(652, 54);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // buttonPurge
            // 
            this.buttonPurge.Location = new System.Drawing.Point(3, 3);
            this.buttonPurge.Name = "buttonPurge";
            this.buttonPurge.Size = new System.Drawing.Size(75, 45);
            this.buttonPurge.TabIndex = 13;
            this.buttonPurge.Text = "Purge Now";
            this.buttonPurge.UseVisualStyleBackColor = true;
            this.buttonPurge.Click += new System.EventHandler(this.buttonPurge_Click);
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(15, 86);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(35, 17);
            this.checkBoxId.TabIndex = 16;
            this.checkBoxId.Text = "Id";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // checkBoxPublisher
            // 
            this.checkBoxPublisher.AutoSize = true;
            this.checkBoxPublisher.Location = new System.Drawing.Point(15, 133);
            this.checkBoxPublisher.Name = "checkBoxPublisher";
            this.checkBoxPublisher.Size = new System.Drawing.Size(69, 17);
            this.checkBoxPublisher.TabIndex = 17;
            this.checkBoxPublisher.Text = "Publisher";
            this.checkBoxPublisher.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeveloper
            // 
            this.checkBoxDeveloper.AutoSize = true;
            this.checkBoxDeveloper.Location = new System.Drawing.Point(15, 156);
            this.checkBoxDeveloper.Name = "checkBoxDeveloper";
            this.checkBoxDeveloper.Size = new System.Drawing.Size(75, 17);
            this.checkBoxDeveloper.TabIndex = 18;
            this.checkBoxDeveloper.Text = "Developer";
            this.checkBoxDeveloper.UseVisualStyleBackColor = true;
            // 
            // checkBoxDescription
            // 
            this.checkBoxDescription.AutoSize = true;
            this.checkBoxDescription.Location = new System.Drawing.Point(15, 179);
            this.checkBoxDescription.Name = "checkBoxDescription";
            this.checkBoxDescription.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDescription.TabIndex = 19;
            this.checkBoxDescription.Text = "Description";
            this.checkBoxDescription.UseVisualStyleBackColor = true;
            // 
            // checkBoxYearReleased
            // 
            this.checkBoxYearReleased.AutoSize = true;
            this.checkBoxYearReleased.Location = new System.Drawing.Point(15, 202);
            this.checkBoxYearReleased.Name = "checkBoxYearReleased";
            this.checkBoxYearReleased.Size = new System.Drawing.Size(96, 17);
            this.checkBoxYearReleased.TabIndex = 20;
            this.checkBoxYearReleased.Text = "Year Released";
            this.checkBoxYearReleased.UseVisualStyleBackColor = true;
            // 
            // checkBoxDBName
            // 
            this.checkBoxDBName.AutoSize = true;
            this.checkBoxDBName.Location = new System.Drawing.Point(15, 248);
            this.checkBoxDBName.Name = "checkBoxDBName";
            this.checkBoxDBName.Size = new System.Drawing.Size(72, 17);
            this.checkBoxDBName.TabIndex = 21;
            this.checkBoxDBName.Text = "DB Name";
            this.checkBoxDBName.UseVisualStyleBackColor = true;
            // 
            // checkBoxGenre
            // 
            this.checkBoxGenre.AutoSize = true;
            this.checkBoxGenre.Location = new System.Drawing.Point(15, 107);
            this.checkBoxGenre.Name = "checkBoxGenre";
            this.checkBoxGenre.Size = new System.Drawing.Size(55, 17);
            this.checkBoxGenre.TabIndex = 22;
            this.checkBoxGenre.Text = "Genre";
            this.checkBoxGenre.UseVisualStyleBackColor = true;
            // 
            // labelGameplay
            // 
            this.labelGameplay.AutoSize = true;
            this.labelGameplay.Location = new System.Drawing.Point(419, 308);
            this.labelGameplay.Name = "labelGameplay";
            this.labelGameplay.Size = new System.Drawing.Size(10, 13);
            this.labelGameplay.TabIndex = 43;
            this.labelGameplay.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Roms with no gameplay image";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(419, 284);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(10, 13);
            this.labelTitle.TabIndex = 41;
            this.labelTitle.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Roms with no Title image";
            // 
            // labelBoxart
            // 
            this.labelBoxart.AutoSize = true;
            this.labelBoxart.Location = new System.Drawing.Point(419, 260);
            this.labelBoxart.Name = "labelBoxart";
            this.labelBoxart.Size = new System.Drawing.Size(10, 13);
            this.labelBoxart.TabIndex = 39;
            this.labelBoxart.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Roms with no Boxart image";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(419, 86);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(10, 13);
            this.labelId.TabIndex = 37;
            this.labelId.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Roms with no TheGamesDB.net Id";
            // 
            // labelYearReleased
            // 
            this.labelYearReleased.AutoSize = true;
            this.labelYearReleased.Location = new System.Drawing.Point(419, 212);
            this.labelYearReleased.Name = "labelYearReleased";
            this.labelYearReleased.Size = new System.Drawing.Size(10, 13);
            this.labelYearReleased.TabIndex = 35;
            this.labelYearReleased.Text = "-";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(419, 186);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(10, 13);
            this.labelDescription.TabIndex = 34;
            this.labelDescription.Text = "-";
            // 
            // labelDeveloper
            // 
            this.labelDeveloper.AutoSize = true;
            this.labelDeveloper.Location = new System.Drawing.Point(419, 162);
            this.labelDeveloper.Name = "labelDeveloper";
            this.labelDeveloper.Size = new System.Drawing.Size(10, 13);
            this.labelDeveloper.TabIndex = 33;
            this.labelDeveloper.Text = "-";
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(419, 134);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(10, 13);
            this.labelPublisher.TabIndex = 32;
            this.labelPublisher.Text = "-";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(419, 108);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(10, 13);
            this.labelGenre.TabIndex = 31;
            this.labelGenre.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Roms with no Year Released";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Roms with no Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Roms with no Developer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Roms with no Publisher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Roms with no Genre";
            // 
            // checkBoxRating
            // 
            this.checkBoxRating.AutoSize = true;
            this.checkBoxRating.Location = new System.Drawing.Point(15, 225);
            this.checkBoxRating.Name = "checkBoxRating";
            this.checkBoxRating.Size = new System.Drawing.Size(57, 17);
            this.checkBoxRating.TabIndex = 44;
            this.checkBoxRating.Text = "Rating";
            this.checkBoxRating.UseVisualStyleBackColor = true;
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Location = new System.Drawing.Point(419, 235);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(10, 13);
            this.labelRating.TabIndex = 46;
            this.labelRating.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Roms with no Rating";
            // 
            // FormPurgeRomData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 502);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxRating);
            this.Controls.Add(this.labelGameplay);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelBoxart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.checkBoxGenre);
            this.Controls.Add(this.checkBoxDBName);
            this.Controls.Add(this.checkBoxYearReleased);
            this.Controls.Add(this.checkBoxDescription);
            this.Controls.Add(this.checkBoxDeveloper);
            this.Controls.Add(this.checkBoxPublisher);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.comboBoxPlatform);
            this.Controls.Add(this.label1);
            this.Name = "FormPurgeRomData";
            this.Text = "Purge Rom Data";
            this.Load += new System.EventHandler(this.FormPurgeRomData_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonPurge;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxPublisher;
        private System.Windows.Forms.CheckBox checkBoxDeveloper;
        private System.Windows.Forms.CheckBox checkBoxDescription;
        private System.Windows.Forms.CheckBox checkBoxYearReleased;
        private System.Windows.Forms.CheckBox checkBoxDBName;
        private System.Windows.Forms.CheckBox checkBoxGenre;
        private System.Windows.Forms.Label labelGameplay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelBoxart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelYearReleased;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDeveloper;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxRating;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label label8;
    }
}