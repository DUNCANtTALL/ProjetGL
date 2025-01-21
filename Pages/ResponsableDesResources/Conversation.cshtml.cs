using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class ConversationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int fournisseurId { get; set; }

        private readonly GestionMessages _gestionMessages = new GestionMessages();

        public List<Message> Conversation { get; private set; }
        public int CurrentUserId { get; private set; } = 2;

       
        public void OnGet()
        {
            Conversation = _gestionMessages.GetConversation(CurrentUserId, fournisseurId);
        }

        public IActionResult OnPost(int senderId, int receiverId, string messageContent)
        {
            if (!string.IsNullOrWhiteSpace(messageContent))
            {
                _gestionMessages.addMessage(senderId, receiverId, messageContent);
            }

            return RedirectToPage();
        }
    }
}
