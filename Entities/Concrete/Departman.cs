﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Departman:IEntity
    {
        public int Id { get; set; }
        public string DepartmanName { get; set; }
    }
}
