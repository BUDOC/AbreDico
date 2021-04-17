using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{

    public class ParcoursDeMatrice
    {
        public class Case
        {
            public Couple XY = new Couple();
            public List<Case> ListeDesVoisines = new List<Case>();
        }

        public static void TouverVoisinesAcceptables(Case CaseDeTravail)
        {
            // cette procedure trouve les cases voisine de celle passée en pramètre
            // Créer des instance de Case pour chacune 
            //et les ajoute dans la liste des cases voisine de la case passée en pramètre
            int XdeCase = CaseDeTravail.XY.X;
            int YdeCase = CaseDeTravail.XY.Y;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int CoordonneeX = XdeCase + dx;
                    int CoordonneeY = YdeCase + dy;
                    if ((CoordonneeX == XdeCase) && (CoordonneeY == YdeCase))
                    {
                        //On ne fait rien car les coordonnées sont celles de la case d'appel
                    }
                    else
                    {
                        if (CoordonneeX >= 0 && CoordonneeX < 4 && CoordonneeY >= 0 && CoordonneeY < 4)
                        {
                            // on traite car les coordonnées sont acceptables
                            if (TabloUtilisationCase[CoordonneeX, CoordonneeY])
                            {
                                // La  case est déjà utilisée : on ne fait rien
                            }
                            else
                            {
                                // La case est libre donc utilisable donc
                                // on crée un Case de coordonnées courantes qu'on ajoute à la liste des cases voisines
                                Case CaseVoisine = new Case();
                                CaseVoisine.XY.X = CoordonneeX;
                                CaseVoisine.XY.Y = CoordonneeY;
                                CaseDeTravail.ListeDesVoisines.Add(CaseVoisine);
                                //   Test += "V> " + LettreDeLaCase(CaseVoisine) + "\r\n";
                            }
                        }
                        else
                        {
                            // on ne fait rien car au moins une des coordonnées est hors limites
                        }
                    }
                }
            }
            Test += "------" + "\r\n";
        }

        public static bool[,] TabloUtilisationCase = new bool[4, 4];
        public static void InitialiseTabloUtilisationCase()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TabloUtilisationCase[i, j] = false;
                }
            }
        }


        public static int ProfondeurDeRecherche = 0; // variable représentant le niveau de recherche par rapport à la racine

        public static char[] WordGrid = new char[24]; // Chaine représentant la suite de l'exploration de la Racine
        public static void InitaliseWordGrid()
        {
            for (int i = 0; i < WordGrid.Length; i++)
            {
                WordGrid[i] = '.';
            }
        }  // Procédure pour mettre tous les caratères à '.'
        public static int CompteurGeneral =0; // pour deboggage : nombre d'itération de l'exploration pour parcourir la grille

        public static void AfficheWordGrid()
        {
            int LgW = 0;
            Test += "Worgrid = ";
          for (int i=0; i<WordGrid.Length;i++)
            {
                Test += WordGrid[i];
                if (WordGrid[i]!='.') { LgW++; }
            }
            Test+=" Lg= "+LgW.ToString()+"\r\n";
         
        } // Procédure de debog pour afficher la suite de caratères de l'exploration de la racine

        public static void CrerCaseRacine(int X, int Y) // Procédure pour créer la racine et lancer l'explorations des combinaisons
        {
            InitaliseWordGrid();                                // Tous les caractère = '. '
            ProfondeurDeRecherche = 0;                          // Profondeur par rapport à la racine
            ParcoursDeMatrice.InitialiseTabloUtilisationCase(); //Toutes les cases à false = non "cochée"
            ParcoursDeMatrice.Case CaseRacine = new ParcoursDeMatrice.Case(); // Création de la case Racine
            CaseRacine.XY.X = X;                                // Affectation des coordonées de la case racine
            CaseRacine.XY.Y = Y;
            ParcoursDeMatrice.TabloUtilisationCase[CaseRacine.XY.X, CaseRacine.XY.Y] = true;
            // Cochage de la case rarcine (utilisée)
                  Test += LettreDeLaCase(CaseRacine) + "\r\n";              // Affichage pour debog dans textbox2
            WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseRacine);   // Affectation du premier caractère de Wordgrid
                   AfficheWordGrid(); // Affichage pour debog dans textbox2
            ParcoursDeMatrice.TouverVoisinesAcceptables(CaseRacine);        // trouve les voisines  crée les intances de la racine et la liste des vosines
            for (int L = 0; L < CaseRacine.ListeDesVoisines.Count; L++)
            {
                // Pour chaque voisine de la case racine on explore les chemins possibles                                               
                ParcoursDeMatrice.InitialiseTabloUtilisationCase();         // toutes les cases du tableau de cochage sont mises à false
                ParcoursDeMatrice.TabloUtilisationCase[CaseRacine.XY.X, CaseRacine.XY.Y] = true; // la case correspondante à Racine ets mise à true
                        Test += "  ######################\r\n";             // Affichage pour debog dans textbox2
                        Test += LettreDeLaCase(CaseRacine) + "\r\n";        // Affichage pour debog dans textbox2
                WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseRacine);
                  AfficheWordGrid();
                ExploreCombinaisons(CaseRacine.ListeDesVoisines[L], CaseRacine);
            }
            Test += CompteurGeneral.ToString() + "\r\n";                     // Affichage pour debog dans textbox2
        }
        
        //#####################################################################################################
        // Problème de gestion des cases cochées
        //#####################################################################################################

        public static void ExploreCombinaisons(ParcoursDeMatrice.Case CaseCourante, ParcoursDeMatrice.Case CaseAppelante)
        {   
            // Procédure récursive pour trouver les chemins d'exploration de la grille de lettres
            CompteurGeneral++;                                          // Pour debogage       
            Test += "Exploration de " + LettreDeLaCase(CaseCourante) + " en (" + CaseCourante.XY.X.ToString() + "," + CaseCourante.XY.Y.ToString() + ")" + "\r\n";// Affichage pour debog dans textbox2
            ParcoursDeMatrice.TouverVoisinesAcceptables(CaseCourante);   // trouve les voisines  crée les intances de la case courrante et la liste des vosines            
            if (CaseCourante.ListeDesVoisines.Count == 0)
            {
                //si la liste des voisines de la case courante est vide
                //on  supprime référence à la case courante dans la listes des cases voisines de la case appelante
                CaseAppelante.ListeDesVoisines.RemoveAt(0);
                ParcoursDeMatrice.TabloUtilisationCase[CaseCourante.XY.X, CaseCourante.XY.Y] = false;
                // On affecte false à la case corante da le tableau de cochage car les pas ou plus de voisine
                // ParcoursDeMatrice.TabloUtilisationCase[CaseAppelante.XY.X, CaseAppelante.XY.Y] = false;
                //=====pour test dernier maillon
                WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseCourante);
                Test += "Dernier Maillon" + "\r\n";                
                AfficheWordGrid();
                    
                //=====

                WordGrid[ProfondeurDeRecherche] = '.';                  // on "vide" la lettre quicorrespondant à la case courante
                ProfondeurDeRecherche--;                                // On décrémente la profondeur d'exploration
                Test += "Remontée Profondeur = " + ProfondeurDeRecherche.ToString() + "\r\n"; // Affichage pour debog dans textbox2
            }
            else
            { // La liste des cases voisines de la case courante n'est pas vide
                ParcoursDeMatrice.TabloUtilisationCase[CaseCourante.XY.X, CaseCourante.XY.Y] = true;    // on coche la case comme utilisée
                //  ParcoursDeMatrice.WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseCourante);
                ProfondeurDeRecherche++;                                // on incrémente la profondeur d'exploration
                for (int j = 0; j < CaseCourante.ListeDesVoisines.Count; j++)
                {   // pour toute les voisines  de la case courante
                    WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseCourante);     // Affectation du caractère de Worgrid à la position "profondeur de l'exploration"
                    AfficheWordGrid();                                  // Affichage pour debog dans textbox2
                    ExploreCombinaisons(CaseCourante.ListeDesVoisines[j], CaseCourante);
                    // on relance la procédure en procédure d'exploration pour toutes les cases voisines de la case courante
                }
            }
        }

        public static string Test = ""; //  variables à détruire quand le fonctionnement sera OK

        

        public static char LettreDeLaCase(Case UneCase)
        {
            return DonneesLettres.tableauDeLettres[UneCase.XY.X, UneCase.XY.Y];
        }




    }
}
