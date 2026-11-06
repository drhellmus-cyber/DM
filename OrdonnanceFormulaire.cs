using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static patient.Patient;
using static QuestPDF.Helpers.Colors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace patient
{
    public partial class OrdonnanceFormulaire : Form
    {
        private Patient _patient;
        private Consultation _consultation;
        private PatientDbContext _context;
        private Ordonnance _ordonnance;
        // Le BindingSource sert de pont dynamique entre la liste C# et le DataGridView
        private BindingSource _detailsBindingSource = new BindingSource();


        public OrdonnanceFormulaire()
        {
            InitializeComponent();
        }

        public OrdonnanceFormulaire(Patient patient, Consultation consultation, PatientDbContext context)

        {
            InitializeComponent();
            _patient = patient;
            _consultation = consultation;
            // Propager et valider le contexte reçu depuis Form1
            _context = context ?? throw new ArgumentNullException(nameof(context));


            if (_consultation.Id > 0)
            {
                // Charge l'ordonnance liée à la consultation
                _context.Entry(_consultation).Reference(c => c.Ordonnance).Load();
                _ordonnance = _consultation.Ordonnance;

                if (_ordonnance != null)
                {
                    // Charge les détails de l'ordonnance en incluant explicitement l'objet Medicament pour chaque ligne
                    _context.Entry(_ordonnance)
                            .Collection(o => o.OrdonnanceDetails)
                            .Query()
                            .Include(d => d.Medicament)
                            .Load();
                }
            }
            // Si l'ordonnance n'existe pas encore
            if (_ordonnance == null)
            {
                _ordonnance = new Ordonnance
                {
                    Consultation = _consultation,
                    DateOrd = DateTime.Today,
                    OrdonnanceDetails = new List<OrdonnanceDetail>()
                };
                _context.Ordonnances.Add(_ordonnance);
            }

            // Configuration graphique
            InitialiserComposantsOrdonnance();
            // --- CONFIGURATION DE L'INTERFACE ---
            // ConfigurerComposantsMedicaments();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_patient == null || _consultation == null)
            {
                return;
            }

            // 1. Remplir les champs informatifs (Lecture seule) provenant de Form1
            lblNom.Text = _patient.Nom;
            lblPrenom.Text = _patient.Prenom;
            lblAge.Text = _patient.Age.ToString();
            lblDateConsult.Text = _consultation.DateConsultation.ToShortDateString();
            //lblPremierePartie.Text = _consultation.Diagnostic; // Exemple d'élément déjà saisi

            // 2. Lier les TextBox restants au même objet Consultation
            //// // Ainsi, tout ce qui est écrit ici modifie directement l'objet de Form1 !
            //rtCertificat.DataBindings.Add("Text", _consultation, "Certificat", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtSignesFlle.DataBindings.Add("Text", _consultation, "SignesFlle", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtClinique.DataBindings.Add("Text", _consultation, "Observation", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtNaso.DataBindings.Add("Text", _consultation, "Naso", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtDGC.DataBindings.Add("Text", _consultation, "Dgc", true, DataSourceUpdateMode.OnPropertyChanged);


        }
        private void InitialiserComposantsOrdonnance()
        {
            // 1. Remplissage de la ComboBox avec votre table des médicaments disponibles
            cmbMedicaments.DataSource = _context.Medicaments.ToList();
            cmbMedicaments.DisplayMember = "Nom"; // Propriété 'Nom' de votre classe Medicament
            cmbMedicaments.ValueMember = "Id";

            cmbMedicaments.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedicaments.AutoCompleteSource = AutoCompleteSource.ListItems;

            // 2. Liaison de la liste générique au DataGridView via un BindingList réactif
            var bindingList = new BindingList<OrdonnanceDetail>(_ordonnance.OrdonnanceDetails);
            _detailsBindingSource.DataSource = bindingList;
            dgvOrdonnanceDetails.DataSource = _detailsBindingSource;

            // 3. Nettoyage visuel des colonnes système et ID de la grille
            MaskerColonnesInutiles();
            // Charger les modèles d'ordonnances disponibles en base de données
            cmbOrdonnancesTypes.DataSource = _context.OrdonnanceTypes.ToList();
            cmbOrdonnancesTypes.DisplayMember = "NomModele";
            cmbOrdonnancesTypes.ValueMember = "Id";
            cmbOrdonnancesTypes.SelectedIndex = -1; // Pour ne rien sélectionner par défaut
                                                    // --- ACTIVATION DYNAMIQUE DU PANEL PÉDIATRIQUE ---
            int cat = _patient.Age;
            if (cat < 16)
            {
                panelPediatrie.Visible = true;
                label18.Text = $"Pds théorique : {_patient.Age * 2 + 8}";
                textBox1.Text = (_patient.Age * 2 + 8).ToString();

                //label12.Text = "";//pds * 50//choix Cp//=IF(G4>1750;1000;IF(G4>850;500;IF(G4>438;250;125)))
                //double pdsDosage = Convert.ToDouble(textBox1.Text)*50;

                //label13.Text = "";//
                // label14.Text = "";//choix nbre//= IF(H4*3<=G4+G4*10/100;3;2)


            }


            else
            {
                panelPediatrie.Visible = false; // Masqué pour les adultes/adolescents
            }
        }
        private void MaskerColonnesInutiles()
        {
            string[] colonnesAMasquer = { "Id", "OrdonnanceId", "Ordonnance", "MedicamentId", "Medicament" };
            foreach (var col in colonnesAMasquer)
            {
                if (dgvOrdonnanceDetails.Columns[col] != null)
                    dgvOrdonnanceDetails.Columns[col].Visible = false;
            }

            // On peut réordonner ou renommer la colonne dynamique si besoin
            if (dgvOrdonnanceDetails.Columns["NomMedicament"] != null)
            {
                dgvOrdonnanceDetails.Columns["NomMedicament"].HeaderText = "Médicament";
                dgvOrdonnanceDetails.Columns["NomMedicament"].DisplayIndex = 0; // Met le nom en première colonne
            }
        }

        private void Ordonnance_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _detailsBindingSource.EndEdit(); // Valide les saisies directes du tableau

                // --- SÉCURISATION 1 : LE PATIENT ---
                // On s'assure que le patient est suivi par le contexte.
                if (_patient != null && _patient.Id == 0)
                {
                    if (!_context.Patients.Local.Contains(_patient))
                    {
                        _context.Patients.Add(_patient);
                    }
                }
                else if (_patient != null)
                {
                    // Si le patient existe déjà mais a été détaché du contexte
                    _context.Patients.Attach(_patient);
                }

                // --- SÉCURISATION 2 : LA CONSULTATION ---
                // On lie explicitement le PatientId au cas où il serait à 0 ou non propagé
                if (_patient != null)
                {
                    _consultation.Patient = _patient;
                    _consultation.PatientId = _patient.Id;
                }

                // Si la consultation est nouvelle, on l'ajoute au contexte
                if (_consultation.Id == 0)
                {
                    if (!_context.Consultations.Local.Contains(_consultation))
                    {
                        _context.Consultations.Add(_consultation);
                    }
                }
                else
                {
                    _context.Consultations.Attach(_consultation);
                }

                // --- SÉCURISATION 3 : L'ORDONNANCE ET SES DÉTAILS ---
                _ordonnance.Consultation = _consultation;
                if (_consultation.Id > 0)
                {
                    _ordonnance.ConsultationId = _consultation.Id;
                }

                foreach (var detail in _ordonnance.OrdonnanceDetails)
                {
                    // Empêche EF Core d'essayer d'insérer à nouveau le médicament dans sa table
                    if (detail.MedicamentId > 0)
                    {
                        detail.Medicament = null;
                    }
                }

                _context.SaveChanges(); // Enregistre l'ordonnance et ses détails associés

                MessageBox.Show("Ordonnance mise à jour avec succès.");
                this.DialogResult = DialogResult.OK; // Ferme la forme en validant
                this.Close();
            }
            catch (Exception ex)
            {
                string messageInterne = ex.InnerException != null ? ex.InnerException.Message : "Pas d'erreur interne";

                MessageBox.Show($"Erreur principale : {ex.Message}\n\nErreur interne : {messageInterne}");
                //MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicament medSelectionne = cmbMedicaments.SelectedItem as Medicament;

            if (medSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament dans la liste.");
                return;
            }

            // Évite d'ajouter deux fois le même médicament sur l'ordonnance en cours
            if (_ordonnance.OrdonnanceDetails.Any(d => d.MedicamentId == medSelectionne.Id))
            {
                MessageBox.Show("Ce médicament figure déjà sur cette ordonnance.");
                return;
            }

            // Utilisation de votre constructeur personnalisé ! Il copie automatiquement les "Suggest"
            var nouveauDetail = new OrdonnanceDetail(medSelectionne);

            // Ajout au BindingSource : Met à jour la List<> ET rafraîchit le DataGridView en temps réel
            _detailsBindingSource.Add(nouveauDetail);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dgvOrdonnanceDetails.CurrentRow != null)
            {
                // Récupère l'objet lié à la ligne sélectionnée
                var detailASupprimer = dgvOrdonnanceDetails.CurrentRow.DataBoundItem as OrdonnanceDetail;

                if (detailASupprimer != null)
                {
                    // Si la ligne existe déjà en base de données, on informe EF de la supprimer
                    if (detailASupprimer.Id > 0)
                    {
                        _context.OrdonnanceDetails.Remove(detailASupprimer);
                    }

                    // Retire de l'affichage et de la liste locale
                    _detailsBindingSource.Remove(detailASupprimer);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string texteSaisi = cmbMedicaments.Text.Trim();

            if (string.IsNullOrWhiteSpace(texteSaisi))
            {
                MessageBox.Show("Veuillez saisir ou sélectionner un médicament.");
                return;
            }

            Medicament medAUtiliser = null;

            // Cas A : Le médecin a sélectionné un médicament existant dans la liste
            if (cmbMedicaments.SelectedItem is Medicament medSelectionne && medSelectionne.Nom == texteSaisi)
            {
                medAUtiliser = medSelectionne;
            }
            else
            {
                // Cas B : Le médecin a écrit un texte libre. On vérifie si ce nom existe quand même en BD
                medAUtiliser = _context.Medicaments.FirstOrDefault(m => m.Nom.ToLower() == texteSaisi.ToLower());

                // Si le médicament n'existe vraiment pas, on le crée "à la volée"
                if (medAUtiliser == null)
                {
                    medAUtiliser = new Medicament
                    {
                        Nom = texteSaisi,
                        DosageSuggest = txtDosage.Text,       // Utilise les champs de saisie actuels

                        Forme = txtForme.Text,
                        FrequenceSuggest = txtFrequence.Text, // comme valeurs suggérées par défaut
                        DureeSuggest = txtDuree.Text,
                        RqSuggest = txtRq.Text
                    };

                    // On l'ajoute au contexte pour qu'il soit créé dans SQLite au SaveChanges
                    _context.Medicaments.Add(medAUtiliser);
                    _context.SaveChanges(); // Optionnel : Sauvegarde immédiate pour obtenir un ID valide tout de suite

                    // Mettre à jour la ComboBox pour inclure ce nouveau médicament dans la liste future
                    ActualiserListeComboBox();
                }
            }

            // Éviter les doublons dans l'ordonnance actuelle
            if (_ordonnance.OrdonnanceDetails.Any(d => d.MedicamentId == medAUtiliser.Id && medAUtiliser.Id > 0))
            {
                MessageBox.Show("Ce médicament figure déjà sur cette ordonnance.");
                return;
            }

            // Utilisation de votre constructeur personnalisé
            var nouveauDetail = new OrdonnanceDetail(medAUtiliser);

            // Sécurisation pour EF Core
            nouveauDetail.Medicament = null;
            nouveauDetail.MedicamentId = medAUtiliser.Id;

            // Ajout et rafraîchissement automatique de la grille
            _detailsBindingSource.Add(nouveauDetail);
        }
        private void ActualiserListeComboBox()
        {
            string texteActuel = cmbMedicaments.Text;
            cmbMedicaments.DataSource = _context.Medicaments.ToList();
            cmbMedicaments.Text = texteActuel;
            cmbMedicaments.SelectionStart = texteActuel.Length;
        }

        private void btnAppliquerModele_Click(object sender, EventArgs e)
        {
            if (cmbOrdonnancesTypes.SelectedItem is not OrdonnanceType modeleSelectionne)
            {
                MessageBox.Show("Veuillez sélectionner un modèle d'ordonnance type.");
                return;
            }

            // Charger explicitement les détails du modèle et leurs médicaments associés
            _context.Entry(modeleSelectionne)
                    .Collection(m => m.Details)
                    .Query()
                    .Include(d => d.Medicament)
                    .Load();

            if (modeleSelectionne.Details == null || modeleSelectionne.Details.Count == 0)
            {
                MessageBox.Show("Ce modèle ne contient aucun médicament.");
                return;
            }

            // Optionnel : Demander confirmation si le tableau contient déjà des lignes
            if (_ordonnance.OrdonnanceDetails.Count > 0)
            {
                var result = MessageBox.Show("Voulez-vous remplacer les médicaments actuels par ce modèle ?",
                                             "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // On vide l'ordonnance actuelle
                    _detailsBindingSource.Clear();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Injecter les lignes du modèle type dans l'ordonnance du patient
            foreach (var itemType in modeleSelectionne.Details)
            {
                // Éviter les doublons si on a choisi d'accumuler
                if (_ordonnance.OrdonnanceDetails.Any(d => d.MedicamentId == itemType.MedicamentId))
                    continue;

                var nouveauDetail = new OrdonnanceDetail
                {
                    MedicamentId = itemType.MedicamentId,
                    Medicament = itemType.Medicament,
                    Dosage = itemType.Dosage,
                    Forme = itemType.Forme,
                    Frequence = itemType.Frequence,
                    Duree = itemType.Duree,
                    Rq = itemType.Rq
                };

                // Ajout au BindingSource pour mettre à jour la grille instantanément
                _detailsBindingSource.Add(nouveauDetail);
            }
        }

        private void btnEnregistrerCommeModele_Click(object sender, EventArgs e)
        {
            if (_ordonnance.OrdonnanceDetails.Count == 0)
            {
                MessageBox.Show("L'ordonnance actuelle est vide.");
                return;
            }

            // Fenêtre rapide pour demander le nom du modèle
            string nomModele = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nom de ce modèle d'ordonnance :", "Nouveau Modèle Type", "");

            if (string.IsNullOrWhiteSpace(nomModele)) return;

            var nouveauModele = new OrdonnanceType { NomModele = nomModele };

            foreach (var detail in _ordonnance.OrdonnanceDetails)
            {
                nouveauModele.Details.Add(new OrdonnanceTypeDetail
                {
                    MedicamentId = detail.MedicamentId,
                    Dosage = detail.Dosage,
                    Forme = detail.Forme,
                    Frequence = detail.Frequence,
                    Duree = detail.Duree,
                    Rq = detail.Rq
                });
            }

            _context.OrdonnanceTypes.Add(nouveauModele);
            _context.SaveChanges();

            MessageBox.Show("Modèle d'ordonnance type enregistré !");

            // Rafraîchir la ComboBox
            cmbOrdonnancesTypes.DataSource = _context.OrdonnanceTypes.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label13.Text = "-- mg";
                label14.Text = "-- fois";
                return;
            }

            if (double.TryParse(textBox1.Text, out double poids))
            {
                // 1. Calcul du dosage avec un switch expression (très lisible)
                int ChoixForme = (poids * 50) switch
                {
                    > 1750 => 1000,
                    > 850 => 500,
                    > 438 => 250,
                    _ => 125 // Le signe '_' remplace le 'else' (valeur par défaut)
                };

                // 2. Calcul du nombre de fois avec un opérateur ternaire (plus compact qu'un if/else)
                int nbreFoisParJour = (ChoixForme * 3 <= (poids * 50) * 1.1) ? 3 : 2;

                // 3. Affichage
                label13.Text = $"{ChoixForme} mg";
                label14.Text = $"{nbreFoisParJour} fois par jour";
            }
            else
            {
                label13.Text = "Poids invalide";
                label14.Text = "-- fois";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label16.Text = "-- mg";
                label17.Text = "-- fois";
                return;
            }
            if (double.TryParse(textBox2.Text, out double dosage) && double.TryParse(textBox1.Text, out double poids))
            {

                // 1. Calcul du dosage avec un switch expression (très lisible)
                int ChoixForme = (poids * dosage) switch
                {
                    > 1750 => 1000,
                    > 850 => 500,
                    > 438 => 250,
                    _ => 125 // Le signe '_' remplace le 'else' (valeur par défaut)
                };

                // 2. Calcul du nombre de fois avec un opérateur ternaire (plus compact qu'un if/else)
                int nbreFoisParJour = (ChoixForme * 3 <= (poids * dosage) * 1.1) ? 3 : 2;

                // 3. Affichage
                label16.Text = $"{ChoixForme} mg";
                label17.Text = $"{nbreFoisParJour} fois par jour";
            }
            else
            {
                label16.Text = "Dosage invalide";
                label17.Text = "-- fois";
            }
        }

        private void btnImprimerOrdonnance_Click(object sender, EventArgs e)
        {

            string nomPatient = _patient.Nom;
            string prenomPatient = _patient.Prenom;
            int agePatient = _patient.Age;

            QuestPDF.Settings.License = LicenseType.Community;

            string documentName = "Ordonnance";
            string cheminFichierFinal = GestionnaireFichiers.ObtenirCheminEnregistrementPatient(nomPatient, prenomPatient, documentName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin((float)1.5, Unit.Centimetre); //page.Margin(35);
                    page.Size(PageSizes.A5);// Format ordonnance A5
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));
                    //page.DefaultTextStyle(x => x.FontSize(10));

                    // En-tête

                    page.Header().Column(header =>
                    {
                        header.Item().AlignCenter().Text(cnfg.enteteEtabl.ToUpper()).SemiBold().FontSize(14).FontColor(Colors.Blue.Darken3);
                        header.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);
                        //// espace entre l'entête et le contenu principal
                        header.Item().PaddingTop(10).Row(row =>
                        {

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text($"Nom : {nomPatient} ");//.Bold().FontSize(11);
                                col.Item().Text($"Prénom : {prenomPatient} ");//.Bold().FontSize(11);
                                col.Item().Text($"Age : {agePatient}");//.FontSize(11);


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
                    page.Content().PaddingVertical(10).Column(column =>
                    {

                        column.Item().PaddingVertical(20).Text("ORDONNANCE").Bold().FontSize(16).Underline().AlignCenter().FontColor(Colors.Blue.Medium);


                        // --- TABLEAU DES MÉDICAMENTS (QuestPDF .Table) ---


                        // Liste des médicaments au format épuré (Lignes sans bordures de tableaux)
                        column.Item().Column(medsColumn =>
                        {
                            int index = 1;
                            foreach (var detail in _ordonnance.OrdonnanceDetails)
                            {

                                string nomMed = detail.Medicament != null ? detail.Medicament.Nom : _context.Medicaments.Find(detail.MedicamentId)?.Nom ?? "Médicament";

                                // Ligne du haut : Numéro + Médicament (à gauche) -------- QSP (à droite)
                                medsColumn.Item().PaddingBottom(12).Column(groupColumn =>
                                {
                                    groupColumn.Item().Row(row =>
                                    {
                                        // Numérotation ou puce discrète
                                        row.ConstantItem(25).Text($"{index}/").Bold().FontColor(Colors.Blue.Medium);

                                        // Détails du traitement
                                        row.RelativeItem().Text(nomMed).Bold().FontSize(12);
                                        // 3. Mention QSP poussée tout à fait vers la droite au même niveau
                                        if (!string.IsNullOrEmpty(detail.Rq))
                                        {
                                            string qsp = detail.Rq.ToLower() switch
                                            {
                                                "jour" or "jours" or "mois" => $"QSP {detail.Duree} {detail.Rq}",
                                                _ => $"{detail.Duree} {detail.Rq}"
                                            };
                                            row.ConstantItem(100).AlignRight().Text(qsp).Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                                        }
                                        // Ligne du dessous : La posologie décalée au même niveau que le texte du médicament
                                        if (!string.IsNullOrEmpty(detail.Dosage))
                                        {
                                            groupColumn.Item().PaddingLeft(25).PaddingTop(4).Text($"{detail.Dosage} {detail.Forme} {detail.Frequence}/j")
                                            .Italic().FontColor(Colors.Grey.Darken3).FontSize(10);
                                        }
                                    });
                                });
                                index++;
                            }
                        });
                        /* column.Item().Table(table =>
                         {
                             // Définition des colonnes
                             table.ColumnsDefinition(columns =>
                             {
                                 columns.ConstantColumn(30);  // N°
                                 columns.RelativeColumn(3);   // Médicament
                                 columns.RelativeColumn(2);   // Dosage / Posologie
                                 columns.RelativeColumn(2);   // Durée & Fréquence
                             });

                             // Entête du tableau
                             table.Header(header =>
                             {
                                 header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("N°").Bold();
                                 header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Médicament").Bold();
                                 header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Posologie").Bold();
                                 header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Durée / Rq").Bold();
                             });

                             // Remplissage dynamique des lignes
                             int compteur = 1;
                             foreach (var detail in _ordonnance.OrdonnanceDetails)
                             {
                                 // Récupérer le nom du médicament de secours si l'objet de navigation est nul
                                 string nomMed = detail.Medicament != null ? detail.Medicament.Nom : _context.Medicaments.Find(detail.MedicamentId)?.Nom ?? "Médicament";

                                 table.Cell().BorderBottom(0.5f, Unit.Point).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{compteur++}");
                                 table.Cell().BorderBottom(0.5f, Unit.Point).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(nomMed).Bold();
                                 table.Cell().BorderBottom(0.5f, Unit.Point).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{detail.Dosage} ({detail.Frequence})");
                                 table.Cell().BorderBottom(0.5f, Unit.Point).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{detail.Duree} {detail.Rq}");
                             }
                         });
                        */
                    });

                    /* page.Footer().Row(row =>
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
                     */
                    // --- PIED DE PAGE ---
                    page.Footer().Column(column =>
                    {
                        
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text("Griffe et Signature").Italic().AlignRight().FontSize(9);
                        });
                        // Un espace vide important (55 unités) pour signer librement sous le texte de signature
                        column.Item().PaddingBottom(55).Element(x => x.Height(0));

                        // 2. La ligne horizontale est déplacée ici, juste au-dessus des informations de bas de page
                        column.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten1);

                        // À gauche : Lieu, date et heure
                        column.Item().Row(row =>
                        {
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
                });

            })
            .GeneratePdf(cheminFichierFinal); // Crée le fichier

            MessageBox.Show("Le PDF a été généré avec succès dans le dossier prévu.");
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo(cheminFichierFinal)
                {
                    UseShellExecute = true
                });
        }
    }
}
