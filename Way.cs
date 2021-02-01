using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    internal class Way
    {
        public class MyCellClass

        // définition de la case : level sera affecté en fonction de la profondeur d'exploration du chemin
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Level { get; set; }

            internal List<MyCellClass> ListOfPossibleNeighbor { get; set; } = new List<MyCellClass>();
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

        public static void FindAcceptablesNeighbors(MyCellClass workingCell)
        {
            // cette procedure trouve les cases voisines de celle passée en pramètre
            // Créer des instance de Case pour chacune
            // et les ajoute dans la liste des cases voisine de la case passée en pramètre
            // et le niveau de parcours du chemin?
            int xofCell = workingCell.X;
            int yofCell = workingCell.Y;
            int nextLevel = workingCell.Level + 1;
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
                                    Level = nextLevel,
                                };
                                workingCell.ListOfPossibleNeighbor.Add(neighborsCell);
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

        public static void TotalExploration()
        {
            int cpt = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cpt++;
                    BeginTree(i, j);
                }
            }
        }

        public static void BeginTree(int x, int y)
        {
            InitialiseArrayOfUsedfCells();
            InitializePossibleWord();
            MyCellClass root = new MyCellClass
            {
                X = x,
                Y = y,
                Level = 0,
            };
            ArrayOfUsedCells[root.X, root.Y] = true;
            PossibleWord[root.Level] = LetterOfCell(root);
            FindAcceptablesNeighbors(root);
            ShowCell(root);
            for (int round0 = 0; round0 < root.ListOfPossibleNeighbor.Count; round0++)
            {
                GoOnTree(root, root.ListOfPossibleNeighbor[round0]);
            }
        }

        public static void GoOnTree(MyCellClass topCell, MyCellClass donwCell)
        {
            ArrayOfUsedCells[donwCell.X, donwCell.Y] = true;
            PossibleWord[donwCell.Level] = LetterOfCell(donwCell);
            FindAcceptablesNeighbors(donwCell);
            ShowCell(donwCell);
            if (donwCell.ListOfPossibleNeighbor.Count == 0)
            {
                ArrayOfUsedCells[donwCell.X, donwCell.Y] = false;
                PossibleWord[donwCell.Level] = '*';
                int maxIndex = topCell.ListOfPossibleNeighbor.Count;

                // Vire la reference à la celulle courante de la liste de la cellule mère
                for (int numCell = 0; numCell < maxIndex; numCell++)
                { // Vire de la liste des voisines possibles de la case de niveau supérieur la référence à la cellule en cours
                    if (topCell.ListOfPossibleNeighbor[numCell].X == donwCell.X && topCell.ListOfPossibleNeighbor[numCell].Y == donwCell.Y)
                    {
                        topCell.ListOfPossibleNeighbor.RemoveAt(numCell);
                        numCell = maxIndex; // pour sortir
                    }
                }
            }
            else
            {
                GoOnTree(donwCell, donwCell.ListOfPossibleNeighbor[0]);
                if (donwCell.ListOfPossibleNeighbor.Count != 0)
                {
                    ArrayOfUsedCells[donwCell.X, donwCell.Y] = false;
                }
            }
        }

        private static void ShowCell(MyCellClass cell)
        {
            FindPossibleWord(cell.Level);
            if (ArbreDesMots.WordExists(WordFind, ArbreDesMots.NoeudRacine))
            {
                // Test += WordFind + "\r\n";
                AddWordInListExistingWords(WordFind);
            }
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
