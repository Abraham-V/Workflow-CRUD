using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProducts.Models;
using MvcEkkremotites.Models;
using MvcPromitheftes.Models;
using MvcTechnician.Models;
using Microsoft.AspNetCore.Authorization;
using MvcProsEpiskevi.Models;

namespace Unique.Controllers
{
    [Authorize]
    public class TechnicianController : Controller
    {
        private readonly MvcProductsContext _context;

        public TechnicianController(MvcProductsContext context)
        {
            _context = context;
        }

        public IActionResult AddDate(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDate([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] cProsEpiskevi product, int id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();

            it.FixDate = product.FixDate;
            it.Location = product.Location;

            if (ModelState.IsValid)
            {
                _context.Update(it);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // POST: Ekkremotites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET: Kostologisi/Create
        public IActionResult Move(int? id)
        {
            return View();
        }

        // POST: Kostologisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Move([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] Technician product, int id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();

            it.ErgasiaTexnikou = product.ErgasiaTexnikou;
            it.UsedExtra = product.UsedExtra;
            it.ChargeExtra = product.ChargeExtra;
            it.ChargeWork = product.ChargeWork;
            it.ExtraNotes = product.ExtraNotes;
            it.Location = product.Location;

            if (ModelState.IsValid)
            {
                _context.Update(it);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        public IActionResult MoveEkkremotites(int? id)
        {
            return View();
        }

        // POST: Kostologisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoveEkkremotites([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] cEkkremotites product, int id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();

            it.Ekkremotites = product.Ekkremotites;
            it.Location = product.Location;

            if (ModelState.IsValid)
            {
                _context.Update(it);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        public IActionResult MovePromitheftes(int? id)
        {
            return View();
        }

        // POST: Kostologisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MovePromitheftes([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location,UsedExtra,FPA,Ekkremotites,Promitheftes,Total,ExtraNotes")] cPromitheftes product, int id)
        {
            Product it = (from p in _context.Product
                          where p.ID == id
                          select p).SingleOrDefault();

            it.Promitheftes = product.Promitheftes;
            it.Location = product.Location;

            if (ModelState.IsValid)
            {
                _context.Update(it);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        // GET: Technician
        public async Task<IActionResult> Index()
        {

            return View(await _context.Product.ToListAsync());
        }

        // GET: Technician/Details/5
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

        // GET: Technician/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,ReceiveDate,FixDate,Name,Phone,Products,Description,Notes,Send,ErgasiaTexnikou,ExtraParts,ChargeExtra,ChargeWork,ChargeMethod,Location")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Technician/Edit/5
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

        // POST: Technician/Edit/5
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

        // GET: Technician/Delete/5
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

        // POST: Technician/Delete/5
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
