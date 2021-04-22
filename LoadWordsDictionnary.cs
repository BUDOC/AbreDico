using System.IO;

namespace AbreDico
{
  /// <summary>
  /// Classe qui permet la modélisation du dictionnaire des mots français sous forme d'arbre.
  /// </summary>
  internal class LoadWordsDictionnary
  {
    private static bool startAuthorization = true;

    /// <summary>
    /// Premier noeud de l'arbre représentant le dictionnaire.
    /// </summary>
    public static Noeud NoeudRacine { get; private set; }

    /// <summary>
    /// Return true if succes on dictinary loading.
    /// </summary>
    /// <returns></returns>
    public static bool GetAuthorizationStatus()
    {
      return startAuthorization;
    }

    /// <summary>
    /// initialisation des données pour la construction de l'arbre des lettres des mots français.
    /// </summary>
    public static void InitialiseEnvironnement()
    {
      // this.pictureBox1.Visible = true;
      // Création de l'arbre à partir du fichier texte.
      // ===================
      // initialisation du dictionnaire
      string nomDuDico = Directory.GetCurrentDirectory() + "\\MOTS TRADUITS.txt";
      string[] lignesDico;
      try
      {
        lignesDico = File.ReadAllLines(nomDuDico);

        // c'est le dictionnaire (arbre)
        NoeudRacine = WordsTree.NoeudRacineConstructionArbre(lignesDico);
      }
      catch
      {
        startAuthorization = false;
      }
    }
  }
}
