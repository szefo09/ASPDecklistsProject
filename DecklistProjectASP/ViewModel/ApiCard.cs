using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class ApiCard
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string atk { get; set; }
        public string def { get; set; }
        public string type { get; set; }
        public string level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public string scale { get; set; }
        public string linkval { get; set; }
        public string linkmarkers { get; set; }
        public string archetype { get; set; }
        public string set_tag { get; set; }
        public string setcode { get; set; }
        public string ban_tcg { get; set; }
        public string ban_ocg { get; set; }
        public string ban_goat { get; set; }
        public string CardArtPath { get; set; }
    }
}
