namespace EmuLoader.Forms
{
    partial class FormBatchAddPictures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatchAddPictures));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxChoosePlatform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonBoxart = new System.Windows.Forms.RadioButton();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.radioButtonGameplay = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.buttonAddDir = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Emulator/Platform";
            // 
            // comboBoxChooseEmulator
            // 
            this.comboBoxChoosePlatform.FormattingEnabled = true;
            this.comboBoxChoosePlatform.Location = new System.Drawing.Point(15, 44);
            this.comboBoxChoosePlatform.Name = "comboBoxChooseEmulator";
            this.comboBoxChoosePlatform.Size = new System.Drawing.Size(247, 21);
            this.comboBoxChoosePlatform.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Directory Containing the Pictures";
            // 
            // radioButtonBoxart
            // 
            this.radioButtonBoxart.AutoSize = true;
            this.radioButtonBoxart.Checked = true;
            this.radioButtonBoxart.Location = new System.Drawing.Point(15, 164);
            this.radioButtonBoxart.Name = "radioButtonBoxart";
            this.radioButtonBoxart.Size = new System.Drawing.Size(59, 17);
            this.radioButtonBoxart.TabIndex = 5;
            this.radioButtonBoxart.TabStop = true;
            this.radioButtonBoxart.Text = "Box Art";
            this.radioButtonBoxart.UseVisualStyleBackColor = true;
            // 
            // radioButtonTitle
            // 
            this.radioButtonTitle.AutoSize = true;
            this.radioButtonTitle.Location = new System.Drawing.Point(93, 164);
            this.radioButtonTitle.Name = "radioButtonTitle";
            this.radioButtonTitle.Size = new System.Drawing.Size(111, 17);
            this.radioButtonTitle.TabIndex = 6;
            this.radioButtonTitle.Text = "Title Screen/Logo";
            this.radioButtonTitle.UseVisualStyleBackColor = true;
            // 
            // radioButtonGameplay
            // 
            this.radioButtonGameplay.AutoSize = true;
            this.radioButtonGameplay.Location = new System.Drawing.Point(220, 164);
            this.radioButtonGameplay.Name = "radioButtonGameplay";
            this.radioButtonGameplay.Size = new System.Drawing.Size(72, 17);
            this.radioButtonGameplay.TabIndex = 7;
            this.radioButtonGameplay.Text = "Gameplay";
            this.radioButtonGameplay.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Choose Picture Type";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(15, 213);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(96, 213);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(15, 106);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(247, 20);
            this.textBoxDir.TabIndex = 11;
            // 
            // buttonAddDir
            // 
            this.buttonAddDir.Location = new System.Drawing.Point(268, 106);
            this.buttonAddDir.Name = "buttonAddDir";
            this.buttonAddDir.Size = new System.Drawing.Size(45, 20);
            this.buttonAddDir.TabIndex = 12;
            this.buttonAddDir.Text = "...";
            this.buttonAddDir.UseVisualStyleBackColor = true;
            this.buttonAddDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 259);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(350, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // FormBatchAddPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 309);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonAddDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonGameplay);
            this.Controls.Add(this.radioButtonTitle);
            this.Controls.Add(this.radioButtonBoxart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxChoosePlatform);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBatchAddPictures";
            this.Text = "Batch Add Pictures";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChoosePlatform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonBoxart;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.RadioButton radioButtonGameplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button buttonAddDir;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}