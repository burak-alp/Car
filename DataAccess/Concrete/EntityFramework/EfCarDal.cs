using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using CarDbContext context = new CarDbContext();
            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         join co in context.Colors
                         on c.ColorId equals co.ColorId
                         select new CarDetailDto
                         {
                             CarId = c.CarId,
                             BrandName = b.BrandName,
                             ColorName = co.ColorName,

                         };



            return result.ToList();
        }
    }
}
