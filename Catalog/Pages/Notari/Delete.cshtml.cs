using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Notari
{
    public class DeleteModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public DeleteModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Notare Notare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notare == null)
            {
                return NotFound();
            }

            var notare = await _context.Notare.FirstOrDefaultAsync(m => m.ID == id);

            if (notare == null)
            {
                return NotFound();
            }
            else 
            {
                Notare = notare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Notare == null)
            {
                return NotFound();
            }
            var notare = await _context.Notare.FindAsync(id);

            if (notare != null)
            {
                Notare = notare;
                _context.Notare.Remove(Notare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
