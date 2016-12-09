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

        public void Insert(UserRole _userRole)
        {
            userRoleProviderRepository.Insert(_userRole);
        }

        public void Update(UserRole _userRole)
        {
            userRoleProviderRepository.Update(_userRole);
        }

        public void Delete(UserRole _userRole)
        {
            userRoleProviderRepository.Delete(_userRole);
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
            Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>> orderBy = null)
        {
            return await userRoleProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
