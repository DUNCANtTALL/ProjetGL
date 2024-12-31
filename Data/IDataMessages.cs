using ProjetGL.Models;

namespace ProjetGL.Data
{
    public interface IDataMessages
    {
        public void AddMessage(int senderId, int receiverId, string content);
        public List<Message> GetConversation(int senderId, int receiverId);
        public Message GetMessageById(int messageId);


    }
}
