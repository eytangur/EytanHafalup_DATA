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
            user.PhoneNum = reader["phoneNum"].ToString();
            user.UserName = reader["username"].ToString();
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.BDay = DateTime.Parse(reader["bDay"].ToString());
            user.IsManager = bool.Parse(reader["isManager"].ToString());
            user.Beliver = bool.Parse(reader["beliver"].ToString());
            user.Married = bool.Parse(reader["married"].ToString());
            user.Desiese = reader["desiese"].ToString();
            user.Child = int.Parse(reader["child"].ToString());

            ReligionDB religionDB = new ReligionDB();
            user.MyReligion =religionDB.SelectById(int.Parse(reader["religion"].ToString()));

            PropertiseDB propertiseDB = new PropertiseDB();
            user.Propertises = propertiseDB.SelectByUser(user);
            return user;
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@username", user.UserName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@bDay", user.BDay.ToString("dd/MM/yyyy"));
            command.Parameters.AddWithValue("@phoneNum", user.PhoneNum);
            command.Parameters.AddWithValue("@isManager", user.IsManager);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@child", user.Child);
            command.Parameters.AddWithValue("@beliver", user.Beliver);
            command.Parameters.AddWithValue("@religion", user.MyReligion==null?1: user.MyReligion.Id);
            command.Parameters.AddWithValue("@desiese", user.Desiese==null?"": user.Desiese);
            command.Parameters.AddWithValue("@married", user.Married);
            command.Parameters.AddWithValue("@id", user.Id);
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM TBLusers";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLusers WHERE id= " + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO TBLusers ([password], username, email, bDay, phoneNum, isManager, gender, child, beliver, religion, desiese, married) " +
                "VALUES (@password, @username, @email, @bDay, @phoneNum, @isManager, @gender, @child, @beliver, @religion, @desiese, @married) ";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int InsertUserProp(User user,Propertise propertise)
        {
            command.CommandText = "INSERT INTO TBLUserProp (UserID, PropID) " +
                $"VALUES ({user.Id}, {propertise.Id}) ";
            return ExecuteCRUD();
        }
        public int DeleteUserProp(User user, Propertise propertise)
        {
            if (user != null)
                command.CommandText = $"DELETE FROM TBLUserProp WHERE (UserID={user.Id} AND PropID={propertise.Id}) ";
            else
                command.CommandText = $"DELETE FROM TBLUserProp WHERE (PropID={propertise.Id}) ";
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE TBLusers SET [password] = @password, username = @username, email = @email, phoneNum = @phoneNum, bDay = @bDay, gender = @gender, child = @child, beliver = @beliver, religion = @religion, desiese = @desiese, married = @married ";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User user)
        {
            command.CommandText = "DELETE FROM TBLusers WHERE (id = @id) ";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE (username = '{user.UserName}') AND ([password] = '{user.Password}')";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
            {
                return list[0];
            }
            return null;
        }

        public User SelectByUsername(string UserName)
        {
            command.CommandText = string.Format($"SELECT * FROM TblUsers "
                + $"WHERE (username = '{UserName}')");
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
        public UserList SelectUsersByProp(Propertise prop)
        {
            command.CommandText = string.Format($"SELECT TBLusers.* FROM (TBLusers INNER JOIN TBLUserProp ON TBLusers.id = TBLUserProp.UserID) WHERE (TBLUserProp.PropID = {prop.Id}) ");
            UserList list = new UserList(base.ExecuteCommand());
            return list;

        }
    }
}
