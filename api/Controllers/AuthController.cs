using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using api.DAL.dtos;
using api.DAL.Interfaces;
using api.DAL.data;

namespace OnlineValveApplication_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister ufr)
        {
            ufr.username = ufr.username.ToLower();
            if (await _repo.UserExists(ufr.username)) { return BadRequest("User already exists ..."); }
            User test = new User { username = ufr.username };
            var createdUser = await _repo.Register(test, ufr.password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin ufl)
        {
            var userFromRepo = await _repo.Login(ufl.username.ToLower(), ufl.password);
            if (userFromRepo == null) { return BadRequest("Unauthorized"); }
            // generate a token
            var claims = new[] {
        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, userFromRepo.username),
        new Claim(ClaimTypes.Role, userFromRepo.user_role)
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokendescriptor);
            return Ok(new { token = tokenhandler.WriteToken(token) }
            );

        }
    }
}