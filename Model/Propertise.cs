using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]

    public class Propertise : BaseEntity
    {
        protected string propName;
        protected Category propCategory;

        [DataMember]
        public string PropName
        {
            get { return propName; }
            set { propName = value; }
        }
        [DataMember]
        public Category PropCategory
        {
            get { return propCategory; }
            set { propCategory = value; }
        }
    }
    [CollectionDataContract]
    public class PropertiseList : List<Propertise>
    {
        public PropertiseList() { }
        public PropertiseList(IEnumerable<Propertise> list)
            : base(list) { }
        public PropertiseList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Propertise>().ToList()) { }
    }
}
