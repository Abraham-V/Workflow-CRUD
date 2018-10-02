using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProducts.Models;
using MvcKostologisi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Unique.Controllers
{
    [Authorize]
    public class KostologisiController : Controller
    {
        private readonly MvcProductsContext _context;

        public KostologisiController(MvcProductsContext context)
        {
            _context = context;
        }

        // POST: Ekkremotites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET: Kostologisi/Create
        
        public IActionResult Move(int? id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();
            ViewBag.ChargeExtra = it.ChargeExtra;
            ViewBag.ChargeWork = it.ChargeWork;
                        
            return View();
        }

        // POST: Kostologisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Move([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] Kostologisi product, int id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();

            it.ChargeExtra = product.ChargeExtra;
            it.ChargeWork = product.ChargeWork;
            it.ChargeMethod = product.ChargeMethod;
            it.Total = product.Total;
            it.Location = product.Location;

            if (ModelState.IsValid)
            {
                _context.Update(it);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }


        // GET: Kostologisi
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Kostologisi/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Kostologisi/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kostologisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Kostologisi/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Kostologisi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
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
            return View(product);
        }

        // GET: Kostologisi/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Kostologisi/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
