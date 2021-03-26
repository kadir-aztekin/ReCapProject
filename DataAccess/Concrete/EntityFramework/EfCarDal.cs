using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarInformationContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarInformationContext context = new CarInformationContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto {
                                 BrandName=b.BrandName,
                                 Description=c.Description,
                                 ColorName=co.ColorName,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 CarId=c.CarId};
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsFatih(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarInformationContext context = new CarInformationContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}