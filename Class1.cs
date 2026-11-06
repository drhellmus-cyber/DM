using patient.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace patient;

public class Patient
{
    public int Id {  get; set; }
    public string Nom {  get; set; }
    public string Prenom { get; set; }
    public int Age {  get; set; }
    public enum Sexe { Masculin, Féminin }
    public Sexe Genre { get; set; }
    public enum StatutOperatoire { PsIndicationOp, Programmé, Opéré }
    public StatutOperatoire Statut { get; set; } = StatutOperatoire.PsIndicationOp;
    // Constructeur sans paramètre requis par Entity Framework et pour instanciation par défaut
    public Patient() { }

    public Patient(string nom, string prenom, int age)
    {
        Nom = nom;
        Prenom = prenom;
        Age = age;
        Genre = Sexe.Masculin;
    }
    public string categorieAge
    {
        get
        {
            if (Age < 1)
                return "Nouveau-né";
            else if (Age < 3)
                return "Nourrisson";
            else if (Age < 12)
                return "Enfant";
            else if (Age < 18)
                return "Adolescent";
            else
                return "Adulte";
        }
    }
    public string NomComplet
    {
        get
        {
            string titre = Genre == Sexe.Masculin ? "Mr" : "Mme";
            return $"{titre} {Prenom.ToString()} {Nom.ToUpper()}";
        }
    }
    public string NomAge
    {
        get
        { string civilite="";
            if (categorieAge == "Nouveau-né" || categorieAge == "Nourrisson" || categorieAge == "Enfant")
            {
                civilite = "enfant";
            }
            else if(categorieAge == "Adolescent")
            {
                civilite = Genre == Sexe.Masculin ? "Adolescent" : "Adolescente";
            }
            else
            {
                civilite = Genre == Sexe.Masculin ? "Mr" : "Mme";
            }
            return $"{civilite} {NomComplet} ({categorieAge})";
        }
    }
   
   
    // ps d'indication opératoire,pré-op => indication opératoire et  programmé, CRO rempli =>opéré//valeur defaut ps d'indication opératoire

    // catégorie Nouveau-né/Nourrisson/enfant/adolescent/adulte,
    // date d naissance
   
    public List <Consultation> Consultations { get; set; }
}
public class Consultation
{
    public int Id { get; set; }
    public DateTime DateConsultation { get; set; } = DateTime.Today;
    public string? SignesFlle { get; set; }
   
    //signes fonctionelle = sous formes de tableau, avec nom, présence(bool),//latéralité//, intensité(0,+,++,+++), classe(oto, rhino, phryngo-laryngo),//évolutivité//
    // classe signespatient//classe === list===dsignespatientsDetail
     //enum Intensite { 0, +, ++, +++ }/ou Absent,  Leger, Modere,   Severe
    //enum/bool Presence { Absent, Present }
    //enum Latéralité {PasDeCote, // Pour les signes généraux (ex: dysphonie), Bilateral,  Droite, Gauche }
    //enum Evolutivite// {aigue/subaigue, chronique, progressive, récurrente}
    //signesPatient.Where(s => s.Cote == Lateralite.Droite)
    public string? MotifDeConsultation { get; set; }
    // motif, mode de debut, durée, évolution, contexte, facteurs aggravants, facteurs déclenchants, signes associés, traitements antérieurs
    //aigue/subaigue, chronique, progressive, récurrente//
    //liste des diagnostics, chaque dgc == signes fflle== liste dgc suggéré==CAT suggéré==intervention suggéré
    // 
    public string? Dgc { get; set; }
    //liste ATCD médicaux, chirurgicaux // , traumatiques, familiaux, allergiques, médicamenteux, toxiques, sociaux
    // ATCD modèle suivant motif, OMC ,dysphonie,dysthyroidie,surdité,
    // otite à répétition, alcoolo-tabagisme,malmnage, surmenage vocale, notion BCG, ATCD radiothérapie...
    public string? Intervention { get; set; }
    public string ATCD { get; set; } = "RAS";

    
    public string Observation 
    {
        get
        {
            var lignes = new List<string>();

            // On ajoute la ligne uniquement si l'examen est renseigné
            if (!string.IsNullOrWhiteSpace(OTO))
                lignes.Add($"Otoscopie : {OTO}");
            if (!string.IsNullOrWhiteSpace(Vestibulaire))
                lignes.Add($"Examen vestibulaire : {Vestibulaire}");

            if (!string.IsNullOrWhiteSpace(RA))
                lignes.Add($"Rhinoscopie antérieure : {RA}");

            if (!string.IsNullOrWhiteSpace(CB))
                lignes.Add($"Examen Buccal : {CB}");

            if (!string.IsNullOrWhiteSpace(Face))
                lignes.Add($"Examen de la face : {Face}");
            if (!string.IsNullOrWhiteSpace(Cou))
                lignes.Add($"Otoscopie : {Cou}");
            if (!string.IsNullOrWhiteSpace(Neurologique))
                lignes.Add($"Examen Neurologique : {Neurologique}");

            // Concaténation avec un retour à la ligne propre
            return string.Join(Environment.NewLine, lignes);

        }
    }
    // otoscopie/rhinoscopie//CB//cou//face//autres
    // public string Otoscopie { get; set; } //
    // public string Otoscopie { get; set; }//RA//CB//COU//Face
    public string OTO { get; set; } = "Sans particularités";
    // public OtoscopieDetail otoscopie? liason plus tard en bas
    public string RA {  get; set; } = "Sans particularités";
    public string CB { get; set; } = "Sans particularités";
    public string Cou { get; set; } = "Sans particularités";
    public string Face { get; set; } = "Sans particularités";
    public string Vestibulaire { get; set; } = "Sans particularités";
    public string Neurologique { get; set; } = "Sans particularités";
    public string? Naso { get; set; }
    //public string BilanAudio { get; set; }
    //public string BilanVestib { get; set; }
    //VNG//L'épreuve calibrée et oculomotrice//L'épreuve positionnelle//L'épreuve calorique//
    //VHIT (Video Head Impulse Test) 
    // Les Potentiels Évoqués Myogéniques Vestibulaires  VEMP
    //Posturographie

    public string? Certificat {  get; set; }
    public string? OrientationMotif { get; set; }
    public string? Orientation { get; set; }
    public string? JustiArret {  get; set; }
    public string? BilanRadiologique { get; set; }  
    public string? BilanBiologique { get; set; }//liste des bilans biologiques
    //anapath,cyto,
    //Examen complémentaire audiométrie,PEA,ASSR,OEA, impédancemétrie,VNG,exploration vestibulaire(), autres
    public string? CRO { get; set; }
    public DateTime? DateRDV { get; set; }
    // Clé étrangère 
    public int PatientId {  get; set; }
    public Patient Patient { get; set; }
    //Relation 
    public Ordonnance Ordonnance { get; set; }
    //RDV
    //public DateTime? DateRdv { get; set; }

}
public class Ordonnance
{
    public int Id { get; set; }
    public DateTime DateOrd {  get; set; }
    // Clé étrangère
    public int ConsultationId { get; set; }
    public Consultation Consultation { get; set; }
    // Relation 
    public List<OrdonnanceDetail> OrdonnanceDetails { get; set; }   

}
public class OrdonnanceDetail
{
    public int Id { get; set; }
    public int OrdonnanceId { get; set; }
    public Ordonnance Ordonnance { get; set; }
    // Clé étrangère vers le Médicament sélectionné
    public int MedicamentId { get; set; }
    public Medicament Medicament { get; set; }

    // --- PROPRIÉTÉ D'AFFICHAGE AUTOMATIQUE POUR LE DATAGRIVIEW ---
    [NotMapped]
    public string NomMedicament => Medicament?.Nom ?? "";

    // Informations spécifiques qui reçoivent les suggestions par défaut
    public string Dosage { get; set; }
    public string Forme { get; set; }
    public string Frequence { get; set; }
    public string Duree {  get; set; }
    public string Rq { get; set; }
    
    // Constructeur vide requis pour Entity Framework / la sérialisation
    public OrdonnanceDetail() { }
    // Constructeur personnalisé pour créer un détail à partir d'un médicament sélectionné
    public OrdonnanceDetail(Medicament medicament)
    {
        if (medicament != null)
        {
            this.MedicamentId = medicament.Id;
            this.Medicament = medicament;

            // Importation des valeurs suggérées comme valeurs par défaut
            this.Dosage = medicament.DosageSuggest;
            this.Forme=medicament.Forme;
            this.Frequence = medicament.FrequenceSuggest;
            this.Duree = medicament.DureeSuggest;
            this.Rq = medicament.RqSuggest;
        }
    }




}
public class Medicament
{
    public int Id { get; set; }
    public string Nom {  get; set; }
    public string Forme { get; set; }
    public string DosageSuggest { get; set; }
    public string FrequenceSuggest { get; set; }
    public string DureeSuggest { get; set; }
    public string RqSuggest { get; set; }


}
public class OrdonnanceType
{
    public int Id { get; set; }
    public string NomModele { get; set; } // Ex: "Angine Aiguë Adulte", "Otite Enfant"

    // Relation avec les médicaments du modèle
    public List<OrdonnanceTypeDetail> Details { get; set; } = new();
}

public class OrdonnanceTypeDetail
{
    public int Id { get; set; }
    public int OrdonnanceTypeId { get; set; }
    public OrdonnanceType OrdonnanceType { get; set; }

    public int MedicamentId { get; set; }
    public Medicament Medicament { get; set; }

    // Posologie type prédéfinie
    public string Dosage { get; set; }
    public string Forme { get; set; }
    public string Frequence { get; set; }
    public string Duree { get; set; }
    public string Rq { get; set; }
}
public enum CategorieOrl
{
    Otologique,
    Rhinologique,
    PharyngoLarynge,
    Neurologique,
    General
}

public class SigneOrl
{
    // rendre SignesFlle sous forme d'une listes d'éléments SigneOrldans les future ameilloration, avec ExamenClinique
    public int Id { get; set; }
    public string Nom { get; set; }
    public bool Presence { get; set; }
    public string Intensite { get; set; }
    public CategorieOrl Categorie { get; set; } // Nouvelle propriété de classement

    public SigneOrl(string nom, CategorieOrl categorie)
    {
        Nom = nom;
        Categorie = categorie;
        Presence = false;
        Intensite = "0";
    }
}
public enum ExamenCote
{
    PasDeCote,
    CoteDroit,
    CoteGauche,
    Bilaterale
}
public class ExamenClinique
{
    public int Id { get; set; }
    public string NomExamen { get; set; }
    public bool  Pathologique { get; set; }

    public ExamenCote Lateralite {  get; set; }

    public CategorieOrl CategorieExamen { get; set; }
    public ExamenClinique(string nomExamen, ExamenCote lateralite,CategorieOrl categorieExamen )
    {
        NomExamen = nomExamen;
        Lateralite = lateralite;
        Pathologique = false;
        CategorieExamen=categorieExamen;
    }
    // 

    ///// otoscopie/////
}
/// <summary>
/// Représente une otoscopie avec les détails du conduit auditif externe et du tympan.
/// </summary>
public class Otoscopie
{
    ExamenCote Cote {  get; set; }
    CaeDetail CAE { get; set; } = new();
    TympanDetail Tympan { get; set; } = new();

}
public class TympanDetail
{
    public EtatTympan Etat { get; set; } = EtatTympan.Intact;

    // Contient les détails si l'état est Pathologique
    public PathologieTympanDetail? DetailPathologie { get; set; }
}
public class PathologieTympanDetail
{
    public TypePathologieTympan Type { get; set; }

    // Rempli uniquement si Rétraction Tympanique (Grades 1 à 4)
    
    public  ClassificationSade? sade { get; set; }
    public  ClassificationCharachon? charachon { get; set; }
    public  ClassificationTos? tos { get; set; }
    public  LesionOtiteSequellaire? otiteSequellaire  { get; set; }
    public  PerforationMarginale?  perforationMarginale { get; set; }
    public  PerforationVolume?  perforationVolume { get; set; }
    public  PerforationBerges? perforationBerges { get; set; }
    public  PerforationFondCaisse? perforationFondCaisse { get; set; }
    public  ClassificationChole? chole { get; set; }



 
    // Rempli uniquement si Poche de Rétraction (Classes 1 à 3)
    

    // Rempli uniquement si Otite Séquellaire (Perforation et/ou Myringosclérose)
    //public LesionOtiteSequellaire LesionsSequellaires { get; set; } = LesionOtiteSequellaire.Aucune;
}
public class CaeDetail
{
    public bool EstLibre { get; set; } = true;

    // Permet de cocher plusieurs pathologies en même temps grâce au [Flags]
    //public PathologieCae Pathologies { get; set; } = PathologieCae.Aucune;
}
public enum EtatTympan
{
    Intact,
    Pathologique
}
[Flags]
public enum TypePathologieTympan
{
    //Aucune = 0,
    RetractionTympanique= 1 << 0,
    PocheDeRetraction = 1 << 1,
    PocheAtticale = 1 << 2 ,
    OtiteSequellaire= 1 << 3 ,
    Cholesteatome= 1 << 4 ,
    RechauffementOMC= 1 << 5 ,
    OMA= 1 << 6 ,
    myringiteChronique= 1 << 7 ,
    GlomusTympanique= 1 << 8 ,
    OSM= 1 << 9 ,
    Tumorale= 1 << 10 ,

}


[Flags]
public enum PathologieCae
{
    //Aucune = 0,
    Congestive = 1 << 0,
    Stenose = 1 << 1,
    Otorrhee = 1 << 2,
    Otorragie = 1 << 3,
    Croutes = 1 << 4,
    Cérumene = 1 << 5,
    BC = 1 << 6,
    Polype = 1 << 7,
    Ostéome = 1 << 8 ,
    Exostose = 1 << 9 ,
    MasseTumorale = 1 << 10 ,
    CE = 1 << 11 
}
public enum ClassificationSade
{
    //[Description("Grade 1: Slight retraction of the pars tensa.")]
    Grade1,
   // [Description("Grade 2: Retraction of the pars tensa onto the incus or stapes.")]

    Grade2,
   // [Description("Grade 3: Retraction of the pars tensa onto the promontory.")]

    Grade3,
    //[Description("Grade 4: Adhesive otitis media.")]
    Grade4
}
public enum ClassificationCharachon
{
    ControlableDecollableAutonettoyant,
    ControlableNonDecollableAutonettoyant,
    NonControlableFixe

}
public enum ClassificationTos
{
    stadeI,
    stadeII,
    stadeIII,
    stadeIV
}
[Flags]
public enum LesionOtiteSequellaire
{
    Aucune = 0,
    Perforation = 1 << 0,
    Myringosclerose = 1 << 1,
    MembranePellucide = 1 << 2
}
public enum PerforationMarginale
{
    Marginale,
    NonMarginale,
    
}
public enum PerforationVolume
{
    PosteroInf,
    PosteroSup,
    AnteroSup,
    AnteroInf,
    Reniforme,
    SubTotale,
    Totale,
    Multiple
}
/// <summary>
/// Spécifie les différents types de perforations des berges.[flag?!
/// </summary>
public enum PerforationBerges
{
    saine,
    Congestive,
    Epidermose,
    InverseVersCaisse
}
public enum PerforationFondCaisse
{
    Saine,
    Congestive,
    Polypoide,
    Secretion, 
    //Claire, Purulente,
    Tympanosclerose,
    Epidermose
}
public enum ClassificationChole
{
    Atticale,
    Sinusale,
    Holotympanique
    
}
public static class Nasale
{
    public static List<string> Muqueuse = new List<string>
        {
            "Saine",
            "Congestive",
            "Oedématie",
            "secretion claire",
            "secretion purulente",
            "Croûte",
            "Granulation",
            //"Tumorale"
        };

    public static List<string> Meats = new List<string>
        {
            "Libre",
            "Polypoide",
            "Issue de secretion claire",
            "Issue de secretion purulente",
            "Bombement"

        };
    public static List<string> Cloison = new List<string>
        {
            "Saine",
            "Déviée",
            "Perforée",
            "Ulcérée",
            "Polypoide",
            "Tumorale"
        };
    public static List<string> Choanes = new List<string>
        {
            "Perméables",
            "Sténosées",
            "Obstruées"
        };
    
}
// examen vestibulaire; nystagmus, absent/present, horizonto-rotatoire; dte /gche/multidirection/uni// intesnsité//
//head shking test//Dix-Hallpick/Romberg/ pietinement en place fuduka/déviation des indexe/Head impulse test
// examen de la marche // examen vestibyulaire//mobilité coulaire ou occulomotricité//paire cranien// skew test// HINTS
//presence de Red Flag diplopie/dysatrhire/dysphagie/dysmetrie

//// RA
///FN dte/FN gche //muqueuse normale; congestive,secretion claire;purulente, croûte, granulation ; tumorale
// cloison nasale; tache vasculaire kiesselbach//deviation, perforation, ulcération, polype, tumeur
//meat moy //processus unciné//L'infundibulum ethmoïdal//récessus frontal//l'agger nasi// bille éthmoidale//La gouttière rétro-bullaire (Hiatus semilunaris superior) 
//La gouttière pré-bullaire (Hiatus semilunaris inferior) 
// CI normale,congestive, hypertrophié,
//Cm normale; inversé; globuleux
//meat moyen libre, polypoide, bombement
// recesus frontale// fente sphénoi-éthmodale//sinus sphénoide
//choanes premeables; sténosé; obstrué

//levre//vestibule oral et la muqueuse jugale (joues)//ostium du canal de Sténon//La langue (//Face supérieure (dos) //Bords latéraux//Le plancher buccal
//hypopharynx// vallecule//sinus piriformes//margelle laryngé
// cavum  paroi potéro-sup libre; congestive; reliquat de vg; masse tumorale,granualtion,// orifice tubaire libre; lévre ant ou post tuméfie; obstrué; Fossette rosenmuller libre ; bombé extension tumorale
//voile //fermeture(type); loge amygdalie
//vallécule; epiglotte ; 3 repli, sinus piriforme
//sus glottique; BV, ventricule de morgani; repli ary-épiglottique; aryténoides; 
//etage glottique 2 cv; aspet; mobilité; CA(commisure antérieur)
// étage sous glottique +anneaux tracheaux
//CB etat dentaire,gencive, langue dos; ventre, canal wharton , sténon; pelv-linguale; V lingual, base de la langue Piliers anty et post (gosier); loge amygdalienne , paroi post


//examen du cou  //aires gonglionnaires// jugulaire haurte moy inf spinale haute basse/sublinguale sous maxillaire sous d2/parot/mastoid/
// unique/multiple  //aigu/subaigue/chronique// fixe/mobile 
// boitier laryngé  mobile crépitant// fixée//
// classe constructeur et bd ExamenClinique, otoscopie, rhinoscopie,CB,+-Naso,cou, face
// 
//// faire des signes flle , commme objet, sur tableau database: nom, presence(bool), intensité(0,+,++,+++), classe(oto, rhino, phryngo-laryngo)
////de même , otoscopie(dte, gche, CAE, Tympan)//// signe physique père nom, présence(bool), intensité(0,+,++,+++), classe(oto, rhino, phryngo-laryngo)
////
////CB, RA, Cou, Naso, face..
//// ATCD 
//// Motif de consultation
///motif orentation
///Diagnostics
///Bilan biologique


