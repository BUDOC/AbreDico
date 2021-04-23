namespace AbreDico
{

  /// <summary>
  /// [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
  /// Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.
  /// Classes.
  /// </summary>
  public class DataGame
  {
    // GERE LES SCORES
    private static int ScoreMotJoueur;
    private static int NumberOFGoodWord;
    public static int ScoreTotal;

    /// <summary>
    ///  Retoutene le score du mot du joueur.
    /// </summary>
    /// <returns> score du mot.</returns>
    public static int GetScoreMotJoueur()
    {
      return ScoreMotJoueur;
    }

    /// <summary>
    /// Return good wors number.
    /// </summary>
    /// <returns> Nombre de mots valides.</returns>
    public static int GetNumberOfGoodWord()
    {
      return NumberOFGoodWord;
    }

    /// <summary>
    ///  Reset du nombre de mots valdses.
    /// </summary>
    public static void ResetNumberOfGoodWord()
    {
      NumberOFGoodWord = 0;
    }

    /// <summary>
    ///  Incrémente le nombre de mots valides.
    /// </summary>
    public static void IncrementeNumberOfGoddWord()
    {
      NumberOFGoodWord++;
    }


    /// <summary>
    /// Remet le score du joueur à zéro.
    /// </summary>
    public static void ResetWordScore()
    {
      ScoreMotJoueur = 0;
    }

    /// <summary>
    /// Met à jour le score du joueur.
    /// </summary>
    /// <param name="scoreLettre"> nombre de points attribués à la lettre.</param>
    public static void UpdatePlayerScore(int scoreLettre)
    {
      ScoreMotJoueur += scoreLettre;
    }

    /// <summary>
    /// Remet le score total à zéro.
    /// </summary>
    public static void RazScoreTotal()
    {
      ScoreTotal = 0;
    }

    /// <summary>
    /// Actualise le score total.
    /// </summary>
    /// <param name="scoreMot"> nombre de points du mot.</param>
    public static void ActualiseScoreTotal(int scoreMot)
    {
      ScoreTotal += scoreMot;
    }
  }
}
