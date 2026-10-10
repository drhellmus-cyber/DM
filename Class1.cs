using System;
using System.Collections.Generic;
using System.Text;

namespace patient;

public class Patient
{
    public int Id {  get; set; }
    public string Nom {  get; set; }
    public int Age {  get; set; }
    public List <Consultation> Consultations { get; set; }
}
public class Consultation
{
    public int Id { get; set; }
    public DateTime DateConsultation { get; set; }  
    public string SignesFlle { get; set; }
    public string Observation {  get; set; }
    public string Naso { get; set; }
    public string Certificat {  get; set; }
    public string Orientation { get; set; }
    public string JustiArret {  get; set; }
    public string ExamenCmpl { get; set; }  
    // Clé étrangère 
    public int PatientId {  get; set; }
    public Patient Patient { get; set; }
    //Relation 
    public Ordonnance Ordonnance { get; set; }

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
    public int MedicamentId { get; set; }
    public Medicament Medicament { get; set; }
    // information spécifique
    public string Dosage { get; set; }
    public string Frequence { get; set; }
    public string Duree {  get; set; }
    public string Rq { get; set; }


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
//// faire des signes flle , commme objet, sur tableau database: nom, presence(bool), intensité(0,+,++,+++), classe(oto, rhino, phryngo-laryngo)
///de même , otoscopie(dte, gche, CAE, Tympan)
///CB, RA, Cou, Naso, face..
/// ATCD 
