using ProjetGL.Buisness;
using ProjetGL.Data;
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
           

            List<Ordinateur> ordinateurs = new List<Ordinateur>();
     List<Imprimante> imprimantes = new List<Imprimante>();
            imprimantes = ServicesPages.gestionAppeleDoffre.GetImprimante(24);
            ordinateurs = ServicesPages.gestionAppeleDoffre.GetOrdinateurs(24);
            foreach (var item in imprimantes)
            {
                Console.WriteLine("imprimante : " + item.Marsque);
            }
            foreach (var item in ordinateurs)
            {
                Console.WriteLine("ordinateur : " + item.Marque);
            }





            app.Run();
        }
    }
}
