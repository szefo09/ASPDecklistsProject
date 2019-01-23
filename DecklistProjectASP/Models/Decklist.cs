using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class Decklist
    {
        public int Id { get; set; }
        public string NameOfDeck { get; set; }
        public string DecklistData { get;set; }
        public ICollection<CardsDecklists> CardsDecklists { get; set; }
    }
}
