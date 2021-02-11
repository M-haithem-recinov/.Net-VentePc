using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentePc.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string NomProduit { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
         

    }
}
