using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionMessages
    {
        List<Message> messages;

        public GestionMessages()
        {
            messages = new List<Message>();

        }

        public List<Message> GetMessages()
        {
            return messages;
        }
        public void addMessage(Message message)
        {
            messages.Add(message);
        }
        public void DeleteMessage(Message message)
        {
            messages.Remove(message);
        }

       
    }
}
