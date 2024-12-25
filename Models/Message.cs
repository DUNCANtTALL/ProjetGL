namespace ProjetGL.Models
{
    public class Message
    {
        public int MessageId { get; set; } 
        public string Content { get; set; }
        public DateTime SentAt { get; set; } 

        public User Sender { get; set; } 
        public User Receiver { get; set; } 

        public Message() { }

        public Message(User sender, User receiver, string content)
        {
            Sender = sender;
            Receiver = receiver;
            Content = content;
            SentAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"From: {Sender.Name} ({Sender.Email})\nTo: {Receiver.Name} ({Receiver.Email})\nSent At: {SentAt}\nMessage: {Content}";
        }
    }
}
