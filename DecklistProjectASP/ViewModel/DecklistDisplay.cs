using DecklistProjectASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class DecklistDisplay
    {
        public int Id { get; set; }
        [Display(Name = "Decklist Name:")]
        public string DeckName { get; set; }
        [Display(Name = "Decklist:")]
        public Deck Deck { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
