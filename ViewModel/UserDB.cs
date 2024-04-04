using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.PhoneNum = int.Parse(reader["phoneNum"].ToString());
            user.userName = reader["username"].ToString();
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.BDay = DateTime.Parse(reader["bDay"].ToString());
            user.IsManager = bool.Parse(reader["isManager"].ToString());
            user.Beliver = bool.Parse(reader["beliver"].ToString());
            user.Married = bool.Parse(reader["married"].ToString());
            user.Desiese = reader["desiese"].ToString();
            user.Religion = reader["religion"].ToString();
            user.Child = int.Parse(reader["child"].ToString());
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tbCity";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tbCity WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}
