using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetGL.Pages.Fournisseur
{
    public class HomeModel : PageModel
    {
        public bool IsMenuVisible { get; set; } = true;

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }



        public void OnGet()
        {
            Console.WriteLine("id"+UserId);
        }
    }
}
