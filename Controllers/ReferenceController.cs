﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReferenceReferralApp.Models;

namespace ReferenceReferralApp.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ReferenceContext _context;

        public ReferenceController(ReferenceContext context)
        {
            _context = context;
        }

        // GET: Reference
        public async Task<IActionResult> Index()
        {
            return View(await _context.References.ToListAsync());
        }

        // GET: Reference/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: Reference/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,firstName,lastName,email")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,firstName,lastName,email")] Reference reference)
        {
            if (id != reference.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.ID))
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
            return View(reference);
        }

        // GET: Reference/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: Reference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.References.FindAsync(id);
            _context.References.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(int id)
        {
            return _context.References.Any(e => e.ID == id);
        }
    }
}
