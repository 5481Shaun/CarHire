using CarRentalAPI.Model.Domain;

namespace CarRentalAPI.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
