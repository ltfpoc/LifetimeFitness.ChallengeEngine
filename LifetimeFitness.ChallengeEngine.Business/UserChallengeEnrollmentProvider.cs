using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.Core.Domin;
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

        public int Insert(Enrollment _enrollment)
        {
            ChallengeClubRelationProvider _ChallengeClubRelationProvider = new ChallengeClubRelationProvider();
            var entity = _ChallengeClubRelationProvider.GetChallengeClubRelationshipSync(_enrollment.ClubId, _enrollment.ChallengeId);
            _enrollment.ChallengeClubRelationId = entity.ChallengeClubRelationId;
            UserChallengeEnrollment _userClubEnrollment = new UserChallengeEnrollment();
            _userClubEnrollment.UserId = _enrollment.UserId;
            _userClubEnrollment.ChallengeId = _enrollment.ChallengeId;
            _userClubEnrollment.ChallengeClubRelationId = _enrollment.ChallengeClubRelationId;
            return Insert(_userClubEnrollment);
        }


        public int Insert(UserChallengeEnrollment _userChallengeEnrollment)
        {
            return userChallengeEnrollmentProviderRepository.Insert(_userChallengeEnrollment);
        }

        public int Update(UserChallengeEnrollment _userChallengeEnrollment)
        {
            return userChallengeEnrollmentProviderRepository.Update(_userChallengeEnrollment);
        }

        public int Delete(UserChallengeEnrollment _userChallengeEnrollment)
        {
            return userChallengeEnrollmentProviderRepository.Delete(_userChallengeEnrollment);
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
            Func<IEnumerable<UserChallengeEnrollment>, IOrderedEnumerable<UserChallengeEnrollment>> orderBy = null)
        {
            return await userChallengeEnrollmentProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
