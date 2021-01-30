using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbreDico
{
    public partial class Form1 : Form
    {
        // crée une variable d'instance à laquelle on affectera le noeud racine (passage du pointeur)
        // pour en disposer dans Form1
        // **** Couleurs de l'environnement
        private readonly Color defaultColor = Color.FromName("Navy");

        public void CreerMatrice() // Génère aléatoirement des lettres qui sont mises dans le tableau"matrice"
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
                    if (lettre != DonneesLettres.TabloListeDesCaracteres[i - 1])
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
                                if (DonneesLettres.PlaceDansLaMatrice(lettre) == -1 && noteDeChiant <= 4)
                                {
                                    // difficile pas en double
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
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
                                DonneesLettres.TabloListeDesCaracteres[i] = lettre;
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
                                if ((difficulteLettre == 2 && DonneesLettres.PlaceDansLaMatrice(lettre) == -1) || (difficulteLettre <= 1 && (DonneesLettres.NbDeLaLettreDansMatrice(lettre) < 3)))

                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
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
                                if ((noteDeChiant < 3) && (DonneesLettres.NbDeLaLettreDansMatrice(lettre) < 2)) // acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;

                                    // augmentation de la note globale de chiant
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
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
            if (DonneesLettres.NbDeLaLettreDansMatrice('E') < 2) // pas assez de E
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
                        DonneesLettres.TabloListeDesCaracteres[j] = 'E';
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
                    car = DonneesLettres.TabloListeDesCaracteres[b];
                    if (!DonneesLettres.EstVoyelle(car))
                    {
                        int c = rand.Next(0, 2);

                        // this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        DonneesLettres.TabloListeDesCaracteres[b] = DonneesLettres.VoyellesCourantes[c];
                        tour++;
                    }
                }

                // fin modifications pour rendre plus jouable
            }

            // transfert des lettres de Matrice vers tableaudelettres
            int ligne = 0, colonne = 0;
            for (int r = 0; r < 16; r++)
            {
                DonneesLettres.TableauDeLettres[ligne, colonne] = DonneesLettres.TabloListeDesCaracteres[r];
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

        private void BoutonVerifMot(object sender, EventArgs e)

        // Bouton qui déclenche l'action de vocontroler si le mot estr acceptable
        {
            this.VerifMot();
            this.labNmotsTrouves.Text = "Nombre de mots trouvés = " + DataGame.NumberOFGoodWord.ToString();
            decimal percentOfFind = Convert.ToDecimal(DataGame.NumberOFGoodWord * 100) / Convert.ToDecimal(Chemin.NumberOfWordCanBeDone);

            this.LabPourcentageDeTrouves.Text = "Pourcentage de mots trouvés = " + percentOfFind.ToString("F1");
            this.textBox1.Clear();
            DataGame.ResetWordScore();
            this.labScoreMotJoueur.Text = string.Empty;
            this.DessineMatrice();
        }

        private void VerifMot() // Vérifie si le mot à controler n'est pas un mot déjà utilisé
        {
            this.pictureBox1.Visible = false;

            if (ArbreDesMots.Motexiste(this.textBox1.Text, ArbreDesMots.NoeudRacine))
            { // le mot propose par joueur existe
                bool motDejaUtilise = false;
                for (int cptM = 0; cptM < this.listBox1.Items.Count; cptM++)
                { // verifie si le mot a déjà été proposé
                    if (this.listBox1.Items[cptM].ToString() == this.textBox1.Text)
                    {
                        motDejaUtilise = true;
                        this.ImageTriste.Visible = true;
                        this.labNotification.Text = "Mot déja choisi";
                        this.DessineMatrice();
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
        { // Réalise un nouveau tirage de lettres et configure l'IHM
            DataGame.ResetWordScore();
            DataGame.NumberOFGoodWord = 0;
            this.NouvelleDonne();
            this.DessineMatrice();
            this.textBox1.Clear();
            this.pictureBox1.Visible = true;
        }

        private void NouvelleDonne()
        { // Réalise un nouveau tirage de lettres
            this.listBox1.Items.Clear();
            DataGame.ResetWordScore();
            DataGame.RazScoreTotal();
            this.labScoreMotJoueur.Text = "Score du mot";
            this.labScoreTotal.Text = "Score de la partie.";
            this.CreerMatrice();
            this.DessineMatrice();
            Chemin.TotalExploration();
            this.labNbMotPossible.Text = "Le nombre de mots possibles est de " + Chemin.NumberOfWordCanBeDone.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string t;
            int cpt = 0;
            for (int j = 0; j < 4; j++) // Création des LABEL  de la grille
            {
                for (int i = 0; i < 4; i++)
                {
                    cpt++;
                    int pas = 60;

                    // Label L = new System.Windows.Forms.Label();
                    LAbelXY l = new LAbelXY();
                    {
                        l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
                        l.Parent = this;
                    }

                    l.Click += new EventHandler(this.LableEstChoisi);
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
            ArbreDesMots.InitialiseEnvironnement(); // Pour la contruction d'un arbre des lettres à partir de la liste des mots français
            DonneesLettres.InitDataPourGrille();
            this.NouvelleDonne();
        }

        private class LAbelXY : Label
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        private void LableEstChoisi(object sender, EventArgs e)
        {
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
            LAbelXY choisi = (LAbelXY)sender;

            // this.Text = Choisi.X.ToString() + ", " + Choisi.Y.ToString();
            choisi.Visible = false;
            this.GereClicSurLettre(choisi.Name.ToString(), choisi.Y, choisi.X);
        }

        private void DessineMatrice()
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

            DonneesLettres.CasePrecedente.X = -1; // initialise case précédente
            DonneesLettres.CasePrecedente.Y = -1;
            DonneesLettres.InitialiseTablocochage();
        }

        private bool EstVoisineDeCasePrecedente()
        { // retourn vrai si la case est une case voisine
            int rx, ry;
            this.labNotification.Text = string.Empty;
            if (DonneesLettres.CasePrecedente.X != -1) // pas la première case
            {// traitement
                rx = Math.Abs(DonneesLettres.CaseChoisie.X - DonneesLettres.CasePrecedente.X);
                ry = Math.Abs(DonneesLettres.CaseChoisie.Y - DonneesLettres.CasePrecedente.Y);
                if (rx >= -1 && rx <= 1 && ry >= -1 && ry <= 1)
                {
                    DonneesLettres.StockeCaseChoisie();
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
                DonneesLettres.StockeCaseChoisie();
                this.labNotification.Text = " ";
                return true;
            }
        }

        private void GereClicSurLettre(string nomDuLabel, int ligne, int colonne)
        {
            DonneesLettres.CaseChoisie.X = colonne;
            DonneesLettres.CaseChoisie.Y = ligne;

            // ParcoursDeMatrice.TrouveVoisinePossible(colonne, ligne);
            if (this.EstVoisineDeCasePrecedente())
            {
                foreach (Label labelDeLettre in this.Controls.OfType<Label>()) // pour tous les label de la form
                {
                    if (labelDeLettre.Name == nomDuLabel) // si le label est celui cliqué
                    {
                        this.textBox1.Text += labelDeLettre.Text;
                        this.ActualiseScoreMot(char.Parse(labelDeLettre.Text));
                        DonneesLettres.TabloCochage[colonne, ligne] = true;
                    }

                    DonneesLettres.DefinitCoupleCaseCochee(ligne, colonne);
                }
            }
        }

        private void ActualiseScoreMot(char c)
        {
            for (int i = 0; i < DonneesLettres.Alphabet.Length - 1; i++)
            {
                if (DonneesLettres.Alphabet[i] == c) // caractère identifié
                {
                    DataGame.ActualiseScoreMotJoeur(DonneesLettres.TabloPointsParLettre[i]);
                    this.labScoreMotJoueur.Text = DataGame.ScoreMotJoueur.ToString();
                }
            }
        }

        private void Bt_Rotation_Click(object sender, EventArgs e)
        {
            DonneesLettres.TourneTableauDeLettres();
            this.DessineMatrice();
        }

        private void Bt_test_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            Chemin.TotalExploration();
            string listBoxText = string.Empty;
            for (int i = 0; i < Chemin.ListExistingWords.Count; i++)
            {
                listBoxText += Chemin.ListExistingWords[i] + "\r\n";
            }

            listBoxText += "Nombre de mots possible =" + Chemin.NumberOfWordCanBeDone + "\r\n";
            this.textBox2.Text = listBoxText;
        }
    }// fin classe Form1
}// FIn  namspace
