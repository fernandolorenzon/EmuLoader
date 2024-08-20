namespace EmuLoader.Gui.Forms
{
    partial class FormSeries
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
            this.labelSeries = new System.Windows.Forms.Label();
            this.textBoxSeries = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelSeries
            // 
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(12, 35);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(81, 13);
            this.labelSeries.TabIndex = 2;
            this.labelSeries.Text = "Type the Series";
            // 
            // textBoxSeries
            // 
            this.textBoxSeries.Location = new System.Drawing.Point(15, 51);
            this.textBoxSeries.Name = "textBoxSeries";
            this.textBoxSeries.Size = new System.Drawing.Size(212, 20);
            this.textBoxSeries.TabIndex = 3;
            // 
            // FormSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(598, 424);
            this.Controls.Add(this.textBoxSeries);
            this.Controls.Add(this.labelSeries);
            this.Name = "FormSeries";
            this.Text = "Select Series";
            this.Load += new System.EventHandler(this.FormSeries_Load);
            this.Controls.SetChildIndex(this.labelSeries, 0);
            this.Controls.SetChildIndex(this.textBoxSeries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeries;
        private System.Windows.Forms.TextBox textBoxSeries;
    }
}