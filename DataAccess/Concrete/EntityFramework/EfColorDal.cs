using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarDbContext>, IColorDal
    {
       
    }
}
