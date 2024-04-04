using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PropertiseDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Propertise();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Propertise propertise = entity as Propertise;
            propertise.Id = int.Parse(reader["PropID"].ToString());
            propertise.PropName = reader["propName"].ToString();
            CategoryDB categoryDB=new CategoryDB();
            propertise.PropCategory = categoryDB.SelectById(int.Parse(reader["categoryID"].ToString()));
            return propertise;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Propertise propertise = entity as Propertise;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@propName", propertise.PropName);
            command.Parameters.AddWithValue("@categoryID", propertise.PropCategory.Id);
            command.Parameters.AddWithValue("@PropID", propertise.Id);
        }
        public PropertiseList SelectAllPropertise()
        {
            command.CommandText = "SELECT * FROM TBLproprtise ";
            PropertiseList list = new PropertiseList(ExecuteCommand());
            return list;
        }
        public PropertiseList SelectByCategory(Category category)
        {
            command.CommandText = $"SELECT * FROM TBLproprtise WHERE categoryID={category.Id}";
            PropertiseList list = new PropertiseList(ExecuteCommand());
            return list;
        }
        public Propertise SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLproprtise WHERE PropID= " + id;
            PropertiseList list = new PropertiseList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public PropertiseList SelectByUser(User user)
        {
            command.CommandText = "SELECT TBLproprtise.* FROM (TBLproprtise INNER JOIN TBLUserProp ON TBLproprtise.PropID = TBLUserProp.PropID)" +
                $" WHERE (TBLUserProp.UserID = {user.Id})";
            PropertiseList list = new PropertiseList(ExecuteCommand());
            return list;
        }
        public int Insert(Propertise propertise)
        {
            command.CommandText = "INSERT INTO TBLproprtise (propName,categoryID) " +
                "VALUES (@propName,@categoryID) ";
            LoadParameters(propertise);
            return ExecuteCRUD();
        }
        public int Update(Propertise propertise)
        {
            command.CommandText = "UPDATE TBLproprtise " +
                "SET  propName = @propName,categoryID = @categoryID " +
                "WHERE  (PropID = @PropID) ";
            LoadParameters(propertise);
            return ExecuteCRUD();
        }
        public int Delete(Propertise propertise)
        {
            command.CommandText = $"DELETE FROM TBLproprtise WHERE (PropID = {propertise.Id}) ";
            LoadParameters(propertise);
            return ExecuteCRUD();
        }

    }
}
