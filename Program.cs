using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.UseDeveloperExceptionPage();
         
            Commande commande = new Commande();
            commande.IdAppelOffre = 1;
            commande.Datelivraison = DateTime.Now;
            commande.Dategarantie = DateTime.Now;
            commande.Marque = "hp";
            commande.Quantite = 12;
            commande.PrixUnitaire = 1;
            commande.IdFournisseur = 1; 
            ServicesPages.gestionCommande.addCommande(commande);
            


            app.Run();
        }
    }
}
