using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentePc.Models.Repositories
{
    interface IProduitRepository
    {
        Produit GetProduit(int Id);
        IEnumerable<Produit> GetAllProduit();
        Produit Add(Produit produit);
        Produit Update(Produit produitChanges);
        Produit Delete(int Id);

    }
}

