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
    public class DetailsModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public DetailsModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

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
    }
}
