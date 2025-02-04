using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages.Fournisseurs
{
    public class MessageModel : PageModel
    {
        private readonly GestionMessages _gestionMessages = new GestionMessages();

        public List<Message> Conversation { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }
        public int ReceiverId { get; private set; } = 1006;

        public void OnGet()
        {
            Conversation = _gestionMessages.GetConversation(UserId, ReceiverId);
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
