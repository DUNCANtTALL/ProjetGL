using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProjetGL.Buisness;
using ProjetGL.Models;

namespace ProjetGL.Pages
{
    public class MessageModel : PageModel
    {
        private readonly GestionMessages _gestionMessages = new GestionMessages();

        public List<Message> Conversation { get; private set; }
        public int CurrentUserId { get; private set; } = 1; 
        public int ReceiverId { get; private set; } = 2;   

        public void OnGet()
        {
            Conversation = _gestionMessages.GetConversation(CurrentUserId, ReceiverId);
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
