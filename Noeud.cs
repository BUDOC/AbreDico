﻿namespace AbreDico
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // this is the tree of french words contructed with the dictionnary file
    public class Noeud
    {
        public char Lettre { get; set; }

        public bool EndOfWord { get; set; }

        public Dictionary<char, Noeud> DictionnaireDesSousNoeuds { get; set; }
    }
}
