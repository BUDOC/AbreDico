namespace AbreDico
{
  // [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
  // Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.
  // Classes
  public class DataGame
  {
    // GERE LES SCORES
    public static int ScoreMotJoueur;
    public static int NumberOFGoodWord;
    public static int ScoreTotal;

    public static void ResetWordScore()
    {
      ScoreMotJoueur = 0;
    }

    public static void UpdatePlayerScore(int scoreLettre)
    {
      // remplacer par nb point du mot
      ScoreMotJoueur += scoreLettre;
    }

    public static void RazScoreTotal()
    {
      ScoreTotal = 0;
    }

    public static void ActualiseScoreTotal(int scoreMot)
    {
      ScoreTotal += scoreMot;
    }
  }
}
