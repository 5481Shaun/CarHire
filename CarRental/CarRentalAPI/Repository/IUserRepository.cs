using CarRentalAPI.Model.Domain;

namespace CarRentalAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
