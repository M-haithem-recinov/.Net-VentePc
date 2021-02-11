using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentePc.Models.Repositories
{
    public class SQLProduitRepository:IProduitRepository
    { 
    private readonly AppDbContext context;
    public SQLProduitRepository(AppDbContext context)
    {
        this.context = context;
    }
    public Produit Add(Produit produit)
    {
        context.Produits.Add(produit);
        context.SaveChanges();
        return produit;
    }
    public Produit Delete(int Id)
    {
        Produit produit = context.Produits.Find(Id);
        if (produit != null)
        {
            context.Produits.Remove(produit);
            context.SaveChanges();
        }
        return produit;
    }

    public IEnumerable<Produit> GetAllProduit()
    {
            return context.Produits;
        }

   

    public Produit GetProduit(int Id)
    {
            return context.Produits.Find(Id);
        }

   
   
    public Produit Update(Produit produitChanges)
    {
        var produit =
        context.Produits.Attach(produitChanges);
        produit.State = EntityState.Modified;
        context.SaveChanges();
        return produitChanges;
    }
}
}
