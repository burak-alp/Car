using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstact
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetById(Car car);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);


    }
}
