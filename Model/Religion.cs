using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Religion : BaseEntity 
    {
        protected string religionName;

        public string ReligionName
        {
            get { return religionName; }
            set { religionName = value; }
        }
    }
    public class ReligionList : List<Religion>
    {
        public ReligionList() { }
        public ReligionList(IEnumerable<Religion> list)
            : base(list) { }
        public ReligionList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Religion>().ToList()) { }
    }
}
