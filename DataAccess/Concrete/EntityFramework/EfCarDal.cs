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
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             select new CarDetailDto {BrandId=c.BrandId,BrandName=c.BrandName,DailyPrice=p.DailyPrice,Description=p.Description,ModelYear=p.ModelYear};
                return result.ToList();
            }
        }
    }
}