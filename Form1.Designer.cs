namespace patient
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
            lblNom = new Label();
            lblPrenom = new Label();
            lblAge = new Label();
            lblDiagnostic = new Label();
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            txtAge = new TextBox();
            lblPreOp = new Label();
            gbPreOp = new GroupBox();
            radioECG = new RadioButton();
            radioStandard = new RadioButton();
            btnPrOp = new Button();
            btnCourbeTA = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btnClinique = new Button();
            btnNaso = new Button();
            btnOrdonnance = new Button();
            btnOrientation = new Button();
            button10 = new Button();
            button11 = new Button();
            lblMotif = new Label();
            lblResume = new Label();
            richTbxOrientation = new RichTextBox();
            label4 = new Label();
            comboOrientation = new ComboBox();
            comboDiagnostic = new ComboBox();
            button9 = new Button();
            btnCertificat = new Button();
            lblDateConsult = new Label();
            tbxDateConsult = new TextBox();
            gbMaladie = new GroupBox();
            radioReprise = new RadioButton();
            radioArretScolaire = new RadioButton();
            radioArretTravail = new RadioButton();
            radioJustification = new RadioButton();
            lblDureeMaladie = new Label();
            txtDureeMaladie = new TextBox();
            lblATCD = new Label();
            gbDestinataire = new GroupBox();
            radioAmi = new RadioButton();
            radioCollegue = new RadioButton();
            radioConfrere = new RadioButton();
            gbSexe = new GroupBox();
            radioButton1 = new RadioButton();
            radioM = new RadioButton();
            txtATCD = new TextBox();
            checkedListBoxATCD = new CheckedListBox();
            validate = new Button();
            comboDemandeStandard = new ComboBox();
            lblDemandeStandard = new Label();
            btnDemandStandard = new Button();
            gbPreOp.SuspendLayout();
            gbMaladie.SuspendLayout();
            gbDestinataire.SuspendLayout();
            gbSexe.SuspendLayout();
            SuspendLayout();
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(48, 71);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(40, 15);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(48, 110);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 1;
            lblPrenom.Text = "Prénom :";
            lblPrenom.UseMnemonic = false;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(48, 156);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(34, 15);
            lblAge.TabIndex = 2;
            lblAge.Text = "Age :";
            // 
            // lblDiagnostic
            // 
            lblDiagnostic.AutoSize = true;
            lblDiagnostic.Location = new Point(997, 30);
            lblDiagnostic.Name = "lblDiagnostic";
            lblDiagnostic.Size = new Size(69, 15);
            lblDiagnostic.TabIndex = 3;
            lblDiagnostic.Text = "Diagnostic :";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(143, 71);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(275, 23);
            txtNom.TabIndex = 4;
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(143, 110);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(275, 23);
            txtPrenom.TabIndex = 5;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(143, 156);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(111, 23);
            txtAge.TabIndex = 6;
            // 
            // lblPreOp
            // 
            lblPreOp.AutoSize = true;
            lblPreOp.BorderStyle = BorderStyle.FixedSingle;
            lblPreOp.Location = new Point(1033, 185);
            lblPreOp.Name = "lblPreOp";
            lblPreOp.Size = new Size(51, 17);
            lblPreOp.TabIndex = 8;
            lblPreOp.Text = "Pré-op :";
            lblPreOp.Click += label1_Click;
            // 
            // gbPreOp
            // 
            gbPreOp.Controls.Add(radioECG);
            gbPreOp.Controls.Add(radioStandard);
            gbPreOp.Location = new Point(1137, 168);
            gbPreOp.Name = "gbPreOp";
            gbPreOp.Size = new Size(107, 78);
            gbPreOp.TabIndex = 9;
            gbPreOp.TabStop = false;
            gbPreOp.Text = "Pré-op";
            gbPreOp.Enter += groupBox1_Enter;
            // 
            // radioECG
            // 
            radioECG.AutoSize = true;
            radioECG.Location = new Point(6, 41);
            radioECG.Name = "radioECG";
            radioECG.Size = new Size(76, 19);
            radioECG.TabIndex = 1;
            radioECG.TabStop = true;
            radioECG.Text = "Avec ECG";
            radioECG.UseVisualStyleBackColor = true;
            // 
            // radioStandard
            // 
            radioStandard.AutoSize = true;
            radioStandard.Location = new Point(8, 19);
            radioStandard.Name = "radioStandard";
            radioStandard.Size = new Size(72, 19);
            radioStandard.TabIndex = 0;
            radioStandard.TabStop = true;
            radioStandard.Text = "Standard";
            radioStandard.UseVisualStyleBackColor = true;
            // 
            // btnPrOp
            // 
            btnPrOp.Location = new Point(1033, 223);
            btnPrOp.Name = "btnPrOp";
            btnPrOp.Size = new Size(75, 23);
            btnPrOp.TabIndex = 10;
            btnPrOp.Text = "Imprimer";
            btnPrOp.UseVisualStyleBackColor = true;
            btnPrOp.Click += btnPrOp_Click;
            // 
            // btnCourbeTA
            // 
            btnCourbeTA.Location = new Point(572, 316);
            btnCourbeTA.Name = "btnCourbeTA";
            btnCourbeTA.Size = new Size(129, 23);
            btnCourbeTA.TabIndex = 11;
            btnCourbeTA.Text = "Courbe de TA";
            btnCourbeTA.UseVisualStyleBackColor = true;
            btnCourbeTA.Click += btnPrOp_Click;
            // 
            // button1
            // 
            button1.Location = new Point(48, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Imprimer";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(143, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Imprimer";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(244, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 14;
            button3.Text = "Imprimer";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(343, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 15;
            button4.Text = "Imprimer";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(461, 12);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 16;
            button5.Text = "Imprimer";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnClinique
            // 
            btnClinique.Location = new Point(585, 71);
            btnClinique.Name = "btnClinique";
            btnClinique.Size = new Size(75, 23);
            btnClinique.TabIndex = 17;
            btnClinique.Text = "Clinique";
            btnClinique.UseVisualStyleBackColor = true;
            // 
            // btnNaso
            // 
            btnNaso.Location = new Point(585, 112);
            btnNaso.Name = "btnNaso";
            btnNaso.Size = new Size(104, 23);
            btnNaso.TabIndex = 18;
            btnNaso.Text = "Nasofibroscopie";
            btnNaso.UseVisualStyleBackColor = true;
            // 
            // btnOrdonnance
            // 
            btnOrdonnance.Location = new Point(585, 156);
            btnOrdonnance.Name = "btnOrdonnance";
            btnOrdonnance.Size = new Size(75, 23);
            btnOrdonnance.TabIndex = 19;
            btnOrdonnance.Text = "Ordonnance";
            btnOrdonnance.UseVisualStyleBackColor = true;
            // 
            // btnOrientation
            // 
            btnOrientation.Location = new Point(27, 556);
            btnOrientation.Name = "btnOrientation";
            btnOrientation.Size = new Size(75, 23);
            btnOrientation.TabIndex = 20;
            btnOrientation.Text = "Imprimer";
            btnOrientation.UseVisualStyleBackColor = true;
            btnOrientation.Click += btnPrOp_Click;
            // 
            // button10
            // 
            button10.Location = new Point(1200, 599);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 21;
            button10.Text = "Imprimer";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(807, 251);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 22;
            button11.Text = "Imprimer";
            button11.UseVisualStyleBackColor = true;
            button11.Click += btnPrOp_Click;
            // 
            // lblMotif
            // 
            lblMotif.AutoSize = true;
            lblMotif.Location = new Point(48, 320);
            lblMotif.Name = "lblMotif";
            lblMotif.Size = new Size(45, 15);
            lblMotif.TabIndex = 23;
            lblMotif.Text = "Motif : ";
            // 
            // lblResume
            // 
            lblResume.AutoSize = true;
            lblResume.Location = new Point(38, 381);
            lblResume.Name = "lblResume";
            lblResume.Size = new Size(55, 15);
            lblResume.TabIndex = 24;
            lblResume.Text = "Résumé :";
            // 
            // richTbxOrientation
            // 
            richTbxOrientation.Location = new Point(140, 378);
            richTbxOrientation.Name = "richTbxOrientation";
            richTbxOrientation.Size = new Size(380, 193);
            richTbxOrientation.TabIndex = 26;
            richTbxOrientation.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(178, 276);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 27;
            label4.Text = "Lettre d'orientation";
            label4.Click += label4_Click;
            // 
            // comboOrientation
            // 
            comboOrientation.FormattingEnabled = true;
            comboOrientation.Location = new Point(140, 317);
            comboOrientation.Name = "comboOrientation";
            comboOrientation.Size = new Size(380, 23);
            comboOrientation.TabIndex = 28;
            // 
            // comboDiagnostic
            // 
            comboDiagnostic.FormattingEnabled = true;
            comboDiagnostic.Location = new Point(1072, 30);
            comboDiagnostic.Name = "comboDiagnostic";
            comboDiagnostic.Size = new Size(305, 23);
            comboDiagnostic.TabIndex = 29;
            // 
            // button9
            // 
            button9.Location = new Point(343, 156);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 30;
            button9.Text = "Imprimer";
            button9.UseVisualStyleBackColor = true;
            // 
            // btnCertificat
            // 
            btnCertificat.Location = new Point(585, 201);
            btnCertificat.Name = "btnCertificat";
            btnCertificat.Size = new Size(104, 23);
            btnCertificat.TabIndex = 31;
            btnCertificat.Text = "Certificat-ORL";
            btnCertificat.UseVisualStyleBackColor = true;
            // 
            // lblDateConsult
            // 
            lblDateConsult.AutoSize = true;
            lblDateConsult.Location = new Point(48, 209);
            lblDateConsult.Name = "lblDateConsult";
            lblDateConsult.Size = new Size(122, 15);
            lblDateConsult.TabIndex = 32;
            lblDateConsult.Text = "Date de consultation :";
            // 
            // tbxDateConsult
            // 
            tbxDateConsult.Location = new Point(176, 206);
            tbxDateConsult.Name = "tbxDateConsult";
            tbxDateConsult.Size = new Size(111, 23);
            tbxDateConsult.TabIndex = 33;
            // 
            // gbMaladie
            // 
            gbMaladie.Controls.Add(radioReprise);
            gbMaladie.Controls.Add(radioArretScolaire);
            gbMaladie.Controls.Add(radioArretTravail);
            gbMaladie.Controls.Add(radioJustification);
            gbMaladie.Location = new Point(799, 57);
            gbMaladie.Name = "gbMaladie";
            gbMaladie.Size = new Size(107, 122);
            gbMaladie.TabIndex = 34;
            gbMaladie.TabStop = false;
            gbMaladie.Text = "Maladie";
            // 
            // radioReprise
            // 
            radioReprise.AutoSize = true;
            radioReprise.Location = new Point(8, 91);
            radioReprise.Name = "radioReprise";
            radioReprise.Size = new Size(63, 19);
            radioReprise.TabIndex = 35;
            radioReprise.TabStop = true;
            radioReprise.Text = "Reprise";
            radioReprise.UseVisualStyleBackColor = true;
            radioReprise.CheckedChanged += Maladie_click;
            // 
            // radioArretScolaire
            // 
            radioArretScolaire.AutoSize = true;
            radioArretScolaire.Location = new Point(8, 66);
            radioArretScolaire.Name = "radioArretScolaire";
            radioArretScolaire.Size = new Size(94, 19);
            radioArretScolaire.TabIndex = 35;
            radioArretScolaire.TabStop = true;
            radioArretScolaire.Text = "Arrêt scolaire";
            radioArretScolaire.UseVisualStyleBackColor = true;
            radioArretScolaire.CheckedChanged += Maladie_click;
            // 
            // radioArretTravail
            // 
            radioArretTravail.AutoSize = true;
            radioArretTravail.Location = new Point(6, 41);
            radioArretTravail.Name = "radioArretTravail";
            radioArretTravail.Size = new Size(102, 19);
            radioArretTravail.TabIndex = 1;
            radioArretTravail.TabStop = true;
            radioArretTravail.Text = "Arrêt de travail";
            radioArretTravail.UseVisualStyleBackColor = true;
            radioArretTravail.CheckedChanged += Maladie_click;
            // 
            // radioJustification
            // 
            radioJustification.AutoSize = true;
            radioJustification.Location = new Point(8, 19);
            radioJustification.Name = "radioJustification";
            radioJustification.Size = new Size(88, 19);
            radioJustification.TabIndex = 0;
            radioJustification.TabStop = true;
            radioJustification.Text = "Justification";
            radioJustification.UseVisualStyleBackColor = true;
            radioJustification.CheckedChanged += Maladie_click;
            // 
            // lblDureeMaladie
            // 
            lblDureeMaladie.AutoSize = true;
            lblDureeMaladie.Location = new Point(750, 201);
            lblDureeMaladie.Name = "lblDureeMaladie";
            lblDureeMaladie.Size = new Size(44, 15);
            lblDureeMaladie.TabIndex = 35;
            lblDureeMaladie.Text = "Durée :";
            // 
            // txtDureeMaladie
            // 
            txtDureeMaladie.Location = new Point(800, 198);
            txtDureeMaladie.Name = "txtDureeMaladie";
            txtDureeMaladie.Size = new Size(106, 23);
            txtDureeMaladie.TabIndex = 36;
            // 
            // lblATCD
            // 
            lblATCD.AutoSize = true;
            lblATCD.Location = new Point(1025, 75);
            lblATCD.Name = "lblATCD";
            lblATCD.Size = new Size(41, 15);
            lblATCD.TabIndex = 37;
            lblATCD.Text = "ATCD :";
            // 
            // gbDestinataire
            // 
            gbDestinataire.Controls.Add(radioAmi);
            gbDestinataire.Controls.Add(radioCollegue);
            gbDestinataire.Controls.Add(radioConfrere);
            gbDestinataire.Location = new Point(27, 399);
            gbDestinataire.Name = "gbDestinataire";
            gbDestinataire.Size = new Size(107, 87);
            gbDestinataire.TabIndex = 38;
            gbDestinataire.TabStop = false;
            gbDestinataire.Text = "Destinataire";
            // 
            // radioAmi
            // 
            radioAmi.AutoSize = true;
            radioAmi.Location = new Point(8, 66);
            radioAmi.Name = "radioAmi";
            radioAmi.Size = new Size(47, 19);
            radioAmi.TabIndex = 35;
            radioAmi.TabStop = true;
            radioAmi.Text = "Ami";
            radioAmi.UseVisualStyleBackColor = true;
            // 
            // radioCollegue
            // 
            radioCollegue.AutoSize = true;
            radioCollegue.Location = new Point(6, 41);
            radioCollegue.Name = "radioCollegue";
            radioCollegue.Size = new Size(72, 19);
            radioCollegue.TabIndex = 1;
            radioCollegue.TabStop = true;
            radioCollegue.Text = "Collègue";
            radioCollegue.UseVisualStyleBackColor = true;
            // 
            // radioConfrere
            // 
            radioConfrere.AutoSize = true;
            radioConfrere.Location = new Point(8, 19);
            radioConfrere.Name = "radioConfrere";
            radioConfrere.Size = new Size(71, 19);
            radioConfrere.TabIndex = 0;
            radioConfrere.TabStop = true;
            radioConfrere.Text = "Confrère";
            radioConfrere.UseVisualStyleBackColor = true;
            // 
            // gbSexe
            // 
            gbSexe.Controls.Add(radioButton1);
            gbSexe.Controls.Add(radioM);
            gbSexe.Location = new Point(27, 490);
            gbSexe.Name = "gbSexe";
            gbSexe.Size = new Size(79, 63);
            gbSexe.TabIndex = 39;
            gbSexe.TabStop = false;
            gbSexe.Text = "Sexe";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 41);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Female";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioM
            // 
            radioM.AutoSize = true;
            radioM.Location = new Point(8, 19);
            radioM.Name = "radioM";
            radioM.Size = new Size(51, 19);
            radioM.TabIndex = 0;
            radioM.TabStop = true;
            radioM.Text = "Male";
            radioM.UseVisualStyleBackColor = true;
            radioM.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // txtATCD
            // 
            txtATCD.Location = new Point(1072, 76);
            txtATCD.Multiline = true;
            txtATCD.Name = "txtATCD";
            txtATCD.Size = new Size(203, 86);
            txtATCD.TabIndex = 40;
            // 
            // checkedListBoxATCD
            // 
            checkedListBoxATCD.FormattingEnabled = true;
            checkedListBoxATCD.Location = new Point(1302, 81);
            checkedListBoxATCD.Name = "checkedListBoxATCD";
            checkedListBoxATCD.Size = new Size(148, 130);
            checkedListBoxATCD.TabIndex = 41;
            // 
            // validate
            // 
            validate.Location = new Point(1272, 178);
            validate.Name = "validate";
            validate.Size = new Size(20, 21);
            validate.TabIndex = 42;
            validate.Text = "Validate";
            validate.UseVisualStyleBackColor = true;
            validate.Click += validate_Click;
            // 
            // comboDemandeStandard
            // 
            comboDemandeStandard.FormattingEnabled = true;
            comboDemandeStandard.Location = new Point(572, 414);
            comboDemandeStandard.Name = "comboDemandeStandard";
            comboDemandeStandard.Size = new Size(168, 23);
            comboDemandeStandard.TabIndex = 43;
            // 
            // lblDemandeStandard
            // 
            lblDemandeStandard.AutoSize = true;
            lblDemandeStandard.Location = new Point(585, 381);
            lblDemandeStandard.Name = "lblDemandeStandard";
            lblDemandeStandard.Size = new Size(113, 15);
            lblDemandeStandard.TabIndex = 44;
            lblDemandeStandard.Text = "Demande standard :";
            // 
            // btnDemandStandard
            // 
            btnDemandStandard.Location = new Point(746, 414);
            btnDemandStandard.Name = "btnDemandStandard";
            btnDemandStandard.Size = new Size(48, 21);
            btnDemandStandard.TabIndex = 45;
            btnDemandStandard.Text = "Validate";
            btnDemandStandard.UseVisualStyleBackColor = true;
            btnDemandStandard.Click += btnPrOp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1490, 646);
            Controls.Add(btnDemandStandard);
            Controls.Add(lblDemandeStandard);
            Controls.Add(comboDemandeStandard);
            Controls.Add(validate);
            Controls.Add(checkedListBoxATCD);
            Controls.Add(txtATCD);
            Controls.Add(gbSexe);
            Controls.Add(gbDestinataire);
            Controls.Add(lblATCD);
            Controls.Add(txtDureeMaladie);
            Controls.Add(lblDureeMaladie);
            Controls.Add(gbMaladie);
            Controls.Add(tbxDateConsult);
            Controls.Add(lblDateConsult);
            Controls.Add(btnCertificat);
            Controls.Add(button9);
            Controls.Add(comboDiagnostic);
            Controls.Add(comboOrientation);
            Controls.Add(label4);
            Controls.Add(richTbxOrientation);
            Controls.Add(lblResume);
            Controls.Add(lblMotif);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(btnOrientation);
            Controls.Add(btnOrdonnance);
            Controls.Add(btnNaso);
            Controls.Add(btnClinique);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnCourbeTA);
            Controls.Add(btnPrOp);
            Controls.Add(gbPreOp);
            Controls.Add(lblPreOp);
            Controls.Add(txtAge);
            Controls.Add(txtPrenom);
            Controls.Add(txtNom);
            Controls.Add(lblDiagnostic);
            Controls.Add(lblAge);
            Controls.Add(lblPrenom);
            Controls.Add(lblNom);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gbPreOp.ResumeLayout(false);
            gbPreOp.PerformLayout();
            gbMaladie.ResumeLayout(false);
            gbMaladie.PerformLayout();
            gbDestinataire.ResumeLayout(false);
            gbDestinataire.PerformLayout();
            gbSexe.ResumeLayout(false);
            gbSexe.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label lblNom;
        private Label lblPrenom;
        private Label lblAge;
        private Label lblDiagnostic;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtAge;
        private Label lblPreOp;
        private GroupBox gbPreOp;
        private RadioButton radioECG;
        private RadioButton radioStandard;
        private Button btnPrOp;
        private Button btnCourbeTA;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btnClinique;
        private Button btnNaso;
        private Button btnOrdonnance;
        private Button btnOrientation;
        private Button button10;
        private Button button11;
        private Label lblMotif;
        private Label lblResume;
        private RichTextBox richTbxOrientation;
        private Label label4;
        private ComboBox comboOrientation;
        private ComboBox comboDiagnostic;
        private Button button9;
        private Button btnCertificat;
        private Label lblDateConsult;
        private TextBox tbxDateConsult;
        private GroupBox gbMaladie;
        private RadioButton radioArretTravail;
        private RadioButton radioJustification;
        private RadioButton radioReprise;
        private RadioButton radioArretScolaire;
        private Label lblDureeMaladie;
        private TextBox txtDureeMaladie;
        private Label lblATCD;
        private GroupBox gbDestinataire;
        private RadioButton radioAmi;
        private RadioButton radioCollegue;
        private RadioButton radioConfrere;
        private GroupBox gbSexe;
        private RadioButton radioButton1;
        private RadioButton radioM;
        private TextBox txtATCD;
        private CheckedListBox checkedListBoxATCD;
        private Button validate;
        private ComboBox comboDemandeStandard;
        private Label lblDemandeStandard;
        private Button btnDemandStandard;
    }
}
