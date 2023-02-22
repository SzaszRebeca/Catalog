using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.ListaProfesoriMaterii
{
    public class IndexModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public IndexModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IList<ListaProfesoriMaterie> ListaProfesoriMaterie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ListaProfesoriMaterie != null)
            {
                ListaProfesoriMaterie = await _context.ListaProfesoriMaterie
                .Include(l => l.Materie)
                .Include(l => l.Profesor).ToListAsync();
            }
        }
    }
}
