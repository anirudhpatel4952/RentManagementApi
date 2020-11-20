using System;
using System.Collections.Generic;
using System.Linq;

using rentManagement.Models;

namespace rentManagement.Storage
{
    public class TenantStorageList : IStoreTenants
    {
        private List<Tenant> _tenantStorageList;
        public TenantStorageList()
        {
            _tenantStorageList = new List<Tenant>();
        }
        //changes for webApi
        public Tenant Create(Tenant tenantToCreate) {
            _tenantStorageList.Add(tenantToCreate);
            return tenantToCreate;
            
        }
        public Tenant CreateATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned){
            if (_tenantStorageList.Count <= 8){
            var tenant = new Tenant(tenantId, firstName, lastName, address, postalCode, city, idProof, deposit, isAssigned);
            _tenantStorageList.Add(tenant);
            return tenant;
            }
           else{
                throw new Exception("Maximum only 8 units equal to 8 Tenants. Limit reached");
            }
            
        }

        //method to delete a tenant

        public Tenant Remove(long tenantIdInput){
             
            for (int i = 0; i < _tenantStorageList.Count; i++) {
                var tenant = _tenantStorageList[i];
                if (tenantIdInput == tenant.TenantId)
                {
                    var delTenant = _tenantStorageList;
                    delTenant.RemoveAt(i);
                    return tenant;
                    
                }
               
            }
            return null;   
        }
        
        public List<Tenant> GetAll(){
            return _tenantStorageList;
        }

        public Tenant GetById(long tenantToSearchById){
            for (int i = 0; i < _tenantStorageList.Count; i++) {
                var tenant = _tenantStorageList[i];
                if (tenantToSearchById == tenant.TenantId)
                {
                    return tenant;
                }
                
            }
            return null;
        }
    }
}