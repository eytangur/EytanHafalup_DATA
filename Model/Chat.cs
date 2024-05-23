using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Chat : BaseEntity
    {
        protected User user1; 
        protected User user2;
        protected bool approve1;
        protected bool approve2;
        [DataMember]
        public User User1 
        {
            get { return user1; }
            set { user1 = value; }
        }
        [DataMember]
        public User User2
        {
            get { return user2; }
            set { user2 = value; }
        }
        [DataMember]
        public bool Approve1
        {
            get { return approve1; }
            set { approve1 = value; }
        }
        [DataMember]
        public bool Approve2
        {
            get { return approve2; }
            set { approve2 = value; }
        }
    }
    [CollectionDataContract]
    public class ChatList : List<Chat>
    {
        public ChatList() { }
        public ChatList(IEnumerable<Chat> list)
            : base(list) { }
        public ChatList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Chat>().ToList()) { }
    }
}
