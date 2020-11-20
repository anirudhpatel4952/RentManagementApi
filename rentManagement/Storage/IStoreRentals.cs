using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public interface IStoreRentals
    {
        
        void Create(Rental unitToCreate);
        List<Rental> GetAll();

        Rental GetByUnitNum(int unitToSearchByUnitNum);

    }
}