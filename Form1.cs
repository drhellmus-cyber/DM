using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace patient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
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
            tbxDateConsult.Text = vtime;
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
            tbxDateConsult.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

           /// radiobutton
            radioStandard.Checked = true;
            radioJustification.Checked = true;
            radioConfrere.Checked = true;
            radioM.Checked = true;
            txtATCD.Text = "RAS";
            lblDureeMaladie.Visible = false;
            txtDureeMaladie.Visible = false;

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
            int agePatient = int.Parse(txtAge.Text);
            ////  Déterminer le Sender
            string senderName = sender is Button btn ? btn.Name : string.Empty;//string senderName = ((Button)sender).Name;
            string maladieName = gbMaladie.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";
            string motifOrientation = comboOrientation.Text ;
            string detailOrientation = richTbxOrientation.Text;
            string destinataireName = gbDestinataire.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";
            string sexePatient = gbSexe.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked)?
                                     .Text ?? "Aucune sélection";

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
                "btnCourbeTA" => "CourbeTA",
                "btnDemandStandard" => "Demande_standard"
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
                                 text.Span("Cher confrère, permettez-moi de vous adresser le patient sus-nommé pour évaluation pré-anesthésique.\n\n");

                                 text.Span("ATCD : ").Bold();//text.Line($"- {maladiePrincipale}");
                                 //text.Span(txtATCD.Text + "\n");

                                 text.Line("-"+txtATCD.Text );

                                 text.Span("Motif : ").Bold();
                                 text.Span(comboDiagnostic.Text);


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
                             column.Item().PaddingTop(15).Padding(10).Column(text =>
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
                                    text.Span(destinataireName ).Bold().FontSize(11).Underline();

                                    column.Item().PaddingBottom(10);//

                                });

                                column.Item().Text(text =>
                                {
                                    text.Span("Permettez moi de vous adresser le patient sus-nommé, agé de " + agePatient + " ans, pour ");
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

                    }
                    //// Fin select contenu principal

                    // Pied de page global avec numérotation
                    page.Footer().AlignCenter().Text(x =>
                    {

                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });

                    // Pied de page
                    //page.Footer().AlignCenter().Text(x =>
                    //{
                    //   x.CurrentPageNumber();
                    //  x.Span(" / ");
                    // x.TotalPages();
                    //});
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
    }
}


