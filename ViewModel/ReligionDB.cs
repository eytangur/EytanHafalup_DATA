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
            return religen;
        }
        protected override BaseEntity NewEntity()
        {
            return new Religion();
        }
        public ReligionList SelectAll()
        {
            command.CommandText = "SELECT * FROM TBLreligions";
            ReligionList list = new ReligionList(ExecuteCommand());
            return list;
        }
        public Religion SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLreligions WHERE religionID=" + id;
            ReligionList list = new ReligionList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}
