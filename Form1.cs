using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static patient.Patient;

namespace patient
{
    public partial class Form1 : Form
    {
        public bool False { get; private set; }
        private PatientDbContext _context;
        private BindingSource _bindingSource = new BindingSource();
        //
        private BindingSource _consultationBindingSource = new BindingSource();

        private Patient _patientActuel; // Remplacez "Patient" par le nom de votre classe de modèle
        private bool isGridMaximized = false;

        // Variables pour sauvegarder l'emplacement et la taille d'origine
        private Point originalLocation;
        private System.Drawing.Size originalSize;
        private AnchorStyles originalAnchor;


        public Form1()
        {
            InitializeComponent();
        }

        private void AjouterColonneFormeSiManquante()
        {
            var connection = _context.Database.GetDbConnection();
            var connectionWasClosed = connection.State == ConnectionState.Closed;

            try
            {
                if (connectionWasClosed)
                    connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText =
                    "SELECT COUNT(*) FROM pragma_table_info('OrdonnanceDetails') WHERE name = 'Forme';";

                var colonneExiste = Convert.ToInt32(command.ExecuteScalar()) > 0;
                if (!colonneExiste)
                {
                    command.CommandText =
                        "ALTER TABLE OrdonnanceDetails ADD COLUMN Forme TEXT NOT NULL DEFAULT '';";
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connectionWasClosed)
                    connection.Close();
            }
        }



        //
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 1. Initialiser le DbContext
            _context = new PatientDbContext();

            // Applique les migrations pendantes et crée la BD si nécessaire
            // Nécessite le package Microsoft.EntityFrameworkCore et le using correspondant
            _context.Database.Migrate();
            AjouterColonneFormeSiManquante();

            // Initialiser la DataSource du BindingSource au type Patient
            // Cela évite l'ArgumentException si la DataSource est null au moment
            // de l'ajout des DataBindings.
            _bindingSource.DataSource = typeof(patient.Patient);

            // ====================================================================
            // NOUVEAU : Initialiser le BindingSource Esclave pour les Consultations
            // Il se synchronise automatiquement sur la propriété "Consultations" du Patient courant
            // ====================================================================
            _consultationBindingSource.DataSource = _bindingSource;
            _consultationBindingSource.DataMember = "Consultations"; // Doit correspondre au nom de la ICollection<Consultation> dans votre classe Patient
            _bindingSource.CurrentChanged += BindingSource_CurrentChanged;



            // 2. Configurer les DataBindings des TextBox
            // "Text" est la propriété du TextBox, _bindingSource est la source, et le 3e paramètre est la propriété de votre modèle
            txtNom.DataBindings.Add("Text", _bindingSource, "Nom", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrenom.DataBindings.Add("Text", _bindingSource, "Prenom", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", _bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            //
            // 1. Bouton Masculin
            Binding bindMasculin = new Binding("Checked", _bindingSource, "Genre", true, DataSourceUpdateMode.OnPropertyChanged);
            bindMasculin.Format += (sender, e) => e.Value = (e.Value is Sexe sexeEnBase && sexeEnBase == Sexe.Masculin);
            bindMasculin.Parse += (sender, e) => { if ((bool)e.Value) e.Value = Sexe.Masculin; };
            radioM.DataBindings.Add(bindMasculin);

            // 2. Bouton Féminin
            Binding bindFeminin = new Binding("Checked", _bindingSource, "Genre", true, DataSourceUpdateMode.OnPropertyChanged);
            bindFeminin.Format += (sender, e) => e.Value = (e.Value is Sexe sexeEnBase && sexeEnBase == Sexe.Féminin);
            bindFeminin.Parse += (sender, e) => { if ((bool)e.Value) e.Value = Sexe.Féminin; };
            radioButton1.DataBindings.Add(bindFeminin);
            ///
            lblCateg.DataBindings.Add("Text", _bindingSource, "categorieAge", true, DataSourceUpdateMode.OnPropertyChanged);

            // ====================================================================
            // NOUVEAU : Configurer les DataBindings pour le tableau et les champs Consultation
            // ====================================================================
            // Liaison du DataGridView des consultations (nommé dgvConsultations)
            dgvConsultations.DataSource = _consultationBindingSource;
            // Liaison des champs de saisie/affichage de la consultation en cours
            // (Adaptez "Date", "Diagnostic", "Observations" selon les noms exacts de vos propriétés dans votre classe Consultation)
            txtDateConsult.DataBindings.Add("Text", _consultationBindingSource, "DateConsultation", true, DataSourceUpdateMode.OnPropertyChanged);
            comboDiagnostic.DataBindings.Add("Text", _consultationBindingSource, "Intervention", true, DataSourceUpdateMode.OnPropertyChanged);
            comboOrientation.DataBindings.Add("Text", _consultationBindingSource, "OrientationMotif", true, DataSourceUpdateMode.OnPropertyChanged);
            richTbxOrientation.DataBindings.Add("Text", _consultationBindingSource, "Orientation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtATCD.DataBindings.Add("Text", _consultationBindingSource, "ATCD", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRDV.DataBindings.Add("Text", _consultationBindingSource, "DateRDV", true, DataSourceUpdateMode.OnPropertyChanged);


            // Charger les patients en mémoire, puis préparer un nouvel enregistrement.
            ActualiserListe();
            InitialiserNouvelEnregistrement();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Libérer le contexte à la fermeture
            _context?.Dispose();
            base.OnFormClosing(e);
        }
        private void InitialiserNouvelEnregistrement()
        {
            _patientActuel = new Patient
            {
                Consultations = new List<Consultation>
                {
                    new Consultation()
                }
            };

            // L'objet reste détaché jusqu'au clic sur Enregistrer.
            // Il est néanmoins immédiatement disponible pour les deux BindingSources.
            _bindingSource.DataSource = _patientActuel;
            _consultationBindingSource.Position = 0;
        }
        private void ActualiserListe()
        {

            // Charger uniquement les patients. Les consultations sont chargées
            // à la demande pour le patient actuellement sélectionné.
            _context.Patients.Load();

            // 2. Lier le BindingSource à la collection locale d'Entity Framework
            // C'est cela qui permet de naviguer et de sauvegarder n'importe quel patient !
            _bindingSource.DataSource = _context.Patients.Local.ToBindingList();


            // Charger tous les patients depuis la base SQLite
            //var listePatients = _context.Patients.ToList();
            // _bindingSource.DataSource = listePatients;
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Patient patient || _context is null)
            {
                return;
            }

            // Les patients existants sont suivis par EF ; le nouveau patient
            // créé au démarrage reste détaché et ne nécessite aucun chargement.
            if (_context.Entry(patient).State == EntityState.Detached)
            {
                return;
            }

            _context.Entry(patient).Collection(p => p.Consultations).Load();
            _consultationBindingSource.ResetBindings(false);

            // Lors d'une navigation, sélectionner directement la consultation
            // la plus récente pour éviter une sélection manuelle obligatoire.
            if (_consultationBindingSource.Count > 0)
            {
                _consultationBindingSource.Position = _consultationBindingSource.Count - 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e, string vtime1)
        {
            // Liste des motifs d'orientation
            var motifs = new List<string>
            {
                "Avis et meilleure prise en charge",
                "Échographie cervicale",
                "TDM des rochers",
                "IRM cérébrale",
                "IRM cérébrale, APC et rochers",
                "Prick-test",
                "Autre"
            };
            comboOrientation.DataSource = motifs;

            // Liste des diagnostics / interventions
            var diagnostics = new List<string>
            {
                "Amygdalectomie / Végétations",
                "Végétations",
                "Amygdalectomie",
                "UPPP (Uvélo-palato-pharyngoplastie)",
                "Thyroïdectomie",
                "Septoplastie",
                "Appendice préauriculaire"
            };
            comboDiagnostic.DataSource = diagnostics;

            string vtime = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateConsult.Text = vtime;
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOrientation_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Liste des motifs d'orientation
            var motifs = new List<string>
            {
                "Avis et meilleure prise en charge",
                "Échographie cervicale",
                "TDM des rochers",
                "IRM cérébrale",
                "IRM cérébrale, APC et rochers",
                "Prick-test",
                "Autre"
            };
            comboOrientation.DataSource = motifs;

            // Liste des diagnostics / interventions
            var diagnostics = new List<string>
            {
                "Amygdalectomie / Végétations",
                "Végétations",
                "Amygdalectomie",
                "UPPP (Uvélo-palato-pharyngoplastie)",
                "Thyroïdectomie",
                "Septoplastie",
                "Appendice préauriculaire"
            };
            comboDiagnostic.DataSource = diagnostics;

            // string vtime = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateConsult.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // ATCD, checklistboxatcd et textatcd
            var atcdList = new List<string>
            {
                "Diabète",
                "Hypertension",
                "Asthme",
                "Allergies",
                "Maladies cardiaques",
                "Maladies pulmonaires",
                "Maladies rénales",
                "Maladies hépatiques",
                "Maladies neurologiques",
                "Autres"
            };
            checkedListBoxATCD.DataSource = atcdList;

            //// Demande Standard

            var demandestandard = new List<string>
            {
                "TLT(face)",
                "Rx de cavum(profil)",
                "Rx des OPN(profil)",
                "ECG",
                "Rx des sinus (NMP+NFP)",
                "Rx du Rachis Cervicale(F+P)",
                "Audiogramme",
                "Incidence de Gosserez",
               //// "Sérologie HBS",
               // "Sérologie HCV"
            };

            comboDemandeStandard.DataSource = demandestandard;


            ///// Bilans
            ///////////////////////0///////1/////////////2/////3////////4////5///
            string stringBilan = "FNS,Glycémie à jeun,HGPO,Hb glyqué,Uree,Créat," +// 0-5
                                                                                   //6//7////8//////9/////////10///////
                "TP,TCK,INR,Fibrinogene,Willebrand," +// 6-10 /5
                                                      //11///12///13/14//15//16///17//18//19//20/
                "CholT,HDL,LDL,TG,ASAT,ALAT,Ggt,PAL,BT,BRD," +// 11-20/9
                                                              //21//22//23//24//25//26///27////////28////////29///////30/////////40//41//42//
                "Alb,EPP,IEP,TSH,FT3,FT4,Anti-TPO,Anti-RTSH,Calcémie,Phosphorémie,HIV,HBS,HCV," +
                //43//44//45///////////////////46/47//48//49////50
                "TPHA,VDRL,Groupage sanguin Rh,VS,CRP,ASLO,Iono,Labstix";
            string[] tabBilan = stringBilan.Split(',');


            clbBilan.DataSource = tabBilan;



            /// radiobutton
            radioStandard.Checked = true;
            radioJustification.Checked = true;
            radioConfrere.Checked = true;
            //radioM.Checked = true;
            //txtATCD.Text = "RAS";
            lblDureeMaladie.Visible = false;
            txtDureeMaladie.Visible = false;
            ////binding

        }

        private void validate_Click(object sender, EventArgs e)
        {
            List<string> selectedATCDs = new List<string>();
            foreach (var item in checkedListBoxATCD.CheckedItems)
            {
                selectedATCDs.Add(item.ToString());
            }
            txtATCD.Clear();
            foreach (var atcd in selectedATCDs)
            {
                //MessageBox.Show(atcd);
                txtATCD.Text += atcd + Environment.NewLine; // "; ";

            }
        }

        private void Maladie_click(object sender, EventArgs e)
        {
            RadioButton boutonClique = (RadioButton)sender;
            if (boutonClique.Checked)
            {
                switch (boutonClique.Name)
                {
                    case "radioJustification":
                    case "radioReprise":
                        lblDureeMaladie.Visible = false;
                        txtDureeMaladie.Visible = false;
                        break;
                    case "radioArretTravail":
                    case "radioArretScolaire":
                        lblDureeMaladie.Visible = true;
                        txtDureeMaladie.Visible = true;
                        break;

                }
            }
        }

        private void btnPrOp_Click(object sender, EventArgs e)
        {
            // 1. Récupération de vos données de formulaire
            string nomPatient = txtNom.Text;
            string prenomPatient = txtPrenom.Text;
            //int agePatient = int.Parse(txtAge.Text);
            int agePatient = int.TryParse(txtAge.Text, out int res) ? res : 0;
            ////  Déterminer le Sender
            string senderName = sender is Button btn ? btn.Name : string.Empty;//string senderName = ((Button)sender).Name;
            string maladieName = gbMaladie.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";
            string motifOrientation = comboOrientation.Text;
            string detailOrientation = richTbxOrientation.Text;
            string destinataireName = gbDestinataire.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";
            string sexePatient = gbSexe.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";
            bool isMale = sexePatient == "Male";
            var elementsBilan = clbBilan.CheckedItems
                                        .Cast<object>()
                                        .Select(item => item.ToString())
                                        .ToList();
            //• Nouveau-né : De 0 à 28 jours.• Nourrisson: De 29 jours à 2 ans• Enfant: De 2 à 11 ou 12 ans• Adolescent: De 12 à 17 ans révolus.

            bool isChild = agePatient < 12; // Détermine si le patient est un enfant (moins de 12 ans)
                                            //bool estMasculin = rbMasculin.Checked; // Ou comboSexe.Text == "Masculin"
                                            // bool isNRS = agePatient < 2; // Nouveau-né ou nourrisson (moins de 2 an)

            // Définition des accords dynamiques
            // string leLa = estMasculin ? "le" : "la";
            //string patiente = estMasculin ? "patient" : "patiente";
            //string agee = estMasculin ? "âgé" : "âgée";
            //string ilElle = estMasculin ? "il" : "elle";
            //string oriente = estMasculin ? "orienté" : "orientée";

            // 2. Obligatoire : Définir la licence Community (gratuite)
            QuestPDF.Settings.License = LicenseType.Community;
            // QuestPDF.Drawing.FontManager.DiscoverSystemFonts();
            // QuestPDF.Settings.UseSystemFonts = true;(ou)

            // 3. Définir le chemin de sortie (Enregistrement sur le Bureau)
            //string cheminBureau = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string cheminFichier = Path.Combine(cheminBureau, $"Fiche_{nomPatient}.pdf");
            string documentName = senderName switch
            {
                "btnPrOp" => "PreOp",
                "button11" => maladieName.Replace(" ", "_"), // Remplace les espaces par des underscores pour le nom du fichier
                "btnOrientation" => "Orientation",
                "btnCourbeTA" => "Demande_CourbeTA",
                "btnDemandStandard" => "Demande_standard",
                "btnBilan" => "Demande_Bilan",
                "btnRDV" => "RDV",
            };
            string cheminFichierFinal = GestionnaireFichiers.ObtenirCheminEnregistrementPatient(nomPatient, prenomPatient, documentName);

            // 4. Génération de la structure du document
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(35);
                    page.Size(PageSizes.A5);// Format ordonnance A5
                                            //page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // En-tête
                    // page.Header()
                    //   .Text("FICHE ANESTHESIE")
                    //  .SemiBold().FontSize(20).FontColor(Colors.Blue.Darken3);
                    // En-tête global répété ou géré par page
                    page.Header().Column(header =>
                    {
                        header.Item().AlignCenter().Text(cnfg.enteteEtabl.ToUpper()).SemiBold().FontSize(14).FontColor(Colors.Blue.Darken3);
                        //// header.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                        //// espace entre l'entête et le contenu principal
                        header.Item().PaddingTop(10).Row(row =>
                        {
                            // Bloc gauche : Infos de l'établissement ou du médecin
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text($"Nom : {nomPatient} ").Bold().FontSize(11);
                                col.Item().Text($"Prénom : {prenomPatient} ").Bold().FontSize(11);
                                col.Item().Text($"Age : {agePatient}").FontSize(11);


                            });

                            // Bloc droit : Date d'émission

                            row.ConstantItem(120).AlignRight().Column(col =>
                            {
                                col.Item().Text("Service d'ORL & CCF").FontSize(10).AlignRight();
                                col.Item().Text($"{cnfg.enteteEndroit} le : {DateTime.Now:dd/MM/yyyy}").FontSize(10).SemiBold();
                            });
                        });
                        ////

                        header.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                    });


                    ///// Début Select contenu principal

                    switch (senderName)
                    {

                        case "btnPrOp":

                            // Contenu principal
                            // CORPS DU DOCUMENT (Les 3 pages imbriquées)
                            page.Content().PaddingVertical(20).Column(column =>
                            {
                                // ==========================================
                                // PAGE 1 : ORIENTATION
                                // ==========================================
                                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                                column.Item().PaddingBottom(10);

                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Consultation pré-anesthesie").Bold().FontSize(11).Underline();

                                    column.Item().PaddingBottom(10);//

                                });

                                column.Item().Text(text =>
                                {
                                    text.Span("Cher confrère, permettez-moi de vous adresser ");
                                    if (isMale)
                                    {
                                        text.Span("le patient sus-nommé ");
                                    }
                                    else
                                    {
                                        text.Span("la patiente sus-nommée ");
                                    }
                                    text.Span("pour évaluation pré-anesthésique.\n\n");
                                });


                                column.Item().Column(x =>
                                {
                                    x.Item().Row(row =>
                                    {


                                        // AutoItem prend uniquement la largeur du texte "ATCD : "
                                        row.AutoItem().Text("ATCD : ").Bold();

                                        // RelativeItem occupe tout l'espace restant pour le détail
                                        row.RelativeItem().PaddingLeft(5).Text(txtATCD.Text);

                                    });


                                });
                                column.Item().Column(x =>
                                {
                                    x.Item().Row(row =>
                                    {

                                        // AutoItem prend uniquement la largeur du texte "Motif : "
                                        row.AutoItem().Text("Motif : ").Bold();

                                        // RelativeItem occupe tout l'espace restant pour le détail
                                        row.RelativeItem().PaddingLeft(5).Text(comboDiagnostic.Text);
                                    });


                                });
                                // Vous pouvez ajouter d'autres détails ici...

                                // On force le passage à la page suivante
                                column.Item().PageBreak();

                                // ==========================================
                                // PAGE 2 : BILAN PRE-OPÉRATOIRE
                                // ==========================================
                                column.Item().PaddingBottom(10).Text("Prière de faire le bilan biologique :").Underline().Bold().FontSize(11).FontColor(Colors.Blue.Darken3);
                                string chaineBilan = "FNS,Glycémie à jeun,Urée,Créatinine,TP,TCK,Groupage sanguin, Sérologie HIV,     //     HBS,    //    HCV";
                                string[] bilanItems = chaineBilan.Split(',');
                                column.Item().PaddingLeft(10).Text(text =>
                                {
                                    text.ParagraphSpacing(4);
                                    int compt = 1;
                                    foreach (var item in bilanItems)
                                    {
                                        text.Span($"{compt}- {item}\n");
                                        compt++;
                                    }


                                });


                                // On force le passage à la page suivante
                                column.Item().PageBreak();

                                // ==========================================
                                // PAGE 3 : TLT      
                                // ==========================================
                                column.Item().PaddingTop(10).Text("Priére de faire :").Underline().Bold().FontSize(12).FontColor(Colors.Blue.Darken3);
                                column.Item().PaddingTop(25).Padding(10).Column(text =>
                                {
                                    //rdvBox.Item().Text($"Patient convoqué : {nomPatient} {prenomPatient}").SemiBold();
                                    // rdvBox.Item().PaddingTop(5).Text("Veuillez vous présenter au secrétariat muni de ce document ainsi que de votre bilan médical récent.");
                                    text.Item().Text("-TLT(face)");

                                });
                                if (radioECG.Checked)
                                {
                                    column.Item().PageBreak();
                                    // ECG
                                    column.Item().PaddingTop(10).Text("Priére de faire :").Underline().Bold().FontSize(12).FontColor(Colors.Blue.Darken3);
                                    column.Item().PaddingTop(40).Padding(10).Text("-ECG");
                                }
                                ;
                            });
                            break;

                        case "button11":

                            //" Je sousigné, Dr HELLAOUI, certifie avoir récu et examiné le patient sus-nommé ce jour, " 
                            //Choisir([maladie];"Justification";"Arrêt de travail";"Arrêt scolaire";"Reprise")
                            //Choisir([maladie];", au niveau de la consultation d'ORL.";"et déclare que son état de santé nécessite un repos de
                            //" & [Formulaire]![duree_travail] & " jours.";"et déclare que son état de santé nécessite un repos de " & [Formulaire]![duree_travail]
                            //& " jours.";" et je déclare qu'il peut reprendre son travail à partir d'aujourdhui.")

                            page.Content().PaddingVertical(20).Column(column =>
                            {
                                // ==========================================
                                // JUSTIFICATION / ARRET DE TRAVAIL / ARRET SCOLAIRE / REPRISE
                                // ==========================================
                                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                                column.Item().PaddingBottom(10);

                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span(maladieName).Bold().FontSize(11).Underline();

                                    column.Item().PaddingBottom(10);//

                                });

                                column.Item().Text(text =>
                                {
                                    text.Span("Je sousigné, " + cnfg.enteteMedTraitant + " , certifie avoir récu et examiné le patient sus-nommé ce jour,");

                                    text.Span(maladieName switch
                                    {
                                        "Justification" => "au niveau de la consultation d'ORL. ",
                                        "Arrêt de travail" => "et déclare que son état de santé nécessite un repos de ", // + txtDureeMaladie.Text + " jours.",
                                        "Arrêt scolaire" => "et déclare que son état de santé nécessite un repos de ", // + txtDureeMaladie.Text + " jours.",
                                        "Reprise" => "et je déclare qu'il peut reprendre son travail à partir d'aujourdhui."
                                    });
                                    if (maladieName == "Arrêt de travail" || maladieName == "Arrêt scolaire")
                                    {

                                        text.Span(txtDureeMaladie.Text).Bold(); // <-- Uniquement le nombre en gras
                                        text.Span(" jours.");
                                    }
                                    text.Span("\n \n \n  Dont certificat ");




                                });

                            });
                            break;
                        case "btnOrientation":

                            // Orientation cher confrère

                            page.Content().PaddingVertical(20).Column(column =>
                            {
                                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                                column.Item().PaddingBottom(10);

                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("cher " + destinataireName).Bold().FontSize(11).Underline();

                                    column.Item().PaddingBottom(10);//

                                });

                                column.Item().Text(text =>
                                {
                                    if (isMale)
                                    {
                                        text.Span("Permettez moi de vous adresser le patient sus-nommé, agé de " + agePatient + " ans, pour ");
                                    }
                                    else
                                    {
                                        text.Span("Permettez moi de vous adresser la patiente sus-nommée, agée de " + agePatient + " ans, pour ");
                                    }

                                    //text.Span("Permettez moi de vous adresser le patient sus-nommé, agé de " + agePatient + " ans, pour ");

                                    text.Span(motifOrientation).Underline();
                                    text.Span(". \n \n \n  ");
                                    text.Span("Motif ").Bold();
                                    text.Span(": " + detailOrientation + "\n \n \n  ");



                                    text.Span("Confraternellement ");




                                });

                            });





                            break;
                        case "btnCourbeTA":
                            //courbe TA

                            page.Content().PaddingVertical(20).Column(column =>
                            {
                                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                                column.Item().PaddingBottom(10);

                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Courbe de TA").Bold().FontSize(11).Underline();

                                    column.Item().PaddingBottom(20);//

                                });
                                column.Item().Table(table =>
                                {
                                    // Définition des colonnes (3 colonnes de largeurs égales)
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(); // Date
                                        columns.RelativeColumn(); // Matin
                                        columns.RelativeColumn(); // Soir
                                    });

                                    // En-tête du tableau
                                    table.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Date").Bold().AlignCenter();
                                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Matin (Repos)").Bold().AlignCenter();
                                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Soir (Repos)").Bold().AlignCenter();
                                    });

                                    // Remplissage dynamique des 10 lignes avec nos dates générées

                                    List<string> datesSuivi = new List<string>();
                                    DateTime dateDebut = DateTime.Today; // Prend automatiquement la date du jour (10/10/2026)

                                    for (int i = 0; i < 10; i++)
                                    {
                                        datesSuivi.Add(dateDebut.AddDays(i).ToString("dd/MM/yyyy"));
                                    }
                                    foreach (string date in datesSuivi)
                                    {
                                        // Colonne Date
                                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Text(date).AlignCenter();

                                        // Colonne Matin (Vide pour l'écriture manuscrite)
                                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Text(".................. / ..................").AlignCenter().FontColor(Colors.Grey.Medium);

                                        // Colonne Soir (Vide pour l'écriture manuscrite)
                                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Text(".................. / ..................").AlignCenter().FontColor(Colors.Grey.Medium);
                                    }
                                });



                            });

                            //});


                            break;

                        case "btnDemandStandard":

                            // demande standard 
                            page.Content().PaddingVertical(20).Column(column =>
                            {

                                column.Item().PaddingTop(10).Text("Priére de faire :").Underline().Bold().FontSize(12).FontColor(Colors.Blue.Darken3);
                                column.Item().PaddingTop(40).Padding(10).Text("-" + comboDemandeStandard.Text);


                            });
                            break;
                        case "btnBilan":
                            //// Bilans

                            page.Content().PaddingVertical(20).Column(column =>
                            {

                                column.Item().PaddingTop(10).Text("Priére de faire :").Underline().Bold().FontSize(12).FontColor(Colors.Blue.Darken3);



                                //column.Item().PaddingTop(40).Padding(10).Text("-" + comboDemandeStandard.Text);
                                column.Item().Column(listColumn =>
                                {
                                    listColumn.Spacing(5);
                                    if (elementsBilan.Count == 0)
                                    {
                                        listColumn.Item().Text("Aucun élément sélectionné!").Italic().FontColor(Colors.Grey.Medium);
                                    }
                                    else
                                    {
                                        foreach (var element in elementsBilan)
                                        {
                                            listColumn.Item().Row(row =>
                                            {
                                                row.ConstantItem(20).Text("-").FontColor(Colors.Green.Darken2).Bold();
                                                row.RelativeItem().Text(element);
                                            });
                                        }
                                    }
                                });
                                column.Item().PaddingTop(1, Unit.Centimetre).Text("Merci");


                            });



                            break;
                        case "btnRDV":
                            //// Carte de RDV


                            page.Content().PaddingVertical(20).Column(column =>
                            {

                                column.Item().PaddingTop(10).Text(x =>
                                {
                                    x.Span("RDV le : ").Bold().FontSize(12);

                                    x.Span(txtRDV.Text).Underline().Bold().FontSize(12);
                                    x.Span(" à 8h:00 ").Bold().FontSize(12);
                                });

                                //column.Item().PaddingTop(40).Padding(10).Text($"numéro dossier: {_patientActuel.Id}");// donne 0;
                                //il faut récupérer l'id du patient actuel dans la base de données


                            });

                            break;

                    }
                    //// Fin select contenu principal

                    // Pied de page global avec numérotation
                    // page.Footer().AlignCenter().Text(x =>
                    // {

                    ////      x.Span("Page ");
                    //      x.CurrentPageNumber();
                    ////       x.Span(" / ");
                    //       x.TotalPages();
                    // });

                    // Pied de page
                    //page.Footer().AlignCenter().Text(x =>
                    //{
                    //   x.CurrentPageNumber();
                    //  x.Span(" / ");
                    // x.TotalPages();
                    //});
                    // À gauche : Lieu, date et heure
                    page.Footer().Row(row =>
                    {
                        // À gauche : Lieu, date et heure
                        string dateEtHeure = DateTime.Now.ToString("dd/MM/yyyy à HH:mm");
                        row.RelativeItem().AlignLeft().Text($"{cnfg.enteteEndroit}, le {dateEtHeure}");

                        // À droite : Numérotation des pages
                        row.RelativeItem().AlignRight().Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        });
                    });
                });
            })
            .GeneratePdf(cheminFichierFinal); // Crée le fichier
                                              // 2. L'afficher directement dans le compagnon au lieu de GeneratePdf()  //        await document.ShowInCompanionAsync();

            // 5. Message de confirmation à l'utilisateur
            MessageBox.Show("Le PDF a été généré avec succès dans le dossier prévu.");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(cheminFichierFinal)
            {
                UseShellExecute = true
            });
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void gbMaladie_Enter(object sender, EventArgs e)
        {

        }

        private void bilan_clic(object sender, EventArgs e)
        {
            RadioButton boutonClique = (RadioButton)sender;
            List<int> listBilan = new List<int>(); listBilan.Clear();
            if (boutonClique.Checked)
            {
                switch (boutonClique.Name)
                {
                    case "radioButton2":
                        listBilan.AddRange(new int[] { 0, 1, 3, 4, 5, 6, 7, 11, 24, 26, 29, 30, 48, 49 });

                        break;
                    case "radioButton3":
                        listBilan.AddRange(new int[] { 0, 22, 46, 47, 48 });
                        break;
                    case "radioButton4":
                        listBilan.AddRange(new int[] { 4, 5, 50 });
                        break;
                    case "radioButton5":
                        listBilan.AddRange(new int[] { 15, 16, 17, 18, 19, 20 });
                        break;
                    case "radioButton6":
                        listBilan.AddRange(new int[] { 24, 25, 26, 27, 28, 29, 30 });
                        break;
                    case "radioButton7":
                        listBilan.AddRange(new int[] { 40, 41, 42, 43, 44 });
                        break;
                    case "radioButton8":
                        listBilan.Clear();
                        break;

                }

                for (int i = 0; i < clbBilan.Items.Count; i++)
                {
                    if (listBilan.Contains(i))
                    {
                        clbBilan.SetItemChecked(i, true);
                    }
                    else
                    {
                        clbBilan.SetItemChecked(i, False);
                    }
                }
            }

        }

        private void RDV_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton boutonClique = (RadioButton)sender;
            DateTime rdv = DateTime.Now.AddDays(7); // Date par défaut : 7 jours après la date actuelle
            if (boutonClique.Checked)
            {
                switch (boutonClique.Name)
                {
                    case "radioRDV1":
                        rdv = DateTime.Now.AddDays(7);
                        break;
                    case "radioRDV2":
                        rdv = DateTime.Now.AddDays(15);
                        break;
                    case "radioRDV3":
                        rdv = DateTime.Now.AddDays(30);
                        break;
                    case "radioRDV4":
                        rdv = DateTime.Now.AddDays(60);
                        break;
                    case "radioRDV5":
                        rdv = DateTime.Now.AddDays(90);
                        break;
                    case "radioRDV6":
                        rdv = DateTime.Now.AddDays(120);
                        break;


                }
                txtRDV.Text = CalculerProchainLundi(rdv).ToString("dd/MM/yyyy");
                monthCalendar1.RemoveAllBoldedDates();
                monthCalendar1.AddBoldedDate(CalculerProchainLundi(rdv));
                monthCalendar1.UpdateBoldedDates();
                monthCalendar1.SetDate(CalculerProchainLundi(rdv));
            }

        }
        private DateTime CalculerProchainLundi(DateTime date)
        {
            // Calcule le nombre de jours jusqu'au prochain lundi (0 si c'est déjà lundi)
            int joursAAjouter = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(joursAAjouter);
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Autorise uniquement les chiffres (0-9) et la touche Retour arrière (BackSpace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Bloque le caractère en disant qu'il a déjà été géré
                e.Handled = true;
            }
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtPrenom_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                txtPrenom.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrenom.Text.ToLower());
            }
        }

        private void txtAgeAnnee_Leave(object sender, EventArgs e)
        {
            txtAge.Text = (DateTime.Now.Year - int.Parse(txtAgeAnnee.Text)).ToString();
        }

        private void txtAgeAnnee_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAgeAnnee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Bloque le caractère en disant qu'il a déjà été géré
                e.Handled = true;

            }

        }

        private void btnClinique_Click(object sender, EventArgs e)
        {
            //
            var patientActuel = _bindingSource.Current as Patient;
            var consultationActuelle = _consultationBindingSource.Current as Consultation;
            if (_context.Entry(patientActuel).State == EntityState.Detached)
            {
                // En ajoutant le patient, EF Core va automatiquement suivre la consultation 
                // présente dans sa liste locale 'Consultations'
                _context.Patients.Add(patientActuel);
            }
            consultationActuelle.Patient = patientActuel;

            if (patientActuel != null && consultationActuelle != null)
            {
                // 2. Ouvrir la clinique en lui passant les données (propagation du DbContext)
                using (clinique f2 = new clinique(patientActuel, consultationActuelle, _context))
                {
                    // ShowDialog bloque l'accès à Form1 tant que Form2 est ouverte
                    if (f2.ShowDialog() == DialogResult.OK)
                    {
                        // De retour sur Form1, le tableau et les liaisons se mettent à jour
                        _consultationBindingSource.ResetCurrentItem();
                        // Optionnel : Vous pouvez sauvegarder automatiquement en base ici 
                        // après la fermeture de Form2 si vous le souhaitez :
                        _context.SaveChanges();

                        MessageBox.Show("La consultation a été complétée et enregistrée !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient et une consultation active avant d'ouvrir la suite.");
            }

            //
            // 1. Récupération des données des TextBox de Form1
            //string nomSaisi = txtNom.Text;
            //string prenomSaisi = txtPrenom.Text;
            //string ageSaisi = txtAge.Text;

            // 2. Création de l'instance de Form2 en lui passant les données via les ()
            //Form2 nouvelleFenetre = new Form2(nomSaisi, prenomSaisi, ageSaisi);

            // 3. Affichage de Form2
            //nouvelleFenetre.Show();

            // Optionnel : Si vous voulez masquer Form1, ajoutez : this.Hide();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. FORCE WinForms à valider le texte tapé et à l'envoyer vers l'objet C#
                this.Validate();
                _bindingSource.EndEdit();

                // 2. Vérification que l'objet existe bien
                var patientActuel = (Patient)_bindingSource.Current;
                if (patientActuel == null)
                {
                    MessageBox.Show("Aucun patient n'est sélectionné à enregistrer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Validation humaine rapide pour éviter d'enregistrer des lignes vides
                if (string.IsNullOrWhiteSpace(patientActuel.Nom))
                {
                    MessageBox.Show("Le champ 'Nom' est obligatoire !", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Détection automatique : Nouveau vs Existant
                // Si l'ID est égal à 0 (valeur par défaut d'un int), c'est un NOUVEL enregistrement
                if (patientActuel.Id == 0)
                {
                    _context.Patients.Add(patientActuel);
                }
                else
                {
                    // Pour un ancien, on s'assure qu'EF Core le suit s'il a été détaché
                    if (_context.Entry(patientActuel).State == EntityState.Detached)
                    {
                        _context.Patients.Update(patientActuel);
                    }
                }

                // 5. Sauvegarde physique dans le fichier SQLite
                _context.SaveChanges();

                // 6. Rafraîchir l'affichage sans perdre le patient qui vient d'être enregistré
                ActualiserListe();

                // ActualiserListe() rebinde la liste et sélectionne par défaut son premier élément.
                // Repositionner explicitement le BindingSource sur le patient sauvegardé.
                int positionPatientEnregistre = _bindingSource.IndexOf(patientActuel);
                if (positionPatientEnregistre >= 0)
                {
                    _bindingSource.Position = positionPatientEnregistre;
                    _patientActuel = patientActuel;
                }

                if (_consultationBindingSource.Count > 0)
                {
                    _consultationBindingSource.Position = _consultationBindingSource.Count - 1;
                }

                MessageBox.Show("Patient enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si EF Core bloque (ex: violation de clé, type incorrect), ce message vous dira EXACTEMENT pourquoi !
                MessageBox.Show($"Erreur interne : {ex.Message}\n\nDétails : {ex.InnerException?.Message}",
                                "Erreur de Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            InitialiserNouvelEnregistrement();

            // Optionnel : Mettre le focus sur le premier champ
            txtNom.Focus();
        }

        private bool BasculerVersLaListePourNaviguer(bool allerAuDernier = false)
        {
            // Au démarrage, le BindingSource pointe directement sur le nouveau patient.
            // Il faut le rebinder sur la liste des patients existants avant de naviguer.
            if (_bindingSource.DataSource is not Patient)
            {
                return false;
            }

            ActualiserListe();

            if (_bindingSource.Count == 0)
            {
                // La base est vide : conserver le formulaire prêt pour un nouvel ajout.
                InitialiserNouvelEnregistrement();
                return true;
            }

            if (allerAuDernier)
            {
                _bindingSource.MoveLast();
            }
            else
            {
                _bindingSource.MoveFirst();
            }

            return true;
        }

        private void btnPremier_Click(object sender, EventArgs e)
        {
            if (BasculerVersLaListePourNaviguer())
            {
                return;
            }

            _bindingSource.MoveFirst();
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (BasculerVersLaListePourNaviguer(allerAuDernier: true))
            {
                return;
            }

            _bindingSource.MovePrevious();
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (BasculerVersLaListePourNaviguer())
            {
                return;
            }

            _bindingSource.MoveNext();
        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
            if (BasculerVersLaListePourNaviguer(allerAuDernier: true))
            {
                return;
            }

            _bindingSource.MoveLast();
        }

        private void txtRechercher_TextChanged(object sender, EventArgs e)
        {
            // string recherche = txtRechercher.Text.Trim().ToLower();

            //  if (string.IsNullOrEmpty(recherche))
            //  {
            // Si la recherche est vide, on réaffiche tout
            //      ActualiserListe();
            //   }
            //   else
            //   {
            // Filtrage en mémoire avec LINQ sur le Nom ou le Prénom
            //     var resultats = _context.Patients
            //        .Where(p => p.Nom.ToLower().Contains(recherche) || p.Prenom.ToLower().Contains(recherche))
            //       .ToList();

            //    _bindingSource.DataSource = resultats;
            //  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // helper local function pour accès sûr aux champs
            string Field(string[] arr, int index) => (index >= 0 && index < arr.Length) ? arr[index] : string.Empty;

            var lignes = File.ReadAllLines("C:\\Users\\SUD_TEC\\Documents\\patient.csv").Skip(1);
            foreach (var ligne in lignes)
            {
                var data = ligne.Split(';');

                // parse sécurisé de la date
                DateTime? dateConsultation = null;
                var rawDate = Field(data, 4);
                if (!string.IsNullOrWhiteSpace(rawDate) && DateTime.TryParse(rawDate, out var dt))
                    dateConsultation = dt;

                var nouveauPatient = new Patient
                {
                    Nom = Field(data, 1),
                    Prenom = Field(data, 2),
                    Age = int.TryParse(Field(data, 3), out var age) ? age : 0,
                    Consultations = new List<Consultation>
                    {
                        new Consultation
                        {
                            // si la propriété DateConsultation est non-nullable, GetValueOrDefault fournit DateTime.MinValue quand absent
                            DateConsultation = dateConsultation.GetValueOrDefault(),
                           // Observation = Field(data, 5) + "\n" + Field(data, 6),
                            Orientation = Field(data, 8) + "\n" + Field(data, 9),
                            Naso = Field(data, 11),
                            Certificat = Field(data, 13),
                        }
                    }

                };
                _context.Patients.Add(nouveauPatient);
            }
            _context.SaveChanges();
        }

        private void btnSuivantConsult_Click(object sender, EventArgs e)
        {
            _consultationBindingSource.MoveNext();
        }

        private void btnprecedentConsultat_Click(object sender, EventArgs e)
        {
            _consultationBindingSource.MovePrevious();
        }

        private void btnNouvelConsult_Click(object sender, EventArgs e)
        {
            // Vérifier d'abord qu'un patient est bien sélectionné
            if (_bindingSource.Current != null)
            {
                // Ajoute une consultation vide liée automatiquement à ce patient
                _consultationBindingSource.AddNew();

                // Pré-remplir la date du jour par défaut pour la nouvelle consultation
                txtDateConsult.Text = DateTime.Now.ToString();

                comboOrientation.Focus();
            }
            else
            {
                MessageBox.Show("Veuillez d'abord sélectionner ou ajouter un patient.");
            }
        }

        private void btnSauvegarderConsult_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Valider le contrôle graphique en cours de saisie (applique le dernier texte tapé)
                this.Validate();

                // 2. Confirmer la fin de l'édition dans les deux BindingSources
                _consultationBindingSource.EndEdit();
                _bindingSource.EndEdit();

                // 3. Envoyer toutes les modifications (Patients et Consultations) vers SQLite
                _context.SaveChanges();

                MessageBox.Show("La consultation a été enregistrée avec succès !",
                                "Enregistrement réussi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Exception vraieErreur = ex;
                while (vraieErreur.InnerException != null)
                {
                    vraieErreur = vraieErreur.InnerException;
                }

                // On affiche le vrai message technique de SQLite
                MessageBox.Show($"Vrai problème détecté :\n\n{vraieErreur.Message}",
                                "Détails de l'erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                // MessageBox.Show($"Erreur lors de l'enregistrement de la consultation : {ex.Message}",
                //               "Erreur de sauvegarde",
                //             MessageBoxButtons.OK,
                //           MessageBoxIcon.Error);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtRDV.Text = e.Start.ToString("dd/MM/yyyy");
        }

        private void gbSexe_Enter(object sender, EventArgs e)
        {

        }

        private void btnCertificat_Click(object sender, EventArgs e)
        {
            var patientActuel = _bindingSource.Current as Patient;
            var consultationActuelle = _consultationBindingSource.Current as Consultation;

            if (_context.Entry(patientActuel).State == EntityState.Detached)
            {
                // En ajoutant le patient, EF Core va automatiquement suivre la consultation 
                // présente dans sa liste locale 'Consultations'
                _context.Patients.Add(patientActuel);
            }
            consultationActuelle.Patient = patientActuel;
            if (patientActuel != null && consultationActuelle != null)
            {
                // 2. Ouvrir la clinique en lui passant les données (propagation du DbContext)
                using (CertificatORL f2 = new CertificatORL(patientActuel, consultationActuelle, _context))
                {
                    // ShowDialog bloque l'accès à Form1 tant que Form2 est ouverte
                    if (f2.ShowDialog() == DialogResult.OK)
                    {

                        _consultationBindingSource.ResetCurrentItem();

                        _context.SaveChanges();

                        MessageBox.Show("La consultation a été complétée et enregistrée !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient et une consultation active avant d'ouvrir la suite.");
            }

        }

        private void btnOrdonnance_Click(object sender, EventArgs e)
        {
            var patientActuel = _bindingSource.Current as Patient;
            var consultationActuelle = _consultationBindingSource.Current as Consultation;

            if (_context.Entry(patientActuel).State == EntityState.Detached)
            {
                // En ajoutant le patient, EF Core va automatiquement suivre la consultation 
                // présente dans sa liste locale 'Consultations'
                _context.Patients.Add(patientActuel);
            }
            consultationActuelle.Patient = patientActuel;


            if (patientActuel != null && consultationActuelle != null)
            {
                // 2. Ouvrir la clinique en lui passant les données (propagation du DbContext)
                using (OrdonnanceFormulaire f2 = new OrdonnanceFormulaire(patientActuel, consultationActuelle, _context))
                {
                    // ShowDialog bloque l'accès à Form1 tant que Form2 est ouverte
                    if (f2.ShowDialog() == DialogResult.OK)
                    {

                        _consultationBindingSource.ResetCurrentItem();

                        _context.SaveChanges();

                        MessageBox.Show("La consultation a été complétée et enregistrée !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient et une consultation active avant d'ouvrir la suite.");
            }
        }



        private void dgvConsultations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On n'agit que si le tableau n'est pas déjà agrandi
            if (!isGridMaximized)
            {
                // Sauvegarde de l'état initial
                originalLocation = dgvConsultations.Location;
                originalSize = dgvConsultations.Size;
                originalAnchor = dgvConsultations.Anchor;

                // Désactivation temporaire des ancres pour éviter les conflits de redimensionnement
                dgvConsultations.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                // Configuration de la taille "Maximisée" (ex: laisse une marge de 20 pixels tout autour du formulaire)
                dgvConsultations.Location = new Point(20, 20);
                dgvConsultations.Size = new System.Drawing.Size(this.ClientSize.Width - 40, this.ClientSize.Height - 40);

                // Amène le tableau au tout premier plan pour couvrir les autres contrôles (TextBox, labels...)
                dgvConsultations.BringToFront();

                // Force les colonnes à ajuster leur largeur pour occuper tout le nouvel espace disponible
                dgvConsultations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                isGridMaximized = true;
            }
        }

        private void dgvConsultations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // On n'agit que si le tableau est déjà agrandi
            if (isGridMaximized)
            {
                // Restauration de la position et de la taille d'origine
                dgvConsultations.Location = originalLocation;
                dgvConsultations.Size = originalSize;
                dgvConsultations.Anchor = originalAnchor;

                // Restauration du mode d'affichage des colonnes d'origine
                dgvConsultations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                isGridMaximized = false;
            }
        }

        private void btnNaso_Click(object sender, EventArgs e)
        {
            var patientActuel = _bindingSource.Current as Patient;
            var consultationActuelle = _consultationBindingSource.Current as Consultation;

            if (_context.Entry(patientActuel).State == EntityState.Detached)
            {
                // En ajoutant le patient, EF Core va automatiquement suivre la consultation 
                // présente dans sa liste locale 'Consultations'
                _context.Patients.Add(patientActuel);
            }
            consultationActuelle.Patient = patientActuel;


            if (patientActuel != null && consultationActuelle != null)
            {
                // 2. Ouvrir la clinique en lui passant les données (propagation du DbContext)
                using (ParaClinique f2 = new ParaClinique(patientActuel, consultationActuelle, _context))
                {
                    // ShowDialog bloque l'accès à Form1 tant que Form2 est ouverte
                    if (f2.ShowDialog() == DialogResult.OK)
                    {

                        _consultationBindingSource.ResetCurrentItem();

                        _context.SaveChanges();

                        MessageBox.Show("La consultation a été complétée et enregistrée !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient et une consultation active avant d'ouvrir la suite.");
            }
        }
    }
}


//
/*private void btnSupprimer_Click(object sender, EventArgs e)
{
    // Vérifier s'il y a bien un élément sélectionné
    if (_bindingSource.Current != null)
    {
        var confirmation = MessageBox.Show(
            "Êtes-vous sûr de vouloir supprimer cet enregistrement ?", 
            "Confirmation", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question
        );

        if (confirmation == DialogResult.Yes)
        {
            // Supprime l'élément courant de l'affichage local
            _bindingSource.RemoveCurrent();
            
            // Note : Pour rendre cette suppression définitive en base de données immédiatement,
            // vous pouvez appeler la méthode de sauvegarde ici :
            SauvegarderModifications();
        }
    }
}
*/
/*   _bindingSource.EndEdit();
    
    var patientActuel = (Patient)_bindingSource.Current;

    if (_context.Entry(patientActuel).State == EntityState.Detached)
    {
        _context.Patients.Add(patientActuel);
    }

    _context.SaveChanges();
    
    // Forcer le DataGridView à se rafraîchir graphiquement
    dgvPatients.Refresh();
    MessageBox.Show("Patient enregistré.");
*/



