using _netCoreWebApp.Models;

namespace _netCoreWebApp.DAL
{
    interface IUserRepository
    {
        Task<List<UsersModel>> GetUsers();
        void CreateUser(UsersModel user);
        Task<UsersModel> GetDetails(int id);
        Task<UsersModel> EditUser(int id);
        void EditUser(int id , UsersModel user);
        Task<UsersModel> DeleteUser(int id);
        void DeleteUserConfirmed(UsersModel user);

        bool UserModelExists(int id);

        void SaveChanges();
        Task<UsersModel> FindAsync(int id);
        Task<UsersModel> FirstOrDefault(int id);


    }
}
