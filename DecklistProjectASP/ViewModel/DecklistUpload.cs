using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DecklistProjectASP.ViewModel
{
    public class DecklistUpload
    {
        [Required]
        [Display(Name = "Decklist Name")]
        [StringLength(60, MinimumLength = 3)]
        public string DecklistName { get; set; }
        [Required]
        [Display(Name = "Decklist File")]
        public IFormFile DecklistFile { get; set; }
    }
}
