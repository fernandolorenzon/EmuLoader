namespace EmuLoader.Forms
{
    partial class FormBatchRemovePictures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatchRemovePictures));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxChoosePlatform = new System.Windows.Forms.ComboBox();
            this.radioButtonBoxart = new System.Windows.Forms.RadioButton();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.radioButtonGameplay = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            // radioButtonBoxart
            // 
            this.radioButtonBoxart.AutoSize = true;
            this.radioButtonBoxart.Checked = true;
            this.radioButtonBoxart.Location = new System.Drawing.Point(15, 109);
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
            this.radioButtonTitle.Location = new System.Drawing.Point(93, 109);
            this.radioButtonTitle.Name = "radioButtonTitle";
            this.radioButtonTitle.Size = new System.Drawing.Size(111, 17);
            this.radioButtonTitle.TabIndex = 6;
            this.radioButtonTitle.Text = "Title Screen/Logo";
            this.radioButtonTitle.UseVisualStyleBackColor = true;
            // 
            // radioButtonGameplay
            // 
            this.radioButtonGameplay.AutoSize = true;
            this.radioButtonGameplay.Location = new System.Drawing.Point(220, 109);
            this.radioButtonGameplay.Name = "radioButtonGameplay";
            this.radioButtonGameplay.Size = new System.Drawing.Size(72, 17);
            this.radioButtonGameplay.TabIndex = 7;
            this.radioButtonGameplay.Text = "Gameplay";
            this.radioButtonGameplay.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Choose Picture Type To Remove";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(15, 158);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(96, 158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormBatchRemovePictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 273);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonGameplay);
            this.Controls.Add(this.radioButtonTitle);
            this.Controls.Add(this.radioButtonBoxart);
            this.Controls.Add(this.comboBoxChoosePlatform);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBatchRemovePictures";
            this.Text = "Batch Remove Pictures";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChoosePlatform;
        private System.Windows.Forms.RadioButton radioButtonBoxart;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.RadioButton radioButtonGameplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCancel;
    }
}