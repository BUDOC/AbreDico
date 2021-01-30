using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    internal class DonneesLettres
    {
        public static int ScoreMotJoueur()
        {
            return 0;
        }

        private int scoreTotal = 0;
        private static char[] voyellesCourantes = { 'A', 'E', 'I', 'O', 'U' };

        public static bool EstVoyelle(char lettre)
        {
            bool retour = false;
            for (int i = 0; i < VoyellesCourantes.Length; i++)
            {
                if (VoyellesCourantes[i] == lettre)
                {
                    retour = true;
                }
            }

            return retour;
        }

        public static int NbVoyelles(char[] matrice)
        {
            int cptV = 0;
            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < VoyellesCourantes.Length; k++)
                {
                    if (matrice[j] == VoyellesCourantes[k])
                    {
                        cptV++;
                    }
                }
            }

            return cptV;
        }

        public static readonly char[] P = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };
        private char[] consonnesChiantes = P;
        public static readonly char[] Alphabet = new char[26];
        public static readonly int[] TabloConsonneOuVoyelle = new int[26]; // consonne (0) ou Voyelle (1)
        public static readonly int[] TabloPointsParLettre = new int[26];
        public static readonly int[] TabloDifficulte = new int[26];
        public static readonly bool[,] TabloCochage = new bool[4, 4];
        public static readonly char[,] TableauDeLettres = new char[4, 4];
        public static readonly char[] TabloListeDesCaracteres = new char[16];
        public static readonly Point2D CaseChoisie = new Point2D();
        public static readonly Point2D CasePrecedente = new Point2D();

        public int ScoreTotal { get => this.scoreTotal; set => this.scoreTotal = value; }

        public static char[] VoyellesCourantes { get => voyellesCourantes; set => voyellesCourantes = value; }

        public char[] ConsonnesChiantes { get => this.consonnesChiantes; set => this.consonnesChiantes = value; }

        public static int PlaceDansLaMatrice(char c)
        {
            int i = 0;
            while (c != DonneesLettres.Alphabet[i])
            {
                i++;
                if (i > 15)
                {
                    i = -1;
                    break;
                }
            }

            return i;
        }

        public static int NbDeLaLettreDansMatrice(char c) // renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
        {
            int cpt = 0;
            for (int i = 0; i < DonneesLettres.TabloListeDesCaracteres.Length - 1; i++)
            {
                if (DonneesLettres.TabloListeDesCaracteres[i] == c)
                {
                    cpt++;
                }
            }

            return cpt;
        }

        public static void TourneTableauDeLettres()
        {
            char[,] tableauDeTravail = new char[4, 4];

            // Vidage du tableau
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableauDeTravail[i, j] = '?';
                }
            }

            for (int j = 0; j < 4; j++) // From line 0 to target column 3
            {
                tableauDeTravail[j, 3] = TableauDeLettres[0, j];
            }

            for (int j = 0; j < 4; j++) // From column 3 to target line 3
            {
                tableauDeTravail[3, 3 - j] = TableauDeLettres[j, 3];
            }

            for (int j = 0; j < 4; j++) // From line 3 to target column 0
            {
                tableauDeTravail[j, 0] = TableauDeLettres[3, j];
            }

            for (int j = 0; j < 4; j++) // From column 0 to target line 0
            {
                tableauDeTravail[0, 3 - j] = TableauDeLettres[j, 0];
            }

            for (int j = 1; j < 3; j++) // From column 1 to target line 1
            {
                tableauDeTravail[1, 3 - j] = TableauDeLettres[j, 1];
            }

            for (int j = 1; j < 3; j++) // From line 1 to target column2 1
            {
                tableauDeTravail[j, 2] = TableauDeLettres[1, j];
            }

            for (int j = 1; j < 3; j++) // From column 2 to target line 2
            {
                tableauDeTravail[2, 3 - j] = TableauDeLettres[j, 2];
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TableauDeLettres[i, j] = tableauDeTravail[i, j];
                }
            }
        }

        public static void AffecteConsonneOuVoyelle()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloConsonneOuVoyelle[i] = 0; // Lettre courante (mis en consonne par défaut)
            }

            // voyelles*
            DonneesLettres.TabloConsonneOuVoyelle[0] = 1; // A
            DonneesLettres.TabloConsonneOuVoyelle[4] = 1; // E
            DonneesLettres.TabloConsonneOuVoyelle[8] = 1; // I
            DonneesLettres.TabloConsonneOuVoyelle[14] = 1; // O
            DonneesLettres.TabloConsonneOuVoyelle[20] = 1; // U
            DonneesLettres.TabloConsonneOuVoyelle[24] = 1; // Y
        }

        public static void GenereAlphabet()
        {
            for (int i = 65; i < 91; i++)
            {
                DonneesLettres.Alphabet[i - 65] = Convert.ToChar(i);
            }
        }

        public static void AffectePoidsDesLettres()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloPointsParLettre[i] = 1; // Lettres communes
            }

            DonneesLettres.TabloPointsParLettre[5] = 4; // F
            DonneesLettres.TabloPointsParLettre[6] = 2; // G
            DonneesLettres.TabloPointsParLettre[7] = 4; // H
            DonneesLettres.TabloPointsParLettre[10] = 10; // K
            DonneesLettres.TabloPointsParLettre[11] = 2; // L
            DonneesLettres.TabloPointsParLettre[12] = 2; // M
            DonneesLettres.TabloPointsParLettre[15] = 3; // P
            DonneesLettres.TabloPointsParLettre[16] = 8; // Q
            DonneesLettres.TabloPointsParLettre[21] = 5; // V
            DonneesLettres.TabloPointsParLettre[22] = 15; // W
            DonneesLettres.TabloPointsParLettre[23] = 10; // X
            DonneesLettres.TabloPointsParLettre[24] = 8; // Y
            DonneesLettres.TabloPointsParLettre[25] = 10; // Z
        }

        public static void AffecteDidifficulteUtilisationLettre()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloDifficulte[i] = 0; // Sans difficulté
            }

            for (int i = 11; i < 16; i++)
            {
                DonneesLettres.TabloDifficulte[i] = 1; // L M N O P peu de difficulté
            }

            DonneesLettres.TabloDifficulte[5] = 2; // F  difficulté moyenne
            DonneesLettres.TabloDifficulte[20] = 2; // U
            DonneesLettres.TabloDifficulte[14] = 2; // O
            DonneesLettres.TabloDifficulte[6] = 2; // G
            DonneesLettres.TabloDifficulte[7] = 3; // H difficulté prononcée
            DonneesLettres.TabloDifficulte[21] = 3; // V
            DonneesLettres.TabloDifficulte[10] = 4; // difficulté très prononcée
            DonneesLettres.TabloDifficulte[9] = 4;  // J
            DonneesLettres.TabloDifficulte[16] = 4; // Q
            for (int i = 22; i < 26; i++) // W X Y Z
            {
                DonneesLettres.TabloDifficulte[i] = 4;
            }
        }

        public static void InitDataPourGrille()
        {
            GenereAlphabet();
            DonneesLettres.AffecteConsonneOuVoyelle();
            AffectePoidsDesLettres();
            AffecteDidifficulteUtilisationLettre();
        }

        public static void InitialiseTablocochage()
        { // met toutes les case du tablo des cases cochées = false
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    TabloCochage[i, j] = false;
                }
            }
        }

        public static void DefinitCoupleCaseCochee(int x, int y)
        {
            CaseChoisie.X = x;
            CaseChoisie.Y = y;
        }

        public static void StockeCaseChoisie()
        {
            CasePrecedente.X = CaseChoisie.X;
            CasePrecedente.Y = CaseChoisie.Y;
        }
    }
}
