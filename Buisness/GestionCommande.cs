﻿using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionCommande
    {
        IDataCommande data = new DataCommande();


        public List<Commande> GetAllCommande()
        {
            return data.GetAllCommande();
        }
        
        public void addCommande(Commande commande)
        {
            data.AddCommande(commande);
        }
        public void deleteCommande(DateTime dateCommande)
        {
            data.DeleteCommande(dateCommande);
        }
        public void validateCommande(int id)
        {
            data.ValidateCommande(id);
        }
    }
}
