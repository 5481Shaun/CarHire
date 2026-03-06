using CarRentalAPI.Model.DTO;
using CarRentalAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Model.Domain;

namespace CarRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;

        }

        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {

            //Validate the incoming request


            //Check if user is authenticated
            //Check username and password

            var user = await userRepository.AuthenticateAsync(
                loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                //Generate a token
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(new { result = true, token });
            }

            return BadRequest(new { result = false, message = "Invalid UserName or Password!" });
        }

    }
}