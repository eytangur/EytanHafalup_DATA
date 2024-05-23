using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChatDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Chat();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            chat.Id = int.Parse(reader["id"].ToString());
            chat.Approve1 = bool.Parse(reader["approved1"].ToString());
            chat.Approve2 = bool.Parse(reader["approved2"].ToString());           
            UserDB userDB = new UserDB();
            chat.User1 = userDB.SelectById(int.Parse(reader["user1"].ToString()));
            chat.User2 = userDB.SelectById(int.Parse(reader["user2"].ToString()));
            return chat;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Chat chat = entity as Chat;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@approved1", chat.Approve1);
            command.Parameters.AddWithValue("@approved2", chat.Approve2);
            command.Parameters.AddWithValue("@user1", chat.User1.Id);
            command.Parameters.AddWithValue("@user2", chat.User2.Id);
            command.Parameters.AddWithValue("@id", chat.Id);
        }
        public ChatList SelectAll()
        {
            command.CommandText = "SELECT * FROM TBLChat ";
            ChatList list = new ChatList(ExecuteCommand());
            return list;
        }
        public ChatList SelectChatByUser(User user)
        {
            command.CommandText = $"SELECT * FROM TBLChat WHERE (user1={user.Id} OR user2={user.Id}) AND (approved1=true AND approved2=true)";
            ChatList list = new ChatList(ExecuteCommand());
            return list;
        }
        public ChatList SelectChatByUserToApprove(User user)
        {
            //שיחות שממתינו לאישור של משתמש
            command.CommandText = $"SELECT * FROM TBLChat WHERE (user1={user.Id} AND approved1=false) OR (user2={user.Id} AND approved2=false)";
            ChatList list = new ChatList(ExecuteCommand());
            return list;
        }
        public ChatList SelectChatMeWaitingToApprove(User user)
        {
            //משתמש ביקש לשוחח ועדיין לא אושר על ידי המשתמש השני
            command.CommandText = $"SELECT * FROM TBLChat WHERE (user1={user.Id} AND approved2=false)";
            ChatList list = new ChatList(ExecuteCommand());
            return list;
        }
        public Chat SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLChat WHERE id=" + id;
            ChatList list = new ChatList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Chat chat)
        {
            command.CommandText = "INSERT INTO TBLChat (approved1,approved2,user1,user2) " +
                "VALUES (@approved1,@approved2,@user1,@user2) ";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Update(Chat chat)
        {
            command.CommandText = "UPDATE TBLChat " +
                "SET  approved1 = @approved1,approved2 = @approved2, user1=@user1, user2=@user2 " +
                "WHERE  (id = @id) ";
            LoadParameters(chat);
            return ExecuteCRUD();
        }
        public int Delete(Chat chat)
        {
            command.CommandText = $"DELETE FROM TBLChat WHERE (id = {chat.Id}) ";
            return ExecuteCRUD();
        }
    }
}
