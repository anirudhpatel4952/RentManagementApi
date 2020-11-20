using System;
using System.Collections.Generic;

using rentManagement.Models;

namespace rentManagement.Storage
{
    public interface IStoreTenants
    {
         //changes for webApi
        Tenant Create(Tenant tenantToCreate);

        //below function for console only
        Tenant CreateATenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned);

        //method to delete a tenant

        Tenant Remove(long tenantIdInput);
        
        List<Tenant> GetAll();

        Tenant GetById(long tenantToSearchById);
        
    }
}

    
