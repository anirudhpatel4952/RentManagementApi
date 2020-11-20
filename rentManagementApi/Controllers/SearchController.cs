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
    public class SearchController : ControllerBase
    {
        //private data member
        private RentManagementSystem _rentManagementSystem; 
        public SearchController (RentManagementSystem rentManagementSystem)
        {
            //constructor
            _rentManagementSystem = rentManagementSystem;
            
        }
        
        //return a searched tenant
        [HttpGet]
        public Tenant SearchATenant(long tenantId){
            var result = _rentManagementSystem.SearchForTenants(tenantId);
            return result;
        }
    }
}
