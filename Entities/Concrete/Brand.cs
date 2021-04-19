using System;
using Core.Entitites;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity

    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
