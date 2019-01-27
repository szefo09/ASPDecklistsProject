using DecklistProjectASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class FoundDecklistAndCard
    {
        [Display(Name = "Decklist:")]
        public Decklist Deck { get; set; }
        [Display(Name = "Decklist's Owner:")]
        public string OwnerName { get; set; }
        [Display(Name = "Cards Found in the Decklist:")]
        public List<string> CardsFound { get; } = new List<string>();
    }
}
