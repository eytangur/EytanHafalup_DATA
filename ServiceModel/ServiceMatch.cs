using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class ServiceMatch : IServiceMatch
    {
        #region User

        public int DeletetUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Delete(user);
        }
        public int InsertUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Insert(user);
        }
        public int UpdateUser(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Update(user); 
        }
        public UserList GetAllUsers()
        {
            UserDB userDB = new UserDB();
            UserList list = userDB.SelectAll();
            return list;
        }
        public User Login(User user)
        {
            UserDB userDB = new UserDB();
            return userDB.Login(user);
        }

        public bool IsUsernameFree(string username)
        {
            UserDB userDB = new UserDB();
            return userDB.SelectByUsername(username)==null;
        }
        public int InsertUserPropertise(User user, Propertise propertise) {
            UserDB userDB = new UserDB();
            return userDB.InsertUserProp(user,propertise);
        }
        public int DeleteUserPropertise(User user, Propertise propertise)
        {
            UserDB userDB = new UserDB();
            return userDB.DeleteUserProp(user, propertise);
        }
        public UserList FindMatch(User user)
        {
            UserList users = new UserList();
            UserDB userDB = new UserDB();
            foreach (Propertise prop in user.Propertises)
            {
                users.AddRange(userDB.SelectUsersByProp(prop));
            }
            return users;
        }

        #endregion

        #region Religion

        public int DeletetReligion(Religion religen)
        {
            ReligionDB religenDB = new ReligionDB();
            return religenDB.Delete(religen);
        }
        public int InsertReligion(Religion religen)
        {
            ReligionDB religenDB = new ReligionDB();
            return religenDB.Insert(religen);
        }
        public int UpdateReligion(Religion religen)
        {
            ReligionDB religenDB = new ReligionDB();
            return religenDB.Update(religen);
        }
        public ReligionList SelectAllReligions()
        {
            ReligionDB religenDB = new ReligionDB();
            ReligionList list = religenDB.SelectAllReligions();
            return list;
        }

        #endregion

        #region Propertise

        public int DeletetPropertise(Propertise propertise)
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            //delete all user-prop
            UserDB userDB = new UserDB();
            userDB.DeleteUserProp(null, propertise);
            return propertiseDB.Delete(propertise);
        }
        public int InsertPropertise(Propertise propertise)
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            return propertiseDB.Insert(propertise);
        }
        public int UpdatePropertise(Propertise propertise)
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            return propertiseDB.Update(propertise);
        }
        public PropertiseList SelectAllPropertise()
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            PropertiseList list = propertiseDB.SelectAllPropertise();
            return list;
        }
        public PropertiseList SelectPropertisesByCategory(Category category)
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            PropertiseList list = propertiseDB.SelectByCategory(category);
            return list;
        }
        public PropertiseList SelectPropertisesByUser(User user)
        {
            PropertiseDB propertiseDB = new PropertiseDB();
            PropertiseList list = propertiseDB.SelectByUser(user);
            return list;
        }
        #endregion

        #region Category

        public int DeletetCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();

            PropertiseList list = SelectPropertisesByCategory(category);
            foreach (Propertise propertise in list)
            {
                DeletetPropertise(propertise);
            }
            return categoryDB.Delete(category);
        }
        public int InsertCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.Insert(category);
        }
        public int UpdateCategory(Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            return categoryDB.Update(category);
        }
        public CategoryList SelectAllCategories()
        {
            CategoryDB religenDB = new CategoryDB();
            CategoryList list = religenDB.SelectAllCategories();
            return list;
        }

        #endregion


        #region Chats
       public  int NewChat(Chat chat){
            ChatDB chatDB = new ChatDB();
            return chatDB.Insert(chat);
        }
       public  int UpdateChat(Chat chat)
        {
            ChatDB chatDB = new ChatDB();
            return chatDB.Update(chat);
        }
       public  int DeletetChat(Chat chat)
        {
            ChatDB chatDB = new ChatDB();
            return chatDB.Delete(chat);
        }
       public  ChatList SelectAllChats(){
            ChatDB chatDB = new ChatDB();
            return chatDB.SelectAll();
        }
       public ChatList SelectChatsByUser(User user){
            ChatDB chatDB = new ChatDB();
            return chatDB.SelectChatByUser(user);
        }

        #endregion
        #region Messages
       public  int InsertMessage(Model.Message message)
        {
            MessageDB messageDB = new MessageDB();
            return messageDB.Insert(message);
        }
       public  int UpdateMessage(Model.Message message){
            MessageDB messageDB = new MessageDB();
            return messageDB.Insert(message);
        }
       public  int DeletetMessage(Model.Message message){
            MessageDB messageDB = new MessageDB();
            return messageDB.Insert(message);
        }
       public  MessageList SelectAllMessages(){
            MessageDB messageDB = new MessageDB();
            return messageDB.SelectAll();
        }
       public MessageList SelectMessagesByChat(Chat chat) {
            MessageDB messageDB = new MessageDB();
            return messageDB.SelectByChat(chat);
        }
        #endregion
    }
}
