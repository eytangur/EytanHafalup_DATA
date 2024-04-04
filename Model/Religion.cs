using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Religion : BaseEntity 
    {
        protected string religionName;
        [DataMember]
        public string ReligionName
        {
            get { return religionName; }
            set { religionName = value; }
        }

    }
    [CollectionDataContract]
    public class ReligionList : List<Religion>
    {
        public ReligionList() { }
        public ReligionList(IEnumerable<Religion> list)
            : base(list) { }
        public ReligionList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Religion>().ToList()) { }
    }
}
