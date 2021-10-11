using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public   class Sick:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Tc { get; set; }
        public string Phone { get; set; }
        public string Homeland { get; set; }

        public string    FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
