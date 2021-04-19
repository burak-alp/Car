using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstact
{
   public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDtos();
    }
}
