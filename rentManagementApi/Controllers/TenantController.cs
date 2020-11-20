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
    public class TenantController : ControllerBase
    {
        //private data member
        private RentManagementSystem _rentManagementSystem; 
        public TenantController (RentManagementSystem rentManagementSystem)
        {
            //constructor
            _rentManagementSystem = rentManagementSystem;
            
        }
        
        //return all tenants
        [HttpGet]
        public List<Tenant> GetTenants()
        {
            var result = _rentManagementSystem.PrintAllTenants();
            return result;
        }

        [HttpPost]

        // public Tenant AddATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, int deposit, bool isAssigned){
        //     var result = _rentManagementSystem.AddATenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned);
        //     return result;
        // }
        public Tenant AddTenant(Tenant tenantToCreate){
            _rentManagementSystem.AddTenant(tenantToCreate);
            return tenantToCreate;
        }
    }
}
