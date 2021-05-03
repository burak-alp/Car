﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
   public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage image);
        IResult Delete(CarImage image);
        IResult Update(IFormFile file, CarImage image);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}
