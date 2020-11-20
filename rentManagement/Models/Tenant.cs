using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace rentManagement.Models
{
    public class Tenant
    {
        // //Data member
        // private long _TenantId;
        // private string _firstName;
        // private string _lastName;
        // private string _address;
        // private string _postalCode;
        // private string _city;
        // private string _idProof;
        // private double _deposit;
        
        //trying composition
        // private Rental _rental;
        // public Tenant()
        // {
            
        // }
        public Tenant(long tenantId, string firstName, string lastName, string address, string postalCode, string city, string idProof, double deposit, bool isAssigned)
        {
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
            City = city;
            IdProof = idProof;
            Deposit = deposit;
            IsAssigned = false;
        }

        //properties or access func
        public long TenantId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName {get {return FirstName +" "+ LastName;}}
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string IdProof { get; private set; }
        public double Deposit { get; private set; }

        public bool IsAssigned { get; set;}
        
        
        //changes made for webApi
        public void Assign(){
            if(!IsAssigned){
                IsAssigned = true;
            }
            else {
                throw new Exception($"Tenant {TenantId} is already assigned!");
            }
        }
        //changes made for webApi
        public void UnAssign(){
            if(IsAssigned){
                IsAssigned = false;
            }
            else{
                throw new Exception($"Tenant {TenantId} is already unassigned!");
            }
        }
        public override string ToString()
        {
            string details = "----- Tenants -----\n";
            details += $"Tenant Id : {TenantId}\n";
            details += $"Full Name : {FullName.ToString()}\n";
            details += $"Full Address : {Address}, {PostalCode}, {City}\n";
            details += $"Id Proof provided : {IdProof}\n";
            details += $"Deposit Collected : {Deposit}\n";
            details += $"Is the Unit assigned : {IsAssigned}\n"; 
            return details;
        }
    }
}