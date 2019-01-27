using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecklistProjectASP.Data;
using DecklistProjectASP.Models;
using DecklistProjectASP.Services;
using DecklistProjectASP.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DecklistProjectASP.Controllers
{
    public class DecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileHelpers _fileHelpers;
        private readonly IFromYDKToCodedDeck _fromYDKToCodedDeck;
        private readonly ILoadCardsFromId _loadCardsFromId;
        private readonly UserManager<IdentityUser> _userManager;

        public DecklistsController(ApplicationDbContext context, IFileHelpers fileHelpers, IFromYDKToCodedDeck fromYDKToCodedDeck, ILoadCardsFromId loadCardsFromId, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _fileHelpers = fileHelpers;
            _fromYDKToCodedDeck = fromYDKToCodedDeck;
            _loadCardsFromId = loadCardsFromId;
            _userManager = userManager;
        }

        // GET: Decklists
        public async Task<IActionResult> Index()
        {
            List<DeckView> deckViews = new List<DeckView>();
            foreach(Decklist deck in _context.Decklists.ToList())
            {
                string user = _context.Users.Find(deck.OwnerID).UserName;
                deckViews.Add(new DeckView()
                {
                    Deck = deck,
                    OwnerName = user
                });
            }
            if (User.IsInRole("Admin"))
            {
                return View(deckViews);
            }
            return View(deckViews.Where(x=>x.Deck.OwnerID == GetCurrentUserAsync().Result.Id));
        }
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

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
            List<CardsDecklists> cardsDecklists = new List<CardsDecklists>();
            
            Decklist decklist = new Decklist()
            {
                DeckName = DecklistUpload.DecklistName,
                DecklistData = DecklistaData,
                OwnerID= GetCurrentUserAsync().Result.Id
            };
            List<CardWithAmount> Cards = await _loadCardsFromId.Load(_context.Card.ToList(),_fromYDKToCodedDeck.Convert(DecklistaData).FullDeck);
            foreach (int card in _fromYDKToCodedDeck.Convert(DecklistaData).FullDeck.Distinct())
            {
                try
                {
                    cardsDecklists.Add(new CardsDecklists()
                    {
                        Card = Cards.Find(x => x.Card.CardIdentifier == card).Card,
                        CardId = Cards.Find(x => x.Card.CardIdentifier == card).Card.CardId,
                        Decklist = decklist,
                        DecklistId = decklist.DecklistId
                    });
                }
                catch
                {
                    return View(DecklistUpload);
                }
            }
            _context.AddRange(cardsDecklists);
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
            DeckEdit de = new DeckEdit()
            {
                DecklistId = decklist.DecklistId,
                DeckName = decklist.DeckName
            };
            if (decklist == null)
            {
                return NotFound();
            }
            return View(de);
        }

        // POST: Decklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeckEdit decklist)
        {
            //if (id != decklist.DecklistId)
            //{
            //    return NotFound();
            //}
            Decklist decklistInDB = _context.Decklists.First(x => x.DecklistId == decklist.DecklistId);
            if (ModelState.IsValid && decklistInDB.OwnerID == GetCurrentUserAsync().Result.Id)
            {
                try
                {
                    decklistInDB.DeckName = decklist.DeckName;
                    _context.Update(decklistInDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecklistExists(decklistInDB.DecklistId))
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
        [HttpPost]
        public async Task<IActionResult> SearchForCard(CardForSearch cardForSearch)
        {
            List<Card> cardResults = new List<Card>();
            List<Decklist> decksFound = new List<Decklist>();
            List<FoundDecklistAndCard> foundDecklistsAndCards = new List<FoundDecklistAndCard>();
            var cards = _context.Card.ToList();
            var decks = _context.Decklists.ToList();
            var cardDecklists = _context.CardsDecklist.ToList();
            var users = _context.Users;
            if (cardForSearch.CardName != null)
            {
                cardResults.AddRange(cards.Where(x => x.CardName.ToLower().Contains(cardForSearch.CardName.ToLower())));
                //case insensitive search.
            }
            else
            {
                cardResults.AddRange(cards.Where(x => x.CardIdentifier.ToString().Contains(cardForSearch.CardIdentifier.ToString())));
            }
            foreach(var card in cardResults)
            {
                foreach(var cd in cardDecklists.FindAll(x => x.Card == card))
                {
                    decksFound.AddRange(decks.FindAll(x => x.DecklistId == cd.DecklistId));
                    foreach(var d in decksFound)
                    {
                        var foundDecklist = new FoundDecklistAndCard()
                        {
                            Deck = d,
                            OwnerName = users.Find(d.OwnerID).UserName
                        };
                        foundDecklist.CardsFound.Add(card.CardName);
                        if (foundDecklistsAndCards.FindIndex(x => x.Deck == d) == -1)
                        {
                            foundDecklistsAndCards.Add(foundDecklist);
                        }
                        else
                        {
                            foundDecklistsAndCards.Find(x => x.Deck == d).CardsFound.Add(card.CardName);
                        }
                        
                    }
                }
            }
            
            return View("SearchForCardResult", foundDecklistsAndCards.Distinct());
        }

        public async Task<IActionResult> SearchForCard()
        {
            return View();
        }
    }
}
