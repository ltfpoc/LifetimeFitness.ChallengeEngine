using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class UserChallengeEnrollmentProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<UserChallengeEnrollment> userChallengeEnrollmentProviderRepository;

        public UserChallengeEnrollmentProvider()
        {
            userChallengeEnrollmentProviderRepository = unitOfWork.Repository<UserChallengeEnrollment>();
        }
        public void Insert(UserChallengeEnrollment _userChallengeEnrollment)
        {
            userChallengeEnrollmentProviderRepository.Insert(_userChallengeEnrollment);
        }

        public void Update(UserChallengeEnrollment _userChallengeEnrollment)
        {
            userChallengeEnrollmentProviderRepository.Update(_userChallengeEnrollment);
        }

        public void Delete(UserChallengeEnrollment _userChallengeEnrollment)
        {
            userChallengeEnrollmentProviderRepository.Delete(_userChallengeEnrollment);
        }


        public async Task<IEnumerable<UserChallengeEnrollment>> GetAll()
        {
            return await userChallengeEnrollmentProviderRepository.GetAll();
        }
        public async Task<UserChallengeEnrollment> GetById(int _id)
        {
            return await userChallengeEnrollmentProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<UserChallengeEnrollment>> FindBy(Expression<Func<UserChallengeEnrollment, bool>> predicate)
        {
            return await userChallengeEnrollmentProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<UserChallengeEnrollment>> GetAllBy(Expression<Func<UserChallengeEnrollment, bool>> filter = null,
            Func<IQueryable<UserChallengeEnrollment>, IOrderedQueryable<UserChallengeEnrollment>> orderBy = null)
        {
            return await userChallengeEnrollmentProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
