using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecklistProjectASP.Data;
using DecklistProjectASP.Models;
using DecklistProjectASP.ViewModel;
using DecklistProjectASP.Services;
using Microsoft.AspNetCore.Authorization;

namespace DecklistProjectASP.Controllers
{
    public class DecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileHelpers _fileHelpers;
        private readonly IFromYDKToCodedDeck _fromYDKToCodedDeck;
        private readonly ILoadCardsFromId _loadCardsFromId;

        public DecklistsController(ApplicationDbContext context,IFileHelpers fileHelpers,IFromYDKToCodedDeck fromYDKToCodedDeck,ILoadCardsFromId loadCardsFromId)
        {
            _context = context;
            _fileHelpers = fileHelpers;
            _fromYDKToCodedDeck = fromYDKToCodedDeck;
            _loadCardsFromId = loadCardsFromId;
        }
        [BindProperty]
        public DecklistUpload DecklistUpload { get; set; }
        // GET: Decklists
        public async Task<IActionResult> Index()
        {
            var decklists = await _context.Decklists.ToListAsync();
            //showcase random decklist.
            return View(decklists);
        }
        // GET: Decklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decklist = await _context.Decklists
                .FirstOrDefaultAsync(m => m.DecklistId == id);
            if (decklist == null)
            {
                return NotFound();
            }
            Deck deck = _fromYDKToCodedDeck.Convert(decklist.DecklistData);

            DecklistDisplay decklistDisplay = new DecklistDisplay
            {

                Deck = deck,
                DeckName = decklist.DeckName,
                Id = decklist.DecklistId,
                Cards = await _loadCardsFromId.Load(_context.Card.ToList(), deck.FullDeck)

            };
            
            return View(decklistDisplay);
        }
        // GET: Decklists/Create
        public IActionResult Create()
        {
            DecklistUpload du = new DecklistUpload();
            return View(du);
        }

        // POST: Decklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DecklistUpload DecklistUpload)
        {
            if (!ModelState.IsValid)
            {
                return View(DecklistUpload);
            }
            var DecklistaData = await _fileHelpers.ProcessFormFile(DecklistUpload.DecklistFile, ModelState);
            if (!ModelState.IsValid)
            {
                return View(DecklistUpload);
            }
            Decklist decklist = new Decklist()
            {
                DeckName = DecklistUpload.DecklistName,
                DecklistData = DecklistaData
            };
                _context.Add(decklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
        // GET: Decklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decklist = await _context.Decklists.FindAsync(id);
            if (decklist == null)
            {
                return NotFound();
            }
            return View(decklist);
        }
        // POST: Decklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Decklist decklist)
        {
            if (id != decklist.DecklistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecklistExists(decklist.DecklistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(decklist);
        }
        // GET: Decklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decklist = await _context.Decklists
                .FirstOrDefaultAsync(m => m.DecklistId == id);
            if (decklist == null)
            {
                return NotFound();
            }

            return View(decklist);
        }
        // POST: Decklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var decklist = await _context.Decklists.FindAsync(id);
            _context.Decklists.Remove(decklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DecklistExists(int id)
        {
            return _context.Decklists.Any(e => e.DecklistId == id);
        }
    }
}
