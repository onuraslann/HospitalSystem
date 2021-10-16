using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IDoctorService
    {
        IResult Add(Doctor doctor);
        IDataResult<List<Doctor>> GetAll();
        IResult Update(Doctor doctor);
        IResult CheckIfTransaction(Doctor doctor);
    }
}
