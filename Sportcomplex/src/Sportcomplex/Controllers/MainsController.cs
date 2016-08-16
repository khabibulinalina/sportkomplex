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
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Sportcomplex.Controllers
{
    public class MainsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public MainsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;    
        }

        // GET: Mains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Main.ToListAsync());
        }

        // GET: Mains/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main.SingleOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: Mains/Create
        [Authorize(Roles = "Admins")]//---------------
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Create([Bind("Id,MainImageURL")] Main main)
        {
            if (ModelState.IsValid)
            {
                _context.Add(main);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(main);
        }

        // GET: Mains/Edit/5
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Edit(long? id)
        {  
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main.SingleOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }
            return View(new EditImage { Id=main.Id});
        }

        // POST: Mains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Edit(long id, [Bind("Id,Image")] EditImage  main)
        {
            if (id != main.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               var par = await _context.Main.SingleOrDefaultAsync(m => m.Id == id);   
               var filename=Path.GetFileName(ContentDispositionHeaderValue.Parse(main.Image.ContentDisposition).FileName.Trim('"'));
               var rash = Path.GetExtension(filename); 
               var way = _env.WebRootPath;  //
               way = Path.Combine(way, "uploads"); 

                if (rash == ".jpg" || rash == ".png")
                {
                    way = Path.Combine(way, filename); 

                    using (FileStream SourceStream = System.IO.File.Open(way, FileMode.OpenOrCreate))
                    {
                        await main.Image.CopyToAsync(SourceStream);
                    }
                    par.MainImageURL = "/uploads/" + filename; 
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(main);
        }

        // GET: Mains/Delete/5
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main.SingleOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: Mains/Delete/5
        [Authorize(Roles = "Admins")]//---------------
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var main = await _context.Main.SingleOrDefaultAsync(m => m.Id == id);
            _context.Main.Remove(main);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MainExists(long id)
        {
            return _context.Main.Any(e => e.Id == id);
        }
    }
}
