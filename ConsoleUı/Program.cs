using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            /*(new EfCarDal());*/
            foreach (var y in carManager.GetAllByColorId(2))
            {
                Console.WriteLine(y.Description);
            }
        }
    }
}
