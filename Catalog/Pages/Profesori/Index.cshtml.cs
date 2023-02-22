using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Profesori
{
    public class IndexModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public IndexModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IList<Profesor> Profesor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Profesor != null)
            {
                Profesor = await _context.Profesor.ToListAsync();
            }
        }
    }
}
