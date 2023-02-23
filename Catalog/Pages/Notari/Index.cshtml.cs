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
    public class IndexModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public IndexModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IList<Notare> Notare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Notare != null)
            {
                Notare = await _context.Notare
                .Include(n => n.Member)
                .Include(n => n.Student).ToListAsync();
            }
        }
    }
}
