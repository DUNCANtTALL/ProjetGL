namespace ProjetGL.Models
{
    public class User
    {
        private string name;
        private string email;
        private string password;
        private List<Message> messages;

        public void SendMessage(Fournisseur receiver, string content)
        {
            var message = new Message(this.email, receiver.Email, content);
            receiver.messages.Add(message); 
        }
        public List<Message> ViewMessages()
        {
            return this.messages;
        }


    }
}
