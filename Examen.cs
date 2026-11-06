using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace patient
{
    public partial class Examen : Form
    {
        private Consultation _consultation;
        private PatientDbContext _context;
        private List<Examen> _bilanClinique;
        public Examen(Consultation consultation, PatientDbContext context)
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
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtOTO.DataBindings.Add("Text", _consultation, "OTO", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRA.DataBindings.Add("Text", _consultation, "RA", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCB.DataBindings.Add("Text", _consultation, "CB", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCou.DataBindings.Add("Text", _consultation, "Cou", true, DataSourceUpdateMode.OnPropertyChanged);
            // txtFace.DataBindings.Add("Text", _consultation, "OTO", true, DataSourceUpdateMode.OnPropertyChanged);
            txtVestibulaire.DataBindings.Add("Text", _consultation, "Vestibulaire", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNeurologique.DataBindings.Add("Text", _consultation, "Neurologique", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void ExamenClinique_Load(object sender, EventArgs e)
        {
            //oreille dte//tabControle1//page 1
            lbxCAEDte.Items.AddRange(Enum.GetNames<PathologieCae>());
            lbxTympanDte.Items.AddRange(Enum.GetNames<TypePathologieTympan>());

            comboSade.Items.AddRange(Enum.GetNames<ClassificationSade>());
            comboCharachon.Items.AddRange(Enum.GetNames<ClassificationCharachon>());
            comboTos.Items.AddRange(Enum.GetNames<ClassificationTos>());
            comboCholesteatome.Items.AddRange(Enum.GetNames<ClassificationChole>());


            comboPerforationMarginale.Items.AddRange(Enum.GetNames<PerforationMarginale>());
            comboPerforationVolume.Items.AddRange(Enum.GetNames<PerforationVolume>());
            comboPerforationBerges.Items.AddRange(Enum.GetNames<PerforationBerges>());
            comboPerforationFondCaisse.Items.AddRange(Enum.GetNames<PerforationFondCaisse>());


            radioCAEDteNormal.Checked = true;
            radioTympanDteNormal.Checked = true;

            lbxCAEDte.Visible = false;
            lbxTympanDte.Visible = false;

            comboSade.Visible = false;
            lblSade.Visible = false;
            comboCharachon.Visible = false;
            lblCharachon.Visible = false;
            comboTos.Visible = false;
            lblTos.Visible = false;
            comboCholesteatome.Visible = false;
            lblCholesteatome.Visible = false;

            gbOtiteSequellaire.Visible = false;

            comboPerforationMarginale.Visible = false;
            lblPerforationMarginale.Visible = false;
            comboPerforationVolume.Visible = false;
            lblPerforationVolume.Visible = false;
            comboPerforationBerges.Visible = false;
            lblPerforationBerges.Visible = false;
            comboPerforationFondCaisse.Visible = false;
            lblPerforationFondCaisse.Visible = false;

            //oreille gche//tabcontrole1//page2

            lbxCAEGche.Items.AddRange(Enum.GetNames<PathologieCae>());
            lbxTympanGche.Items.AddRange(Enum.GetNames<TypePathologieTympan>());

            comboSadeGche.Items.AddRange(Enum.GetNames<ClassificationSade>());
            comboCharachonGche.Items.AddRange(Enum.GetNames<ClassificationCharachon>());
            comboTosGche.Items.AddRange(Enum.GetNames<ClassificationTos>());
            comboCholesteatomeGche.Items.AddRange(Enum.GetNames<ClassificationChole>());


            comboPerforationMarginaleGche.Items.AddRange(Enum.GetNames<PerforationMarginale>());
            comboPerforationVolumeGche.Items.AddRange(Enum.GetNames<PerforationVolume>());
            comboPerforationBergesGche.Items.AddRange(Enum.GetNames<PerforationBerges>());
            comboPerforationFondCaisseGche.Items.AddRange(Enum.GetNames<PerforationFondCaisse>());


            radioCAEGcheNormale.Checked = true;
            radioTympanGcheNormale.Checked = true;

            lbxCAEGche.Visible = false;
            lbxTympanGche.Visible = false;

            comboSadeGche.Visible = false;
            lblSadeGche.Visible = false;
            comboCharachonGche.Visible = false;
            lblCharachonGche.Visible = false;
            comboTosGche.Visible = false;
            lblTosGche.Visible = false;
            comboCholesteatomeGche.Visible = false;
            lblCholesteatomeGche.Visible = false;

            gbOtiteSequellaireGche.Visible = false;

            comboPerforationMarginaleGche.Visible = false;
            lblPerforationMarginaleGche.Visible = false;
            comboPerforationVolumeGche.Visible = false;
            lblPerforationVolumeGche.Visible = false;
            comboPerforationBergesGche.Visible = false;
            lblPerforationBergesGche.Visible = false;
            comboPerforationFondCaisseGche.Visible = false;
            lblPerforationFondCaisseGche.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Ferme la forme en validant
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioCAEDtePath_CheckedChanged(object sender, EventArgs e)
        {
            // Rend la liste visible ou invisible selon l'état du bouton radio
            lbxCAEDte.Visible = radioCAEDtePath.Checked;

            // Si le bouton est coché et que la liste contient des éléments
            if (radioCAEDtePath.Checked && lbxCAEDte.Items.Count > 0)
            {
                lbxCAEDte.Focus();              // Donne le focus pour être prête à interagir
                lbxCAEDte.SelectedIndex = 0;    // Surligne le premier élément
            }
        }
        private void radioCAEGchePath_CheckedChanged(object sender, EventArgs e)
        {

            lbxCAEGche.Visible = radioCAEGchePath.Checked;


            if (radioCAEGchePath.Checked && lbxCAEGche.Items.Count > 0)
            {
                lbxCAEGche.Focus();
                lbxCAEGche.SelectedIndex = 0;
            }
        }
        private void radioTympanDtePath_CheckedChanged(object sender, EventArgs e)
        {
            lbxTympanDte.Visible = radioTympanDtePath.Checked;
            if (radioTympanDtePath.Checked && lbxTympanDte.Items.Count > 0)
            {
                lbxTympanDte.Focus();
                lbxTympanDte.SelectedIndex = 0;
            }
        }
        private void radioTympanGchePath_CheckedChanged(object sender, EventArgs e)
        {
            lbxTympanGche.Visible = radioTympanGchePath.Checked;
            if (radioTympanGchePath.Checked && lbxTympanGche.Items.Count > 0)
            {
                lbxTympanGche.Focus();
                lbxTympanGche.SelectedIndex = 0;
            }
        }

        private void lbxTympanDte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbxTympanDte_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //string elementCible = "RetractionTympanique";
            //string elementCible2 = "PocheDeRetraction";
            string elementClique = lbxTympanDte.Items[e.Index].ToString();
            if (elementClique == "OtiteSequellaire")
            {
                bool doitEtreVisible = e.NewValue == CheckState.Checked;
                gbOtiteSequellaire.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    gbOtiteSequellaire.Focus();
                    // Optionnel : donner le focus à la première checkbox à l'intérieur si nécessaire
                }
                return; // On arrête l'exécution ici pour cet élément
            }


            // Dictionnaire associant chaque texte à son couple (ComboBox, Label)
            var dictionnaireControles = new Dictionary<string, (System.Windows.Forms.ComboBox combo, Label Lbl)>
    {
        { "RetractionTympanique", (comboSade, lblSade) },
        { "PocheDeRetraction",(comboCharachon, lblCharachon)},
        { "PocheAtticale", (comboTos, lblTos) },
        { "Cholesteatome", (comboCholesteatome, lblCholesteatome) }
    };

            // 3. Si l'élément cliqué fait partie de notre dictionnaire
            if (dictionnaireControles.TryGetValue(elementClique, out var controleCible))
            {
                // Déterminer le futur état de visibilité
                bool doitEtreVisible = e.NewValue == CheckState.Checked;

                // Appliquer la visibilité simultanément au combo ET au label
                controleCible.combo.Visible = doitEtreVisible;
                controleCible.Lbl.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    // Sélectionner la 1ère valeur uniquement si aucune sélection n'est faite
                    if (controleCible.combo.SelectedIndex == -1 && controleCible.combo.Items.Count > 0)
                    {
                        controleCible.combo.SelectedIndex = 0;
                    }
                }
            }



        }
        private void lbxTympanGche_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            string elementClique = lbxTympanGche.Items[e.Index].ToString();
            if (elementClique == "OtiteSequellaire")
            {
                bool doitEtreVisible = e.NewValue == CheckState.Checked;
                gbOtiteSequellaireGche.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    gbOtiteSequellaireGche.Focus();

                }
                return;
            }


            // Dictionnaire associant chaque texte à son couple (ComboBox, Label)
            var dictionnaireControles = new Dictionary<string, (System.Windows.Forms.ComboBox combo, Label Lbl)>
    {
        { "RetractionTympanique", (comboSadeGche, lblSadeGche) },
        { "PocheDeRetraction",(comboCharachonGche, lblCharachonGche)},
        { "PocheAtticale", (comboTosGche, lblTosGche) },
        { "Cholesteatome", (comboCholesteatomeGche, lblCholesteatomeGche) }
    };

            // 3. Si l'élément cliqué fait partie de notre dictionnaire
            if (dictionnaireControles.TryGetValue(elementClique, out var controleCible))
            {
                // Déterminer le futur état de visibilité
                bool doitEtreVisible = e.NewValue == CheckState.Checked;

                // Appliquer la visibilité simultanément au combo ET au label
                controleCible.combo.Visible = doitEtreVisible;
                controleCible.Lbl.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    // Sélectionner la 1ère valeur uniquement si aucune sélection n'est faite
                    if (controleCible.combo.SelectedIndex == -1 && controleCible.combo.Items.Count > 0)
                    {
                        controleCible.combo.SelectedIndex = 0;
                    }
                }
            }



        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            comboPerforationMarginale.Visible = checkBox26.Checked;
            lblPerforationMarginale.Visible = checkBox26.Checked;
            comboPerforationMarginale.SelectedIndex = 1;

            comboPerforationVolume.Visible = checkBox26.Checked;
            lblPerforationVolume.Visible = checkBox26.Checked;
            comboPerforationVolume.SelectedIndex = 0;

            comboPerforationBerges.Visible = checkBox26.Checked;
            lblPerforationBerges.Visible = checkBox26.Checked;
            comboPerforationBerges.SelectedIndex = 0;

            comboPerforationFondCaisse.Visible = checkBox26.Checked;
            lblPerforationFondCaisse.Visible = checkBox26.Checked;
            comboPerforationFondCaisse.SelectedIndex = 0;

        }
        private void checkBox26Gche_CheckedChanged(object sender, EventArgs e)
        {
            comboPerforationMarginaleGche.Visible = checkBox26Gche.Checked;
            lblPerforationMarginaleGche.Visible = checkBox26Gche.Checked;
            comboPerforationMarginaleGche.SelectedIndex = 1;

            comboPerforationVolumeGche.Visible = checkBox26Gche.Checked;
            lblPerforationVolumeGche.Visible = checkBox26Gche.Checked;
            comboPerforationVolumeGche.SelectedIndex = 0;

            comboPerforationBergesGche.Visible = checkBox26Gche.Checked;
            lblPerforationBergesGche.Visible = checkBox26Gche.Checked;
            comboPerforationBergesGche.SelectedIndex = 0;

            comboPerforationFondCaisseGche.Visible = checkBox26Gche.Checked;
            lblPerforationFondCaisseGche.Visible = checkBox26Gche.Checked;
            comboPerforationFondCaisseGche.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var otoscopie = new System.Text.StringBuilder();
            otoscopie.Append("Oreille droite: ");
            otoscopie.Append(" - CAE: ");

            // 1. CAEdte
            if (radioCAEDteNormal.Checked)
            {
                otoscopie.Append("sans anomalies");

            }
            else
            {
                var itemsCoches = lbxCAEDte.CheckedItems.Cast<object>().Select(x => x.ToString());
                string listeCae = string.Join(", ", itemsCoches);
                otoscopie.AppendLine($"{listeCae}.");

            }
            otoscopie.AppendLine();
            // 2 Tympan dte
            otoscopie.Append("                          - Tympan :");

            if (radioTympanDteNormal.Checked)
            {
                otoscopie.AppendLine("sans anomalies");

            }
            else
            {
                bool estPremierElement = true;

                foreach (var item in lbxTympanDte.CheckedItems)
                {
                    if (item?.ToString() is not string elementCoche) continue;
                    string prefixeAlignement = estPremierElement ? "" : "                                             ";
                    estPremierElement = false;


                    switch (elementCoche)
                    {
                        case "RetractionTympanique":
                            string stadeSade = comboSade.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Rétraction Tympanique : Stade  {stadeSade} de Sade.");
                            break;

                        case "PocheDeRetraction":
                            string stadeCharachon = comboCharachon.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Poche de Rétraction : Stade  {stadeCharachon}.");
                            break;

                        case "PocheAtticale":
                            string stadeTos = comboTos.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Poche Atticale : Stade {stadeTos} de Tos.");
                            break;

                        case "OtiteSequellaire":
                            otoscopie.AppendLine($"{prefixeAlignement}- Otite Séquellaire, avec ");
                            if (checkBox26.Checked)
                            {
                                string berges = comboPerforationBerges.SelectedItem?.ToString() ?? "non précisé";
                                string fdc = comboPerforationFondCaisse.SelectedItem?.ToString() ?? "non précisé";
                                string siege = comboPerforationVolume.SelectedItem?.ToString() ?? "non précisé";
                                string marginale = comboPerforationMarginale.SelectedItem?.ToString() ?? "non précis";
                                otoscopie.AppendLine($"{prefixeAlignement}- Perforation  {siege}, {marginale}, dont les berges sont {berges}, avec un fond de caisse {fdc}.");
                            }
                            if (checkBox25.Checked)
                            {
                                otoscopie.AppendLine($"{prefixeAlignement}-Myringosclérose");
                            }
                            if (checkBox24.Checked)
                            {
                                otoscopie.AppendLine($"{prefixeAlignement}-Zones pellucide");
                            }
                            // Optionnel : Vous pouvez ajouter ici les sous-éléments du gbOtiteSequellaire s'il y a des cases cochées dedans

                            break;

                        //case "Perforation":
                        // Récupération des valeurs des 3 ComboBox associées
                        //string berges = comboBerges.SelectedItem?.ToString() ?? "non précisé";
                        // string fdc = comboFDC.SelectedItem?.ToString() ?? "non précisé";
                        // string siege = comboSiege.SelectedItem?.ToString() ?? "non précisé";

                        //  otoscopie.AppendLine($"- Perforation Tympanique : Berges [{berges}], FDC [{fdc}], Siège [{siege}].");
                        //  break;



                        case "Cholesteatome":
                            string typeChol = comboCholesteatome.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Cholestéatome  {typeChol}.");
                            break;

                        default:
                            // Pour tout autre élément coché qui n'a pas de ComboBox liée
                            otoscopie.AppendLine($"{prefixeAlignement}- {elementCoche} présent.");
                            break;
                    }
                }

            }
            ////// otoscopie gauche
            otoscopie.AppendLine();
            otoscopie.Append("Oreille gauche: ");
            otoscopie.Append(" - CAE: ");

            // 1. CAEdte
            if (radioCAEGcheNormale.Checked)
            {
                otoscopie.Append("sans anomalies");

            }
            else
            {
                var itemsCoches = lbxCAEGche.CheckedItems.Cast<object>().Select(x => x.ToString());
                string listeCae = string.Join(", ", itemsCoches);
                otoscopie.AppendLine($"{listeCae}.");

            }
            otoscopie.AppendLine();
            // 2 Tympan gche
            otoscopie.Append("                          - Tympan :");

            if (radioTympanGcheNormale.Checked)
            {
                otoscopie.AppendLine("sans anomalies");

            }
            else
            {
                bool estPremierElement = true;

                foreach (var item in lbxTympanGche.CheckedItems)
                {
                    if (item?.ToString() is not string elementCoche) continue;
                    string prefixeAlignement = estPremierElement ? "" : "                                             ";
                    estPremierElement = false;


                    switch (elementCoche)
                    {
                        case "RetractionTympanique":
                            string stadeSade = comboSadeGche.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Rétraction Tympanique : Stade  {stadeSade} de Sade.");
                            break;

                        case "PocheDeRetraction":
                            string stadeCharachon = comboCharachonGche.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Poche de Rétraction : Stade  {stadeCharachon}.");
                            break;

                        case "PocheAtticale":
                            string stadeTos = comboTosGche.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Poche Atticale : Stade {stadeTos} de Tos.");
                            break;

                        case "OtiteSequellaire":
                            otoscopie.AppendLine($"{prefixeAlignement}- Otite Séquellaire, avec ");
                            if (checkBox26Gche.Checked)
                            {
                                string berges = comboPerforationBergesGche.SelectedItem?.ToString() ?? "non précisé";
                                string fdc = comboPerforationFondCaisseGche.SelectedItem?.ToString() ?? "non précisé";
                                string siege = comboPerforationVolumeGche.SelectedItem?.ToString() ?? "non précisé";
                                string marginale = comboPerforationMarginaleGche.SelectedItem?.ToString() ?? "non précis";
                                otoscopie.AppendLine($"{prefixeAlignement}- Perforation  {siege}, {marginale}, dont les berges sont {berges}, avec un fond de caisse {fdc}.");
                            }
                            if (checkBox25Gche.Checked)
                            {
                                otoscopie.AppendLine($"{prefixeAlignement}-Myringosclérose");
                            }
                            if (checkBox24Gche.Checked)
                            {
                                otoscopie.AppendLine($"{prefixeAlignement}-Zones pellucide");
                            }


                            break;




                        case "Cholesteatome":
                            string typeChol = comboCholesteatomeGche.SelectedItem?.ToString() ?? "non précisé";
                            otoscopie.AppendLine($"{prefixeAlignement}- Cholestéatome  {typeChol}.");
                            break;

                        default:
                            // Pour tout autre élément coché qui n'a pas de ComboBox liée
                            otoscopie.AppendLine($"{prefixeAlignement}- {elementCoche} présent.");
                            break;
                    }
                }

            }
            txtOTO.Text = otoscopie.ToString();

            // Si aucune case n'était cochée
            //if (lbxTympanDte.CheckedItems.Count == 0)
            // {
            //    otoscopie.AppendLine("- Aucun signe pathologique coché (Tympan Normal).");
            // }

            //return otoscopie.ToString();
        }

        private void radioCAEGcheNormale_CheckedChanged(object sender, EventArgs e)
        {
            lbxCAEGche.Visible = radioCAEGchePath.Checked;


            if (radioCAEGchePath.Checked && lbxCAEGche.Items.Count > 0)
            {
                lbxCAEGche.Focus();
                lbxCAEGche.SelectedIndex = 0;
            }
        }

        private void radioTympanGcheNormale_CheckedChanged(object sender, EventArgs e)
        {
            lbxTympanGche.Visible = radioTympanGchePath.Checked;
            if (radioTympanGchePath.Checked && lbxTympanGche.Items.Count > 0)
            {
                lbxTympanGche.Focus();
                lbxTympanGche.SelectedIndex = 0;
            }
        }

        private void lbxTympanGche_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {

            string elementClique = lbxTympanGche.Items[e.Index].ToString();
            if (elementClique == "OtiteSequellaire")
            {
                bool doitEtreVisible = e.NewValue == CheckState.Checked;
                gbOtiteSequellaireGche.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    gbOtiteSequellaireGche.Focus();

                }
                return;
            }


            // Dictionnaire associant chaque texte à son couple (ComboBox, Label)
            var dictionnaireControles = new Dictionary<string, (System.Windows.Forms.ComboBox combo, Label Lbl)>
    {
        { "RetractionTympanique", (comboSadeGche, lblSadeGche) },
        { "PocheDeRetraction",(comboCharachonGche, lblCharachonGche)},
        { "PocheAtticale", (comboTosGche, lblTosGche) },
        { "Cholesteatome", (comboCholesteatomeGche, lblCholesteatomeGche) }
    };

            // 3. Si l'élément cliqué fait partie de notre dictionnaire
            if (dictionnaireControles.TryGetValue(elementClique, out var controleCible))
            {
                // Déterminer le futur état de visibilité
                bool doitEtreVisible = e.NewValue == CheckState.Checked;

                // Appliquer la visibilité simultanément au combo ET au label
                controleCible.combo.Visible = doitEtreVisible;
                controleCible.Lbl.Visible = doitEtreVisible;

                if (doitEtreVisible)
                {
                    // Sélectionner la 1ère valeur uniquement si aucune sélection n'est faite
                    if (controleCible.combo.SelectedIndex == -1 && controleCible.combo.Items.Count > 0)
                    {
                        controleCible.combo.SelectedIndex = 0;
                    }
                }
            }



        }

        private void checkBox26Gche_CheckedChanged_1(object sender, EventArgs e)
        {
            comboPerforationMarginaleGche.Visible = checkBox26Gche.Checked;
            lblPerforationMarginaleGche.Visible = checkBox26Gche.Checked;
            comboPerforationMarginaleGche.SelectedIndex = 1;

            comboPerforationVolumeGche.Visible = checkBox26Gche.Checked;
            lblPerforationVolumeGche.Visible = checkBox26Gche.Checked;
            comboPerforationVolumeGche.SelectedIndex = 0;

            comboPerforationBergesGche.Visible = checkBox26Gche.Checked;
            lblPerforationBergesGche.Visible = checkBox26Gche.Checked;
            comboPerforationBergesGche.SelectedIndex = 0;

            comboPerforationFondCaisseGche.Visible = checkBox26Gche.Checked;
            lblPerforationFondCaisseGche.Visible = checkBox26Gche.Checked;
            comboPerforationFondCaisseGche.SelectedIndex = 0;

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void lblNom_Click(object sender, EventArgs e)
        {

        }
    }
}
