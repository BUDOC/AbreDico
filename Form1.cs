using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AbreDico
{
    public partial class Form1 : Form
    {
    private static List<string> FindedWordList = new List<string>();

    // crée une variable d'instance à laquelle on affectera le noeud racine (passage du pointeur)
    // pour en disposer dans Form1
    // **** Couleurs de l'environnement
    private readonly Color defaultColor = Color.FromName("Navy");

        // retourne une consonne en fonction du niveau de diffculté
        static Random rand = new Random();

        private static int RangConsonnant(int maxDifficulty)
        {
            int range;
            do
            {
                range = rand.Next(0, 26);
            }
            while
            (DonneesLettres.TabloDifficulte[range] >= maxDifficulty &&
                        DonneesLettres.TabloConsonneOuVoyelle[range] == 1);

            return range;
        }

        private void MatriceCreate()
        {
            // this part was programmed with feet but it works :-)
            // Variables
            var rand = new Random();
            int number0fVowel = rand.Next(8, 11);
            List<char> vowelList = new List<char>();
            char[,] lettersPositionningArray = new char[4, 4];

            // variable de limitation des voyelles répétée
            int maxO = 2;
            int maxU = 3;
            int maxI = 3;
            int maxA = 3;
            int maxE = 4;
            int cptO = 0;
            int cptU = 0;
            int cptI = 0;
            int cptA = 0;
            int cptE = 0;

            // initialise le tableau de lettre
            for (int line = 0; line < 4; line++)
            {
                for (int column = 0; column < 4; column++)
                {
                    lettersPositionningArray[line, column] = '?';
                }
            }

            // Ajoute des voyelles tirées au hasard dans la liste des voyelles
            vowelList.Clear();
            for (int i = 0; i <= number0fVowel; i++)
            {
                vowelList.Add(DonneesLettres.UsualVowels[rand.Next(0, 4)]);
            }

            void PlaceVoyelleDansQuart(int x1, int y1, int x2, int y2)
            {
                // a ajouter controle de nombre de voyelles répétées
                char vowel;
                for (int i = 0; i < 2; i++)
                {
                    int li = rand.Next(x1, y1);
                    Thread.Sleep(12);
                    int co = rand.Next(x2, y2);
                    Thread.Sleep(12);
                    if (lettersPositionningArray[li, co] == '?')
                    {
                        vowel = vowelList[rand.Next(0, vowelList.Count)];
                        Thread.Sleep(12);
                        switch (vowel)
                        {
                            case 'O':
                                if (cptO <= maxO)
                                {
                                    lettersPositionningArray[li, co] = vowel;
                                    cptO++;
                                }
                                else
                                {
                                    i--;
                                }

                                break;
                            case 'U':
                                if (cptU <= maxU)
                                {
                                    lettersPositionningArray[li, co] = vowel;
                                    cptU++;
                                }
                                else
                                {
                                    i--;
                                }

                                break;
                            case 'I':
                                if (cptI <= maxI)
                                {
                                    lettersPositionningArray[li, co] = vowel;
                                    cptI++;
                                }
                                else
                                {
                                    i--;
                                }

                                break;
                            case 'A':
                                if (cptA <= maxA)
                                {
                                    lettersPositionningArray[li, co] = vowel;
                                    cptA++;
                                }
                                else
                                {
                                    i--;
                                }
                                break;
                            case 'E':
                                if (cptE <= maxE)
                                {
                                    lettersPositionningArray[li, co] = vowel;
                                    cptE++;
                                }
                                else
                                {
                                    i--;
                                }

                                break;
                        }
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            // Place 2 voyelles aléatoirement dans chaque quart et le reste aléatoirement (donc 8 voyelles)
            // Quart NO
            PlaceVoyelleDansQuart(0, 2, 0, 2);

            // Quart NE
            PlaceVoyelleDansQuart(0, 2, 1, 4);

            // Quart SO
            PlaceVoyelleDansQuart(1, 4, 0, 2);

            // QuartSE
            PlaceVoyelleDansQuart(1, 4, 1, 4);

            // Ajoute si nécessaires pour atteindre le nombre de voyelles fixé aléatoirement
            if (number0fVowel < 8)
            {
                for (int i = 0; i < number0fVowel - 8; i++)
                {
                    int li = rand.Next(0, 4);
                    Thread.Sleep(14);
                    int co = rand.Next(0, 4);
                    Thread.Sleep(12);
                    while (lettersPositionningArray[li, co] == '?')
                    {
                        li = rand.Next(0, 4);
                        Thread.Sleep(13);
                        co = rand.Next(0, 4);
                        Thread.Sleep(14);
                    }
                    lettersPositionningArray[li, co] = vowelList[rand.Next(0, vowelList.Count)];
                }
            }

            // Remplit aléatoirement le reste du tableau avec des consonnes
            // en gérant la difficuté
            int difficultyLevel = 8;
            int rangTrouve;
            for (int li = 0; li < 4; li++)
            {
                for (int co = 0; co < 4; co++)
                {
                    rangTrouve = rand.Next(0, 26);
                    Thread.Sleep(12);
                    // pour toutes les cases du tableau
                    // si la case n'est pas utilisée
                    if (lettersPositionningArray[li, co] == '?')
                    {
                        // tire une consonne
                        char test = DonneesLettres.Alphabet[RangConsonnant(difficultyLevel)];
                        Thread.Sleep(11);
                        lettersPositionningArray[li, co] = test;
                        if (DonneesLettres.TabloDifficulte[rangTrouve] >= 3)
                        {
                            difficultyLevel -= 4;
                            if (difficultyLevel <= 0)
                            {
                                difficultyLevel = 1;
                            }
                        }
                    }
                }

                // transfere les lettres dans la matrice
            }

            for (int lig = 0; lig < 4; lig++)
            {
                for (int co = 0; co < 4; co++)
                {
                    DonneesLettres.TableauDeLettres[lig, co] = lettersPositionningArray[lig, co];
                }
            }

            this.CreateMatrix();
        }

        public void CreateMatrix() // Génère aléatoirement des lettres qui sont mises dans le tableau"matrice"
        {
            int cptVoyelle = 0;
            int voyelleDeSuite = 0;
            int consonneDeSuite = 0;
            int noteDeChiant = 0;
            int difficulteLettre;
            int maxVoyelle = 6;
            bool estUneVoyelle;
            bool accord = true;
            char lettre;
            var rand = new Random();

            // remplit un tableau [0..15] d'un caractère aléatoire
            int i = 0;

            // this.textBox2.Clear();
            while (i < 16)
            {
                int a = rand.Next(0, 25);
                lettre = DonneesLettres.Alphabet[a];
                if (i > 0)
                {
                    if (lettre != DonneesLettres.ArrayOfLetters[i - 1])
                    {
                        accord = true;
                    }
                    else
                    {
                        accord = false;
                    }
                }

                if (accord)
                {
                    // this.textBox2.Text = this.textBox2.Text + lettre.ToString() + " TIRE = " + nbDeLaLettre(lettre).ToString() + " fois \r\n";
                    difficulteLettre = DonneesLettres.TabloDifficulte[a];
                    if (DonneesLettres.TabloConsonneOuVoyelle[a] == 1) // détermine si le caractère est ou non une voyelle
                    {
                        estUneVoyelle = true;
                    }
                    else
                    {
                        estUneVoyelle = false;
                    }

                    if (estUneVoyelle && voyelleDeSuite < 3)
                    { // Tirage d'une voyelle
                        if (cptVoyelle <= maxVoyelle) // nombre de voyelles tirées inférieur au maximaum autorisé
                        { // cas autorisé
                            if (difficulteLettre > 0) // si tirage voyelle difficile
                            {
                                if (DonneesLettres.PlaceInMatrix(lettre) == -1 && noteDeChiant <= 4)
                                {
                                    // difficile pas en double
                                    DonneesLettres.ArrayOfLetters[i] = lettre;
                                    noteDeChiant += DonneesLettres.TabloDifficulte[i];
                                    cptVoyelle++;
                                    i++;
                                    voyelleDeSuite++;
                                    consonneDeSuite = 0;

                                    // this.textBox2.Text = this.textBox2.Text + "Voyelle difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                            }
                            else
                            {
                                // voyelle facile
                                DonneesLettres.ArrayOfLetters[i] = lettre;
                                voyelleDeSuite++;
                                consonneDeSuite = 0;

                                // this.textBox2.Text = this.textBox2.Text + "Voyelle facile Ajoutée = " + lettre.ToString() + "\r\n";
                            }
                        }
                    }
                    else
                    {// tirage d'une consonne
                        if (consonneDeSuite <= 2) // et pas trop de consonnnes d'affilé
                        {
                            if (difficulteLettre < 2) // facile
                            {
                                if ((difficulteLettre == 2 && DonneesLettres.PlaceInMatrix(lettre) == -1) || (difficulteLettre <= 1 && (DonneesLettres.HowManyInMatrix(lettre) < 3)))

                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    DonneesLettres.ArrayOfLetters[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;

                                    // this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile Ajoutée = " + lettre.ToString() + " exemplaire n° " + nbDeLaLettre(lettre).ToString() + "\r\n";
                                }
                                else
                                {
                                    // this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile rejetée = " + lettre.ToString() + "\r\n";
                                }
                            }
                            else
                            { // pas facile
                                if ((noteDeChiant < 3) && (DonneesLettres.HowManyInMatrix(lettre) < 2)) // acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;

                                    // augmentation de la note globale de chiant
                                    DonneesLettres.ArrayOfLetters[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;

                                    // this.textBox2.Text = "  " + this.textBox2.Text + " consonne difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                                else
                                {
                                    // on ne fait rien car pas acceptable
                                    //  this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "      Consonne rejetée" + lettre.ToString() + "\r\n";
                                }
                            }
                        } // consoles d'affilé
                    }
                } // fin du if = lettre precedente et conssonne et voyelles à suivre trop nombreuses
            } // fin du while remmplissage matrice

            // modifications pour rendre plus jouable
            if (DonneesLettres.HowManyInMatrix('E') < 2) // pas assez de E
            {
                int difMax = 0;
                for (int j = 0; j < 16; j++) // Repérage du plus haut diveau de difficulté présent
                {
                    if (DonneesLettres.TabloDifficulte[j] > difMax)
                    {
                        difMax = DonneesLettres.TabloDifficulte[j];
                    }
                }

                for (int j = 0; j < 16; j++) // la première lettre di niveau de difficulté Max est remplacée par E
                {
                    if (DonneesLettres.TabloDifficulte[j] == difMax)
                    {
                        // this.textBox2.Text = this.textBox2.Text + matrice[j].ToString() + " remplacée par = E \r\n";
                        DonneesLettres.ArrayOfLetters[j] = 'E';
                        cptVoyelle++;
                        j = 16;
                    }
                }

                for (int k = 0; k < 16; k++)
                {
                    // this.textBox2.Text = "  " + this.textBox2.Text + k.ToString() + "  " + matrice[k].ToString() + "\r\n";
                }
            }

            if (cptVoyelle < 6) // pas assez de voyelles
            {
                int aChanger = maxVoyelle - cptVoyelle - 1;
                int tour = 0;
                char car;
                while (tour < aChanger)
                { // substitution de consonnes par des voyelles
                    int b = rand.Next(0, 15);
                    car = DonneesLettres.ArrayOfLetters[b];
                    if (!DonneesLettres.EstVoyelle(car))
                    {
                        int c = rand.Next(0, 2);

                        // this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        DonneesLettres.ArrayOfLetters[b] = DonneesLettres.UsualVowels[c];
                        tour++;
                    }
                }

                // fin modifications pour rendre plus jouable
            }

            // transfert des lettres de Matrice vers tableaudelettres
            int ligne = 0, colonne = 0;
            for (int r = 0; r < 16; r++)
            {
                DonneesLettres.TableauDeLettres[ligne, colonne] = DonneesLettres.ArrayOfLetters[r];
                colonne++;
                if (colonne == 4)
                {
                    ligne++;
                    colonne = 0;
                }
            }

            // MessageBox.Show("nb voyelles =" + cptVoyelle);
        }

        public Form1()
        {
            this.InitializeComponent();
        }

        // Bouton qui déclenche l'action de controler si le mot est acceptable
        private void BoutonVerifMot(object sender, EventArgs e)
        {
            this.VerifMot();
            this.labNmotsTrouves.Text = "Nombre de mots trouvés = " + DataGame.NumberOFGoodWord.ToString();           
            this.textBox1.Clear();
            DataGame.ResetWordScore();
            this.labScoreMotJoueur.Text = string.Empty;
            this.DrawMatrix();
        }

        // Vérifie si le mot à controler n'est pas un mot déjà utilisé
        private void VerifMot()
        {   // ICI supprumer l'utilisation de Listbox1 et remplacer pas findedWordList !!!!!!!!!!!!
            this.pictureBox1.Visible = false;

            if (WordsTree.WordExists(this.textBox1.Text, LoadWordsDictionnary.NoeudRacine))
            { // le mot propose par joueur existe
                bool motDejaUtilise = false;
                for (int cptM = 0; cptM < this.listBox1.Items.Count; cptM++)
                {
                    // verifie si le mot a déjà été proposé
                    if (this.listBox1.Items[cptM].ToString() == this.textBox1.Text)
                    {
                        motDejaUtilise = true;
                        this.ImageTriste.Visible = true;
                        this.labNotification.Text = "Mot déja choisi";
                        this.DrawMatrix();
                    }
                }

                if (motDejaUtilise == false)
                {
                    this.ImageGai.Visible = true;
                    this.ImageTriste.Visible = false;
                    DataGame.ActualiseScoreTotal(DataGame.ScoreMotJoueur);
                    DataGame.NumberOFGoodWord++;
                    this.labScoreTotal.Text = DataGame.ScoreTotal.ToString();
                    this.listBox1.Items.Add(this.textBox1.Text);
                    this.textBox1.Clear();
                }
                else
                {
                    this.ImageGai.Visible = false;
                    this.ImageTriste.Visible = true;
                }
            }
            else
            {
                this.ImageTriste.Visible = true;
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {// n'est plus utilisé dans la configuration terminée du jeu
            this.pictureBox1.Visible = true;
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
        }

    private void Button1_Click(object sender, EventArgs e)
        {
            // Réalise un nouveau tirage de lettres et configure l'IHM
            this.textBox2.Clear();
            DataGame.ResetWordScore();
            DataGame.NumberOFGoodWord = 0;
            this.NewGame();
            this.DrawMatrix();
            this.textBox1.Clear();
            this.pictureBox1.Visible = true;
        }

    private void NewGame()
        { // Réalise un nouveau tirage de lettres
            this.listBox1.Items.Clear();
            FindedWordList.Clear();
            DataGame.ResetWordScore();
            DataGame.RazScoreTotal();
            this.labScoreMotJoueur.Text = "Score du mot";
            this.labScoreTotal.Text = "Score de la partie.";
            this.CreateMatrix();
            this.DrawMatrix();
            WordsInGrid.ExploreCellWay();
      this.PossibleWordsInTextbox2();
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            string t;
            int cpt = 0;
            for (int j = 0; j < 4; j++)
             {
              // Création des LABEL  de la grille
                for (int i = 0; i < 4; i++)
                {
                    cpt++;
                    int pas = 60;
                    LAbelXY l = new LAbelXY();
                    {
                        l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                        l.Parent = this;
                    }

                    l.Click += new EventHandler(this.LetterIsChoosen);
                    t = cpt.ToString();
                    l.Text = t;
                    l.Name = t;
                    l.Width = pas - 20;
                    l.Height = pas - 20;
                    l.Top = 20 + (j * pas);
                    l.Left = 20 + (i * pas);
                    l.ForeColor = this.defaultColor;
                    l.X = i;
                    l.Y = j;
                    l.Show();
                }
            }

            DataGame.ResetWordScore();
            DataGame.RazScoreTotal();

            // Pour la contruction d'un arbre des lettres à partir de la liste des mots français
            LoadWordsDictionnary.InitialiseEnvironnement();
            if (LoadWordsDictionnary.GetAuthorizationStatus())
            {
                DonneesLettres.MatrixIniialization();
                this.NewGame();
            }
            else
            {
                MessageBox.Show(
                    "Erreur à l'ouverture du dictionnaire des mots Français\r\n" +
                    " Verifiez si le fichier MOTS TRADUITS.txt est présent sous le même répertoire que celui\r\n" +
                    " de l'application.", "Erreur fatale.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

      this.PossibleWordsInTextbox2();
        }

        private void PossibleWordsInTextbox2()
    {
      this.textBox2.Clear();
      this.textBox2.Text = "La nombre de mots trouvables est de " + WordsInGrid.WordList.Count + "\r\n";
      for (int i = 0; i < WordsInGrid.WordList.Count; i++)
      {
        // on ajoute la liste des mots possiles
        this.textBox2.Text += WordsInGrid.WordList[i] + "\r\n";
      }
    }

        private class LAbelXY : Label
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        private void LetterIsChoosen(object sender, EventArgs e)
        {
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
            LAbelXY choisi = (LAbelXY)sender;
            {
                // this.Text = Choisi.X.ToString() + ", " + Choisi.Y.ToString();
                choisi.Visible = false; choisi.Visible = false;
                this.GereClicSurLettre(choisi.Name.ToString(), choisi.Y, choisi.X);
            }
        }


        private void DrawMatrix2()
        {
            int compteur = 0;
            try
            {
                foreach (LAbelXY labelDeLettre in this.Controls.OfType<LAbelXY>())
                {
                    labelDeLettre.Text = DonneesLettres.TableauDeLettres[labelDeLettre.Y, labelDeLettre.X].ToString();
                    labelDeLettre.Visible = true;
                    compteur++;
                }
            }
            catch
            {
                MessageBox.Show("Erreur dans la boucle foreach de dessinneMatrice");
            }

            DonneesLettres.PrecedentSquare.X = -1;

            // initialise case précédente
            DonneesLettres.PrecedentSquare.Y = -1;
        }

        private void DrawMatrix()
        {
            int compteur = 0;
            try
            {
                foreach (LAbelXY labelDeLettre in this.Controls.OfType<LAbelXY>())
                {
                    labelDeLettre.Text = DonneesLettres.TableauDeLettres[labelDeLettre.Y, labelDeLettre.X].ToString();
                    labelDeLettre.Visible = true;
                    compteur++;
                }
            }
            catch
            {
                MessageBox.Show("Erreur dans la boucle foreach de dessinneMatrice");
            }

            DonneesLettres.PrecedentSquare.X = -1; 
            // initialise case précédente

            DonneesLettres.PrecedentSquare.Y = -1;
            DonneesLettres.ResetLettersUtilisationArray();
        }

        private bool IsNeighbourrFromPrecedent()
        {
            // retourn vrai si la case est une case voisine
            int rx, ry;
            this.labNotification.Text = string.Empty;

            // pas la première case
            if (DonneesLettres.PrecedentSquare.X != -1)
            {
                // traitement
                rx = Math.Abs(DonneesLettres.ChoosenSquare.X - DonneesLettres.PrecedentSquare.X);
                ry = Math.Abs(DonneesLettres.ChoosenSquare.Y - DonneesLettres.PrecedentSquare.Y);
                if (rx >= -1 && rx <= 1 && ry >= -1 && ry <= 1)
                {
                    DonneesLettres.StoreUsingPlace();
                    this.labNotification.Text = " ";
                    return true;
                }
                else
                {
                    this.labNotification.Text = "Choix innacceptable : pas voisine";
                    return false;
                }
            }
            else
            {
                DonneesLettres.StoreUsingPlace();
                this.labNotification.Text = " ";
                return true;
            }
        }

        private void GereClicSurLettre(string labelName, int ligne, int colonne)
        {
            DonneesLettres.ChoosenSquare.X = colonne;
            DonneesLettres.ChoosenSquare.Y = ligne;

            // ParcoursDeMatrice.TrouveVoisinePossible(colonne, ligne);
            if (this.IsNeighbourrFromPrecedent())
            {
                // pour tous les labels de la form
                foreach (Label letterLabel in this.Controls.OfType<Label>())
                {
                    // si le label est celui cliqué
                    if (letterLabel.Name == labelName)
                    {
                        this.textBox1.Text += letterLabel.Text;
                        this.UpdateWordScore(char.Parse(letterLabel.Text));
                        DonneesLettres.ArrayOfLetterUse[colonne, ligne] = true;
                    }

                    DonneesLettres.SetPlaceOfUsingLetter(ligne, colonne);
                }
            }
        }

        private void UpdateWordScore(char c)
        {
            for (int i = 0; i < DonneesLettres.Alphabet.Length - 1; i++)
            {
                if (DonneesLettres.Alphabet[i] == c)

        // caractère identifié
        {
                    DataGame.UpdatePlayerScore(DonneesLettres.PointArrayForAletter[i]);
                    this.labScoreMotJoueur.Text = DataGame.ScoreMotJoueur.ToString();
                }
            }
        }

        private void Bt_Rotation_Click(object sender, EventArgs e)
        {
            DonneesLettres.RotateMatrix();
            this.DrawMatrix();
        }

        private void Bt_test_Click(object sender, EventArgs e)
        {
           
        }

        private void btTest2_Click(object sender, EventArgs e)
        {
            this.MatriceCreate();
            this.DrawMatrix2();
        }

        // fin classe Form1
    }



    // FIn  namspace
}
