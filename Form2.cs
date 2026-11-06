using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Indispensable pour .Where() et .ToList()
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; // Assurez-vous d'avoir ce using pour EF Core

namespace patient
{
    public partial class Form2 : Form
    {
        private Consultation _consultation;
        private PatientDbContext _context; // On récupère un accès au contexte pour lire la table
        private List<SigneOrl> _bilanOrl; // Cette liste sera maintenant remplie par la BDD

        private readonly string[] _echelleIntensite = { "0 (Absent)", "+ (Léger)", "++ (Modéré)", "+++ (Sévère)" };
        private const string CleNotesLibres = "Notes additionnelles : ";

        // Le constructeur reçoit la consultation ET le contexte de la base de données
        public Form2(Consultation consultation, PatientDbContext context)
        {
            InitializeComponent();
            _consultation = consultation;
            // Valider et stocker le contexte reçu (fail fast si null)
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Récupération du contexte existant

            if (consultation.Patient != null)
            {
                lblNom.Text = consultation.Patient.Nom;
                lblPrenom.Text = consultation.Patient.Prenom;
                lblAge.Text = consultation.Patient.Age.ToString();
            }

            // Configuration du conteneur visuel
            flowLayoutPanelPrincipal.Dock = DockStyle.None;
            flowLayoutPanelPrincipal.Location = new Point(15, 80);
            flowLayoutPanelPrincipal.Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - 240);
            flowLayoutPanelPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelPrincipal.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelPrincipal.AutoScroll = true;

            // ====================================================================
            // 1. DYNAMIQUE : Charger les signes directement depuis votre table SQLite
            // ====================================================================
            _bilanOrl = _context.SignesOrl.ToList();

            // 2. Restaurer l'historique et cocher les cases correspondantes
            RestaurerSignesExistants();

            // 3. Dessiner l'interface graphique
            InitialiserInterfaceVisuelle();

            txtNotesLibres.TextChanged += (s, e) => MettreAJourChaineSignes();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtSignesORL.DataBindings.Add("Text", _consultation, "SignesFlle", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void InitialiserInterfaceVisuelle()
        {
            // On boucle sur les entiers 0, 1, 2, 3, 4 qui représentent vos catégories en BDD
            int[] categoriesId = { 0, 1, 2, 3, 4 };

            foreach (int catId in categoriesId)
            {
                // Extraire de la BDD uniquement les signes appartenant à cette catégorie numérique
                var signesDeLaCategorie = _bilanOrl.Where(s => s.Categorie == (CategorieOrl)catId).ToList();

                // Si aucun signe n'est configuré dans cette catégorie, on n'affiche pas le cadre vide
                if (!signesDeLaCategorie.Any()) continue;

                GroupBox groupeVisuel = new GroupBox
                {
                    Text = ObtenirNomCategorie(catId),
                    Width = 200,
                    Height = 400,
                    Margin = new Padding(10)
                };

                FlowLayoutPanel conteneurInterne = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    AutoScroll = true
                };

                foreach (var signe in signesDeLaCategorie)
                {
                    CheckBox chk = new CheckBox { Text = signe.Nom, AutoSize = true };
                    ComboBox cmbIntensite = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 95, Visible = false };
                    cmbIntensite.Items.AddRange(_echelleIntensite);

                    // Les valeurs par défaut configurées (Presence = false, IntensiteText = "0")
                    chk.Checked = signe.Presence;
                    cmbIntensite.SelectedIndex = ConvertirChaineEnIndex(signe.Intensite);
                    cmbIntensite.Visible = signe.Presence;

                    chk.CheckedChanged += (s, e) =>
                    {
                        signe.Presence = chk.Checked;
                        cmbIntensite.Visible = chk.Checked;
                        if (!chk.Checked)
                        {
                            cmbIntensite.SelectedIndex = 0;
                            signe.Intensite = "0";
                        }
                        else if (cmbIntensite.SelectedIndex <= 0)
                        {
                            cmbIntensite.SelectedIndex = 1;
                            signe.Intensite = "+";
                        }
                        MettreAJourChaineSignes();
                    };

                    cmbIntensite.SelectedIndexChanged += (s, e) =>
                    {
                        string selection = cmbIntensite.SelectedItem.ToString();
                        signe.Intensite = selection.Split(' ')[0];

                        if (signe.Intensite == "0")
                        {
                            chk.Checked = false;
                        }
                        MettreAJourChaineSignes();
                    };

                    FlowLayoutPanel ligne = new FlowLayoutPanel { AutoSize = true };
                    ligne.Controls.Add(chk);
                    ligne.Controls.Add(cmbIntensite);
                    conteneurInterne.Controls.Add(ligne);
                }

                groupeVisuel.Controls.Add(conteneurInterne);
                flowLayoutPanelPrincipal.Controls.Add(groupeVisuel);
            }
        }

        private void MettreAJourChaineSignes()
        {
            var lignes = _bilanOrl
                .Where(s => s.Presence && s.Intensite != "0")
                .GroupBy(s => s.Categorie)
                .OrderBy(g => g.Key)
                .Select(g => $"{ObtenirLibelleCategorie(g.Key)} : " +
                             string.Join(", ", g.Select(s => $"{s.Nom} ({s.Intensite})")))
                .ToList();

            string resultat = string.Join(Environment.NewLine, lignes);

            if (!string.IsNullOrWhiteSpace(txtNotesLibres.Text))
            {
                if (resultat.Length > 0) resultat += Environment.NewLine;
                resultat += $"{CleNotesLibres}{txtNotesLibres.Text.Trim()}";
            }

            _consultation.SignesFlle = resultat;
            txtSignesORL.DataBindings["Text"].ReadValue();
        }

        private void RestaurerSignesExistants()
        {
            // Réinitialiser les états en mémoire avant d'appliquer l'historique
            foreach (var s in _bilanOrl)
            {
                s.Presence = false;
                s.Intensite = "0";
            }

            if (string.IsNullOrEmpty(_consultation.SignesFlle)) return;

            string chaineComplete = _consultation.SignesFlle;
            string chaineCases = chaineComplete;

            if (chaineComplete.Contains(CleNotesLibres))
            {
                int indexCle = chaineComplete.IndexOf(CleNotesLibres);
                txtNotesLibres.Text = chaineComplete.Substring(indexCle + CleNotesLibres.Length);
                chaineCases = chaineComplete.Substring(0, indexCle).Trim();
                if (chaineCases.EndsWith("|"))
                    chaineCases = chaineCases.Substring(0, chaineCases.Length - 1).Trim();
            }

            // Accepter le nouveau format catégorisé, tout en conservant la
            // compatibilité avec l'ancien format sans catégories.
            string[] segments = chaineCases
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(ligne =>
                {
                    int indexDeuxPoints = ligne.IndexOf(':');
                    if (indexDeuxPoints >= 0 &&
                        ligne.StartsWith("Signes ", StringComparison.OrdinalIgnoreCase))
                    {
                        ligne = ligne.Substring(indexDeuxPoints + 1);
                    }

                    return ligne.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                })
                .ToArray();
            foreach (string segment in segments)
            {
                string nomSigne = segment;
                string intensite = "+";

                if (segment.Contains("(") && segment.Contains(")"))
                {
                    int indexOuvrant = segment.IndexOf('(');
                    int indexFermant = segment.IndexOf(')');
                    nomSigne = segment.Substring(0, indexOuvrant).Trim();
                    intensite = segment.Substring(indexOuvrant + 1, indexFermant - indexOuvrant - 1).Trim();
                }

                var signeTrouve = _bilanOrl.FirstOrDefault(s => s.Nom.Equals(nomSigne, StringComparison.OrdinalIgnoreCase));
                if (signeTrouve != null)
                {
                    signeTrouve.Presence = true;
                    signeTrouve.Intensite = intensite;
                }
            }
        }

        private int ConvertirChaineEnIndex(string intensiteText)
        {
            return intensiteText switch { "+" => 1, "++" => 2, "+++" => 3, _ => 0 };
        }

        private string ObtenirNomCategorie(int catId)
        {
            return catId switch
            {
                0 => "👂 Otologique",
                1 => "👃 Rhinologique",
                2 => "🗣️ Pharyngo-Laryngé",
                3 => "🧠 Neurologique",
                4 => "🌡️ Général",
                _ => $"Catégorie {catId}"
            };
        }

        private string ObtenirLibelleCategorie(CategorieOrl categorie)
        {
            return categorie switch
            {
                CategorieOrl.Otologique => "Signes otologiques",
                CategorieOrl.Rhinologique => "Signes rhinologiques",
                CategorieOrl.PharyngoLarynge => "Signes pharyngo-laryngés",
                CategorieOrl.Neurologique => "Signes neurologiques",
                CategorieOrl.General => "Signes généraux",
                _ => $"Signes {categorie}"
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MettreAJourChaineSignes();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MettreAJourChaineSignes();
            //txtNotesLibres.Text = _consultation.SignesFlle;
        }
    }
}