﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMIAP = new System.Windows.Forms.Panel();
            this.labelMot = new System.Windows.Forms.Label();
            this.ImageGai = new System.Windows.Forms.PictureBox();
            this.ImageTriste = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtCreateTree = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labNotification = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labScoreTotal = new System.Windows.Forms.Label();
            this.labScoreMotJoueur = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bt_Rotation = new System.Windows.Forms.Button();
            this.bt_test = new System.Windows.Forms.Button();
            this.labNbMotPossible = new System.Windows.Forms.Label();
            this.labNmotsTrouves = new System.Windows.Forms.Label();
            this.LabPourcentageDeTrouves = new System.Windows.Forms.Label();
            this.btTest2 = new System.Windows.Forms.Button();
            this.panelMIAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AbreDico.Properties.Resources.tenor;
            this.pictureBox1.Location = new System.Drawing.Point(412, 318);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(150, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "nouvelle donne";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1005, 18);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(478, 444);
            this.textBox2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labNotification);
            this.panel1.Location = new System.Drawing.Point(14, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 29);
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
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.labScoreTotal);
            this.panel2.Controls.Add(this.labScoreMotJoueur);
            this.panel2.Location = new System.Drawing.Point(13, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 144);
            this.panel2.TabIndex = 22;
            // 
            // labScoreTotal
            // 
            this.labScoreTotal.AutoSize = true;
            this.labScoreTotal.Font = new System.Drawing.Font("Wide Latin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScoreTotal.ForeColor = System.Drawing.Color.Lime;
            this.labScoreTotal.Location = new System.Drawing.Point(35, 79);
            this.labScoreTotal.Name = "labScoreTotal";
            this.labScoreTotal.Size = new System.Drawing.Size(51, 34);
            this.labScoreTotal.TabIndex = 1;
            this.labScoreTotal.Text = "0";
            // 
            // labScoreMotJoueur
            // 
            this.labScoreMotJoueur.AutoSize = true;
            this.labScoreMotJoueur.Font = new System.Drawing.Font("Wide Latin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScoreMotJoueur.ForeColor = System.Drawing.Color.Yellow;
            this.labScoreMotJoueur.Location = new System.Drawing.Point(29, 22);
            this.labScoreMotJoueur.Name = "labScoreMotJoueur";
            this.labScoreMotJoueur.Size = new System.Drawing.Size(51, 34);
            this.labScoreMotJoueur.TabIndex = 0;
            this.labScoreMotJoueur.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(639, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 444);
            this.listBox1.TabIndex = 23;
            // 
            // bt_Rotation
            // 
            this.bt_Rotation.Location = new System.Drawing.Point(250, 282);
            this.bt_Rotation.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Rotation.Name = "bt_Rotation";
            this.bt_Rotation.Size = new System.Drawing.Size(154, 29);
            this.bt_Rotation.TabIndex = 24;
            this.bt_Rotation.Text = "Rotation";
            this.bt_Rotation.UseVisualStyleBackColor = true;
            this.bt_Rotation.Click += new System.EventHandler(this.Bt_Rotation_Click);
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(509, 266);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(77, 45);
            this.bt_test.TabIndex = 25;
            this.bt_test.Text = "test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.Bt_test_Click);
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
            // btTest2
            // 
            this.btTest2.Location = new System.Drawing.Point(853, 162);
            this.btTest2.Name = "btTest2";
            this.btTest2.Size = new System.Drawing.Size(130, 37);
            this.btTest2.TabIndex = 29;
            this.btTest2.Text = "Test2";
            this.btTest2.UseVisualStyleBackColor = true;
            this.btTest2.Click += new System.EventHandler(this.btTest2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 564);
            this.Controls.Add(this.btTest2);
            this.Controls.Add(this.LabPourcentageDeTrouves);
            this.Controls.Add(this.labNmotsTrouves);
            this.Controls.Add(this.labNbMotPossible);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.bt_Rotation);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMIAP);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Wordament by Vieux Dinosaure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMIAP.ResumeLayout(false);
            this.panelMIAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageGai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageTriste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox ImageTriste;
        private System.Windows.Forms.PictureBox ImageGai;
        private System.Windows.Forms.Label labelMot;
        private System.Windows.Forms.Button button1;
     
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labNotification;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labScoreMotJoueur;
        private System.Windows.Forms.Label labScoreTotal;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bt_Rotation;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.Label labNbMotPossible;
        private System.Windows.Forms.Label labNmotsTrouves;
        private System.Windows.Forms.Label LabPourcentageDeTrouves;
        private System.Windows.Forms.Button btTest2;
    }
}

