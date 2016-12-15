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

        public int Insert(Challenge _Challenge)
        {
           return  challengeRepository.Insert(_Challenge);
        }

        public int Update(Challenge _Challenge)
        {
            return challengeRepository.Update(_Challenge);
        }

        public int Delete(Challenge _Challenge)
        {
            return challengeRepository.Delete(_Challenge);
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

        public async Task<IEnumerable<Challenge>> GetAllBy(Expression<Func<Challenge, bool>> filter = null, Func<IEnumerable<Challenge>, IOrderedEnumerable<Challenge>> orderBy = null)
        {
            return await challengeRepository.GetAllBy(filter, orderBy);
        }

        public async Task<IEnumerable<Challenge>> GetChallanges(int _CategoryId, int _ClubId)
        {
            var entity = await GetAll();
            entity = entity.Where(c => c.ChallengeTypeId == _CategoryId).ToList();
            entity = from a in entity.Where(c => c.ChallengeTypeId == _CategoryId).ToList()
                     from b in a.ChallengeClubRelations
                     where b.ClubId == _ClubId
                     select a;
            return entity;
                        //.Where(a => a.ChallengeClubRelations.Any(b => b.ClubId == _ClubId));

        }
    }
}
