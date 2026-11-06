using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace patient
{
    public partial class ParaClinique : Form
    {
        private Patient _patient;
        private Consultation _consultation;
        private PatientDbContext _context;

        private BindingSource _detailsBindingSource = new BindingSource();

        public ParaClinique(Patient patient, Consultation consultation, PatientDbContext context)
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
            //rtNaso.DataBindings.Add("Text", _consultation, "Naso", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtSignesFlle.DataBindings.Add("Text", _consultation, "SignesFlle", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtClinique.DataBindings.Add("Text", _consultation, "Observation", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtNaso.DataBindings.Add("Text", _consultation, "Naso", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtDGC.DataBindings.Add("Text", _consultation, "Dgc", true, DataSourceUpdateMode.OnPropertyChanged);


        }

        private void ParaClinique_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Ferme la forme en validant
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
