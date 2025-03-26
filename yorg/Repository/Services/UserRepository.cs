using Microsoft.EntityFrameworkCore;
using yorg.Model;
using yorg.Repository.Interface;

namespace yorg.Repository.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> GetUserByGoogleId(string googleId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.GoogleId == googleId);
        }

        public async Task<User> GetUserByAppleId(string appleId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.AppleId == appleId);
        }

        public async Task<User> AddUser(User user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            if (result != null)
            {
                result.Name = user.Name?? result.Name;
     
                result.Email = user.Email ?? result.Email;
                result.Role = user.Role ?? result.Role;
     

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteUser(Guid userId)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

    }
}
