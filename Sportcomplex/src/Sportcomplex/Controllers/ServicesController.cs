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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace Sportcomplex.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private object main;

        public ServicesController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Service.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        [Authorize(Roles = "Admins")]//---------------
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Create(long? id, ServiceEditModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new Service
                {
                    Title = model.Title,
                    Description = model.Description,
                    ServiceImgURL = model.ServiceImgURL
                };

                if (model.Image != null)
                {
                    var filename = Path.GetFileName(ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"'));
                    var rash = Path.GetExtension(filename);
                    var way = _env.WebRootPath;
                    way = Path.Combine(way, "uploads");

                    if (rash == ".jpg" || rash == ".png")
                    {
                        way = Path.Combine(way, filename);

                        using (FileStream SourceStream = System.IO.File.Open(way, FileMode.OpenOrCreate))
                        {
                            await model.Image.CopyToAsync(SourceStream);
                        }

                        item.ServiceImgURL = "/uploads/" + filename;
                    }
                }
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Services/Edit/5
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new ServiceEditModel
            {
                Description = service.Description,
                Title = service.Title,
                ServiceImgURL = service.ServiceImgURL
            };

            return View(model);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Edit(long id, ServiceEditModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            var service = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);

            if (ModelState.IsValid)
            {
                var par = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);
               
                  if (model.Image != null)
                     {
                        var filename = Path.GetFileName(ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"'));
                        var rash = Path.GetExtension(filename);
                        var way = _env.WebRootPath;
                        way = Path.Combine(way, "uploads");

                            if (rash == ".jpg" || rash == ".png")
                            {
                                way = Path.Combine(way, filename);

                                using (FileStream SourceStream = System.IO.File.Open(way, FileMode.OpenOrCreate))
                                {
                                    await model.Image.CopyToAsync(SourceStream);
                                }

                                par.ServiceImgURL = "/uploads/" + filename;

                                service.Title = model.Title;
                                service.Description = model.Description;

                                await _context.SaveChangesAsync();
                                return RedirectToAction("Index");
                            }
                            else
                        {
                            return View();
                        }
                }

                service.Title = model.Title;
                service.Description = model.Description;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
            }

        // GET: Services/Delete/5
        [Authorize(Roles = "Admins")]//---------------
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [Authorize(Roles = "Admins")]//---------------
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var service = await _context.Service.SingleOrDefaultAsync(m => m.Id == id);
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServiceExists(long id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
