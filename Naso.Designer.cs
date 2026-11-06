namespace patient
{
    partial class Naso
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
            button1 = new Button();
            lblAge = new Label();
            lblPrenom = new Label();
            lblNom = new Label();
            rtNaso = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(300, 24);
            button1.Name = "button1";
            button1.Size = new Size(81, 25);
            button1.TabIndex = 50;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(28, 62);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(34, 15);
            lblAge.TabIndex = 49;
            lblAge.Text = "Age :";
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(160, 24);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 48;
            lblPrenom.Text = "Prénom :";
            lblPrenom.UseMnemonic = false;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(22, 24);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(40, 15);
            lblNom.TabIndex = 47;
            lblNom.Text = "Nom :";
            // 
            // rtNaso
            // 
            rtNaso.Location = new Point(689, 82);
            rtNaso.Name = "rtNaso";
            rtNaso.Size = new Size(357, 423);
            rtNaso.TabIndex = 51;
            rtNaso.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(1084, 169);
            button2.Name = "button2";
            button2.Size = new Size(70, 26);
            button2.TabIndex = 52;
            button2.Text = "Modèle 1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1084, 229);
            button3.Name = "button3";
            button3.Size = new Size(68, 28);
            button3.TabIndex = 53;
            button3.Text = "Imprimer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 127);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 54;
            label1.Text = "FN date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 359);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 55;
            label2.Text = "FN Gche";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 136);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 56;
            label3.Text = "Muqueuse";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 175);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 57;
            label4.Text = "Méat inf";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 215);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 58;
            label5.Text = "Méat moy";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 283);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 59;
            label6.Text = "Choane";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(436, 215);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 60;
            label7.Text = "Cavum";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(434, 136);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 61;
            label8.Text = "Cloison";
            // 
            // Naso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 607);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(rtNaso);
            Controls.Add(button1);
            Controls.Add(lblAge);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Name = "Naso";
            Text = "Naso";
            Load += Naso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblAge;
        private Label lblPrenom;
        private Label lblNom;
        private RichTextBox rtNaso;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}