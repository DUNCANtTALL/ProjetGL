using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionMessages
    {
    IDataMessages data = new DataMessages(); 
        
        public List<Message> GetConversation(int senderId , int receiverId)
        {
            return data.GetConversation(senderId,receiverId);
        }
        public void addMessage(int senderId, int receiverId, string content)
        {
            Message newMessage = new Message(senderId, receiverId, content);
            data.AddMessage(newMessage.SenderId, newMessage.ReceiverId, newMessage.Content);
        }
        public List<Conversation> GetConversations(int currentUserId)
        {
            return data.GetConversations(currentUserId);
        }


    }
}
