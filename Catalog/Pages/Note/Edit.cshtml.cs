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

namespace Catalog.Pages.Note
{
    public class EditModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public EditModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nota Nota { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota =  await _context.Nota.FirstOrDefaultAsync(m => m.ID == id);
            if (nota == null)
            {
                return NotFound();
            }
            Nota = nota;
           ViewData["MaterieID"] = new SelectList(_context.Materie, "ID", "ID");
           ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "ID", "ID");
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

            _context.Attach(Nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(Nota.ID))
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

        private bool NotaExists(int id)
        {
          return _context.Nota.Any(e => e.ID == id);
        }
    }
}
