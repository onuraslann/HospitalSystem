using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ISickService
    {
        IDataResult<List<Sick>> GetAll();
        IDataResult<List<Sick>> GetByCity(string city);
        IResult Add(Sick sick);
    }
}
