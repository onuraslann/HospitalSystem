using Business.Abstract;
using Business.BusinessAspects;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        IDepartmanDal _departmanDal;

        public DepartmanManager(IDepartmanDal departmanDal)
        {
            _departmanDal = departmanDal;
        }
        [SecuredOperation("admin,editor")]
        public IResult Add(Departman departman)
        {
            _departmanDal.Add(departman);
            return new SuccessResult();
        }

        public IDataResult<List<Departman>> GetAll()
        {
            return new SuccessDataResult<List<Departman>>(_departmanDal.GetAll());
        }
    }
}
