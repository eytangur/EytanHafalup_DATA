using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceMatch
    {
        #region User
        [OperationContract] UserList GetAllUsers();
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeletetUser(User user);
        [OperationContract] User Login(User user);
        [OperationContract] bool IsUsernameFree(string username);

        [OperationContract] int InsertUserPropertise(User user, Propertise propertise);
        [OperationContract] int DeleteUserPropertise(User user, Propertise propertise);
        [OperationContract] void ClearUserPropertise(User user);

        [OperationContract] UserList FindMatch(User user);

        #endregion

        #region Religion
        [OperationContract] int InsertReligion(Religion religen);
        [OperationContract] int UpdateReligion(Religion religen);
        [OperationContract] int DeletetReligion(Religion religen);
        [OperationContract] ReligionList SelectAllReligions();
        #endregion

        #region Propertise
        [OperationContract] int InsertPropertise(Propertise propertise);
        [OperationContract] int UpdatePropertise(Propertise propertise);
        [OperationContract] int DeletetPropertise(Propertise propertise);
        [OperationContract] PropertiseList SelectAllPropertise();
        [OperationContract] PropertiseList SelectPropertisesByCategory(Category category);
        [OperationContract] PropertiseList SelectPropertisesByUser(User user);
        #endregion

        #region Category
        [OperationContract] int InsertCategory(Category category);
        [OperationContract] int UpdateCategory(Category category);
        [OperationContract] int DeletetCategory(Category category);
        [OperationContract] CategoryList SelectAllCategories();
        #endregion

        #region Chats
        [OperationContract] int NewChat(Chat chat);
        [OperationContract] int UpdateChat(Chat chat);
        [OperationContract] int DeletetChat(Chat chat);
        [OperationContract] ChatList SelectAllChats();
        [OperationContract] ChatList SelectChatsByUser(User user);
        [OperationContract] ChatList SelectChatByUserToApprove(User user);

        #endregion
        #region Messages
        [OperationContract] int InsertMessage(Message message);
        [OperationContract] int UpdateMessage(Message message);
        [OperationContract] int DeletetMessage(Message message);
        [OperationContract] MessageList SelectAllMessages();
        [OperationContract] MessageList SelectMessagesByChat(Chat chat);
        #endregion

    }
}
