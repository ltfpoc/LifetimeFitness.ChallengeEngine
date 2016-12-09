using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ClubProvider
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Club> clubProviderRepository;

        public ClubProvider()
        {
            clubProviderRepository = unitOfWork.Repository<Club>();
        }



        public void Insert(Club _club)
        {
            clubProviderRepository.Insert(_club);
        }

        public void Update(Club _club)
        {
            clubProviderRepository.Update(_club);
        }

        public void Delete(Club _club)
        {
            clubProviderRepository.Delete(_club);
        }

        public async Task<Club> GetById(int _id)
        {
            return await clubProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await clubProviderRepository.GetAll();
        }

        public async Task<IEnumerable<Club>> FindBy(Expression<Func<Club, bool>> predicate)
        {
            return await clubProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<Club>> GetAllBy(Expression<Func<Club, bool>> filter = null, Func<IQueryable<Club>, IOrderedQueryable<Club>> orderBy = null)
        {
            return await clubProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
