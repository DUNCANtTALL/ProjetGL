﻿using ProjetGL.Models;
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

        public Message GetMessageById(int messageId)
        {
            Command.CommandText = $@"select * from Messages where MessageId = {messageId}";
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                Message message = new Message
                {
                    MessageId = reader.GetInt32(0),
                    SenderId = reader.GetInt32(1),
                    ReceiverId = reader.GetInt32(2),
                    Content = reader.GetString(3),
                    SentAt = reader.GetDateTime(4)
                };
                return message;
            }
            return null;
        }
    }
}
