using yorg.Model;

namespace yorg.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid UserId);
        Task<User> GetUserByEmail(string Email);

        Task<User> GetUserByGoogleId(string googleId);
        Task<User> GetUserByAppleId(string appleId);

        Task<User> AddUser(User user);
        Task<User> UpdateUser(User User);

        Task DeleteUser(Guid UserId);
    }
}
