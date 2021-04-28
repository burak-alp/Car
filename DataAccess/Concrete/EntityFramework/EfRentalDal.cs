using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join cus in context.Customers
                             on re.CustomerId equals cus.CustomerId
                             join us in context.Users
                             on cus.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId, 
                                 CustomerName = cus.CompanyName,
                                 CarId = ca.CarId,
                                 RentDate = re.RentalDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName
                             };

                return result.ToList();
            }
        }
    }
}
        
    

