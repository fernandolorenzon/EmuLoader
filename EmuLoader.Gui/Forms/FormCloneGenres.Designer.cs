namespace EmuLoader.Gui.Forms
{
    partial class FormCloneGenres
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
            buttonClone = new Button();
            comboBoxSource = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxTarget = new ComboBox();
            SuspendLayout();
            // 
            // buttonClone
            // 
            buttonClone.Location = new Point(273, 272);
            buttonClone.Name = "buttonClone";
            buttonClone.Size = new Size(118, 86);
            buttonClone.TabIndex = 0;
            buttonClone.Text = "Clone";
            buttonClone.UseVisualStyleBackColor = true;
            buttonClone.Click += buttonClone_Click;
            // 
            // comboBoxSource
            // 
            comboBoxSource.FormattingEnabled = true;
            comboBoxSource.Location = new Point(214, 55);
            comboBoxSource.Name = "comboBoxSource";
            comboBoxSource.Size = new Size(288, 23);
            comboBoxSource.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 58);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 121);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 3;
            label2.Text = "Target";
            // 
            // comboBoxTarget
            // 
            comboBoxTarget.FormattingEnabled = true;
            comboBoxTarget.Location = new Point(214, 118);
            comboBoxTarget.Name = "comboBoxTarget";
            comboBoxTarget.Size = new Size(288, 23);
            comboBoxTarget.TabIndex = 4;
            // 
            // FormCloneGenres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 491);
            Controls.Add(comboBoxTarget);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxSource);
            Controls.Add(buttonClone);
            Name = "FormCloneGenres";
            Text = "Clone Genres";
            Load += FormCloneGenres_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClone;
        private ComboBox comboBoxSource;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxTarget;
    }
}