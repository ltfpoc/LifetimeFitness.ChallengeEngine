using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class ChallengesBL
    {
        private readonly ChallengeProvider _challengestore;
        private readonly ClubProvider _clubstore;        

        public ChallengesBL()
        {
            _challengestore = new ChallengeProvider();
            _clubstore = new ClubProvider();
        }


    }
}
