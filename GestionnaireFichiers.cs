using System;

using System.IO;

namespace patient
{
    public static class GestionnaireFichiers
    {
        public static string ObtenirCheminEnregistrementPatient(string nom, string prenom, string nomDuDocument)
        {
            // 1. Définir le dossier principal (Racine) sur le Bureau
            string dossierRacine = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DocumentsPatients");

            // 2. Nettoyer et normaliser le nom du dossier du patient
            string nomDossierPatient = $"{nom.Trim().ToUpper()} {prenom.Trim()}";
            string dossierPatientComplet = Path.Combine(dossierRacine, nomDossierPatient);

            // 3. Si le dossier de ce patient n'existe pas encore, on le crée
            if (!Directory.Exists(dossierPatientComplet))
            {
                Directory.CreateDirectory(dossierPatientComplet);
            }

            // 4. Composer le nom final du fichier PDF avec un horodatage
            string dateInfo = DateTime.Now.ToString("yyyyMMdd HHmm");
            string nomFichierFinal = $"{nomDuDocument}_{dateInfo}.pdf";

            // Retourne le chemin complet final
            return Path.Combine(dossierPatientComplet, nomFichierFinal);
        }
    }
}
