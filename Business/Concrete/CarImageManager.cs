using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileUpload;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            //if (result.Count > 0)
            //{
            //    return new SuccessDataResult<List<CarImage>>(result);
            //}

            //List<CarImage> images = new List<CarImage>();
            //images.Add(new CarImage() { CarId = 0, ImageId = 0, CreateDate = DateTime.Now, ImagePath = "/images/car-rent.png" });

            return new SuccessDataResult<List<CarImage>>(result);


        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.ImageId == id));
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckCarIMageAmount(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult(Messages.ImagesCantAdded);
            }
            var pathResult = FileHelper.Add(formFile);
            carImage.ImagePath = pathResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult("Eklendi");
            
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Silindi");

        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            var result1 = FileHelper.Update(formFile, result.ImagePath);
            carImage.ImagePath = result1.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarIMageAmount(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId);

            if (result.Count > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();

        }
    }
}
