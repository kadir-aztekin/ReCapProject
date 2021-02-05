using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine($"Lütfen günlük fiyat kısmını 0'dan büyük giriniz. Girdiğiniz değer : {car.DailyPrice}");
            }
        }

        public IEnumerable<Car> GetByDailyPrice(int v)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba başarıyla silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(a => a.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(a => a.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(a => a.DailyPrice >= min && a.DailyPrice <= max);
        }

        

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Güncellendi");
        }
    }
}
