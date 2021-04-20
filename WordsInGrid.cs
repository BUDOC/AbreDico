using System.Collections.Generic;
using System.IO;

namespace AbreDico
{
  class WordsInGrid
  {
    // Liste des mots contenus dans la grille
    public static List<string> WordList = new List<string>();

    private static double cptCombinaisons = 1;

    private static char[] PossibleWord { get; set; } = new char[16];

    private static readonly bool[,] ArrayOfUsedCells = new bool[4, 4];

    public static string Test { get; set; }

    private static string listOfPossibleWord = string.Empty

    public static void ExploreCellWay()
    {
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          BeginTree(i, j);
        }
      }
    }

    private static void InitialiseArrayOfUsedfCells()
    {
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          ArrayOfUsedCells[i, j] = false;
        }
      }
    }

    private static char LetterOfCell(OneCell oneCell)
    {
      return DonneesLettres.TableauDeLettres[oneCell.X, oneCell.Y];
    }

    private static void InitializePossibleWord()
    {
      for (int i = 0; i < 16; i++)
      {
        PossibleWord[i] = '.';
      }
    }

    private static void TestMot(int wordLength)
    {
      string myWord = string.Empty;
      for (int i = 0; i < wordLength + 1; i++)
      {
        myWord += PossibleWord[i];
      }

      if (WordsTree.WordExists(myWord, LoadWordsDictionnary.NoeudRacine))
      {
        if (WordList.Count == 0)
        {
          // si la liste est vide on ajoute le mot
          WordList.Add(myWord);
        }
       else
        {
          // La liste n'est pas vide => on vérifie si le mot n'est pas déjà dans la liste
          bool isInList = false;
          for (int i = 0; i < WordList.Count; i++)
          {
            if (WordList[i] == myWord)
            {
              isInList = true;
              i = WordList.Count;

              // System.Windows.Forms.MessageBox.Show("Le mot " + myWord + " Existe déjà");
            }
          }

          if (isInList == false)
          {
            WordList.Add(myWord);
          }
        }

        listOfPossibleWord += myWord + "\r\n";
        
        // System.Windows.Forms.MessageBox.Show("Le mot " + myWord + " Existe");
      }
    }

    // BegiTree commande la recherche des mots possibles dans la grille à partir de la case aux coordonnées passées en paramètre
    private static void BeginTree(int x, int y)
    {
      InitialiseArrayOfUsedfCells();
      InitializePossibleWord();
      OneCell root = new OneCell
      {
        X = x,
        Y = y,
        Deep = 0,
      };
      ArrayOfUsedCells[root.X, root.Y] = true;
      PossibleWord[root.Deep] = LetterOfCell(root);
      TestMot(root.Deep);
      AddAcceptablesNeighbors(root);
      while (root.ListOfPossiblesCellNeighbors.Count != 0)
      {
        AllWays(root.ListOfPossiblesCellNeighbors[0]);
        root.ListOfPossiblesCellNeighbors.RemoveAt(0);
      }

      // replace  True  by false in used cells array.
      ArrayOfUsedCells[root.X, root.Y] = false;
    }

    // AllWays est appelée par BeginTree pour continuer la recherche des mots possibles
    // dans la grille à partir de la case  passée en paramètre
    private static void AllWays(OneCell lowCell)
    {
      cptCombinaisons++;
      ArrayOfUsedCells[lowCell.X, lowCell.Y] = true;
      PossibleWord[lowCell.Deep] = LetterOfCell(lowCell);
      TestMot(lowCell.Deep);
      AddAcceptablesNeighbors(lowCell);
      while (lowCell.ListOfPossiblesCellNeighbors.Count != 0)
      {
        AllWays(lowCell.ListOfPossiblesCellNeighbors[0]);
        lowCell.ListOfPossiblesCellNeighbors.RemoveAt(0);
      }

      ArrayOfUsedCells[lowCell.X, lowCell.Y] = false;
      PossibleWord[lowCell.Deep] = '+';
    }

    private static void AddAcceptablesNeighbors(OneCell workingCell)
    {
      // cette procedure trouve les cases voisines de celle passée en paramètre
      // Créer des instances de Case pour chacune
      // et les ajoute dans la liste des cases voisines de la case passée en paramètre
      // et le niveau de parcours du chemin est incrémenté pour ces cellules voisines
      int xofCell = workingCell.X;
      int yofCell = workingCell.Y;
      int nextLevel = workingCell.Deep + 1;
      for (
          int dx = -1; dx < 2; dx++)
      {
        for (int dy = -1; dy < 2; dy++)
        {
          int coordonneeX = xofCell + dx;
          int coordonneeY = yofCell + dy;
          if ((coordonneeX == xofCell) && (coordonneeY == yofCell))
          {
            // On ne fait rien car les coordonnées sont celles de la case d'appel
          }
          else
          {
            if (coordonneeX >= 0 && coordonneeX < 4 && coordonneeY >= 0 && coordonneeY < 4)
            {
              // on traite car les coordonnées sont acceptables
              if (ArrayOfUsedCells[coordonneeX, coordonneeY])
              {
                // La  case est déjà utilisée : on ne fait rien
              }
              else
              {
                // La case est libre donc utilisable donc
                // on crée une Case de coordonnées courantes
                // qu'on ajoute à la liste des cases voisines de la case courante si le chemin n'est pas sans issu.
                if (IsNotSteril(Chaine(nextLevel)))
                {
                  OneCell neighborsCell = new OneCell
                  {
                    X = coordonneeX,
                    Y = coordonneeY,
                    Deep = nextLevel,
                  };
                  workingCell.ListOfPossiblesCellNeighbors.Add(neighborsCell);
                }
              }
            }
            else
            {
              // on ne fait rien car au moins une des coordonnées est hors limites
            }
          }
        }
      }
    }

    // retourne le mot ou début de mot
    private static string Chaine(int rang)
    {
      string newWord = string.Empty;
      for (int i = 0; i < rang; i++)
      {
        newWord += PossibleWord[i];
      }

      // System.Windows.Forms.MessageBox.Show(newWord);
      return newWord;
    }

    private static bool IsNotSteril(string suite)
    {
      bool ok = false;
      Noeud noeudDeTravail = LoadWordsDictionnary.NoeudRacine;

      for (int i = 0; i < suite.Length; i++)
      {
        if (noeudDeTravail.DictionnaireDesSousNoeuds != null)
        {
          if (noeudDeTravail.DictionnaireDesSousNoeuds.ContainsKey(suite[i]))
          {
            ok = true;
            noeudDeTravail = noeudDeTravail.DictionnaireDesSousNoeuds[suite[i]];
          }
          else
          {
            ok = false;
          }
        }
        else
        {
          ok = false;
        }
      }

      return ok;
    }

    // fin Class WordsGrid
  }
}
