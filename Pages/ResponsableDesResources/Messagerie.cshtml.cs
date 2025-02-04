using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetGL.Buisness;
using ProjetGL.Models;
using System.Collections.Generic;

namespace ProjetGL.Pages.ResponsableDesResources
{
    public class MessagerieModel : PageModel
    {
        public List<Conversation> Conversations { get; set; }
        public Dictionary<int, User> UserMap { get; set; } // Map User IDs to User objects

        public void OnGet()
        {
            var currentUserId = 1006; 
            var managerMessages = ServicesPages.managerMessages;
            var managerUsers = ServicesPages.managerUsers;

            Conversations = managerMessages.GetConversations(currentUserId);

            UserMap = new Dictionary<int, User>();

            foreach (var conversation in Conversations)
            {
                if (!UserMap.ContainsKey(conversation.ChatUserId))
                {
                    var user = managerUsers.GetUser(conversation.ChatUserId);
                    if (user != null)
                    {
                        UserMap[conversation.ChatUserId] = user;
                    }
                }
            }
        }
    }
}
