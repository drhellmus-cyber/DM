namespace patient
{
    partial class CertificatORL
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
            lblDateConsult = new Label();
            lblAge = new Label();
            lblPrenom = new Label();
            lblNom = new Label();
            rtCertificat = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // lblDateConsult
            // 
            lblDateConsult.AutoSize = true;
            lblDateConsult.Location = new Point(24, 58);
            lblDateConsult.Name = "lblDateConsult";
            lblDateConsult.Size = new Size(122, 15);
            lblDateConsult.TabIndex = 78;
            lblDateConsult.Text = "Date de consultation :";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(24, 43);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(34, 15);
            lblAge.TabIndex = 77;
            lblAge.Text = "Age :";
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(24, 28);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 76;
            lblPrenom.Text = "Prénom :";
            lblPrenom.UseMnemonic = false;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(24, 13);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(40, 15);
            lblNom.TabIndex = 75;
            lblNom.Text = "Nom :";
            // 
            // rtCertificat
            // 
            rtCertificat.Location = new Point(236, 113);
            rtCertificat.Name = "rtCertificat";
            rtCertificat.Size = new Size(480, 306);
            rtCertificat.TabIndex = 79;
            rtCertificat.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(830, 140);
            button1.Name = "button1";
            button1.Size = new Size(76, 29);
            button1.TabIndex = 80;
            button1.Text = "Modèle 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(830, 193);
            button2.Name = "button2";
            button2.Size = new Size(76, 29);
            button2.TabIndex = 81;
            button2.Text = "Modèle 2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(830, 248);
            button3.Name = "button3";
            button3.Size = new Size(76, 29);
            button3.TabIndex = 82;
            button3.Text = "Modèle 3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(273, 12);
            button4.Name = "button4";
            button4.Size = new Size(76, 29);
            button4.TabIndex = 83;
            button4.Text = "Valider";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(647, 460);
            button5.Name = "button5";
            button5.Size = new Size(69, 29);
            button5.TabIndex = 84;
            button5.Text = "Imprimer";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // CertificatORL
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 631);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(rtCertificat);
            Controls.Add(lblDateConsult);
            Controls.Add(lblAge);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Name = "CertificatORL";
            Text = "CertificatORL";
            Load += CertificatORL_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDateConsult;
        private Label lblAge;
        private Label lblPrenom;
        private Label lblNom;
        private RichTextBox rtCertificat;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}