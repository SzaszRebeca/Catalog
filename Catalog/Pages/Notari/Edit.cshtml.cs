using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Notari
{
    public class EditModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public EditModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notare Notare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notare == null)
            {
                return NotFound();
            }

            var notare =  await _context.Notare.FirstOrDefaultAsync(m => m.ID == id);
            if (notare == null)
            {
                return NotFound();
            }
            Notare = notare;
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotareExists(Notare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotareExists(int id)
        {
          return _context.Notare.Any(e => e.ID == id);
        }
    }
}
