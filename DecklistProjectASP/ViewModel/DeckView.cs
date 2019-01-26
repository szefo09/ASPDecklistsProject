using DecklistProjectASP.Models;
using System.ComponentModel.DataAnnotations;

namespace DecklistProjectASP.ViewModel
{
    public class DeckView
    {
        [Display(Name="Decklist:")]
        public Decklist Deck { get; set; }
        [Display(Name ="Decklist's Owner:")]
        public string OwnerName { get; set; }
    }
}
