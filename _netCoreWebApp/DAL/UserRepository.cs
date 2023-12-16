using _netCoreWebApp.Context;
using _netCoreWebApp.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _netCoreWebApp.DAL
{
    public class UserRepository : IUserRepository
    {
        private  AppDbContext _context;

        public UserRepository(AppDbContext context) 
        {
            this._context = context;
        }

        public void CreateUser(UsersModel user)
        {
            _context.Add(user);
       
        }

        public async Task<UsersModel> DeleteUser(int id)
        {
             var user = await _context.users
                            .FirstOrDefaultAsync(m => m.Id == id);
            return user;
        }

        public void DeleteUserConfirmed(UsersModel usersModel)
        {

           _context.users.Remove(usersModel);
            
        }

        public async Task<UsersModel> EditUser(int id)
        {
            var usersModel = await _context.users.FindAsync(id);
            return usersModel;
        }

        public void EditUser(int id, UsersModel user)
        {
            _context.Update(user);
        }

        public async Task<UsersModel> FindAsync(int id)
        {
            return await _context.users.FindAsync(id);
        }

        public async Task<UsersModel> FirstOrDefault(int id)
        {
            return await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<UsersModel> GetDetails(int id)
        {

            var usersModel = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            return usersModel;

        }

        public async Task<List<UsersModel>> GetUsers()
        {
           return await _context.users.ToListAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();

        }

        public bool UserModelExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
