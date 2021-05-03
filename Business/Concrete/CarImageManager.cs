using Business.Abstact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, CarImage image)
        {
            IResult result = Engine.Run(CheckIfImageCountCorrect(image.ImageId), CheckIfImageNull(image.ImageId));
            if (result!=null)
            {
                var ImageResult = FileHelper.Upload(file);
                            _carImageDal.Add(image);
                            return new SuccessResult(Messages.ImageAdded);
            }
            return new ErrorResult(Messages.ImageNotAdded);
        }
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Delete(CarImage image)
        {
            var result = _carImageDal.Get(p => p.ImageId == image.ImageId);
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result= Engine.Run(CheckIfImageNull(id));
            if (result==null)
            {
                return new ErrorDataResult<CarImage>(Messages.ImageNotGet);

            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.ImageId == id), Messages.ImageGet);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
           var result= Engine.Run(CheckIfImageNull(id));
            if (result==null)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.ImageNotGet);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id), Messages.ImageListed);

        }
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Update(IFormFile file, CarImage image)
        {
            var result = _carImageDal.Get(p => p.ImageId == image.ImageId);
            if (result==null)            
            {
                return new ErrorResult("Resim bulunamadı");
            }
            var updateFile = FileHelper.Update(file, result.ImagePath);
            image.ImagePath = updateFile.Message;
            _carImageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckIfImageCountCorrect(int imageId)
        {
            var result = _carImageDal.GetAll(p => p.ImageId == imageId).Count;
            if (result<5)
            {
                return new SuccessResult(Messages.ImageAdded);
            }
            return new ErrorResult(Messages.ImageLimitExceeded);  
        }

        private IDataResult<List<CarImage>> CheckIfImageNull(int imageId)
        {
            string path = @"C:\Users\buuna\source\repos\Car\Image\logo.jpg";
            var result = _carImageDal.GetAll(p => p.ImageId == imageId).Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarImage>>(path);
                
            }
            return new SuccessDataResult<List<CarImage>>("");
        }


    }
}
