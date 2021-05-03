﻿using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class CarImage:IEntity
    {
        public CarImage()
        {
            Date = DateTime.Now;
        }
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public DateTime? Date { get; set; }
        public string ImagePath { get; set; }


    }
}
