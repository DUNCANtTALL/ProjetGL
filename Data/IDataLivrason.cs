using Microsoft.AspNetCore.Mvc;
using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataLivrason
    {
        public Livraison GetLivraison();
        public void validateImprimante(int id);
        public void validateOrdinateur(int id); 
    }
}
