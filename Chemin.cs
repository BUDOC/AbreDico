using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class Chemin
    {
        public class MyCellClass
        // définition de la case : level sera affecté en fonction de la profondeur d'exploration du chemin
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Level { get; set; }
            public List<MyCellClass> ListOfPossibleNeighbor = new List<MyCellClass>();
        }
        public static string Test = "";
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
        public static void FindAcceptablesNeighbors(MyCellClass WorkingCell)
        {
            // cette procedure trouve les cases voisines de celle passée en pramètre
            // Créer des instance de Case pour chacune 
            //et les ajoute dans la liste des cases voisine de la case passée en pramètre 
            // et le niveau de parcours du chemin?
            int XofCell = WorkingCell.X;
            int YofCell = WorkingCell.Y;
            int NextLevel = WorkingCell.Level + 1;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int CoordonneeX = XofCell + dx;
                    int CoordonneeY = YofCell + dy;
                    if ((CoordonneeX == XofCell) && (CoordonneeY == YofCell))
                    {
                        //On ne fait rien car les coordonnées sont celles de la case d'appel
                    }
                    else
                    {
                        if (CoordonneeX >= 0 && CoordonneeX < 4 && CoordonneeY >= 0 && CoordonneeY < 4)
                        {
                            // on traite car les coordonnées sont acceptables
                            if (ArrayOfUsedCells[CoordonneeX, CoordonneeY])
                            {
                                // La  case est déjà utilisée : on ne fait rien
                            }
                            else
                            {
                                // La case est libre donc utilisable donc
                                // on crée une Case de coordonnées courantes 
                                // qu'on ajoute à la liste des cases voisines de la case courante
                                MyCellClass NeighborsCell = new MyCellClass
                                {
                                    X = CoordonneeX,
                                    Y = CoordonneeY,
                                    Level = NextLevel
                                };
                                WorkingCell.ListOfPossibleNeighbor.Add(NeighborsCell);
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
        public static char LetterOfCell(MyCellClass OneCell)
        {
            return DonneesLettres.tableauDeLettres[OneCell.X, OneCell.Y];
        }
        public static char[] PossibleWord = new char[16];
        public static void InitializePossibleWord()
        {
            for (int i = 0; i < 16; i++)
            {
                PossibleWord[i] = '.';
            }
        }
        public static string WordFind;
        public static void FindPossibleWord(int Level)
        {
            WordFind = "";
            for (int i = 0; i <= Level; i++)
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
                    Chemin.BeginTree(i, j);
                }
            }
        }
        public static void BeginTree(int X, int Y)
        {
            InitialiseArrayOfUsedfCells();
            InitializePossibleWord();
            MyCellClass Root = new MyCellClass();
            Root.X = X;
            Root.Y = Y;
            Root.Level = 0;
            ArrayOfUsedCells[Root.X, Root.Y] = true;
            PossibleWord[Root.Level] = LetterOfCell(Root);
            FindAcceptablesNeighbors(Root);
            ShowCell(Root);            
            for (int round0 = 0; round0 < Root.ListOfPossibleNeighbor.Count; round0++)
            {             
                GoOnTree(Root, Root.ListOfPossibleNeighbor[round0]);
            }
        }
        public static void GoOnTree(MyCellClass TopCell, MyCellClass DonwCell)
        {
            ArrayOfUsedCells[DonwCell.X, DonwCell.Y] = true;
            PossibleWord[DonwCell.Level] = LetterOfCell(DonwCell);
            FindAcceptablesNeighbors(DonwCell);            
            ShowCell(DonwCell);
            if (DonwCell.ListOfPossibleNeighbor.Count == 0)
            {
                ArrayOfUsedCells[DonwCell.X, DonwCell.Y] = false;
                PossibleWord[DonwCell.Level] = '*';
                int MaxIndex = TopCell.ListOfPossibleNeighbor.Count;
                // Vire la reference à la celulle courante de la liste de la cellule mère
                for (int NumCell = 0; NumCell < MaxIndex; NumCell++)
                {   // Vire de la liste des voisines possibles de la case de niveau supérieur la référence à la cellule en cours
                    if (TopCell.ListOfPossibleNeighbor[NumCell].X == DonwCell.X && TopCell.ListOfPossibleNeighbor[NumCell].Y == DonwCell.Y)
                    {
                        TopCell.ListOfPossibleNeighbor.RemoveAt(NumCell);
                        NumCell = MaxIndex; //pour sortir
                                           
                    }
                }
            }
            else
            {
                GoOnTree(DonwCell, DonwCell.ListOfPossibleNeighbor[0]);
                if (DonwCell.ListOfPossibleNeighbor.Count != 0)
                {
                    ArrayOfUsedCells[DonwCell.X, DonwCell.Y] = false;
                    PossibleWord[DonwCell.Level] = '|';                   
                }
            }           
        }
        private static void ShowCell(MyCellClass Cell)
        {          
           FindPossibleWord(Cell.Level);        
            if (ArbreDesMots.Motexiste(WordFind, ArbreDesMots.NoeudRacine))
            {
                // Test += WordFind + "\r\n";     
                AddWordInListExistingWords(WordFind);
            }
        }
        public static int NumberOfWordCanBeDone = 0;
        public static  List<string> ListExistingWords = new List<string>();
        public static void AddWordInListExistingWords(string Word)
        {
            bool AlreadyExists = false;
            if (ListExistingWords.Count==0) // si la liste est vide on ajoute le mot
            {
                ListExistingWords.Add(Word);
                NumberOfWordCanBeDone++;
            }
            else
            { // on regarde si le mot existe déja dans la liste
                for(int i=0; i<ListExistingWords.Count; i++)
                {
                    if(ListExistingWords[i]== Word)
                    {
                        AlreadyExists = true;
                        i = ListExistingWords.Count;
                    }
                }
                if(AlreadyExists==false)
                {
                    ListExistingWords.Add(Word);
                    NumberOfWordCanBeDone++;
                }
            }

        }

    }
}
