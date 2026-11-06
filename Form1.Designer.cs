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
            components = new System.ComponentModel.Container();
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
            btnPremier = new Button();
            btnPrecedent = new Button();
            btnSuivant = new Button();
            btnDernier = new Button();
            btnEnregistrer = new Button();
            btnClinique = new Button();
            btnNaso = new Button();
            btnOrdonnance = new Button();
            btnOrientation = new Button();
            btnBilan = new Button();
            button11 = new Button();
            lblMotif = new Label();
            lblResume = new Label();
            richTbxOrientation = new RichTextBox();
            label4 = new Label();
            comboOrientation = new ComboBox();
            comboDiagnostic = new ComboBox();
            btnNouveau = new Button();
            btnCertificat = new Button();
            lblDateConsult = new Label();
            txtDateConsult = new TextBox();
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
            clbBilan = new CheckedListBox();
            button6 = new Button();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            gbBilan = new GroupBox();
            lblRDV = new Label();
            gpRDV = new GroupBox();
            radioRDV6 = new RadioButton();
            radioRDV5 = new RadioButton();
            radioRDV4 = new RadioButton();
            radioRDV3 = new RadioButton();
            radioRDV2 = new RadioButton();
            radioRDV1 = new RadioButton();
            monthCalendar1 = new MonthCalendar();
            btnRDV = new Button();
            txtRDV = new TextBox();
            txtAgeAnnee = new TextBox();
            bindingSource1 = new BindingSource(components);
            txtRechercher = new TextBox();
            lblRechercher = new Label();
            dgvConsultations = new DataGridView();
            btnSuivantConsult = new Button();
            btnprecedentConsultat = new Button();
            btnNouvelConsult = new Button();
            btnSauvegarderConsult = new Button();
            lblNaissance = new Label();
            lblCateg = new Label();
            gbPreOp.SuspendLayout();
            gbMaladie.SuspendLayout();
            gbDestinataire.SuspendLayout();
            gbSexe.SuspendLayout();
            gbBilan.SuspendLayout();
            gpRDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).BeginInit();
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
            txtNom.CharacterCasing = CharacterCasing.Upper;
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
            txtPrenom.TextChanged += txtPrenom_TextChanged;
            txtPrenom.Leave += txtPrenom_Leave;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(143, 156);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(111, 23);
            txtAge.TabIndex = 6;
            txtAge.KeyPress += txtAge_KeyPress;
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
            // btnPremier
            // 
            btnPremier.Location = new Point(48, 12);
            btnPremier.Name = "btnPremier";
            btnPremier.Size = new Size(75, 23);
            btnPremier.TabIndex = 12;
            btnPremier.Text = "Premier";
            btnPremier.UseVisualStyleBackColor = true;
            btnPremier.Click += btnPremier_Click;
            // 
            // btnPrecedent
            // 
            btnPrecedent.Location = new Point(143, 12);
            btnPrecedent.Name = "btnPrecedent";
            btnPrecedent.Size = new Size(75, 23);
            btnPrecedent.TabIndex = 13;
            btnPrecedent.Text = "Précédent";
            btnPrecedent.UseVisualStyleBackColor = true;
            btnPrecedent.Click += btnPrecedent_Click;
            // 
            // btnSuivant
            // 
            btnSuivant.Location = new Point(244, 12);
            btnSuivant.Name = "btnSuivant";
            btnSuivant.Size = new Size(75, 23);
            btnSuivant.TabIndex = 14;
            btnSuivant.Text = "Suivant";
            btnSuivant.UseVisualStyleBackColor = true;
            btnSuivant.Click += btnSuivant_Click;
            // 
            // btnDernier
            // 
            btnDernier.Location = new Point(343, 12);
            btnDernier.Name = "btnDernier";
            btnDernier.Size = new Size(75, 23);
            btnDernier.TabIndex = 15;
            btnDernier.Text = "Dernier";
            btnDernier.UseVisualStyleBackColor = true;
            btnDernier.Click += btnDernier_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(426, 41);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(98, 23);
            btnEnregistrer.TabIndex = 16;
            btnEnregistrer.Text = "Modifier/Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnClinique
            // 
            btnClinique.Location = new Point(585, 71);
            btnClinique.Name = "btnClinique";
            btnClinique.Size = new Size(75, 23);
            btnClinique.TabIndex = 17;
            btnClinique.Text = "Clinique";
            btnClinique.UseVisualStyleBackColor = true;
            btnClinique.Click += btnClinique_Click;
            // 
            // btnNaso
            // 
            btnNaso.Location = new Point(585, 112);
            btnNaso.Name = "btnNaso";
            btnNaso.Size = new Size(116, 23);
            btnNaso.TabIndex = 18;
            btnNaso.Text = "Para-clinique";
            btnNaso.UseVisualStyleBackColor = true;
            btnNaso.Click += btnNaso_Click;
            // 
            // btnOrdonnance
            // 
            btnOrdonnance.Location = new Point(585, 156);
            btnOrdonnance.Name = "btnOrdonnance";
            btnOrdonnance.Size = new Size(75, 23);
            btnOrdonnance.TabIndex = 19;
            btnOrdonnance.Text = "Ordonnance";
            btnOrdonnance.UseVisualStyleBackColor = true;
            btnOrdonnance.Click += btnOrdonnance_Click;
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
            // btnBilan
            // 
            btnBilan.Location = new Point(1091, 598);
            btnBilan.Name = "btnBilan";
            btnBilan.Size = new Size(75, 23);
            btnBilan.TabIndex = 21;
            btnBilan.Text = "Valider";
            btnBilan.UseVisualStyleBackColor = true;
            btnBilan.Click += btnPrOp_Click;
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
            // btnNouveau
            // 
            btnNouveau.Location = new Point(424, 12);
            btnNouveau.Name = "btnNouveau";
            btnNouveau.Size = new Size(100, 23);
            btnNouveau.TabIndex = 30;
            btnNouveau.Text = "Ajouter";
            btnNouveau.UseVisualStyleBackColor = true;
            btnNouveau.Click += btnNouveau_Click;
            // 
            // btnCertificat
            // 
            btnCertificat.Location = new Point(585, 201);
            btnCertificat.Name = "btnCertificat";
            btnCertificat.Size = new Size(104, 23);
            btnCertificat.TabIndex = 31;
            btnCertificat.Text = "Certificat-ORL";
            btnCertificat.UseVisualStyleBackColor = true;
            btnCertificat.Click += btnCertificat_Click;
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
            // txtDateConsult
            // 
            txtDateConsult.Location = new Point(176, 206);
            txtDateConsult.Name = "txtDateConsult";
            txtDateConsult.Size = new Size(111, 23);
            txtDateConsult.TabIndex = 33;
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
            gbMaladie.Enter += gbMaladie_Enter;
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
            lblATCD.Size = new Size(42, 15);
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
            gbSexe.Enter += gbSexe_Enter;
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
            // clbBilan
            // 
            clbBilan.CheckOnClick = true;
            clbBilan.FormattingEnabled = true;
            clbBilan.Location = new Point(1206, 293);
            clbBilan.Name = "clbBilan";
            clbBilan.Size = new Size(182, 328);
            clbBilan.TabIndex = 46;
            // 
            // button6
            // 
            button6.Location = new Point(708, 312);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 47;
            button6.Text = "Valider";
            button6.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(32, 14);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(71, 19);
            radioButton2.TabIndex = 48;
            radioButton2.TabStop = true;
            radioButton2.Text = "Générale";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged_1;
            radioButton2.Click += bilan_clic;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(32, 61);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(100, 19);
            radioButton3.TabIndex = 49;
            radioButton3.TabStop = true;
            radioButton3.Text = "Inflammatoire";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.Click += bilan_clic;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(32, 102);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(60, 19);
            radioButton4.TabIndex = 50;
            radioButton4.TabStop = true;
            radioButton4.Text = "Rénale";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.Click += bilan_clic;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(32, 151);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(80, 19);
            radioButton5.TabIndex = 51;
            radioButton5.TabStop = true;
            radioButton5.Text = "Hépatique";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.Click += bilan_clic;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(32, 201);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(82, 19);
            radioButton6.TabIndex = 52;
            radioButton6.TabStop = true;
            radioButton6.Text = "Thyrôidien";
            radioButton6.UseVisualStyleBackColor = true;
            radioButton6.Click += bilan_clic;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(32, 242);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(74, 19);
            radioButton7.TabIndex = 53;
            radioButton7.TabStop = true;
            radioButton7.Text = "Sérologie";
            radioButton7.UseVisualStyleBackColor = true;
            radioButton7.Click += bilan_clic;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(32, 281);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(87, 19);
            radioButton8.TabIndex = 54;
            radioButton8.TabStop = true;
            radioButton8.Text = "Effacer tous";
            radioButton8.UseVisualStyleBackColor = true;
            radioButton8.Click += bilan_clic;
            // 
            // gbBilan
            // 
            gbBilan.Controls.Add(radioButton8);
            gbBilan.Controls.Add(radioButton7);
            gbBilan.Controls.Add(radioButton6);
            gbBilan.Controls.Add(radioButton5);
            gbBilan.Controls.Add(radioButton4);
            gbBilan.Controls.Add(radioButton3);
            gbBilan.Controls.Add(radioButton2);
            gbBilan.Location = new Point(1040, 279);
            gbBilan.Name = "gbBilan";
            gbBilan.Size = new Size(143, 311);
            gbBilan.TabIndex = 55;
            gbBilan.TabStop = false;
            gbBilan.Text = "Bilans";
            // 
            // lblRDV
            // 
            lblRDV.AutoSize = true;
            lblRDV.Location = new Point(585, 484);
            lblRDV.Name = "lblRDV";
            lblRDV.Size = new Size(29, 15);
            lblRDV.TabIndex = 56;
            lblRDV.Text = "RDV";
            // 
            // gpRDV
            // 
            gpRDV.Controls.Add(radioRDV6);
            gpRDV.Controls.Add(radioRDV5);
            gpRDV.Controls.Add(radioRDV4);
            gpRDV.Controls.Add(radioRDV3);
            gpRDV.Controls.Add(radioRDV2);
            gpRDV.Controls.Add(radioRDV1);
            gpRDV.Location = new Point(633, 457);
            gpRDV.Name = "gpRDV";
            gpRDV.Size = new Size(107, 164);
            gpRDV.TabIndex = 57;
            gpRDV.TabStop = false;
            gpRDV.Text = "RDV(1 Lundi)";
            // 
            // radioRDV6
            // 
            radioRDV6.AutoSize = true;
            radioRDV6.Location = new Point(6, 141);
            radioRDV6.Name = "radioRDV6";
            radioRDV6.Size = new Size(60, 19);
            radioRDV6.TabIndex = 58;
            radioRDV6.TabStop = true;
            radioRDV6.Text = "6 mois";
            radioRDV6.UseVisualStyleBackColor = true;
            radioRDV6.CheckedChanged += RDV_CheckedChanged;
            // 
            // radioRDV5
            // 
            radioRDV5.AutoSize = true;
            radioRDV5.Location = new Point(8, 116);
            radioRDV5.Name = "radioRDV5";
            radioRDV5.Size = new Size(60, 19);
            radioRDV5.TabIndex = 58;
            radioRDV5.TabStop = true;
            radioRDV5.Text = "3 mois";
            radioRDV5.UseVisualStyleBackColor = true;
            radioRDV5.CheckedChanged += RDV_CheckedChanged;
            // 
            // radioRDV4
            // 
            radioRDV4.AutoSize = true;
            radioRDV4.Location = new Point(8, 91);
            radioRDV4.Name = "radioRDV4";
            radioRDV4.Size = new Size(60, 19);
            radioRDV4.TabIndex = 35;
            radioRDV4.TabStop = true;
            radioRDV4.Text = "1 mois";
            radioRDV4.UseVisualStyleBackColor = true;
            radioRDV4.CheckedChanged += RDV_CheckedChanged;
            // 
            // radioRDV3
            // 
            radioRDV3.AutoSize = true;
            radioRDV3.Location = new Point(8, 66);
            radioRDV3.Name = "radioRDV3";
            radioRDV3.Size = new Size(83, 19);
            radioRDV3.TabIndex = 35;
            radioRDV3.TabStop = true;
            radioRDV3.Text = "3 semaines";
            radioRDV3.UseVisualStyleBackColor = true;
            radioRDV3.CheckedChanged += RDV_CheckedChanged;
            // 
            // radioRDV2
            // 
            radioRDV2.AutoSize = true;
            radioRDV2.Location = new Point(6, 41);
            radioRDV2.Name = "radioRDV2";
            radioRDV2.Size = new Size(83, 19);
            radioRDV2.TabIndex = 1;
            radioRDV2.TabStop = true;
            radioRDV2.Text = "2 semaines";
            radioRDV2.UseVisualStyleBackColor = true;
            radioRDV2.CheckedChanged += RDV_CheckedChanged;
            // 
            // radioRDV1
            // 
            radioRDV1.AutoSize = true;
            radioRDV1.Location = new Point(8, 19);
            radioRDV1.Name = "radioRDV1";
            radioRDV1.Size = new Size(78, 19);
            radioRDV1.TabIndex = 0;
            radioRDV1.TabStop = true;
            radioRDV1.Text = "1 semaine";
            radioRDV1.UseVisualStyleBackColor = true;
            radioRDV1.CheckedChanged += RDV_CheckedChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.FirstDayOfWeek = Day.Sunday;
            monthCalendar1.Location = new Point(752, 459);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 58;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // btnRDV
            // 
            btnRDV.Location = new Point(539, 573);
            btnRDV.Name = "btnRDV";
            btnRDV.Size = new Size(75, 23);
            btnRDV.TabIndex = 59;
            btnRDV.Text = "Valider";
            btnRDV.UseVisualStyleBackColor = true;
            btnRDV.Click += btnPrOp_Click;
            // 
            // txtRDV
            // 
            txtRDV.Location = new Point(536, 601);
            txtRDV.Name = "txtRDV";
            txtRDV.Size = new Size(81, 23);
            txtRDV.TabIndex = 60;
            // 
            // txtAgeAnnee
            // 
            txtAgeAnnee.Location = new Point(312, 157);
            txtAgeAnnee.Name = "txtAgeAnnee";
            txtAgeAnnee.Size = new Size(68, 23);
            txtAgeAnnee.TabIndex = 61;
            txtAgeAnnee.TextChanged += txtAgeAnnee_TextChanged;
            txtAgeAnnee.KeyPress += txtAgeAnnee_KeyPress;
            txtAgeAnnee.Leave += txtAgeAnnee_Leave;
            // 
            // txtRechercher
            // 
            txtRechercher.Location = new Point(549, 30);
            txtRechercher.Name = "txtRechercher";
            txtRechercher.Size = new Size(191, 23);
            txtRechercher.TabIndex = 62;
            txtRechercher.TextChanged += txtRechercher_TextChanged;
            // 
            // lblRechercher
            // 
            lblRechercher.AutoSize = true;
            lblRechercher.Location = new Point(597, 12);
            lblRechercher.Name = "lblRechercher";
            lblRechercher.Size = new Size(66, 15);
            lblRechercher.TabIndex = 63;
            lblRechercher.Text = "Rechercher";
            // 
            // dgvConsultations
            // 
            dgvConsultations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultations.Location = new Point(436, 71);
            dgvConsultations.Name = "dgvConsultations";
            dgvConsultations.Size = new Size(143, 64);
            dgvConsultations.TabIndex = 64;
            dgvConsultations.CellClick += dgvConsultations_CellClick;
            dgvConsultations.CellDoubleClick += dgvConsultations_CellDoubleClick;
            // 
            // btnSuivantConsult
            // 
            btnSuivantConsult.Location = new Point(490, 156);
            btnSuivantConsult.Name = "btnSuivantConsult";
            btnSuivantConsult.Size = new Size(73, 26);
            btnSuivantConsult.TabIndex = 65;
            btnSuivantConsult.Text = "Suivant";
            btnSuivantConsult.UseVisualStyleBackColor = true;
            btnSuivantConsult.Click += btnSuivantConsult_Click;
            // 
            // btnprecedentConsultat
            // 
            btnprecedentConsultat.Location = new Point(411, 154);
            btnprecedentConsultat.Name = "btnprecedentConsultat";
            btnprecedentConsultat.Size = new Size(73, 26);
            btnprecedentConsultat.TabIndex = 66;
            btnprecedentConsultat.Text = "Précédent";
            btnprecedentConsultat.UseVisualStyleBackColor = true;
            btnprecedentConsultat.Click += btnprecedentConsultat_Click;
            // 
            // btnNouvelConsult
            // 
            btnNouvelConsult.Location = new Point(447, 195);
            btnNouvelConsult.Name = "btnNouvelConsult";
            btnNouvelConsult.Size = new Size(73, 26);
            btnNouvelConsult.TabIndex = 67;
            btnNouvelConsult.Text = "New";
            btnNouvelConsult.UseVisualStyleBackColor = true;
            btnNouvelConsult.Click += btnNouvelConsult_Click;
            // 
            // btnSauvegarderConsult
            // 
            btnSauvegarderConsult.Location = new Point(447, 227);
            btnSauvegarderConsult.Name = "btnSauvegarderConsult";
            btnSauvegarderConsult.Size = new Size(73, 26);
            btnSauvegarderConsult.TabIndex = 68;
            btnSauvegarderConsult.Text = "Save";
            btnSauvegarderConsult.UseVisualStyleBackColor = true;
            btnSauvegarderConsult.Click += btnSauvegarderConsult_Click;
            // 
            // lblNaissance
            // 
            lblNaissance.AutoSize = true;
            lblNaissance.Location = new Point(296, 139);
            lblNaissance.Name = "lblNaissance";
            lblNaissance.Size = new Size(100, 15);
            lblNaissance.TabIndex = 69;
            lblNaissance.Text = "Naissance(année)";
            // 
            // lblCateg
            // 
            lblCateg.AutoSize = true;
            lblCateg.Location = new Point(40, 245);
            lblCateg.Name = "lblCateg";
            lblCateg.Size = new Size(81, 15);
            lblCateg.TabIndex = 70;
            lblCateg.Text = "Tranche d'age";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1490, 646);
            Controls.Add(lblCateg);
            Controls.Add(lblNaissance);
            Controls.Add(btnSauvegarderConsult);
            Controls.Add(btnNouvelConsult);
            Controls.Add(btnprecedentConsultat);
            Controls.Add(btnSuivantConsult);
            Controls.Add(dgvConsultations);
            Controls.Add(lblRechercher);
            Controls.Add(txtRechercher);
            Controls.Add(txtAgeAnnee);
            Controls.Add(txtRDV);
            Controls.Add(btnRDV);
            Controls.Add(monthCalendar1);
            Controls.Add(gpRDV);
            Controls.Add(lblRDV);
            Controls.Add(gbBilan);
            Controls.Add(button6);
            Controls.Add(clbBilan);
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
            Controls.Add(txtDateConsult);
            Controls.Add(lblDateConsult);
            Controls.Add(btnCertificat);
            Controls.Add(btnNouveau);
            Controls.Add(comboDiagnostic);
            Controls.Add(comboOrientation);
            Controls.Add(label4);
            Controls.Add(richTbxOrientation);
            Controls.Add(lblResume);
            Controls.Add(lblMotif);
            Controls.Add(button11);
            Controls.Add(btnBilan);
            Controls.Add(btnOrientation);
            Controls.Add(btnOrdonnance);
            Controls.Add(btnNaso);
            Controls.Add(btnClinique);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnDernier);
            Controls.Add(btnSuivant);
            Controls.Add(btnPrecedent);
            Controls.Add(btnPremier);
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
            gbBilan.ResumeLayout(false);
            gbBilan.PerformLayout();
            gpRDV.ResumeLayout(false);
            gpRDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).EndInit();
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
        private Button btnPremier;
        private Button btnPrecedent;
        private Button btnSuivant;
        private Button btnDernier;
        private Button btnEnregistrer;
        private Button btnClinique;
        private Button btnNaso;
        private Button btnOrdonnance;
        private Button btnOrientation;
        private Button btnBilan;
        private Button button11;
        private Label lblMotif;
        private Label lblResume;
        private RichTextBox richTbxOrientation;
        private Label label4;
        private ComboBox comboOrientation;
        private ComboBox comboDiagnostic;
        private Button btnNouveau;
        private Button btnCertificat;
        private Label lblDateConsult;
        private TextBox txtDateConsult;
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
        private CheckedListBox clbBilan;
        private Button button6;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private GroupBox gbBilan;
        private Label lblRDV;
        private GroupBox gpRDV;
        private RadioButton radioRDV6;
        private RadioButton radioRDV5;
        private RadioButton radioRDV4;
        private RadioButton radioRDV3;
        private RadioButton radioRDV2;
        private RadioButton radioRDV1;
        private MonthCalendar monthCalendar1;
        private Button btnRDV;
        private TextBox txtRDV;
        private TextBox txtAgeAnnee;
        private BindingSource bindingSource1;
        private TextBox txtRechercher;
        private Label lblRechercher;
        private DataGridView dgvConsultations;
        private Button btnSuivantConsult;
        private Button btnprecedentConsultat;
        private Button btnNouvelConsult;
        private Button btnSauvegarderConsult;
        private Label lblNaissance;
        private Label lblCateg;
    }
}
