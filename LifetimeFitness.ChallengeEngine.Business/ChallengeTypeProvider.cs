using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ChallengeTypeProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<ChallengeType> challengeTypeRepository;

        public ChallengeTypeProvider()
        {
            challengeTypeRepository = unitOfWork.Repository<ChallengeType>();
        }



        public void Insert(ChallengeType _challengeType)
        {
            challengeTypeRepository.Insert(_challengeType);
        }

        public void Update(ChallengeType _challengeType)
        {
            challengeTypeRepository.Update(_challengeType);
        }

        public void Delete(ChallengeType _challengeType)
        {
            challengeTypeRepository.Delete(_challengeType);
        }

        public async Task<ChallengeType> GetById(int _id)
        {
            return await challengeTypeRepository.GetById(_id);
        }

        public async Task<IEnumerable<ChallengeType>> GetAll()
        {
            return await challengeTypeRepository.GetAll();
        }

        public async Task<IEnumerable<ChallengeType>> FindBy(Expression<Func<ChallengeType, bool>> predicate)
        {
            return await challengeTypeRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<ChallengeType>> GetAllBy(Expression<Func<ChallengeType, bool>> filter = null, Func<IQueryable<ChallengeType>, IOrderedQueryable<ChallengeType>> orderBy = null)
        {
            return await challengeTypeRepository.GetAllBy(filter, orderBy);
        }

    }
}
