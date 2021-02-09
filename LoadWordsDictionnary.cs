using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbreDico
{
    class LoadWordsDictionnary
    {
        private static bool startAuthorization = true;
        public static Noeud NoeudRacine { get; private set; }

        // Return true if succes on dictinary loading
        public static bool GetAuthorizationStatus()
        {
            return startAuthorization;
        }

        // initialisation des données pour la construction de l'arbre des lettres des mots français
        public static void InitialiseEnvironnement() 
        {
            // this.pictureBox1.Visible = true;
            // Création de l'arbre à partir du fichier texte.
            // ===================
            // initialisation du dictionnaire            
            string nomDuDico = Directory.GetCurrentDirectory() + "\\MOTS TRADUITS.txt";
            string[] lignesDico;
            try
            {
                lignesDico = File.ReadAllLines(nomDuDico);

                // c'est le dictionnaire (arbre)
                NoeudRacine = WordsTree.NoeudRacineConstructionArbre (lignesDico);
            }
            catch
            {
                startAuthorization = false;
            }
        }

    }
}
