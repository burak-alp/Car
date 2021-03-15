using DataAccess.Abstact;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

     {  
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {new Car {CarId=1,BrandlId=2,ModelYear=2019,ColorId=3,DailyPrice=1509,Description="Hatasız"},
            new Car {CarId=2,BrandlId=2,ModelYear=2018,ColorId=2,DailyPrice=17800,Description="Kazalı" },
            new Car {CarId=3,BrandlId=1,ModelYear=2020,ColorId=9,DailyPrice=16000,Description="Hatasız" },
            new Car {CarId=4,BrandlId=4,ModelYear=2021,ColorId=7,DailyPrice=15000,Description="Temiz" },
            new Car {CarId=5,BrandlId=6,ModelYear=2010,ColorId=1,DailyPrice=1150,Description="Doktordan"}


            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(Car car)
        {
            return _cars;

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandlId = car.BrandlId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;



        }
    }
}
