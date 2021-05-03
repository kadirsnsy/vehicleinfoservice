using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VehicleInfoService.Data;
using VehicleInfoService.Models;

namespace VehicleInfoService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private AtsDbContext atsDbContext;
        List<Vehicle> vehicleList = new List<Vehicle>();
        public VehiclesController(AtsDbContext atsDbContext)
        {
            this.atsDbContext = atsDbContext;
        }

        // GET: api/<VehiclesController>

        [Produces("application/json")]
        [HttpGet]
        public object Get()
        { 
            try
            {
                vehicleList = atsDbContext.Set<Vehicle>().FromSqlRaw("EXEC Sp_SelectInfoOfVehicles").ToList<Vehicle>();
                Logger.Log(vehicleList.Count + " adet araç bilgisi gönderildi.");
            }
            catch (Exception ex)
            {
                Logger.Log("Hata: " + ex.ToString());
                return "Araç bilgileri gönderilemedi.";
            }
            return vehicleList;

        }
        [Produces("application/json")]
        [HttpGet("{Id}")]
        public object Get(int Id)
        {
            try
            {
                var parameterTop = new SqlParameter
                {
                    ParameterName = "VehicleID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Id,
                };
                vehicleList = atsDbContext.Set<Vehicle>().FromSqlRaw("EXEC Sp_SelectInfoOfVehicles @VehicleID", parameterTop).ToList<Vehicle>();
                Logger.Log(vehicleList.Count + " adet araç bilgisi gönderildi (VehicleId:"+Id+").");
            }
            catch (Exception ex)
            {
                Logger.Log("Hata: " + ex.ToString());
                return "Araç bilgileri gönderilemedi.";
            }
            return JsonSerializer.Serialize(vehicleList); ;
        }




    }
}
