using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Message : BaseEntity
    {
        protected User sender;
        protected Chat chat;
        protected string text;
        protected DateTime when;
        [DataMember]
        public User Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        [DataMember]
        public Chat Chat
        {
            get { return chat; }
            set { chat = value; }
        }
        [DataMember]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        [DataMember]
        public DateTime When
        {
            get { return when; }
            set { when = value; }
        }
    }
    [CollectionDataContract]
    public class MessageList : List<Message>
    {
        public MessageList() { }
        public MessageList(IEnumerable<Message> list)
            : base(list) { }
        public MessageList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Message>().ToList()) { }
    }
}
