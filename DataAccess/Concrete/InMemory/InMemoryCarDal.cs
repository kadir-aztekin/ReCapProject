using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //_cars yapmamızıın sebebi classın ıcınde fakat methodun dısında oldugu ıcın boyle tanımlandı  
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                // BRANDID ( 1=RENAULT 2=OPEL 3=FIAT 4=MAZDA 5=Volkswagen) COLORID ( 1=BEYAZ 2=SIYAH 3=KIRMIZI 4=Sarı)
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2000,DailyPrice=70,Description="2000 Reanult Beyaz"},
                new Car{CarId=2,BrandId=2,ColorId=2,ModelYear=2010,DailyPrice=100,Description="2010 Opel Siyah "},
                new Car{CarId=3,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=30,Description="2020 Fiat Kırmızı"},
                new Car{CarId=4,BrandId=4,ColorId=3,ModelYear=2015,DailyPrice=200,Description="2015 Mazda Kırmızı"},
                new Car{CarId=5,BrandId=5,ColorId=4,ModelYear=2018,DailyPrice=500,Description="2018 Volkswagen Sarı"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            //LİNQ İLE DELETE YAPTIK CUNKU FOREACH VEYA IF KULLANILIMI DAHA KOLAY YOLUDUR
            //REFERANS DEGERLERDEN ALINDIGI ICIN 
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(car);
        }

        

        public List<Car> GetAll()
        {
            return _cars;
        }

        //Aslında Bir Fonksıyon tanımladık gibi dusunebilirsiniz
        public List<Car> GetAllCarId(int CarId)
        {
            return _cars.Where(c => c.CarId == c.CarId).ToList();
            
        }

        public void Update(Car car)
        {
            //GUNCELLEME ISLEMINI LİNQ İLE YAPTIK
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }
    }

    public interface ICarDal
    {
        Car Delete { get; set; }
        Car Update { get; set; }

        void Add(Car car);
        List<Car> GetAll(Func<object, object> p);
        List<Car> GetAll();
    }
}
