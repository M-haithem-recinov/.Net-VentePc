using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentePc.Models
{
    public class Vente
    {
        public int VenteId { get; set; }
        [Required]
        [Display(Name ="Produit")]
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public client Client { get; set; }
        [Display(Name = "Date Vente")]
        public DateTime DateVente { get; set; }
    }
}
