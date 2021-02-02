using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDall
    {
        //İNTERFACE KULLANARAK YAPILACAK İŞLEMLERİ TANIMLADIK
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<Car> GetAllCarId(int CarId );


    }
}
