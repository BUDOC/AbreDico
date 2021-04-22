namespace AbreDico
{
  using System.Collections.Generic;

  /// <summary>
  /// Choix : l'abre est représenté par une liste de noeuds
  /// Le noeud est une classe qui comprend
  /// - Un caractère : la donnée
  /// - un booléen indiquant si cette lettre constitue la fin d'un mot
  /// - une liste de noeuds désignant les noeuds enfants.
  /// </summary>
  public class WordsTree
  {
    /* Choix : l'abre est représenté par une liste de noeuds
     * Le noeud est une classe qui comprend
     * - Un caractère : la donnée
     * - un booléen indiquant si cette lettre constitue la fin d'un mot
     * - une liste de noeuds désignant les noeuds enfants
     * */

    /// <summary>
    /// Modélisation du dictionnaire des mots .
    /// Accesssible par NoeudRacineConstructionArbre  racine de l'arbre
    /// </summary>
    /// <param name="lignesDico"> String représentant un mot lu dans le fichier texte du dictionnnaire  francais.</param>
    /// <returns> racine : pointeur du noeud racine. </returns>
    public static Noeud NoeudRacineConstructionArbre(string[] lignesDico)
    {
      // création de la racine
      Noeud racine = new Noeud
      {
        Lettre = ' ',
        EndOfWord = false,
        DictionnaireDesSousNoeuds = null,
      };

      // traitement des mots
      // traitement des lettres du mot
      for (int i = 0; i <= lignesDico.Length - 1; i++)
      {
        string mot = lignesDico[i];

        // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre
        AddCourantLetterIfNeccesity(racine, 0, mot);
      }

      // affecte à NoeudRacineConstructionArbre accessible partout dans form1 la valeur du pointeur de Racine
      return racine;
    }

    /// <summary>
    /// Ajoute un noeud à l'arbre si cela est nécessaire à sa construction.
    /// </summary>
    /// <param name="parentNode"> Noeud parent.</param>
    /// <param name="courantLetterIndex"> Index position de la lettre dans le mot.</param>
    /// <param name="word"> mot en traitement. </param>
    public static void AddCourantLetterIfNeccesity(Noeud parentNode, int courantLetterIndex, string word) // Création de l'arbre
    {
      // n'effectue pas le traitement pour un mot vide
      if (word.Length == 0)
      {
        return;
      }

      char courantLetter = word[courantLetterIndex];

      // si le dico n'existe pas on en crée un vierge
      if (parentNode.DictionnaireDesSousNoeuds == null)
      {
        parentNode.DictionnaireDesSousNoeuds = new Dictionary<char, Noeud>();
      }

      // le dico existe et  si la clé existe
      if (parentNode.DictionnaireDesSousNoeuds.ContainsKey(courantLetter))
      {
        // on cherche la clé (lettre)
        foreach (KeyValuePair<char, Noeud> cle in parentNode.DictionnaireDesSousNoeuds)
        {
          // clé identifiée
          if (cle.Key == courantLetter)
          {
            // (pour lettre suivante du mot)
            courantLetterIndex++;
            if (courantLetterIndex < word.Length)
            {
              // si le traitement du mot n'est pas fini on appelle récursivement la procédure
              // en passant le noeud courant le rang incrémenté et le mot en paramètre.
              // MessageBox.Show("Le dico du noeud père contient " + l + "du mot " + Word + " On cherche " + Word[rang]);
              AddCourantLetterIfNeccesity(cle.Value, courantLetterIndex, word);
            }
          }
        }
      }
      else
      {
        // le dico existe et  clé pas trouvée => ajout noeud dans dico
        Noeud sonNode = new Noeud
        {
          Lettre = courantLetter,
        };

        // dernière lettre du mot  : On ajoute le noeud correspondant
        if (courantLetterIndex == word.Length - 1)
        {
          sonNode.EndOfWord = true;
          parentNode.DictionnaireDesSousNoeuds.Add(courantLetter, sonNode);
          return;
        }
        else
        {
          // PAS dernière lettre du mot  : On ajoute le noeud correspondant et on incémente rang
          // et on relance récursivement la procédure
          sonNode.EndOfWord = false;
          parentNode.DictionnaireDesSousNoeuds.Add(courantLetter, sonNode);
          courantLetterIndex++;
          AddCourantLetterIfNeccesity(sonNode, courantLetterIndex, word);
        }
      }
    }

    /// <summary>
    /// Retourne vrai si le mot est trouvé dans le dictionnaire.
    /// </summary>
    /// <param name="word"> Mot recherché.</param>
    /// <param name="dictionnaireDesMots"> Dictionnaire des mots français modélisé sous forme d'arbre.</param>
    /// <returns> Vrai si le mot existe.</returns>
    public static bool WordExists(string word, Noeud dictionnaireDesMots)
    {
      int lg = word.Length;
      Noeud noeudCourant = dictionnaireDesMots;

      // Faire pour toutes les lettres du mot
      for (int i = 0; i < lg; i++)
      {
        char lettreCourante = word[i];

        // le Dictionnaire du noeud examiné n'est pas null
        if (noeudCourant.DictionnaireDesSousNoeuds != null)
        {
          // le dico contient la lettre du mot
          if (noeudCourant.DictionnaireDesSousNoeuds.ContainsKey(lettreCourante))
          {
            // affectation du noeud trouvé pour la lettre pour le tour de boucle suivant
            noeudCourant = noeudCourant.DictionnaireDesSousNoeuds[lettreCourante];
          }
          else
          {
            // la lettre n'est pas trouvée !
            return false;
          }
        }
        else
        {
          // le dictionnaire est null
          if (i != lg)
          {
            return false;
          }

          // si ce n'est pas la fin de mot c'est anormal on retourne false
          else
          {
            // si fin de mot c'est normal on retourne true
            return true;
          }
        }
      }

      if (noeudCourant.EndOfWord)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
