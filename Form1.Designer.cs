
using System;

namespace AbreDico
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMIAP = new System.Windows.Forms.Panel();
            this.labelMot = new System.Windows.Forms.Label();
            this.ImageGai = new System.Windows.Forms.PictureBox();
            this.ImageTriste = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtCreateTree = new System.Windows.Forms.Button();
            this.Bt_NewGame = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labNotification = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lab_scoreMaxi = new System.Windows.Forms.Label();
            this.labScoreTotal = new System.Windows.Forms.Label();
            this.labScoreMotJoueur = new System.Windows.Forms.Label();
            this.bt_Rotation = new System.Windows.Forms.Button();
            this.bt_see_words = new System.Windows.Forms.Button();
            this.labNbMotPossible = new System.Windows.Forms.Label();
            this.labNmotsTrouves = new System.Windows.Forms.Label();
            this.LabPourcentageDeTrouves = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labEncouragement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labEncouragement2 = new System.Windows.Forms.Label();
            this.toolTopInfoBulle = new System.Windows.Forms.ToolTip(this.components);
            this.panelMIAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMIAP
            // 
            this.panelMIAP.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.panelMIAP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMIAP.Controls.Add(this.labelMot);
            this.panelMIAP.Controls.Add(this.ImageGai);
            this.panelMIAP.Controls.Add(this.ImageTriste);
            this.panelMIAP.Controls.Add(this.textBox1);
            this.panelMIAP.Controls.Add(this.BtCreateTree);
            this.panelMIAP.Location = new System.Drawing.Point(284, 13);
            this.panelMIAP.Margin = new System.Windows.Forms.Padding(4);
            this.panelMIAP.Name = "panelMIAP";
            this.panelMIAP.Size = new System.Drawing.Size(348, 226);
            this.panelMIAP.TabIndex = 1;
            // 
            // labelMot
            // 
            this.labelMot.AutoSize = true;
            this.labelMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMot.Location = new System.Drawing.Point(104, 61);
            this.labelMot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMot.Name = "labelMot";
            this.labelMot.Size = new System.Drawing.Size(123, 25);
            this.labelMot.TabIndex = 5;
            this.labelMot.Text = "Mot à vérifier";
            // 
            // ImageGai
            // 
            this.ImageGai.Image = global::AbreDico.Properties.Resources.gai;
            this.ImageGai.Location = new System.Drawing.Point(22, 0);
            this.ImageGai.Margin = new System.Windows.Forms.Padding(4);
            this.ImageGai.Name = "ImageGai";
            this.ImageGai.Size = new System.Drawing.Size(65, 62);
            this.ImageGai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageGai.TabIndex = 4;
            this.ImageGai.TabStop = false;
            this.ImageGai.Visible = false;
            // 
            // ImageTriste
            // 
            this.ImageTriste.Image = global::AbreDico.Properties.Resources.triste;
            this.ImageTriste.Location = new System.Drawing.Point(248, 20);
            this.ImageTriste.Margin = new System.Windows.Forms.Padding(4);
            this.ImageTriste.Name = "ImageTriste";
            this.ImageTriste.Size = new System.Drawing.Size(65, 62);
            this.ImageTriste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageTriste.TabIndex = 3;
            this.ImageTriste.TabStop = false;
            this.ImageTriste.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(22, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.Enter += new System.EventHandler(this.TextBox1_Enter);
            // 
            // BtCreateTree
            // 
            this.BtCreateTree.Location = new System.Drawing.Point(22, 142);
            this.BtCreateTree.Margin = new System.Windows.Forms.Padding(4);
            this.BtCreateTree.Name = "BtCreateTree";
            this.BtCreateTree.Size = new System.Drawing.Size(291, 51);
            this.BtCreateTree.TabIndex = 0;
            this.BtCreateTree.Text = "Vérification";
            this.BtCreateTree.UseVisualStyleBackColor = true;
            this.BtCreateTree.Click += new System.EventHandler(this.BoutonVerifMot);
            // 
            // Bt_NewGame
            // 
            this.Bt_NewGame.Location = new System.Drawing.Point(22, 294);
            this.Bt_NewGame.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_NewGame.Name = "Bt_NewGame";
            this.Bt_NewGame.Size = new System.Drawing.Size(154, 30);
            this.Bt_NewGame.TabIndex = 3;
            this.Bt_NewGame.Text = "nouvelle donne";
            this.Bt_NewGame.UseVisualStyleBackColor = true;
            this.Bt_NewGame.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(664, 13);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(425, 444);
            this.textBox2.TabIndex = 20;
            this.textBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labNotification);
            this.panel1.Location = new System.Drawing.Point(282, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 50);
            this.panel1.TabIndex = 21;
            // 
            // labNotification
            // 
            this.labNotification.AutoSize = true;
            this.labNotification.Location = new System.Drawing.Point(15, 20);
            this.labNotification.Name = "labNotification";
            this.labNotification.Size = new System.Drawing.Size(0, 20);
            this.labNotification.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.lab_scoreMaxi);
            this.panel2.Controls.Add(this.labScoreTotal);
            this.panel2.Controls.Add(this.labScoreMotJoueur);
            this.panel2.Location = new System.Drawing.Point(18, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 144);
            this.panel2.TabIndex = 22;
            // 
            // lab_scoreMaxi
            // 
            this.lab_scoreMaxi.AutoSize = true;
            this.lab_scoreMaxi.Location = new System.Drawing.Point(9, 108);
            this.lab_scoreMaxi.Name = "lab_scoreMaxi";
            this.lab_scoreMaxi.Size = new System.Drawing.Size(148, 20);
            this.lab_scoreMaxi.TabIndex = 2;
            this.lab_scoreMaxi.Text = "SCORE MAXIMAL";
            // 
            // labScoreTotal
            // 
            this.labScoreTotal.AutoSize = true;
            this.labScoreTotal.Font = new System.Drawing.Font("Wide Latin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScoreTotal.ForeColor = System.Drawing.Color.Red;
            this.labScoreTotal.Location = new System.Drawing.Point(3, 43);
            this.labScoreTotal.Name = "labScoreTotal";
            this.labScoreTotal.Size = new System.Drawing.Size(51, 34);
            this.labScoreTotal.TabIndex = 1;
            this.labScoreTotal.Text = "0";
            // 
            // labScoreMotJoueur
            // 
            this.labScoreMotJoueur.AutoSize = true;
            this.labScoreMotJoueur.Font = new System.Drawing.Font("Wide Latin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScoreMotJoueur.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labScoreMotJoueur.Location = new System.Drawing.Point(3, 9);
            this.labScoreMotJoueur.Name = "labScoreMotJoueur";
            this.labScoreMotJoueur.Size = new System.Drawing.Size(51, 34);
            this.labScoreMotJoueur.TabIndex = 0;
            this.labScoreMotJoueur.Text = "0";
            // 
            // bt_Rotation
            // 
            this.bt_Rotation.Location = new System.Drawing.Point(184, 295);
            this.bt_Rotation.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Rotation.Name = "bt_Rotation";
            this.bt_Rotation.Size = new System.Drawing.Size(154, 29);
            this.bt_Rotation.TabIndex = 24;
            this.bt_Rotation.Text = "Rotation";
            this.bt_Rotation.UseVisualStyleBackColor = true;
            this.bt_Rotation.Click += new System.EventHandler(this.Bt_Rotation_Click);
            // 
            // bt_see_words
            // 
            this.bt_see_words.Location = new System.Drawing.Point(345, 294);
            this.bt_see_words.Name = "bt_see_words";
            this.bt_see_words.Size = new System.Drawing.Size(150, 30);
            this.bt_see_words.TabIndex = 25;
            this.bt_see_words.Text = "Voir les mots";
            this.bt_see_words.UseVisualStyleBackColor = true;
            this.bt_see_words.Click += new System.EventHandler(this.Bt_test_Click);
            // 
            // labNbMotPossible
            // 
            this.labNbMotPossible.AutoSize = true;
            this.labNbMotPossible.Location = new System.Drawing.Point(14, 481);
            this.labNbMotPossible.Name = "labNbMotPossible";
            this.labNbMotPossible.Size = new System.Drawing.Size(0, 20);
            this.labNbMotPossible.TabIndex = 26;
            // 
            // labNmotsTrouves
            // 
            this.labNmotsTrouves.AutoSize = true;
            this.labNmotsTrouves.Location = new System.Drawing.Point(18, 519);
            this.labNmotsTrouves.Name = "labNmotsTrouves";
            this.labNmotsTrouves.Size = new System.Drawing.Size(13, 20);
            this.labNmotsTrouves.TabIndex = 27;
            this.labNmotsTrouves.Text = ".";
            // 
            // LabPourcentageDeTrouves
            // 
            this.LabPourcentageDeTrouves.AutoSize = true;
            this.LabPourcentageDeTrouves.Location = new System.Drawing.Point(588, 505);
            this.LabPourcentageDeTrouves.Name = "LabPourcentageDeTrouves";
            this.LabPourcentageDeTrouves.Size = new System.Drawing.Size(13, 20);
            this.LabPourcentageDeTrouves.TabIndex = 28;
            this.LabPourcentageDeTrouves.Text = ".";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(664, 502);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(425, 23);
            this.progressBar1.TabIndex = 30;
            // 
            // labEncouragement
            // 
            this.labEncouragement.AutoSize = true;
            this.labEncouragement.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEncouragement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labEncouragement.Location = new System.Drawing.Point(417, 331);
            this.labEncouragement.Name = "labEncouragement";
            this.labEncouragement.Size = new System.Drawing.Size(73, 43);
            this.labEncouragement.TabIndex = 31;
            this.labEncouragement.Text = "Hi!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Progression en points marqués.";
            // 
            // labEncouragement2
            // 
            this.labEncouragement2.AutoSize = true;
            this.labEncouragement2.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEncouragement2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labEncouragement2.Location = new System.Drawing.Point(14, 496);
            this.labEncouragement2.Name = "labEncouragement2";
            this.labEncouragement2.Size = new System.Drawing.Size(538, 43);
            this.labEncouragement2.TabIndex = 33;
            this.labEncouragement2.Text = "Encouragement  score total";
            // 
            // toolTopInfoBulle
            // 
            this.toolTopInfoBulle.ToolTipTitle = "Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 564);
            this.Controls.Add(this.labEncouragement2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labEncouragement);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LabPourcentageDeTrouves);
            this.Controls.Add(this.labNmotsTrouves);
            this.Controls.Add(this.labNbMotPossible);
            this.Controls.Add(this.bt_see_words);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_Rotation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Bt_NewGame);
            this.Controls.Add(this.panelMIAP);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Wordament by Vieux Dinosaure .  V 2021/13/11";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.panelMIAP.ResumeLayout(false);
            this.panelMIAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMIAP;
        private System.Windows.Forms.Button BtCreateTree;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox ImageTriste;
        private System.Windows.Forms.PictureBox ImageGai;
        private System.Windows.Forms.Label labelMot;
        private System.Windows.Forms.Button Bt_NewGame;
     
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labNotification;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labScoreMotJoueur;
        private System.Windows.Forms.Label labScoreTotal;
        private System.Windows.Forms.Button bt_Rotation;
        private System.Windows.Forms.Button bt_see_words;
        private System.Windows.Forms.Label labNbMotPossible;
        private System.Windows.Forms.Label labNmotsTrouves;
        private System.Windows.Forms.Label LabPourcentageDeTrouves;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lab_scoreMaxi;
    private System.Windows.Forms.Label labEncouragement;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labEncouragement2;
        private System.Windows.Forms.ToolTip toolTopInfoBulle;
    }
}

