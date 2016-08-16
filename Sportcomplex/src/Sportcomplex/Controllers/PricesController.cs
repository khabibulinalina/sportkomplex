using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sportcomplex.Data;
using Sportcomplex.Models;
using Microsoft.AspNetCore.Authorization;

namespace Sportcomplex.Controllers
{
    public class PricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Prices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Price.ToListAsync());
        }

        // GET: Prices/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price.SingleOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        [Authorize(Roles = "Admins")]//---------------

        // GET: Prices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//--------------------------
        public async Task<IActionResult> Create([Bind("Id,Eight_work,Eleven_work,For_work,NameOfSport,One_work,TimeOfGym")] Price price)
        {
            if (ModelState.IsValid)
            {
                _context.Add(price);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(price);
        }

        // GET: Prices/Edit/5
        [Authorize(Roles = "Admins")]//--------------------------------
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price.SingleOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//--------------------------------
        public async Task<IActionResult> Edit(long id, [Bind("Id,Eight_work,Eleven_work,For_work,NameOfSport,One_work,TimeOfGym")] Price price)
        {
            if (id != price.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(price);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(price.Id))
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
            return View(price);
        }

        // GET: Prices/Delete/5
        [Authorize(Roles = "Admins")]//---------------------------------------
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price.SingleOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // POST: Prices/Delete/5 
        [Authorize(Roles = "Admins")]//------------------------------
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var price = await _context.Price.SingleOrDefaultAsync(m => m.Id == id);
            _context.Price.Remove(price);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PriceExists(long id)
        {
            return _context.Price.Any(e => e.Id == id);
        }
    }
}
