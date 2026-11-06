namespace patient
{
    partial class Form2
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
            lblAge = new Label();
            lblPrenom = new Label();
            lblNom = new Label();
            button1 = new Button();
            flowLayoutPanelPrincipal = new FlowLayoutPanel();
            txtSignesORL = new TextBox();
            txtNotesLibres = new TextBox();
            SuspendLayout();
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(31, 62);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(34, 15);
            lblAge.TabIndex = 36;
            lblAge.Text = "Age :";
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(163, 24);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 35;
            lblPrenom.Text = "Prénom :";
            lblPrenom.UseMnemonic = false;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(25, 24);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(40, 15);
            lblNom.TabIndex = 34;
            lblNom.Text = "Nom :";
            // 
            // button1
            // 
            button1.Location = new Point(261, 23);
            button1.Name = "button1";
            button1.Size = new Size(81, 25);
            button1.TabIndex = 42;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanelPrincipal
            // 
            flowLayoutPanelPrincipal.Location = new Point(25, 126);
            flowLayoutPanelPrincipal.Name = "flowLayoutPanelPrincipal";
            flowLayoutPanelPrincipal.Size = new Size(1115, 481);
            flowLayoutPanelPrincipal.TabIndex = 43;
            // 
            // txtSignesORL
            // 
            txtSignesORL.Location = new Point(770, 20);
            txtSignesORL.Multiline = true;
            txtSignesORL.Name = "txtSignesORL";
            txtSignesORL.Size = new Size(370, 57);
            txtSignesORL.TabIndex = 44;
            // 
            // txtNotesLibres
            // 
            txtNotesLibres.Location = new Point(474, 20);
            txtNotesLibres.Multiline = true;
            txtNotesLibres.Name = "txtNotesLibres";
            txtNotesLibres.Size = new Size(225, 64);
            txtNotesLibres.TabIndex = 45;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 646);
            Controls.Add(txtNotesLibres);
            Controls.Add(txtSignesORL);
            Controls.Add(flowLayoutPanelPrincipal);
            Controls.Add(button1);
            Controls.Add(lblAge);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Name = "Form2";
            Text = "Signes fonctionnelle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblAge;
        private Label lblPrenom;
        private Label lblNom;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanelPrincipal;
        private TextBox txtSignesORL;
        private TextBox txtNotesLibres;
    }
}