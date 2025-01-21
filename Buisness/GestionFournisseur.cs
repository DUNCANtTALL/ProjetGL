﻿using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionFournisseur
    {
        IDataFournisseur data = new DataFournisseurs();

        public void AddFournisseur(Societe fournisseur)
        {
            data.AddFournisseur(fournisseur);
        } 
    }
}
