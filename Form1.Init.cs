using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace patient
{
    public partial class Form1 : Form
    {
        private void Form1_LoadInit(object sender, EventArgs e)
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
    }
}
