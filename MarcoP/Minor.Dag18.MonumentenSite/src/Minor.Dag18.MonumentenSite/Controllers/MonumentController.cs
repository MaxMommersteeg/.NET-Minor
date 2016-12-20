using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Minor.Dag18.MonumentenSite.Models;

namespace Minor.Dag18.MonumentenSite.Controllers
{
    public class MonumentController : Controller
    {
        private readonly MonumentenContext _context;

        public MonumentController(MonumentenContext context)
        {
            _context = context;    
        }

        // GET: Monument
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monument.ToListAsync());
        }

        // GET: Monument/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument.SingleOrDefaultAsync(m => m.ID == id);
            if (monument == null)
            {
                return NotFound();
            }

            return View(monument);
        }

        // GET: Monument/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naam,Stad")] Monument monument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monument);
                await _context.SaveChangesAsync();

                //bool success = false;
                //if (success)
                //{
                //    return RedirectToAction("Index");
                //}

            }
            ModelState.AddModelError("Stad", "Deze stad bestaat niet!");
            return View(monument);
        }

        // GET: Monument/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument.SingleOrDefaultAsync(m => m.ID == id);
            if (monument == null)
            {
                return NotFound();
            }
            return View(monument);
        }

        // POST: Monument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Naam,Stad")] Monument monument)
        {
            if (id != monument.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonumentExists(monument.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(monument);
        }

        // GET: Monument/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monument = await _context.Monument.SingleOrDefaultAsync(m => m.ID == id);
            if (monument == null)
            {
                return NotFound();
            }

            return View(monument);
        }

        // POST: Monument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var monument = await _context.Monument.SingleOrDefaultAsync(m => m.ID == id);
            _context.Monument.Remove(monument);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MonumentExists(long id)
        {
            return _context.Monument.Any(e => e.ID == id);
        }

        [Route("Stad/{stadnaam}/Monument/{monumentnaam?}")]
        public IActionResult SomeMonuments(string stadnaam, string monumentnaam = null)
        {
            return View("Index", _context.Monument.Where(m => m.Stad == stadnaam).ToList());
        }
    }
}
