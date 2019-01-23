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
using DecklistProjectASP.Utilities;

namespace DecklistProjectASP.Controllers
{
    public class DecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DecklistsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public DecklistUpload DecklistUpload { get; set; }

        // GET: Decklists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Decklists.ToListAsync());
        }

        // GET: Decklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decklist = await _context.Decklists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decklist == null)
            {
                return NotFound();
            }

            DecklistDisplay decklistDisplay = new DecklistDisplay
            {
                Deck = await FromYDKToCodedDeck.Convert(decklist.DecklistData),
                DeckName = decklist.DeckName,
                Id = decklist.Id
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
            var DecklistaData = await FileHelpers.ProcessFormFile(DecklistUpload.DecklistFile, ModelState);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfDeck")] Decklist decklist)
        {
            if (id != decklist.Id)
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
                    if (!DecklistExists(decklist.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Decklists.Any(e => e.Id == id);
        }
    }
}
