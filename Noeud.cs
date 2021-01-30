namespace AbreDico
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Noeud
    {
        public char Lettre { get; set; }

        public bool FinDeMot { get; set; }

        public Dictionary<char, Noeud> DictionnaireDesSousNoeuds { get => dictionnaireDesSousNoeuds; set => dictionnaireDesSousNoeuds = value; }

        private Dictionary<char, Noeud> dictionnaireDesSousNoeuds;
    }
}
