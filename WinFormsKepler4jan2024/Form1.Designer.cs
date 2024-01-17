namespace WinFormsKepler4jan2024
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxExoplanet = new ComboBox();
            comboBoxStar = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBoxExoplanet
            // 
            comboBoxExoplanet.FormattingEnabled = true;
            comboBoxExoplanet.Location = new Point(565, 12);
            comboBoxExoplanet.Name = "comboBoxExoplanet";
            comboBoxExoplanet.Size = new Size(113, 23);
            comboBoxExoplanet.TabIndex = 0;            
            // 
            // comboBoxStar
            // 
            comboBoxStar.FormattingEnabled = true;
            comboBoxStar.Location = new Point(804, 12);
            comboBoxStar.Name = "comboBoxStar";
            comboBoxStar.Size = new Size(113, 23);
            comboBoxStar.TabIndex = 1;            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(453, 15);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 2;
            label3.Text = "Mass of exoplanet:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(725, 15);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Mass of star:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 543);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxStar);
            Controls.Add(comboBoxExoplanet);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxExoplanet;
        private ComboBox comboBoxStar;
        private Label label3;
        private Label label4;
    }
}