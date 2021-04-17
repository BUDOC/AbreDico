namespace AbreDico
{
    using System.Collections.Generic;

    // this is the tree of french words contructed with the dictionnary file
    public class Noeud
    {
        public char Lettre { get; set; }

        public bool EndOfWord { get; set; }

        public Dictionary<char, Noeud> DictionnaireDesSousNoeuds { get; set; }
    }
}
