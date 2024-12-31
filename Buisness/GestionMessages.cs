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
        public void addMessage(Message message)
        {
            data.AddMessage(message.SenderId,message.SenderId,message.Content);
        }
        

       
    }
}
