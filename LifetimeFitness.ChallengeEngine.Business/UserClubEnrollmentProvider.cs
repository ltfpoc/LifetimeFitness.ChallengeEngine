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
    public class UserClubEnrollmentProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<UserClubEnrollment> userClubEnrollmentProviderRepository;

        public UserClubEnrollmentProvider()
        {
            userClubEnrollmentProviderRepository = unitOfWork.Repository<UserClubEnrollment>();
        }

        public void Insert(UserClubEnrollment _userClubEnrollment)
        {
            userClubEnrollmentProviderRepository.Insert(_userClubEnrollment);
        }

        public void Update(UserClubEnrollment _userClubEnrollment)
        {
            userClubEnrollmentProviderRepository.Update(_userClubEnrollment);
        }

        public void Delete(UserClubEnrollment _userClubEnrollment)
        {
            userClubEnrollmentProviderRepository.Delete(_userClubEnrollment);
        }


        public async Task<IEnumerable<UserClubEnrollment>> GetAll()
        {
            return await userClubEnrollmentProviderRepository.GetAll();
        }

        public async Task<UserClubEnrollment> GetById(int _id)
        {
            return await userClubEnrollmentProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<UserClubEnrollment>> FindBy(Expression<Func<UserClubEnrollment, bool>> predicate)
        {
            return await userClubEnrollmentProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<UserClubEnrollment>> GetAllBy(Expression<Func<UserClubEnrollment, bool>> filter = null,
            Func<IQueryable<UserClubEnrollment>, IOrderedQueryable<UserClubEnrollment>> orderBy = null)
        {
            return await userClubEnrollmentProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
