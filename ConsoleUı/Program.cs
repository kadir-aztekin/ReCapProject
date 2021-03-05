using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            //DtoTest();
            //BrandGetAll();
            //CustomerTest();
            //RentalTest();
            //UserTest();
            //R/*entalAdded();*/
            //UserAdded();
            //customerdeleted();


        }

        private static void customerdeleted()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Delete(1);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void RentalAdded()
        {
            RentalManager rental = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental() { CustomerId = 1, CarId = 8, RentDate = new DateTime(2020, 02, 01), ReturnDate = null };
            var result = rental.Add(rental1);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User();
            user.FirstName = "kadir";
            user.LastName = "FAFA";
            user.Email = "kfafkakfafafafa@gmail.com";

            

            userManager.Add(user);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();

            {
                if (result.Success)
                {
                    foreach (var user in result.Data)
                    {
                        Console.WriteLine("Mail:   " + user.Email + "  /  " + "FırstName : " + user.FirstName + "  /  " + " LastName : " + user.LastName + "   /  " );
                    }
                }
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var x in result.Data)
                {
                    Console.WriteLine("Car ıd: " + x.CarId + "    " + "CustomerId:" + x.CustomerId + "    " + "RentDate:" + x.RentDate + "    " + "ReturnDate" + x.ReturnDate);
                }
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var x in result.Data)
                {
                    Console.WriteLine(x.UserId);
                }
            }
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
