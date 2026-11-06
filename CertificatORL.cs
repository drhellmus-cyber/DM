using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static patient.Patient;

namespace patient
{
    public partial class CertificatORL : Form
    {
        private Patient _patient;
        private Consultation _consultation;
        private PatientDbContext _context;
        public CertificatORL(Patient patient, Consultation consultation, PatientDbContext context)
        {
            InitializeComponent();
            _patient = patient;
            _consultation = consultation;
            // Propager et valider le contexte reçu depuis Form1
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 1. Remplir les champs informatifs (Lecture seule) provenant de Form1
            lblNom.Text = _patient.Nom;
            lblPrenom.Text = _patient.Prenom;
            lblAge.Text = _patient.Age.ToString();
            lblDateConsult.Text = _consultation.DateConsultation.ToShortDateString();
            //lblPremierePartie.Text = _consultation.Diagnostic; // Exemple d'élément déjà saisi

            // 2. Lier les TextBox restants au même objet Consultation
            //// // Ainsi, tout ce qui est écrit ici modifie directement l'objet de Form1 !
            rtCertificat.DataBindings.Add("Text", _consultation, "Certificat", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtSignesFlle.DataBindings.Add("Text", _consultation, "SignesFlle", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtClinique.DataBindings.Add("Text", _consultation, "Observation", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtNaso.DataBindings.Add("Text", _consultation, "Naso", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtDGC.DataBindings.Add("Text", _consultation, "Dgc", true, DataSourceUpdateMode.OnPropertyChanged);


        }

        private void CertificatORL_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string determinant = (_patient.Genre == Sexe.Masculin) ? "le patient" : "la patiente";
            string accordAge = (_patient.Genre == Sexe.Masculin) ? "âgé" : "âgée";
            var certificat = new System.Text.StringBuilder();

            certificat.Append(@"{\rtf1\ansi\deff0 ");
            certificat.Append($"Je sousigné, {cnfg.enteteMedTraitant}, certifie avoir réçu et  examiné ce jour , {determinant} ");
            certificat.Append(@$"\b {_patient.Nom} {_patient.Prenom}\b0  {accordAge} de {_patient.Age} ans, ");
            certificat.Append("dont l'examne ORL complet avec  audiogramme est sans particularité notable.");
            certificat.AppendLine();
            certificat.AppendLine();
            certificat.AppendLine();
            certificat.AppendLine("Dont certificat");
            certificat.Append("}");
            rtCertificat.Rtf = certificat.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Ferme la forme en validant
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string determinant = (_patient.Genre == Sexe.Masculin) ? "le patient" : "la patiente";
            string accordAge = (_patient.Genre == Sexe.Masculin) ? "âgé" : "âgée";
            var certificat = new System.Text.StringBuilder();
            string configTabs = @"\tx1000\tx2100";// @"\tx1500\tx3200";

            certificat.Append(@"{\rtf1\ansi\deff0 ");
            certificat.Append($"Je sousigné, {cnfg.enteteMedTraitant}, certifie avoir réçu et  examiné ce jour , {determinant} ");
            certificat.Append(@$"\b {_patient.Nom} {_patient.Prenom}\b0  {accordAge} de {_patient.Age} ans, ");
            certificat.Append(@"dont l'examne ORL du jour objective: \par\par");
            certificat.Append(@$"\b Otosopie: \b0\par {configTabs} \tab \ul à droite\ul0 :\tab  - CAE libre,\par ");
            certificat.Append($@"{configTabs}\tab\tab\tab - Tympans d'aspect et de coloration normale,\par ");
            certificat.Append(@$" {configTabs} \tab \ul à gauche\ul0 :\tab  - IDEM.\par\par ");
            certificat.Append(@$"\b Rhinoscopie anérieur: \b0\par {configTabs} \tab \ul à droite\ul0 :\tab  -Fosse nasale libre,\par ");
            certificat.Append($@"{configTabs}\tab\tab\tab -Muqueuse d'aspect  noramle,\par ");
            certificat.Append($@"{configTabs}\tab\tab\tab -Méats libres, pas de secretions,\par ");
            certificat.Append(@$"{configTabs} \tab \ul à gauche\ul0 :\tab  - IDEM.\par\par ");
            certificat.Append(@$"\b Cavité buccale: \b0\par");
            certificat.Append($@"{configTabs}\tab\tab\tab -Muqueuse oropharyngé saine,\par ");
            certificat.Append(@$"{configTabs} \tab \tab\tab  -Loges amygdaliennes propre.\par\par ");
            certificat.Append(@$"\b Examen du cou: \b0\par");
            certificat.Append($@"{configTabs}\tab\tab\tab -boitier laryngé mobile et crépitant,\par ");
            certificat.Append(@$"{configTabs} \tab \tab\tab  -Les aires gonglionnaires sont libres<br>.\par\par ");

            //certificat.AppendLine();
            //certificat.AppendLine();
            //certificat.AppendLine();
            certificat.AppendLine(@"\par\par\tab\tab\tab Dont certificat");
            certificat.Append("}");
            rtCertificat.Rtf = certificat.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nomPatient = _patient.Nom;
            string prenomPatient = _patient.Prenom;
            int agePatient = _patient.Age;

            QuestPDF.Settings.License = LicenseType.Community;

            string documentName = "Certificat";
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

                           // row.RelativeItem().Column(col =>
                            //{
                             //   col.Item().Text($"Nom : {nomPatient} ");//.Bold().FontSize(11);
                              //  col.Item().Text($"Prénom : {prenomPatient} ");//.Bold().FontSize(11);
                               // col.Item().Text($"Age : {agePatient}");//.FontSize(11);


                            //});

                            // Bloc droit : Date d'émission

                            row.ConstantItem(120).AlignCenter().Column(col =>
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

                        column.Item().PaddingVertical(20).Text("Certificat Médical").Bold().FontSize(16).Underline().AlignCenter().FontColor(Colors.Blue.Medium);//Ordonnance//certificat



                        column.Item().Text(text =>
                        {
                            text.Span(rtCertificat.Text).FontSize(11);
                        });

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
                            // row.RelativeItem().Text("Griffe et Signature").Italic().AlignRight().FontSize(9);
                        });
                        // Un espace vide important (55 unités) pour signer librement sous le texte de signature
                        // column.Item().PaddingBottom(55).Element(x => x.Height(0));

                        // 2. La ligne horizontale est déplacée ici, juste au-dessus des informations de bas de page
                        column.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten1);

                        // À gauche : Lieu, date et heure
                        column.Item().Row(row =>
                        {
                            string dateEtHeure = DateTime.Now.ToString("dd/MM/yyyy 'à' HH:mm", System.Globalization.CultureInfo.InvariantCulture);
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
