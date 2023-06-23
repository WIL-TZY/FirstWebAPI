
using FirstWebAPI.Data;
using FirstWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Repository
{
    // Inheriting from interface IUserRepository
    public class UserRepository : IUserRepository
    {
        // Fetching database
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        
        // Functions for CRUD operations/requests (applied to user in UserController.cs)
        public void AddUser(User user)
        {
            //throw new NotImplementedException();
            _context.Add(user);
        }

        public void DeleteUser(User user)
        {
            //throw new NotImplementedException();
            _context.Remove(user);
        }

        public async Task<User> SearchUser(int id)
        {
            //throw new NotImplementedException();

            // Searching users by Id
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> SearchUsers()
        {
            //throw new NotImplementedException();
            return await _context.Users.ToListAsync();
        }

        public void UpdateUser(User user)
        {
            //throw new NotImplementedException();
            _context.Update(user);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0; // .SaveChangesAsync() returns either 0: false or 1: true
        }
    }
}