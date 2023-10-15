using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Invoice.Models;

namespace Test_Invoice.Controllers
{
    public class InvoicesDetailsController : Controller
    {
        private readonly TestInvoiceContext _context;

        public InvoicesDetailsController(TestInvoiceContext context)
        {
            _context = context;
        }

        // GET: InvoicesDetails
        public async Task<IActionResult> Index()
        {
            var testInvoiceContext = _context.InvoicesDetails.Include(i => i.Customer);
            return View(await testInvoiceContext.ToListAsync());
        }

        // GET: InvoicesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoicesDetails == null)
            {
                return NotFound();
            }

            var invoicesDetail = await _context.InvoicesDetails
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.InvoiceDetailId == id);
            if (invoicesDetail == null)
            {
                return NotFound();
            }

            return View(invoicesDetail);
        }

        // GET: InvoicesDetails/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceId");
            return View();
        }

        // POST: InvoicesDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceDetailId,CustomerId,InvoiceDetailQuantity,InvoiceDetailPrice,InvoiceDetailTotalItbis,InvoiceDetailSubtotal,InvoiceDetailTotal")] InvoicesDetail invoicesDetail)
        {

            invoicesDetail.Customer = _context.Invoices.FirstOrDefault(ct => ct.CustomerId == invoicesDetail.CustomerId);
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                _context.Add(invoicesDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceId", invoicesDetail.CustomerId);
            return View(invoicesDetail);
        }

        // GET: InvoicesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoicesDetails == null)
            {
                return NotFound();
            }

            var invoicesDetail = await _context.InvoicesDetails.FindAsync(id);
            if (invoicesDetail == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceId", invoicesDetail.CustomerId);
            return View(invoicesDetail);
        }

        // POST: InvoicesDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceDetailId,CustomerId,InvoiceDetailQuantity,InvoiceDetailPrice,InvoiceDetailTotalItbis,InvoiceDetailSubtotal,InvoiceDetailTotal")] InvoicesDetail invoicesDetail)
        {
            if (id != invoicesDetail.InvoiceDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoicesDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesDetailExists(invoicesDetail.InvoiceDetailId))
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
            ViewData["CustomerId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceId", invoicesDetail.CustomerId);
            return View(invoicesDetail);
        }

        // GET: InvoicesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoicesDetails == null)
            {
                return NotFound();
            }

            var invoicesDetail = await _context.InvoicesDetails
                .Include(i => i.Customer)
                .FirstOrDefaultAsync(m => m.InvoiceDetailId == id);
            if (invoicesDetail == null)
            {
                return NotFound();
            }

            return View(invoicesDetail);
        }

        // POST: InvoicesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoicesDetails == null)
            {
                return Problem("Entity set 'TestInvoiceContext.InvoicesDetails'  is null.");
            }
            var invoicesDetail = await _context.InvoicesDetails.FindAsync(id);
            if (invoicesDetail != null)
            {
                _context.InvoicesDetails.Remove(invoicesDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicesDetailExists(int id)
        {
          return (_context.InvoicesDetails?.Any(e => e.InvoiceDetailId == id)).GetValueOrDefault();
        }
    }
}
