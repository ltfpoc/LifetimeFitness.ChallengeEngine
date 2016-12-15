using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Core.Domin
{
    public class Enrollment
    {
        public int UserId { get; set; }

        public int ChallengeId { get; set; }

        public int ClubId { get; set; }

        public int ChallengeClubRelationId { get; set; }
    }
}
