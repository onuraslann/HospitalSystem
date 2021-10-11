using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmanService
    {
        IDataResult<List<Departman>> GetAll();
        IResult Add(Departman departman);
    }
}
