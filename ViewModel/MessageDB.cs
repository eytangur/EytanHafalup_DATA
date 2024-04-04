using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MessageDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Message();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Message message = entity as Message;
            message.Id = int.Parse(reader["id"].ToString());
            message.Text = reader["message"].ToString();
            message.When =DateTime.Parse(reader["when"].ToString());
            ChatDB chatDB = new ChatDB();
            message.Chat = chatDB.SelectById(int.Parse(reader["chatID"].ToString()));
            UserDB userDB = new UserDB();   
            message.Sender =userDB.SelectById(int.Parse(reader["sender"].ToString()));
            return message;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Message message = entity as Message;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@sender", message.Sender.Id);
            command.Parameters.AddWithValue("@chatId", message.Chat.Id);
            command.Parameters.AddWithValue("@message", message.Text);
            command.Parameters.AddWithValue("@when", message.When.ToString("dd/MM/yyyy HH:mm:ss"));
            command.Parameters.AddWithValue("@id", message.Id);
        }
        public MessageList SelectAll()
        {
            command.CommandText = "SELECT * FROM TBLMessage ";
            MessageList list = new MessageList(ExecuteCommand());
            return list;
        }
        public MessageList SelectByChat(Chat chat)
        {
            command.CommandText = $"SELECT * FROM TBLMessage WHERE chatID={chat.Id}";
            MessageList list = new MessageList(ExecuteCommand());
            return list;
        }
        public Message SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLMessage WHERE id= " + id;
            MessageList list = new MessageList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }        
        public int Insert(Message message)
        {
            command.CommandText = "INSERT INTO TBLMessage (sender, chatId, message, [when]) " +
                "VALUES (@sender, @chatId, @message, @when) ";
            LoadParameters(message);
            return ExecuteCRUD();
        }
        public int Update(Message message)
        {
            command.CommandText = "UPDATE TBLMessage " +
                "SET sender=@sender,chatId=@chatId, message = @message,[when] = @when " +
                "WHERE  (id = @id) ";
            LoadParameters(message);
            return ExecuteCRUD();
        }
        public int Delete(Message message)
        {
            command.CommandText = "DELETE FROM TBLMessage WHERE (id = @id) ";
            LoadParameters(message);
            return ExecuteCRUD();
        }
    }
}
