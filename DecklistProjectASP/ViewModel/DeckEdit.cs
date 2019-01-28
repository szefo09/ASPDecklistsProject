using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class DeckEdit
    {
        public int DecklistId { get; set; }
        [Display(Name = "Decklist Name:")]
        public string DeckName { get; set; }
        [Display(Name = "Show Decklist as Public")]
        public bool isPublic { get; set; }
    }
}
