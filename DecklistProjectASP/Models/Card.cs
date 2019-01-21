using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public string CardName { get; set; }
        public ICollection<CardsDecklists> CardsDecklists { get; set; }
    }
}
