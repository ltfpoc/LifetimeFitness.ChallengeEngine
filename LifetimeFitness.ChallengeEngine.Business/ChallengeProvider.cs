using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ChallengeProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Challenge> challengeRepository;

        public ChallengeProvider()
        {
            challengeRepository = unitOfWork.Repository<Challenge>();
        }

        public void Insert(Challenge _Challenge)
        {
            challengeRepository.Insert(_Challenge);
        }

        public void Update(Challenge _Challenge)
        {
            challengeRepository.Update(_Challenge);
        }

        public void Delete(Challenge _Challenge)
        {
            challengeRepository.Delete(_Challenge);
        }

        public async Task<Challenge> GetById(int _id)
        {
            return await challengeRepository.GetById(_id);
        }

        public async Task<IEnumerable<Challenge>> GetAll()
        {
            return await challengeRepository.GetAll();
        }

        public async Task<IEnumerable<Challenge>> FindBy(Expression<Func<Challenge, bool>> predicate)
        {
            return await challengeRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<Challenge>> GetAllBy(Expression<Func<Challenge, bool>> filter = null, Func<IQueryable<Challenge>, IOrderedQueryable<Challenge>> orderBy = null)
        {
            return await challengeRepository.GetAllBy(filter, orderBy);
        }

        public IEnumerable<Challenge> GetChallanges(int _CategoryId, int _ClubId)
        {
            var entity = GetAll().Result.ToList()
                        .Where(a => a.ChallengeClubRelations.Any(b => b.ClubId == _ClubId));
            return entity;

        }
    }
}
