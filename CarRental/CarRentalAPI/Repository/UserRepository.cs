using CarRentalAPI.Database;
using CarRentalAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext carRentalDbContext;

        public UserRepository(CarRentalDbContext carRentalDbContext)
        {
            this.carRentalDbContext = carRentalDbContext;
        }


        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await carRentalDbContext.Users
     .FirstOrDefaultAsync(x => x.Username.ToLower() == username && x.Password.ToLower() == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await carRentalDbContext.User_Roles
                  .Where(x => x.UserId == user.Id)
                  .ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var useRole in userRoles)
                {
                    var role = await carRentalDbContext.Roles.FirstAsync(x => x.Id == useRole.RoleId);

                    if(role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            user.Password = null;
            return user;
        }
    }
}
