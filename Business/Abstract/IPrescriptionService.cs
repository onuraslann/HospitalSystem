using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IPrescriptionService
    {
        IDataResult<List<Prescription>> GetAll();
        IResult Add(Prescription prescription);
        IResult Delete(Prescription prescription);
    }
}
