namespace EmuLoader.Forms
{
    partial class FormAddPicFromUrl
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSavePicture = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCopySave = new System.Windows.Forms.Button();
            this.checkBoxSaveAsJpg = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paste the picture url here:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 20);
            this.textBox1.TabIndex = 1;
            // 
            // buttonSavePicture
            // 
            this.buttonSavePicture.Location = new System.Drawing.Point(155, 119);
            this.buttonSavePicture.Name = "buttonSavePicture";
            this.buttonSavePicture.Size = new System.Drawing.Size(75, 40);
            this.buttonSavePicture.TabIndex = 2;
            this.buttonSavePicture.Text = "Save Picture";
            this.buttonSavePicture.UseVisualStyleBackColor = true;
            this.buttonSavePicture.Click += new System.EventHandler(this.buttonSavePicture_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(236, 119);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 40);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCopySave
            // 
            this.buttonCopySave.Location = new System.Drawing.Point(12, 119);
            this.buttonCopySave.Name = "buttonCopySave";
            this.buttonCopySave.Size = new System.Drawing.Size(137, 40);
            this.buttonCopySave.TabIndex = 4;
            this.buttonCopySave.Text = "Copy from Clipboard and Save Picture";
            this.buttonCopySave.UseVisualStyleBackColor = true;
            this.buttonCopySave.Click += new System.EventHandler(this.buttonCopySave_Click);
            // 
            // checkBoxSaveAsJpg
            // 
            this.checkBoxSaveAsJpg.AutoSize = true;
            this.checkBoxSaveAsJpg.Checked = true;
            this.checkBoxSaveAsJpg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveAsJpg.Location = new System.Drawing.Point(15, 67);
            this.checkBoxSaveAsJpg.Name = "checkBoxSaveAsJpg";
            this.checkBoxSaveAsJpg.Size = new System.Drawing.Size(88, 17);
            this.checkBoxSaveAsJpg.TabIndex = 5;
            this.checkBoxSaveAsJpg.Text = "Save as JPG";
            this.checkBoxSaveAsJpg.UseVisualStyleBackColor = true;
            // 
            // FormAddPicFromUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 209);
            this.Controls.Add(this.checkBoxSaveAsJpg);
            this.Controls.Add(this.buttonCopySave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSavePicture);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormAddPicFromUrl";
            this.Text = "Add Pic From Url";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSavePicture;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCopySave;
        private System.Windows.Forms.CheckBox checkBoxSaveAsJpg;
    }
}