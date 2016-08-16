using System;
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
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        [Authorize]
        public Cart GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        public void SaveCartToSession(Cart cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        [Authorize]
        public IActionResult AddCart(long id, string returnUrl)
        {
            var service = _dbContext.Service.FirstOrDefault(b => b.Id == id);

            if (service != null)
            {
                var cart = GetCart();
                cart.AddItem(service, 1);
                SaveCartToSession(cart);
            }

            return RedirectToAction("Details", "Services", new { id = id }); //LocalRedirect(returnUrl);
            //return RedirectToActionResult("Index", "", new { returnUrl });
        }
        //GET
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _dbContext.Ñart(m => m.Id == id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
      
        //    return View(cart);
        //}

    }
}