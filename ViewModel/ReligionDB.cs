using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ReligionDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Religion religen = entity as Religion;
            religen.ReligionName = reader["religionName"].ToString();
            religen.Id = int.Parse(reader["religionID"].ToString());
            return religen;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Religion religen = entity as Religion;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@religionName", religen.ReligionName);
            command.Parameters.AddWithValue("@religenID", religen.Id);
        }
        protected override BaseEntity NewEntity()
        {
            return new Religion();
        }
        public ReligionList SelectAllReligions()
        {
            command.CommandText = "SELECT * FROM TBLreligions ";
            ReligionList list = new ReligionList(ExecuteCommand());
            return list;
        }
        public Religion SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLreligions WHERE religionID= " + id;
            ReligionList list = new ReligionList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Religion religen)
        {
            command.CommandText = "INSERT INTO TBLreligions (religionName) VALUES (@religionName) ";
            LoadParameters(religen);
            return ExecuteCRUD();
        }
        public int Update(Religion religen)
        {
            command.CommandText = "UPDATE TBLreligions " +
                "SET  religionName = @religionName " +
                "WHERE  (religenID = @religenID)";
            LoadParameters(religen);
            return ExecuteCRUD();
        }
        public int Delete(Religion religen)
        {
            command.CommandText = "DELETE FROM TBLreligions WHERE (TBLreligions.religenID = @religenID) ";
            LoadParameters(religen);
            return ExecuteCRUD();
        }

    }
}
