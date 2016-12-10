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
    public class UserRoleProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<UserRole> userRoleProviderRepository;

        public UserRoleProvider()
        {
            userRoleProviderRepository = unitOfWork.Repository<UserRole>();
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            return await userRoleProviderRepository.GetAll();
        }

        public int Insert(UserRole _userRole)
        {
           return userRoleProviderRepository.Insert(_userRole);
        }

        public int Update(UserRole _userRole)
        {
           return userRoleProviderRepository.Update(_userRole);
        }

        public int Delete(UserRole _userRole)
        {
           return userRoleProviderRepository.Delete(_userRole);
        }

        public async Task<UserRole> GetById(int _id)
        {
            return await userRoleProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<UserRole>> FindBy(Expression<Func<UserRole, bool>> predicate)
        {
            return await userRoleProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<UserRole>> GetAllBy(Expression<Func<UserRole, bool>> filter = null,
            Func<IEnumerable<UserRole>, IOrderedEnumerable<UserRole>> orderBy = null)
        {
            return await userRoleProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
