using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        IPrescriptionDal _prescriptionDal;

        public PrescriptionManager(IPrescriptionDal prescriptionDal)
        {
            _prescriptionDal = prescriptionDal;
        }

        public IResult Add(Prescription prescription)
        {
            prescription.PrescriptionsDate = DateTime.Now;
            _prescriptionDal.Add(prescription);
            return new SuccessResult(Messages.Prescription);
        }

        public IResult Delete(Prescription prescription)
        {
            _prescriptionDal.Delete(prescription);
            return new SuccessResult();
        }

        public IDataResult<List<Prescription>> GetAll()
        {
            return new SuccessDataResult<List<Prescription>>(_prescriptionDal.GetAll());
        }
    }
}
