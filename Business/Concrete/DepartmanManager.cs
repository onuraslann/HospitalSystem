using Business.Abstract;
using Business.BusinessAspects;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
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
        [CacheRemoveAspect("IDepartmanService.Get")]
        [PerformanceAspect(interval:1)]
        public IResult Add(Departman departman)
        {
            _departmanDal.Add(departman);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(interval: 1)]
        public IDataResult<List<Departman>> GetAll()
        {
            return new SuccessDataResult<List<Departman>>(_departmanDal.GetAll());
        }
    }
}
