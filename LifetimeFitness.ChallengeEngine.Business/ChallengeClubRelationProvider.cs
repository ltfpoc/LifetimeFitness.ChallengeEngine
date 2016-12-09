using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ChallengeClubRelationProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<ChallengeClubRelation> challengeClubRelationRepository;

        public ChallengeClubRelationProvider()
        {
            challengeClubRelationRepository = unitOfWork.Repository<ChallengeClubRelation>();
        }

        

        public void Insert(ChallengeClubRelation _challengeClubRelation)
        {
            challengeClubRelationRepository.Insert(_challengeClubRelation);
        }

        public void Update(ChallengeClubRelation _challengeClubRelation)
        {
            challengeClubRelationRepository.Update(_challengeClubRelation);
        }

        public void Delete(ChallengeClubRelation _challengeClubRelation)
        {
            challengeClubRelationRepository.Delete(_challengeClubRelation);
        }

        public async Task<IEnumerable<ChallengeClubRelation>> GetAll()
        {
            return await challengeClubRelationRepository.GetAll();
        }

        public async Task<ChallengeClubRelation> GetById(int _id)
        {
            return await challengeClubRelationRepository.GetById(_id);
        }

        public async Task<IEnumerable<ChallengeClubRelation>> FindBy(Expression<Func<ChallengeClubRelation, bool>> predicate)
        {
            return await challengeClubRelationRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<ChallengeClubRelation>> GetAllBy(Expression<Func<ChallengeClubRelation, bool>> filter = null, Func<IQueryable<ChallengeClubRelation>, IOrderedQueryable<ChallengeClubRelation>> orderBy = null)
        {
            return await challengeClubRelationRepository.GetAllBy(filter, orderBy);
        }
    }
}
