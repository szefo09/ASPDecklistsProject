using System;
using System.Collections.Generic;
using System.Text;
using DecklistProjectASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DecklistProjectASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CardsDecklists>().HasKey(cd => new { cd.DecklistId, cd.CardId });
        }
        public DbSet<Decklist> Decklists { get; set; }
        virtual public DbSet<Card> Card { get; set; }
        public DbSet<CardsDecklists> CardsDecklist { get; set; }
    }
}
