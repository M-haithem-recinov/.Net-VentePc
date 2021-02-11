using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentePc.Models;

namespace VentePc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<VentePc.Models.Categorie> Categorie { get; set; }
        public DbSet<VentePc.Models.client> client { get; set; }
        public DbSet<VentePc.Models.Vente> Vente { get; set; }

    }
}
