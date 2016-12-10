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
    public class MeasurementProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Measurement> measurementProviderRepository;

        public MeasurementProvider()
        {
            measurementProviderRepository = unitOfWork.Repository<Measurement>();
        }

        public int Insert(Measurement _measurement)
        {
          return  measurementProviderRepository.Insert(_measurement);
        }

        public int Update(Measurement _measurement)
        {
          return  measurementProviderRepository.Update(_measurement);
        }

        public int Delete(Measurement _measurement)
        {
          return  measurementProviderRepository.Delete(_measurement);
        }


        public async Task<IEnumerable<Measurement>> GetAll()
        {
            return await measurementProviderRepository.GetAll();
        }
        public async Task<Measurement> GetById(int _id)
        {
            return await measurementProviderRepository.GetById(_id);
        }

        public async Task<IEnumerable<Measurement>> FindBy(Expression<Func<Measurement, bool>> predicate)
        {
            return await measurementProviderRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<Measurement>> GetAllBy(Expression<Func<Measurement, bool>> filter = null,
            Func<IEnumerable<Measurement>, IOrderedEnumerable<Measurement>> orderBy = null)
        {
            return await measurementProviderRepository.GetAllBy(filter, orderBy);
        }
    }
}
