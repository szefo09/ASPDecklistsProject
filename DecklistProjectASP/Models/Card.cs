using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string CardArtPath { get; set; }
        [NotMapped]
        public bool IsCardArtDownloaded { get; set; }
        ICollection<CardsDecklists> CardsDecklists { get; set; }
    }
}
