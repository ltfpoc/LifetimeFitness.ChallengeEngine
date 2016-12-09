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



        public int Insert(ChallengeType _challengeType)
        {
            return  challengeTypeRepository.Insert(_challengeType);
        }

        public int Update(ChallengeType _challengeType)
        {
            return challengeTypeRepository.Update(_challengeType);
        }

        public int Delete(ChallengeType _challengeType)
        {
            return challengeTypeRepository.Delete(_challengeType);
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
