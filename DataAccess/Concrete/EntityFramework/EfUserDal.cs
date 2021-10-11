using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityRepositoryBase<User, HospitalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (HospitalContext context = new HospitalContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join useroperationClaims in context.UserOperationClaims
on operationClaims.Id equals useroperationClaims.OperationClaimId
                             join users in context.Users
on useroperationClaims.UserId equals users.Id
                             select new OperationClaim
                             {
                                 Id = operationClaims.Id,
                                 Name = operationClaims.Name
                             };
                return result.ToList();
            }
        }
    }
}
