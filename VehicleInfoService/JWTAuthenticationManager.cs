using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static VehicleInfoService.JWTAuthenticationManager;

namespace VehicleInfoService
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        
        private readonly string tokenKey;
        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public string Authenticate(string username, string password)
        {
            if (!(StartParameters.ServiceUserName == username && StartParameters.ServicePassword == password))
            {
                Logger.Log("Kullanıcı bilgileri hatalı");
                return "Kullanıcı bilgileri hatalı";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddYears(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
