using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }
        }
    }
}
