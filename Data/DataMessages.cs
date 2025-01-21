using Microsoft.VisualBasic;
using ProjetGL.Models;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ProjetGL.Data
{
    public class DataMessages : IDataMessages
    {
        SqlConnection connection;
        SqlCommand Command;
        public DataMessages()
        {
            connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            connection.Open();
            Command = new SqlCommand();
            Command.Connection = connection;

        }
        public void AddMessage(int senderId, int receiverId, string content)
        {
            string query = "INSERT INTO Messages (SenderId, ReceiverId, Content) VALUES (@SenderId, @ReceiverId, @Content)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SenderId", senderId);
                command.Parameters.AddWithValue("@ReceiverId", receiverId);
                command.Parameters.AddWithValue("@Content", content);

                command.ExecuteNonQuery();
            }
        }


        public List<Message> GetConversation(int senderId, int receiverId)
        {
            List<Message> messages = new List<Message>();
            Command.CommandText = $@"select * from  Messages where SenderId = {senderId} and ReceiverId = {receiverId} or SenderId = {receiverId} and ReceiverId = {senderId}";
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message
                {
                    MessageId = reader.GetInt32(0),
                    SenderId = reader.GetInt32(1),
                    ReceiverId = reader.GetInt32(2),
                    Content = reader.GetString(3),
                    SentAt = reader.GetDateTime(4)
                };
                messages.Add(message);
            }
            return messages;
        }

        public List<Conversation> GetConversations(int currentUserId)
        {
            List<Conversation> conversations = new List<Conversation>();
            string query = @"
        WITH LatestMessages AS (
            SELECT 
                CASE 
                    WHEN SenderId = @CurrentUserId THEN ReceiverId
                    ELSE SenderId
                END AS ChatUserId,
                MAX(MessageId) AS LatestMessageId
            FROM Messages
            WHERE SenderId = @CurrentUserId OR ReceiverId = @CurrentUserId
            GROUP BY 
                CASE 
                    WHEN SenderId = @CurrentUserId THEN ReceiverId
                    ELSE SenderId
                END
        )
        SELECT 
            LM.ChatUserId,
            M.MessageId,
            M.SenderId,
            M.ReceiverId,
            M.Content,
            M.SentAt
        FROM LatestMessages LM
        INNER JOIN Messages M ON LM.LatestMessageId = M.MessageId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CurrentUserId", currentUserId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int chatUserId = reader.GetInt32(0);
                        Message latestMessage = new Message
                        {
                            MessageId = reader.GetInt32(1),
                            SenderId = reader.GetInt32(2),
                            ReceiverId = reader.GetInt32(3),
                            Content = reader.GetString(4),
                            SentAt = reader.GetDateTime(5)
                        };

                        conversations.Add(new Conversation
                        {
                            ChatUserId = chatUserId,
                            LatestMessage = latestMessage
                        });
                    }
                }
            }

            return conversations;
        }


        public Message GetMessageById(int messageId)
        {
            string query = "SELECT MessageId, SenderId, ReceiverId, Content, SentAt FROM Messages WHERE MessageId = @MessageId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MessageId", messageId);

                // Execute the query
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Message
                        {
                            MessageId = reader.GetInt32(0),
                            SenderId = reader.GetInt32(1),
                            ReceiverId = reader.GetInt32(2),
                            Content = reader.GetString(3),
                            SentAt = reader.GetDateTime(4)
                        };
                    }
                }
            }

            return null;
        }

    }
}
