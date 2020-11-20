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
    
    public class AssignmentController : ControllerBase
    {
        private RentManagementSystem _rentManagementSystem; 
        public AssignmentController (RentManagementSystem rentManagementSystem)
        {
            
           _rentManagementSystem = rentManagementSystem;
           
            //constructor........
        }
        
        //return all tenants
        [HttpGet]
        
        public List<Assignment> GetAssignments(){
            var result = _rentManagementSystem.PrintAllAssignments();
            return result;
        }

        [HttpPost]

        public Assignment Assign(long tenantId, int unitNum){      
            var result = _rentManagementSystem.CreateAssignment(tenantId, unitNum);
            return result;
            
        }

        [HttpPut]

        public void UnAssign(long tenantId, int unitNum){
            _rentManagementSystem.Unassignment(tenantId, unitNum);
        }
    }
}
