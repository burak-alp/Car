using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var car1 = carManager.Add(new Car { CarId = 5, BrandId = 3, ColorId = 2, DailyPrice = 200000, RentDate = DateTime.Now, ModelYear = 2020, UserId = 2 });
            Console.WriteLine(car1.Message);
           
            foreach (var Car in carManager.GetAll().Data)
            {
                Console.WriteLine(Car.CarId+"/"+Car.BrandId+"/"+Car.ColorId+"/"+Car.DailyPrice+"/"+Car.ModelYear+"/"+Car.RentDate+"/"+Car.UserId);

            }
            Console.WriteLine("--------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var result in brandManager.GetAll().Data)
            {
                Console.WriteLine(result.BrandName+"/"+result.BrandId);
            }
            
            foreach (var car2 in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(car2.CarId+"/"+car2.BrandId+"/"+car2.BrandName+"/"+car2.ColorName+"/"+car2.DailyPrice);
            }
        }
    }
}
