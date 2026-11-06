using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static patient.Patient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;


namespace patient
{
    public partial class Naso : Form
    {
        private Consultation _consultation;
        private PatientDbContext _context;
        private Patient _patient;
        public Naso(Consultation consultation, PatientDbContext context)
        {
            InitializeComponent();

            _consultation = consultation;
            // Valider et stocker le contexte reçu (fail fast si null)
            _patient = consultation.Patient ?? throw new ArgumentNullException(nameof(consultation.Patient), "Le patient associé à la consultation ne peut pas être null.");
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Récupération du contexte existant

            if (consultation.Patient != null)
            {
                lblNom.Text = consultation.Patient.Nom;
                lblPrenom.Text = consultation.Patient.Prenom;
                lblAge.Text = consultation.Patient.Age.ToString();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            rtNaso.DataBindings.Add("Text", _consultation, "Naso", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void Naso_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string determinant = (_patient.Genre == Sexe.Masculin) ? "le patient" : "la patiente";
            string accordAge = (_patient.Genre == Sexe.Masculin) ? "âgé" : "âgée";
            var naso = new System.Text.StringBuilder();
            string configTabs = @"\tx1000\tx2100";// @"\tx1500\tx3200";

            naso.Append(@"{\rtf1\ansi\deff0 ");
            naso.Append($"La nasofibroscopie faite ce jour retrouve: \\par\\par ");
            //naso.Append(@$"\b {_patient.Nom} {_patient.Prenom}\b0  {accordAge} fait ce jour retrouve : \par\par ");
            //naso.Append(@"dont l'examne ORL du jour objective: \par\par");
            naso.Append(@$"\b Fosses nasales: \b0\par {configTabs} \tab\ul FN droite\ul0 :\tab  -Muqueuse sainne, pas de sécretions,\par ");
            naso.Append($@"{configTabs}\tab\tab\tab -Méats libres,\par ");
            naso.Append(@$" {configTabs} \tab \ul FN gauche\ul0 :\tab  - IDEM.\par\par ");
            naso.Append(@$"\b Cavum: \b0\par {configTabs} \tab \tab  -Paroi postéro-sup libre,\par ");
            //naso.Append($@"{configTabs}\tab\tab\tab -Paroi postéro-sup libre,\par ");
            naso.Append($@"{configTabs}\tab\tab\tab -Fossettes de Rosenmuller libre.\par\par ");
            naso.Append(@$"\b Etage glotto-sus-glottique: \b0\par");
            naso.Append($@"{configTabs}\tab -Base de la langue + Vallécule libre,\par ");
            naso.Append(@$"{configTabs} \tab   -Sinus piriformes libres,\par\par ");
            naso.Append($@"{configTabs}\tab -Bandes ventriculaires + margelle laryngé normales,\par ");
            naso.Append(@$"{configTabs} \tab   -CV, commissure ant, aryténoides sans anomalies morphologique,\par\par ");
            naso.Append(@$"{configTabs} \tab   -Les 2 CV sont de mobilté conservé, aussi bien à la respiration qu'à la phonation ,\par\par ");
            naso.Append(@$"{configTabs} \tab   -Partie visibles de l'étage sous-glotttique est sans anomalies.\par\par ");

            //certificat.AppendLine();
            //certificat.AppendLine();
            //certificat.AppendLine();
            naso.AppendLine(@"\par\par\tab\tab\tab Cordialement");
            naso.Append("}");
            rtNaso.Rtf = naso.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Ferme la forme en validant
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nomPatient = _patient.Nom;
            string prenomPatient = _patient.Prenom;
            int agePatient = _patient.Age;

            QuestPDF.Settings.License = LicenseType.Community;

            string documentName = "Naso";
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

                        column.Item().PaddingVertical(20).Text("Examen ORL").Bold().FontSize(16).Underline().AlignCenter().FontColor(Colors.Blue.Medium);//Ordonnance//certificat


                       
                        column.Item().Text(text=>
                        {
                           text.Span(rtNaso.Text).FontSize(11);
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
