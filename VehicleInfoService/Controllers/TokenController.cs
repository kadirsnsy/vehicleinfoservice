using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VehicleInfoService.Models;
using static VehicleInfoService.JWTAuthenticationManager;

namespace VehicleInfoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager; 
        public TokenController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Post([FromBody] object _user)
        {
            User user = new User();
            string token = null;
            try
            {
                user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(_user));
                token = jWTAuthenticationManager.Authenticate(user.username, user.password);
                if (token == null)
                    return Unauthorized();
                Logger.Log("Token alındı.");
            }
            catch (Exception ex)
            {
                Logger.Log("Hata: " + ex.ToString());
                return Ok("Hata oluştu");
            }

            return Ok(token);
        }


    }
}
