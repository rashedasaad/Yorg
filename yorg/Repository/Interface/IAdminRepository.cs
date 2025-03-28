using yorg.Model;

namespace yorg.Repository.Interface
{
    public interface IAdminRepository
    {

        Task<IEnumerable<User>> GetAdmins();
        Task<User> GetAdminById(Guid AdminId);
        Task<User> GetAdminByEmail(string Email);
        Task<User> GetAdminByGoogleId(string googleId);
        Task<User> GetAdminByAppleId(string appleId);
        Task<User> AddAdmin(Guid id);
        Task<User> RemoveAdmin(Guid id);
        Task<User> UpdateAdmin(DTOs.User user);
        Task DeleteAdmin(User user);

    }
}
