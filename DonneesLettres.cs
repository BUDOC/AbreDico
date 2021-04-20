using System;

namespace AbreDico
{
    internal class DonneesLettres
    {
        public static int ScoreMotJoueur()
        {
            return 0;
        }

        public static bool EstVoyelle(char lettre)
        {
            bool retour = false;
            for (int i = 0; i < UsualVowels.Length; i++)
            {
                if (UsualVowels[i] == lettre)
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
                for (int k = 0; k < UsualVowels.Length; k++)
                {
                    if (matrice[j] == UsualVowels[k])
                    {
                        cptV++;
                    }
                }
            }

            return cptV;
        }

        public static readonly char[] DifficylConsonnants = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };
        public static readonly char[] Alphabet = new char[26];
        public static readonly int[] TabloConsonneOuVoyelle = new int[26]; // consonne (0) ou Voyelle (1)
        public static readonly int[] PointArrayForAletter = new int[26];
        public static readonly int[] TabloDifficulte = new int[26];
        public static readonly bool[,] ArrayOfLetterUse = new bool[4, 4];
        public static readonly char[,] TableauDeLettres = new char[4, 4];
        public static readonly char[] ArrayOfLetters = new char[16];
        public static readonly Point2D ChoosenSquare = new Point2D();
        public static readonly Point2D PrecedentSquare = new Point2D();

        public int ScoreTotal { get; set; } = 0;

        public static char[] UsualVowels { get; set; } = { 'E', 'A', 'I', 'O', 'U' };

        public char[] DifficultConsonants { get; set; } = DifficylConsonnants;

        public static int PlaceInMatrix(char c)
        {
            int i = 0;
            while (c != Alphabet[i])
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

        public static int HowManyInMatrix(char c)
        {// renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
           int cpt = 0;
           for (int i = 0; i < ArrayOfLetters.Length - 1; i++)
            {
                if (ArrayOfLetters[i] == c)
                {
                    cpt++;
                }
            }

           return cpt;
        }

        public static void RotateMatrix()
        {
            char[,] workingArray = new char[4, 4];

            // Vidage du tableau
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    workingArray[i, j] = '?';
                }
            }

            for (int j = 0; j < 4; j++)
            {// From line 0 to target column 3
              workingArray[j, 3] = TableauDeLettres[0, j];
            }

            for (int j = 0; j < 4; j++)
            {// From column 3 to target line 3
              workingArray[3, 3 - j] = TableauDeLettres[j, 3];
            }

            for (int j = 0; j < 4; j++)
             {// From line 3 to target column 0
              workingArray[j, 0] = TableauDeLettres[3, j];
            }

            for (int j = 0; j < 4; j++)
            {// From column 0 to target line 0
              workingArray[0, 3 - j] = TableauDeLettres[j, 0];
            }

            for (int j = 1; j < 3; j++)
            {// From column 1 to target line 1
              workingArray[1, 3 - j] = TableauDeLettres[j, 1];
            }

            for (int j = 1; j < 3; j++)
            {// From line 1 to target column2 1
              workingArray[j, 2] = TableauDeLettres[1, j];
            }

            for (int j = 1; j < 3; j++)
            {// From column 2 to target line 2
              workingArray[2, 3 - j] = TableauDeLettres[j, 2];
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TableauDeLettres[i, j] = workingArray[i, j];
                }
            }
        }

        public static void MakeItConsonnant()
        {
            for (int i = 0; i < 26; i++)
            {
                // Lettre courante (mis en consonne par défaut)
                TabloConsonneOuVoyelle[i] = 0;
            }

            // voyelles
            TabloConsonneOuVoyelle[0] = 1; // A
            TabloConsonneOuVoyelle[4] = 1; // E
            TabloConsonneOuVoyelle[8] = 1; // I
            TabloConsonneOuVoyelle[14] = 1; // O
            TabloConsonneOuVoyelle[20] = 1; // U
            TabloConsonneOuVoyelle[24] = 1; // Y
        }

        public static void GenerateAlphabet()
        {
            for (int i = 65; i < 91; i++)
            {
                Alphabet[i - 65] = Convert.ToChar(i);
            }
        }

        public static void PointForEachLetter()
        {
            for (int i = 0; i < 26; i++)
            {
                PointArrayForAletter[i] = 1; // Lettres communes
            }

            PointArrayForAletter[5] = 4; // F
            PointArrayForAletter[6] = 2; // G
            PointArrayForAletter[7] = 4; // H
            PointArrayForAletter[10] = 10; // K
            PointArrayForAletter[11] = 2; // L
            PointArrayForAletter[12] = 2; // M
            PointArrayForAletter[15] = 3; // P
            PointArrayForAletter[16] = 8; // Q
            PointArrayForAletter[21] = 5; // V
            PointArrayForAletter[22] = 15; // W
            PointArrayForAletter[23] = 10; // X
            PointArrayForAletter[24] = 8; // Y
            PointArrayForAletter[25] = 10; // Z
        }

        public static void DiffultyLetter()
        {
            for (int i = 0; i < 26; i++)
            {
                TabloDifficulte[i] = 0; // Sans difficulté
            }

            for (int i = 11; i < 16; i++)
            {
                TabloDifficulte[i] = 1; // L M N O P peu de difficulté
            }

            TabloDifficulte[5] = 2; // F  difficulté moyenne
            TabloDifficulte[20] = 2; // U
            TabloDifficulte[14] = 2; // O
            TabloDifficulte[6] = 2; // G
            TabloDifficulte[7] = 4; // H difficulté prononcée
            TabloDifficulte[21] = 4; // V
            TabloDifficulte[10] = 5; // difficulté très prononcée
            TabloDifficulte[9] = 8;  // J
            TabloDifficulte[16] = 8; // Q
            for (int i = 22; i < 26; i++)
            {
              // W X Y Z
              TabloDifficulte[i] = 8;
            }
        }

        public static void MatrixIniialization()
        {
            GenerateAlphabet();
            MakeItConsonnant();
            PointForEachLetter();
            DiffultyLetter();
        }

        public static void ResetLettersUtilisationArray()
        {
            // met toutes les case du tableau des cases cochées = false
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    ArrayOfLetterUse[i, j] = false;
                }
            }
        }

        public static void SetPlaceOfUsingLetter(int x, int y)
        {
            ChoosenSquare.X = x;
            ChoosenSquare.Y = y;
        }

        public static void StoreUsingPlace()
        {
            PrecedentSquare.X = ChoosenSquare.X;
            PrecedentSquare.Y = ChoosenSquare.Y;
        }
    }
}
