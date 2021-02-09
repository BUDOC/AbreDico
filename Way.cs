using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbreDico
{   
    // this class allow the verification of the proposind gamer word exists
    internal class Way
    {
        // définition de la case : Deep sera affecté en fonction de la profondeur d'exploration du chemin
        
        public class MyCellClass
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Deep { get; set; }

            internal List<MyCellClass> ListOfPossiblesCellNeighbors { get; set; } = new List<MyCellClass>();
        }

        private static readonly bool[,] ArrayOfUsedCells = new bool[4, 4];

      

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

        public static void AddAcceptablesNeighbors(MyCellClass workingCell)
        {
            // cette procedure trouve les cases voisines de celle passée en pramètre
            // Créer des instances de Case pour chacune
            // et les ajoute dans la liste des cases voisines de la case passée en pramètre
            // et le niveau de parcours du chemin est incrémenté pour ces cellules voisines
            int xofCell = workingCell.X;
            int yofCell = workingCell.Y;
            int nextLevel = workingCell.Deep + 1;
            for (int dx = -1; dx < 2; dx++)
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
                                // qu'on ajoute à la liste des cases voisines de la case courante
                                MyCellClass neighborsCell = new MyCellClass
                                {
                                    X = coordonneeX,
                                    Y = coordonneeY,
                                    Deep = nextLevel,
                                };
                                workingCell.ListOfPossiblesCellNeighbors.Add(neighborsCell);
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

        public static char LetterOfCell(MyCellClass oneCell)
        {
            return DonneesLettres.TableauDeLettres[oneCell.X, oneCell.Y];
        }

        public static void InitializePossibleWord()
        {
            for (int i = 0; i < 16; i++)
            {
                PossibleWord[i] = '.';
            }
        }

        public static void FindPossibleWord(int level)
        {
            WordFind = string.Empty;
            for (int i = 0; i <= level; i++)
            {
                WordFind += PossibleWord[i];
            }
        }

        // find all combinations workables in  the matrix
        public static void TotalExploration()
        {
            BeginTree(0, 0);
           /* int cpt = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cpt++;
                    BeginTree(i, j);
                }
            }*/
        }

        // begin the exploration in x,y cell of matrix . (set the root)
        public static void BeginTree(int x, int y)
        {
            InitialiseArrayOfUsedfCells();
            InitializePossibleWord();
            MyCellClass root = new MyCellClass
            {
                X = x,
                Y = y,
                Deep = 0,
            };
            ArrayOfUsedCells[root.X, root.Y] = true;
            PossibleWord[root.Deep] = LetterOfCell(root);
            AddAcceptablesNeighbors(root);
            AddPossibleWordsToList(root);

            // for every neighbour of root run GoOntree
           /* for (int round0 = 0; round0 < root.ListOfPossiblesCellNeighbors.Count; round0++)
            {
                GoOnTree(root, root.ListOfPossiblesCellNeighbors[round0]);
            }*/

             while ( root.ListOfPossiblesCellNeighbors.Count != 0)
            {
                  GoOnTree(root, root.ListOfPossiblesCellNeighbors[0]); 
                root.ListOfPossiblesCellNeighbors.RemoveAt(0);
            }

            // erase  True in used cells array.
            ArrayOfUsedCells[root.X, root.Y] = false;
        }

    
        public static void GoOnTree(MyCellClass topCell, MyCellClass donwCell)
        { 

            // add true in array of used cell for downcell
            ArrayOfUsedCells[donwCell.X, donwCell.Y] = true;

            // add the downcell letter to word in construction
            PossibleWord[donwCell.Deep] = LetterOfCell(donwCell);

            // find and add the possibles neighbours of downcell in downcell list of neighbours
            AddAcceptablesNeighbors(donwCell);
            AddPossibleWordsToList(donwCell);

            // dowcell have no neighbour
            if (donwCell.ListOfPossiblesCellNeighbors.Count == 0)
            {
                // make the cell not used
                ArrayOfUsedCells[donwCell.X, donwCell.Y] = false;

                // erase char at level place
                PossibleWord[donwCell.Deep] = '*';

                int maxIndex = topCell.ListOfPossiblesCellNeighbors.Count;

                // Find downcel reference in the neignbours list of Top cell
                for (int numCell = 0; numCell < maxIndex; numCell++)
                {
                    // if it is the cell we want to find we erase it
                    if (topCell.ListOfPossiblesCellNeighbors[numCell].X == donwCell.X && topCell.ListOfPossiblesCellNeighbors[numCell].Y == donwCell.Y)
                    {
                        topCell.ListOfPossiblesCellNeighbors.RemoveAt(numCell);

                        // to exit shortly
                        numCell = maxIndex;
                    }
                }
            }
            else

            // downcell have neighbour(s)
            {
                // ???????????????  c'est ici que la séquence ci-dessous doite être répétée pour toutes les voisines
                for ( int allNeighbours = 0;  allNeighbours < donwCell.ListOfPossiblesCellNeighbors.Count; allNeighbours++)
                {
                    GoOnTree(donwCell, donwCell.ListOfPossiblesCellNeighbors[allNeighbours]);
                }

                if (donwCell.ListOfPossiblesCellNeighbors.Count != 0)
                {
                    ArrayOfUsedCells[donwCell.X, donwCell.Y] = false;
                }
            }
        }

        // If the list of chars betwen 0 to level's cell witch is transmited  is a word it is add to list
        private static void AddPossibleWordsToList(MyCellClass cell)
        {
            FindPossibleWord(cell.Deep);
            if (WordsTree.WordExists(WordFind, LoadWordsDictionnary.NoeudRacine))
            {
                AddWordInListExistingWords(WordFind);

            }
            else
            {

            }

            for (int i = 0; i < PossibleWord.Length; i++)
            {
                Test += PossibleWord[i];
            }
            Test += "\r\n";
        }

        public static List<string> ListExistingWords { get; set; } = new List<string>();

        public static int NumberOfWordCanBeDone { get; set; } = 0;

        public static string WordFind { get; set; }

        public static string Test { get => Test1; set => Test1 = value; }

        public static char[] PossibleWord { get; set; } = new char[16];
        public static string Test1 { get; set; } = string.Empty;

        public static void AddWordInListExistingWords(string word)
        {
            bool alreadyExists = false;
            if (ListExistingWords.Count == 0) // si la liste est vide on ajoute le mot
            {
                ListExistingWords.Add(word);
                NumberOfWordCanBeDone++;
            }
            else
            { // on regarde si le mot existe déja dans la liste
                for (int i = 0; i < ListExistingWords.Count; i++)
                {
                    if (ListExistingWords[i] == word)
                    {
                        alreadyExists = true;
                        i = ListExistingWords.Count;
                    }
                }

                if (alreadyExists == false)
                {
                    ListExistingWords.Add(word);
                    NumberOfWordCanBeDone++;
                }
            }
        }
    }
}
