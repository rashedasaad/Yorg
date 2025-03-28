using Microsoft.EntityFrameworkCore;
using yorg.Model;
using yorg.Repository.Interface;

namespace yorg.Repository.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAdmins()
        {
            return await appDbContext.Users.Where(u => u.IsAdmin == true).ToListAsync();
        }

        public async Task<User> GetAdminById(Guid adminId)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == adminId && e.IsAdmin == true);
        }

        public async Task<User> GetAdminByEmail(string email)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Email == email && e.IsAdmin == true);
        }

        public async Task<User> GetAdminByGoogleId(string googleId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.GoogleId == googleId && u.IsAdmin == true);
        }

        public async Task<User> GetAdminByAppleId(string appleId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.AppleId == appleId && u.IsAdmin == true);
        }

        public async Task<User> AddAdmin(Guid id)
        {
            var result = await appDbContext.Users
                  .FirstOrDefaultAsync(e => e.Id == id );
                result.IsAdmin = true;
            await appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<User> RemoveAdmin(Guid id)
        {
            var result = await appDbContext.Users
                  .FirstOrDefaultAsync(e => e.Id == id);
         
            await appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<User> UpdateAdmin(DTOs.User admin)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == admin.Id && e.IsAdmin == true);
     
                result.Name = admin.Name ?? result.Name;
 
                result.Role = admin.Role ?? result.Role;

                result.IsEmailVerified = admin.IsEmailVerified;
                result.IsAdmin = admin.IsAdmin;
         
                await appDbContext.SaveChangesAsync();
                return result;
            
        
        }

        public async Task DeleteAdmin(User user)
        {
       
                appDbContext.Users.Remove(user);
                await appDbContext.SaveChangesAsync();
            
        
        }



    }
}
