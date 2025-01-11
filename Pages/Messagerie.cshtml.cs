using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Collections.Generic;

namespace ProjetGL.Pages
{
    public class MessagerieModel : PageModel
    {
        private readonly GestionMessages _gestionMessages = new GestionMessages();

        public List<Message> Conversation { get; private set; }
        public int CurrentUserId { get; private set; } = 1; // Replace with dynamic user ID logic
        public int ReceiverId { get; private set; } = 2;   // Replace with dynamic receiver ID logic

        public void OnGet()
        {
            // Retrieve the conversation between the current user and the receiver
            Conversation = _gestionMessages.GetConversation(CurrentUserId, ReceiverId);
        }

        public void OnPost(int senderId, int receiverId, string messageContent)
        {
            // Add the new message
            _gestionMessages.addMessage(senderId, receiverId, messageContent);

            // Reload the conversation after the new message is added
            Conversation = _gestionMessages.GetConversation(senderId, receiverId);
        }
    }
}
