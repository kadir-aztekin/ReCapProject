using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            //DtoTest();
            //BrandGetAll();
            


        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var x in result.Data)
                {
                    Console.WriteLine(x.DailyPrice + " / " + x.Description);
                }
            }
        }

        private static void BrandGetAll()
        { 

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName+"/ "+brand.BrandId);
                }
            }
       }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { ColorName = "Yeşlil", ColorId = 3 };
            colorManager.Add(color);
        }
    }
}
