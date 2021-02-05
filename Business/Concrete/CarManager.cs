using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    //Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.
    //Araba ismi minimum 2 karakter olmalıdır
    //Araba günlük fiyatı 0'dan büyük olmalıdır.



    {
        DataAccess.Concrete.InMemory.ICarDal _CarDal;
        private EfCarDal efCarDal;

        public CarManager(DataAccess.Concrete.InMemory.ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public CarManager(EfCarDal efCarDal)
        {
            this.efCarDal = efCarDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >=2 )
            {
                _CarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Yanlıs Bilgi Girdiniz");
            }
            
        }

        public void Delete(Car car)
        {
            _CarDal.Delete = car;
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

       

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _CarDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _CarDal.Update = car;
        }

        

        List<Car> ICarService.GetCarsByBrandId(int BrandId)
        {
            return _CarDal.GetAll();
        }
    }
}
