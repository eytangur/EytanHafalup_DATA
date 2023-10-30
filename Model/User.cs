using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        protected string username;// שם משתמש
        protected string password;//סיסמה
        protected bool gender;//מין
        protected DateTime bDay;//תאריך לידה
        protected int phoneNum;//מספר טלפון
        protected bool isManager;//?האם מנהל
        protected string email;//חחשבון אימייל
        public string userName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password 
        {
            get { return password; }
            set { password = value; }
        }      
        public DateTime BDay
        {
            get { return bDay; }
            set { bDay = value; }
        }       
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }       
        public int PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public bool IsManager
        {
            get { return isManager; }
            set { isManager = value; }
        }
    }
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