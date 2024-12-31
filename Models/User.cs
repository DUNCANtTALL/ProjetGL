namespace ProjetGL.Models
{
    public  class User
    {
        public int UserId { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 

        // Navigation properties for messaging
        public  List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }

        public User()
        {
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
        }
        

        public void SendMessage(User receiver, string content)
        {
            var message = new Message
            {
                SenderId = this.UserId,
                ReceiverId = receiver.UserId,
                Content = content,
                SentAt = DateTime.Now

            };
            receiver.ReceivedMessages.Add(message);
        }
    }
}
