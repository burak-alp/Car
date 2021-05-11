﻿
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }     
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; } 
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        
    }
}
