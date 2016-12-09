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
    public class ClubLevelProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<ClubLevel> clubLevelProviderRepository;

        public ClubLevelProvider()
        {
            clubLevelProviderRepository = unitOfWork.Repository<ClubLevel>();
        }

       

        public void Insert(ClubLevel _clubLevel)
        {
            clubLevelProviderRepository.Insert(_clubLevel);
        }

        public void Update(ClubLevel _clubLevel)
        {
            clubLevelProviderRepository.Update(_clubLevel);
        }

        public void Delete(ClubLevel _clubLevel)
        {
            clubLevelProviderRepository.Delete(_clubLevel);
        }

        public async Task<ClubLevel> GetById(int _id)
        {
            return await clubLevelProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<ClubLevel>> GetAll()
        {
            return await clubLevelProviderRepository.GetAll();
        }

        public async Task<IEnumerable<ClubLevel>> FindBy(Expression<Func<ClubLevel, bool>> predicate)
        {
            return await clubLevelProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<ClubLevel>> GetAllBy(Expression<Func<ClubLevel, bool>> filter = null, 
            Func<IQueryable<ClubLevel>, IOrderedQueryable<ClubLevel>> orderBy = null)
        {
            return await clubLevelProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
