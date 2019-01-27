using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.ViewModel
{
    public class CardForSearch
    {
        [Range(1, 999999999)]
        [Display(Name = "Card ID")]
        public int? CardIdentifier { get; set; }
        [Display(Name = "Card's name")]
        public string CardName { get; set; }
    }
}
