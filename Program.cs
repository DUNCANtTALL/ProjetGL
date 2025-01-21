using ProjetGL.Buisness;
using ProjetGL.Models;
using System.ComponentModel.Design;
using System.Diagnostics;

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

            List<Commande> Commandes = new List<Commande>(); 
             Commandes = ServicesPages.gestionCommande.GetAllCommande();

            if (Commandes == null || !Commandes.Any())
            {
                Console.WriteLine("No commands found.");
            }
            else
            {
                foreach (var commande in Commandes)
                {
                    Console.WriteLine($"Commande ID: {commande.Id}, Fournisseur: {commande.IdFournisseur}");
                }
            }




            app.Run();
        }
    }
}
