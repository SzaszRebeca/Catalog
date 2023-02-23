using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Notari
{
    public class CreateModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public CreateModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Notare Notare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notare.Add(Notare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
