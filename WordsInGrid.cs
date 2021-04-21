using System.Collections.Generic;
using System.IO;

namespace AbreDico
{
  class WordsInGrid
  {
    // Liste des mots contenus dans la grille
    private List<string> WordList = new List<string>();

    private double cptCombinaisons = 1;

    private char[] PossibleWord { get; set; } = new char[16];

    private readonly bool[,] ArrayOfUsedCells = new bool[4, 4];

    public string Test { get; set; }

    private string listOfPossibleWord = string.Empty;

    public List<string> ExploreCellWay()
    {
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          this.BeginTree(i, j);
        }
      }

      return this.WordList;
    }

    private void InitialiseArrayOfUsedfCells()
    {
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          this.ArrayOfUsedCells[i, j] = false;
        }
      }
    }

    private char LetterOfCell(OneCell oneCell)
    {
      return DonneesLettres.TableauDeLettres[oneCell.X, oneCell.Y];
    }

    private void InitializePossibleWord()
    {
      for (int i = 0; i < 16; i++)
      {
        this.PossibleWord[i] = '.';
      }
    }

    private void TestMot(int wordLength)
    {
      string myWord = string.Empty;
      for (int i = 0; i < wordLength + 1; i++)
      {
        myWord += this.PossibleWord[i];
      }

      if (WordsTree.WordExists(myWord, LoadWordsDictionnary.NoeudRacine))
      {
        if (this.WordList.Count == 0)
        {
          // si la liste est vide on ajoute le mot
          this.WordList.Add(myWord);
        }
        else
        {
          // La liste n'est pas vide => on vérifie si le mot n'est pas déjà dans la liste
          bool isInList = false;
          for (int i = 0; i < this.WordList.Count; i++)
          {
            if (this.WordList[i] == myWord)
            {
              isInList = true;
              i = this.WordList.Count;

              // System.Windows.Forms.MessageBox.Show("Le mot " + myWord + " Existe déjà");
            }
          }

          if (isInList == false)
          {
            this.WordList.Add(myWord);
          }
        }

        this.listOfPossibleWord += myWord + "\r\n";

        // System.Windows.Forms.MessageBox.Show("Le mot " + myWord + " Existe");
      }
    }

    // BegiTree commande la recherche des mots possibles dans la grille à partir de la case aux coordonnées passées en paramètre
    private void BeginTree(int x, int y)
    {
      this.InitialiseArrayOfUsedfCells();
      this.InitializePossibleWord();
      OneCell root = new OneCell
      {
        X = x,
        Y = y,
        Deep = 0,
      };
      this.ArrayOfUsedCells[root.X, root.Y] = true;
      this.PossibleWord[root.Deep] = this.LetterOfCell(root);
      this.TestMot(root.Deep);
      this.AddAcceptablesNeighbors(root);
      while (root.ListOfPossiblesCellNeighbors.Count != 0)
      {
        this.AllWays(root.ListOfPossiblesCellNeighbors[0]);
        root.ListOfPossiblesCellNeighbors.RemoveAt(0);
      }

      // replace  True  by false in used cells array.
      this.ArrayOfUsedCells[root.X, root.Y] = false;
    }

    // AllWays est appelée par BeginTree pour continuer la recherche des mots possibles
    // dans la grille à partir de la case  passée en paramètre
    private void AllWays(OneCell lowCell)
    {
      this.cptCombinaisons++;
      this.ArrayOfUsedCells[lowCell.X, lowCell.Y] = true;
      this.PossibleWord[lowCell.Deep] = this.LetterOfCell(lowCell);
      this.TestMot(lowCell.Deep);
      this.AddAcceptablesNeighbors(lowCell);
      while (lowCell.ListOfPossiblesCellNeighbors.Count != 0)
      {
        this.AllWays(lowCell.ListOfPossiblesCellNeighbors[0]);
        lowCell.ListOfPossiblesCellNeighbors.RemoveAt(0);
      }

      this.ArrayOfUsedCells[lowCell.X, lowCell.Y] = false;
      this.PossibleWord[lowCell.Deep] = '+';
    }

    /// <summary>
    /// cette procedure trouve les cases voisines de celle passée en paramètre
    /// Créer des instances de Case pour chacune
    /// et les ajoute dans la liste des cases voisines de la case passée en paramètre
    /// et le niveau de parcours du chemin est incrémenté pour ces cellules voisines
    /// </summary>
    private void AddAcceptablesNeighbors(OneCell workingCell)
    {
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
              if (this.ArrayOfUsedCells[coordonneeX, coordonneeY])
              {
                // La  case est déjà utilisée : on ne fait rien
              }
              else
              {
                // La case est libre donc utilisable donc
                // on crée une Case de coordonnées courantes
                // qu'on ajoute à la liste des cases voisines de la case courante si le chemin n'est pas sans issu.
                if (this.IsNotSteril(this.Chaine(nextLevel)))
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
    private string Chaine(int rang)
    {
      string newWord = string.Empty;
      for (int i = 0; i < rang; i++)
      {
        newWord += this.PossibleWord[i];
      }

      // System.Windows.Forms.MessageBox.Show(newWord);
      return newWord;
    }

    private bool IsNotSteril(string suite)
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
