using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifetimeFitness.ChallengeEngine.Core;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class CategoryBL
    {
        private readonly ChallengeTypeProvider  _challengtypestore;

        public CategoryBL()
        {
            _challengtypestore = new ChallengeTypeProvider();
        }

        //public async Task<IEnumerable<ChallengeType>> GetChallngeCategories()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
