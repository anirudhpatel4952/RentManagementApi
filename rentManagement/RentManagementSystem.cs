using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using rentManagement.Storage;
using rentManagement.Models;

namespace rentManagement
{
    public class RentManagementSystem
    {
        //--------------CONSTRUCTOR-------------------//
        public RentManagementSystem(
            IStoreRentals rentalStorageArg, 
            IStoreTenants tenantsStorageArg, 
            IStoreAssignmentList assignStorageArg)
    
        {
            _tenantStorageList = tenantsStorageArg;           //<= on doing the dependency injection
            //list of units of apartment
            _rentalStorageList = rentalStorageArg;
            //list of assignments
            _assignStorageList = assignStorageArg;
            //creating the tenant(TENANTS OBJECTS)
            Tenant tenant1 = 
            new Tenant(400, "Jay", "Bhai", "01-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant2 = 
            new Tenant(401, "Jayshree", "Ben", "02-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant3 = 
            new Tenant(402, "Jayesh", "Kumar", "03-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);

            Tenant tenant4 = 
            new Tenant(403, "Jaya", "Kumari", "04-4100 Rae Street", "S4S3A0", "Regina", "Driver's License", 900, false);
            
            
            //creating the rental apartment objects
            Rental unit1 = new Rental(4100, 01, 2, 900, false);
            Rental unit2 = new Rental(4100, 02, 2, 900, false);
            Rental unit3 = new Rental(4100, 03, 2, 900, false);
            Rental unit4 = new Rental(4100, 04, 2, 900, false);


            //adding the tenants in the tenant list
            
            _tenantStorageList.Create(tenant1);
            _tenantStorageList.Create(tenant2);
            _tenantStorageList.Create(tenant3);
            _tenantStorageList.Create(tenant4);



            //adding the apartments in the apartment lists
            
            _rentalStorageList.Create(unit1);
            _rentalStorageList.Create(unit2);
            _rentalStorageList.Create(unit3);
            _rentalStorageList.Create(unit4);
        }
        //---------END OF CONTRUCTOR---------------//

        //---------DATA MEMBERS---------//
        private IStoreTenants _tenantStorageList;
        private IStoreRentals _rentalStorageList;
        
        private IStoreAssignmentList _assignStorageList; 

        //----------METHODS-------------//
        //method to add a tenant 
        
        //changes for webapi
        public Tenant AddTenant(Tenant tenant){
            _tenantStorageList.Create(tenant);
            return tenant;
        }
        //below function for console only
        // public Tenant AddATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
        //     return _tenantStorageList.CreateATenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned); 
        // }
        //added for webApi
        public Assignment CreateAssignment(long tenantId, int unitNum){
            var tenant = _tenantStorageList.GetById(tenantId);
            tenant.Assign();

            var unit = _rentalStorageList.GetByUnitNum(unitNum);
            unit.Assign();
            
            var assignment = new Assignment(unit, tenant);
            _assignStorageList.Create(assignment);
            assignment.IsAssigned = true;
            return assignment;
            
        }
        public void Unassignment(long tenantId, int unitNum){
            var tenant = _tenantStorageList.GetById(tenantId);
            tenant.UnAssign();

            var unit = _rentalStorageList.GetByUnitNum(unitNum);
            unit.UnAssign();
            
            var assignment = _assignStorageList.GetByTenantIdAndUnit(tenantId, unitNum);
            assignment.IsAssigned = false;
            
        }
        
        //method to delete a tenant

        public Tenant DeleteATenant(long tenantIdInput){
            return _tenantStorageList.Remove(tenantIdInput); 
        }
        
        //method to print all the tenants
        
        public List<Tenant> PrintAllTenants(){
            return _tenantStorageList.GetAll();
        }

        //method to print all the units in the apartment
        public List<Rental> PrintAllUnitsInApartn(){
            return _rentalStorageList.GetAll();
        }
        //method to print all assignments
        public List<Assignment> PrintAllAssignments(){
            return _assignStorageList.GetAll();
        }
        
        //method to check if the unit is assigned to tenant
        // public Assignment UnitAssigner(long tenantIdInput, int unitNumInput)
        // {
        //     var tenant = _tenantStorageList.GetById(tenantIdInput);
        //     var unit = _rentalStorageList.GetByUnitNum(unitNumInput);
        //     var newAssignment = new Assignment() {
        //         Tenant = tenant,
        //         Rental = unit,
        //         ContractDate = DateTime.Now,
        //         IsAssigned = false,
        //         AssignId = Guid.NewGuid()
        //     };
        //     if (tenant.IsAssigned == false && unit.IsAssigned == false){
        //         var tenantAssigned = tenant.IsAssigned = true;
        //         var unitAssigned = unit.IsAssigned = true;
        //         var assignmentComplete = newAssignment.IsAssigned = true;
        //     }
        //     _assignStorageList.Create(newAssignment);
        //     return newAssignment;

        // }
        
        //search functionality to search for a tenant
        public Tenant SearchForTenants(long tenantToSearchById){
           return _tenantStorageList.GetById(tenantToSearchById);
        }

        //search functionality to search for a unit
        public Rental SearchForUnits(int unitToSearchByUnitNum) {
            return _rentalStorageList.GetByUnitNum(unitToSearchByUnitNum);
        }

    }
}