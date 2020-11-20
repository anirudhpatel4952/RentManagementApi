using System;
using System.Collections.Generic;
using rentManagement.Models;

namespace rentManagement.Storage
{
    public class RentalStorageList : IStoreRentals
    {
        private List<Rental> _rentalStorageList;
        public RentalStorageList()
        {
            _rentalStorageList = new List<Rental>();
        }
        public void Create(Rental unitToCreate){
            _rentalStorageList.Add(unitToCreate);
        }
        public List<Rental> GetAll(){
            return _rentalStorageList;
        }

        public Rental GetByUnitNum(int unitToSearchByUnitNum) {
            for (int i = 0; i < _rentalStorageList.Count;i++) {
                var unit = _rentalStorageList[i];
                if (unitToSearchByUnitNum == unit.Unit){
                    return unit;
                }
                
            }
            return null;
        }

    }
}