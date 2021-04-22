using System.Collections.Generic;
using System.IO;

namespace AbreDico
{
  /// <summary>
  /// Objet représentant une case de la matrice.
  /// </summary>
  public class OneCell
  {
    /// <summary>
    /// Coordonné X de la case.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Coordonné Y de la case.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// profondeur de la case dans le parcours de la matrice.
    /// </summary>
    public int Deep { get; set; }

    /// <summary>
    /// Liste de cases voisines.
    /// </summary>
    internal List<OneCell> ListOfPossiblesCellNeighbors { get; set; } = new List<OneCell>();
  }
}
