namespace ProjetGL.Models
{
    public class Message
    {
        public int MessageId { get; set; } 
        public string Content { get; set; }
        public DateTime SentAt { get; set; } 

        public int SenderId { get; set; } 
        public int ReceiverId { get; set; } 

        public Message() { }

        public Message(int senderid, int receiverid, string content)
        {
            SenderId = senderid;
            ReceiverId = receiverid;
            Content = content;
            SentAt = DateTime.Now;
        }

        
    }
}
