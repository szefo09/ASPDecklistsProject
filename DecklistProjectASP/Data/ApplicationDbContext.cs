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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CardsDecklists>().HasKey(cd => new { cd.CardId, cd.DecklistId });
            modelBuilder.Entity<CardsDecklists>().HasOne(cd => cd.Card).WithMany(c => c.CardsDecklists).HasForeignKey(cd => cd.DecklistId);
            modelBuilder.Entity<CardsDecklists>().HasOne(cd => cd.Decklist).WithMany(d => d.CardsDecklists).HasForeignKey(cd => cd.CardId);
        }
        public DbSet<Decklist> Decklists { get; set; }
        public DbSet<Card> Card { get; set; }
    }
}
