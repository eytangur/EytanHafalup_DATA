using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {
        protected string username;// שם משתמש
        protected string password;//סיסמה
        protected bool gender;//מין
        protected DateTime bDay;//תאריך לידה
        protected string phoneNum;//מספר טלפון
        protected bool isManager;//?האם מנהל
        protected string email;//חחשבון אימייל
        protected int child;//כמות ילדים
        protected bool beliver;//האם אתה מאמין באלוהים?
        protected Religion myReligion;//איזה דת?
        protected string desiese;//חולה במחלה?
        protected bool married;//האם נשוי?
        protected PropertiseList propertises;

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password 
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public DateTime BDay
        {
            get { return bDay; }
            set { bDay = value; }
        }
        [DataMember]
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        [DataMember]
        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public bool IsManager
        {
            get { return isManager; }
            set { isManager = value; }
        }
        [DataMember]
        public int Child
        {
            get { return child; }
            set { child = value; }
        }
        [DataMember]
        public Religion MyReligion
        {
            get { return myReligion; }
            set { myReligion = value; }
        }
        [DataMember]
        public bool Beliver
        {
            get { return beliver; }
            set { beliver = value; }
        }
        [DataMember]
        public string Desiese
        {
            get { return desiese; }
            set { desiese = value; }
        }
        [DataMember]
        public bool Married
        {
            get { return married; }
            set { married = value; }
        }
        [DataMember]
        public PropertiseList Propertises
        { get { return propertises; } set { propertises = value; } }
    }
    [CollectionDataContract]
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}