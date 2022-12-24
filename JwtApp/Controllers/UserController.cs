using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, {currentUser.GivenName}, you are an {currentUser.Role}.");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, {currentUser.GivenName}, you are an {currentUser.Role}.");
        }

        [HttpGet("AdminisAndSellers")]
        [Authorize(Roles = "Administrator, Seller")]
        public IActionResult AdminisAndSellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi, {currentUser.GivenName}, you are an {currentUser.Role}.");
        }


        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, You are on public endpoint.");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null) return null;

            var userClaims = identity.Claims;
            return new UserModel
            {
                Username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                EmailAddress = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value,
                GivenName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value,
                SureName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Surname)?.Value,
                Role = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value
            };
        }
    }
}
