﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstact
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
