using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifetimeFitness.ChallengeEngine.Core;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ClubBL
    {
        private readonly ClubProvider _clubstore;

        public ClubBL()
        {
            _clubstore = new ClubProvider();
        }

        public async Task<IEnumerable<Club>> GetClubList()
        {
            try
            {
                var entity = await _clubstore.GetAll();
                return entity;
            }
            catch (Exception ex)
            {
                // ToDo: Implement Nlog to log exception details
                return null;
            }
        }

        public async Task<Club> GetClubbyId(int id)
        {
            try
            {
                var entity = await _clubstore.GetById(id);
                return entity;
            }
            catch (Exception ex)
            {
                // ToDo: Implement Nlog to log exception details
                return null;
            }
        }

    }
}
