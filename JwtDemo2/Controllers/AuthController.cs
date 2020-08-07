using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtDemo2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        // GET
        [HttpGet]
        public string Token()
        {
            var tokenHandler = new JwtSecurityTokenHandler();  
            var key = Encoding.ASCII.GetBytes("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImp0aSI6ImQ0OWUwMWI4LTc5YjUtNDViYi1hNmJjLWM0Yzk1OTMyZjUwZSIsImlhdCI6MTU5NjgxMjgwNSwiZXhwIjoxNTk2ODE2NDA1fQ.2h0qCwDIzXtRN87eA36WlQS9evToqkM863veBCmgMT0");  
            var tokenDescriptor = new SecurityTokenDescriptor  
            {  
                Subject = new ClaimsIdentity(new[]  
                {  
                    new Claim(ClaimTypes.Email, "bob@example.com")  
                }),  
                Expires = DateTime.UtcNow.AddMinutes(600),  
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)  
            };  
  
            var token = tokenHandler.CreateToken(tokenDescriptor);  
  
            return tokenHandler.WriteToken(token);
        }
    }
}