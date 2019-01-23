﻿using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Models
{
    public class Decklist
    {
        public int Id { get; set; }
        [Display(Name = "Decklist Name")]
        public string DeckName { get; set; }
        public string DecklistData { get;set; }
        public ICollection<CardsDecklists> CardsDecklists { get; set; }
    }
}
