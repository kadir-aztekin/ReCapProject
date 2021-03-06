﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Filter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<IEnumerable<Car>> GetByDailyPrice(int v)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==06)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.ColorId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.DailyPrice >= min && a.DailyPrice <= max));
        }

        

        public IResult Update(Car car)
           
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDtoColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(x=>x.ColorId==colorId).ToList());
        }
        public IDataResult<List<CarDetailDto>> GetCarDtoBrandId(int brandId)
        {
           
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(x => x.BrandId == brandId).ToList());
        }

        public IDataResult<CarDetailDto> GetCarById(int carId)
        {
            var result = _carDal.GetCarDetails().Where(x=>x.CarId==carId).SingleOrDefault();
            return new SuccessDataResult<CarDetailDto>(result);
        }
    }
}
