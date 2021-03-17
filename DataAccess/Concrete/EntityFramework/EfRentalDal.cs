using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarInformationContext>,IRentalDal
    {
        public List<RentalsDetailDto> GetRentalsDetails()
        {
            using (CarInformationContext context = new CarInformationContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join user in context.Users
                             on rental.UserId equals user.Id
                             select new RentalsDetailDto { Id = rental.Id, brandName = car.BrandName, userName = user.FirstName + " " + user.LastName, rentDate = rental.RentDate, returnDate = rental.ReturnDate };
                return result.ToList();
            }
        }
    }
}
