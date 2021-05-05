using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User, CarDbContext>, IUserDal
    {
    }
}
