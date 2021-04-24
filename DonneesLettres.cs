using System;

namespace AbreDico
{
  /// <summary>
  /// Contient les méthodes de gestion des lettres.
  /// </summary>
  internal class DonneesLettres
  {
    /// <summary>
    /// Retourne tru si le caratère passé est une voyelle.
    /// </summary>
    /// <param name="lettre"> caractère.</param>
    /// <returns> true ou false.</returns>
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

    /// <summary>
    /// Retourne le noumbre de voyelles du tableau.
    /// </summary>
    /// <param name="matrice"> Matrice.</param>
    /// <returns> nombre de voyelles.</returns>
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

    /// <summary>
    /// Ensemble des consonnnes considérées difficiles.
    /// </summary>
    public static readonly char[] DifficylConsonnants = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };

    /// <summary>
    /// Tableau qui contient les lettres de l'alphabet.
    /// </summary>
    public static readonly char[] Alphabet = new char[26];

    /// <summary>
    /// consonne (0) ou Voyelle (1).
    /// </summary>
    public static readonly int[] TabloConsonneOuVoyelle = new int[26];

    /// <summary>
    /// Tableau du nombes des points attribué à chaque lettre. Fonctionne en paralèlle du tableau alphabet.
    /// </summary>
    public static readonly int[] PointArrayForAletter = new int[26];

    /// <summary>
    /// Tableau de niveau de difficulté d'utilisation de chaque lettre. Fonctionne en paralèlle du tableau alphabet.
    /// </summary>
    public static readonly int[] TabloDifficulte = new int[26];

    /// <summary>
    /// Tableau carrré représentant l'utilisation des cases de la matrice.
    /// </summary>
    public static readonly bool[,] ArrayOfLetterUse = new bool[4, 4];

    /// <summary>
    /// Tableau carrré des lettres de la matrice.
    /// </summary>
    public static readonly char[,] TableauDeLettres = new char[4, 4];

    /// <summary>
    /// Tableau linéaire des 16 lettres de la matrice.
    /// </summary>
    public static readonly char[] ArrayOfLetters = new char[16];

    /// <summary>
    ///  Coordonnées de la case choisie par le joueur.
    /// </summary>
    public static readonly Point2D ChoosenSquare = new Point2D();

    /// <summary>
    ///  Coordonnées de la case choisie par le joueur au tour précédent.
    /// </summary>
    public static readonly Point2D PrecedentSquare = new Point2D();

    /// <summary>
    /// Tableau des voyelles usuelles.
    /// </summary>
    public static char[] UsualVowels = { 'E', 'A', 'I', 'O', 'U' };

    /// <summary>
    /// Score total du joueur.
    /// </summary>
    public int ScoreTotal = 0;

    /// <summary>
    /// Retourne la place dans le tableau alphabet du caractère passé en paramètre.
    /// </summary>
    /// <param name="c"> caractère. </param>
    /// caractère à tester
    /// <returns> le caractère. </returns>
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

    /// <summary>
    /// renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char.
    /// </summary>
    /// <param name="c"> caractère.</param>
    /// <returns> Nombre de voyelles.</returns>
    public static int HowManyInMatrix(char c)
    {
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

    /// <summary>
    /// Tourne la matrice de 90°.
    /// </summary>
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

    /// <summary>
    ///  Affecte à chaque lettre de l'alphabet la valeur consonnen(0) ou voyelle(1).
    /// </summary>
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

    /// <summary>
    /// Remplit le tableau alphabet.
    /// </summary>
    public static void GenerateAlphabet()
    {
      for (int i = 65; i < 91; i++)
      {
        Alphabet[i - 65] = Convert.ToChar(i);
      }
    }

    /// <summary>
    /// Affecte le nombre de points à chaque lettre.
    /// </summary>
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

    /// <summary>
    /// Affecte à chaque letttre de l'alphabet un niveau de difficulté d'utilisation.
    /// </summary>
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

    /// <summary>
    /// Initialise la matrice de lettres.
    /// </summary>
    public static void MatrixIniialization()
    {
      GenerateAlphabet();
      MakeItConsonnant();
      PointForEachLetter();
      DiffultyLetter();
    }

    /// <summary>
    /// Réinitialise le tableau d'utilisation des cases.
    /// </summary>
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

    /// <summary>
    /// Fixe la valeur des coordonnnées de la case chosie.
    /// </summary>
    /// <param name="x"> X.</param>
    /// <param name="y">Y.</param>
    public static void SetPlaceOfUsingLetter(int x, int y)
    {
      ChoosenSquare.X = x;
      ChoosenSquare.Y = y;
    }

    /// <summary>
    /// Fixe la valeur des coordonnnées de la case chosie au tour précéde t.
    /// </summary>
    /// <param name="x"> X.</param>
    /// <param name="y">Y.</param>
    public static void StoreUsingPlace()
    {
      PrecedentSquare.X = ChoosenSquare.X;
      PrecedentSquare.Y = ChoosenSquare.Y;
    }
  }
}
