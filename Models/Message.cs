namespace ProjetGL.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; } 
        public string ReceiverEmail { get; set; } 
        public string Content { get; set; }
        public DateTime Timestamp { get; set; } 

        public Message(string senderEmail, string receiverEmail, string content)
        {
            SenderEmail = senderEmail;
            ReceiverEmail = receiverEmail;
            Content = content;
            Timestamp = DateTime.Now;
        }
    }
}
