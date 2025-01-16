using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetGL.Pages.Appelsdoffres
{
    public class DashBoardModel : PageModel
    {
        public bool IsMenuVisible { get; set; } = true;
        public void OnGet()
        {
        }
    }
}
