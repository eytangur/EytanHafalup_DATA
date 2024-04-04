using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]

    public class Category : BaseEntity 
    {
        protected string categoryName;
        [DataMember]
        public string CategoryName 
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

    }
    [CollectionDataContract]
    public class CategoryList : List<Category>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public CategoryList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public CategoryList(IEnumerable<Category> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public CategoryList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Category>().ToList()) { }
    }
}
