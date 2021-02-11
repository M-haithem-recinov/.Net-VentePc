using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentePc.Models;

namespace VentePc.Controllers
{
    [Authorize]
    public class VentesController : Controller
    {
        private readonly AppDbContext _context;

        public VentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ventes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Vente.Include(v => v.Client).Include(v => v.Produit);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Ventes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente
                .Include(v => v.Client)
                .Include(v => v.Produit)
                .FirstOrDefaultAsync(m => m.VenteId == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // GET: Ventes/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.client, "ClientId", "ClientId");
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ProduitId", "ProduitId");
            return View();
        }

        // POST: Ventes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenteId,ProduitId,ClientId,DateVente")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.client, "ClientId", "ClientId", vente.ClientId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ProduitId", "ProduitId", vente.ProduitId);
            return View(vente);
        }

        // GET: Ventes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente.FindAsync(id);
            if (vente == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.client, "ClientId", "ClientId", vente.ClientId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ProduitId", "ProduitId", vente.ProduitId);
            return View(vente);
        }

        // POST: Ventes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VenteId,ProduitId,ClientId,DateVente")] Vente vente)
        {
            if (id != vente.VenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenteExists(vente.VenteId))
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
            ViewData["ClientId"] = new SelectList(_context.client, "ClientId", "ClientId", vente.ClientId);
            ViewData["ProduitId"] = new SelectList(_context.Produits, "ProduitId", "ProduitId", vente.ProduitId);
            return View(vente);
        }

        // GET: Ventes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente
                .Include(v => v.Client)
                .Include(v => v.Produit)
                .FirstOrDefaultAsync(m => m.VenteId == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // POST: Ventes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vente = await _context.Vente.FindAsync(id);
            _context.Vente.Remove(vente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenteExists(int id)
        {
            return _context.Vente.Any(e => e.VenteId == id);
        }
    }
}
