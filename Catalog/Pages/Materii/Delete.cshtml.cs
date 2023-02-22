using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Materii
{
    public class DeleteModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public DeleteModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Materie Materie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }

            var materie = await _context.Materie.FirstOrDefaultAsync(m => m.ID == id);

            if (materie == null)
            {
                return NotFound();
            }
            else 
            {
                Materie = materie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }
            var materie = await _context.Materie.FindAsync(id);

            if (materie != null)
            {
                Materie = materie;
                _context.Materie.Remove(Materie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
