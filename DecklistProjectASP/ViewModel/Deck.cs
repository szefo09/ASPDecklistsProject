using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class Deck
    {
        public IList<int> Main { get; private set; }
        public IList<int> Extra { get; private set; }
        public IList<int> Side { get; private set; }

        public D Deck_O { get; private set; }

        public class D
        {
            public IList<int> Main = new List<int>();
            public IList<int> Extra = new List<int>();
            public IList<int> Side = new List<int>();
        }

        public Deck()
        {
            Main = new List<int>();
            Extra = new List<int>();
            Side = new List<int>();
            Deck_O = new D();
        }
    }
}
