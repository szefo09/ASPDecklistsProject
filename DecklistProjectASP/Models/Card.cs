using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class Card
    {
        public int CardId { get; set; }
        [Range(1, 999999999)]
        [Display(Name ="Card ID")]
        [Required]
        public int CardIdentifier { get; set; }
        [Required]
        [Display(Name ="Card's name")]
        public string CardName { get; set; }
        public ICollection<CardsDecklists> CardsDecklists { get; } = new List<CardsDecklists>();
    }
}
