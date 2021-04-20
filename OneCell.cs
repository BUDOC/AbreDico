using System.Collections.Generic;
using System.IO;

namespace AbreDico
{
  public class OneCell
  {
    public int X { get; set; }

    public int Y { get; set; }

    public int Deep { get; set; }

    internal List<OneCell> ListOfPossiblesCellNeighbors { get; set; } = new List<OneCell>();
  }
}
