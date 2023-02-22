using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.Models;

namespace Catalog.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext (DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Catalog.Models.ListaProfesoriMaterie> ListaProfesoriMaterie { get; set; } = default!;

        public DbSet<Catalog.Models.Materie> Materie { get; set; }

        public DbSet<Catalog.Models.Nota> Nota { get; set; }

        public DbSet<Catalog.Models.Profesor> Profesor { get; set; }

        public DbSet<Catalog.Models.Student> Student { get; set; }
    }
}
