
using System.Data;
using CarRentalAPI.Model.Domain;

namespace CarRentalAPI.Repository
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            //new User()
            //{
            //    FirstName = "Read Only", LastName = "User", email = "readonly@user.com",
            //    Id = Guid.NewGuid(), userName = "readonly@user.com", password = "Readonly@user",
            //    Roles = new List<string>{ "reader" }
            //},
            //new User()
            // {
            //    FirstName = "Read Write", LastName = "User", email = "readwrite@user.com",
            //    Id = Guid.NewGuid(), userName = "readwrite@user.com", password = "Readwrite@user",
            //    Roles = new List<string>{ "reader", "writer" }
            //}
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
           var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

          
                return user;
           
        }
    }
}
