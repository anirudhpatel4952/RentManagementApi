using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rentManagement;
using rentManagement.Models;
using rentManagement.Storage;
namespace rentManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private RentManagementSystem _rentManagementSystem; 
        public RentalController (RentManagementSystem rentManagementSystem)
        {
            _rentManagementSystem = rentManagementSystem;
            //constructor........
        }
        
        //return all units
        [HttpGet]
        
        public List<Rental> GetRentals(){
            var result = _rentManagementSystem.PrintAllUnitsInApartn();
            return result;
        } 
    }
}
