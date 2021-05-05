using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDal : EfEntityRepositoryBase<Image, CarDbContext>, IImageDal
    {

    }
}