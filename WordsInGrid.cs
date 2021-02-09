using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    public class OneCell
    {

        public int X { get; set; }

        public int Y { get; set; }

        public int Deep { get; set; }

        internal List<OneCell> ListOfPossiblesCellNeighbors { get; set; } = new List<OneCell>();
    }

    class WordsInGrid
    {
        private static Double cptCombinaisons = 1;

        private static char[] PossibleWord { get; set; } = new char[16];

        private static readonly bool[,] ArrayOfUsedCells = new bool[4, 4];

        public static string Test { get; set; }

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

        public static void CreateTestLetterArray()
        {
            char[,] testLetterArray = new char[4, 4];
            testLetterArray[0, 0] = 'I';
            testLetterArray[0, 1] = 'M';
            testLetterArray[0, 2] = 'L';
            testLetterArray[0, 3] = 'I';
            testLetterArray[1, 0] = 'M';
            testLetterArray[1, 1] = 'O';
            testLetterArray[1, 2] = 'U';
            testLetterArray[1, 3] = 'M';
            testLetterArray[2, 0] = 'E';
            testLetterArray[2, 1] = 'R';
            testLetterArray[2, 2] = 'T';
            testLetterArray[2, 3] = 'A';
            testLetterArray[3, 0] = 'I';
            testLetterArray[3, 1] = 'T';
            testLetterArray[3, 2] = 'N';
            testLetterArray[3, 3] = 'I';

            for (int li = 0; li < 4; li++)
            {
                for (int co = 0; co < 4; co++)
                {
                    DonneesLettres.TableauDeLettres[li, co] = testLetterArray[li, co];
                }
            }
        }

        public static void DebogAfficheWord()
        {
            string toto = "";
            for (int i = 0; i < 16; i++)
            {
                toto += PossibleWord[i];
            }
            sw2.WriteLine(toto);
            // Test += "\r\n";
        }

        private static StreamWriter sw2 = new StreamWriter("test Combinaisons.txt");

        public static void BeginTree(int x, int y)
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
            DebogAfficheWord();
            AddAcceptablesNeighbors(root);

            // AddPossibleWordsToList(root);

            while (root.ListOfPossiblesCellNeighbors.Count != 0)
            {
              //  sw2.WriteLine(" APPEL EXPLORATION VOISINE ROOT. =========");
                AllWays(root, root.ListOfPossiblesCellNeighbors[0]);
                root.ListOfPossiblesCellNeighbors.RemoveAt(0);
            }

            // erase  True in used cells array.
            ArrayOfUsedCells[root.X, root.Y] = false;
            Test += cptCombinaisons.ToString() + " \r\n ";

        }

        public static void AllWays(OneCell upCell, OneCell lowCell)
        {
            cptCombinaisons++;
            ArrayOfUsedCells[lowCell.X, lowCell.Y] = true;
            PossibleWord[lowCell.Deep] = LetterOfCell(lowCell);
            DebogAfficheWord();
            AddAcceptablesNeighbors(lowCell);
            while (lowCell.ListOfPossiblesCellNeighbors.Count != 0)
            {
                AllWays(lowCell, lowCell.ListOfPossiblesCellNeighbors[0]);
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
                                OneCell neighborsCell = new OneCell
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

        
        public static void ExploreCellWay()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    BeginTree(i, j);
                }
            }
            sw2.Close();
            TrouveMots();
        }

        private static void TrouveMots()
        {
            string[] combinaisons;
            combinaisons = File.ReadAllLines("test Combinaisons.txt");

            string mot = "";
            StreamWriter sw3 = new StreamWriter("Mots retenus.txt");
            int cptMots = 0;
            int rang ;
                 for (int i = 0; i <= combinaisons.Length - 1; i++)
                {
                rang = 0;
                mot = "";
                while ((int)combinaisons[i][rang] >= 65  && (int)combinaisons[i][rang] <= 90 && rang<15)
                {
                  
                    mot += combinaisons[i][rang];
                    rang++;
                }
            
                    if (WordsTree.WordExists(mot, LoadWordsDictionnary.NoeudRacine))
                    {
                        sw3.WriteLine(mot);
                        Test += mot+ "\r\n";
                        cptMots++;
                    }
                }
                 Test+=cptMots.ToString() + "\r\n";
            sw3.Close();
        }
    }

        // fin Class WordsGrid
    }

