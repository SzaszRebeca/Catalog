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

namespace Catalog.Pages.ListaProfesoriMaterii
{
    public class EditModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public EditModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListaProfesoriMaterie ListaProfesoriMaterie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListaProfesoriMaterie == null)
            {
                return NotFound();
            }

            var listaprofesorimaterie =  await _context.ListaProfesoriMaterie.FirstOrDefaultAsync(m => m.ID == id);
            if (listaprofesorimaterie == null)
            {
                return NotFound();
            }
            ListaProfesoriMaterie = listaprofesorimaterie;
           ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID", "ID");
           ViewData["ProfesorID"] = new SelectList(_context.Set<Profesor>(), "ID", "ID");
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

            _context.Attach(ListaProfesoriMaterie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaProfesoriMaterieExists(ListaProfesoriMaterie.ID))
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

        private bool ListaProfesoriMaterieExists(int id)
        {
          return _context.ListaProfesoriMaterie.Any(e => e.ID == id);
        }
    }
}
