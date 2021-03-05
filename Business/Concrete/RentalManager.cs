using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
        
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId ==rental.CarId  && x.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ResultAdded);

        }

        
        
            

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ResultDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCarId(int carid)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarId == carid));
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
             return new SuccessResult(Messages.ResultUptaded);
        }
    }
}
