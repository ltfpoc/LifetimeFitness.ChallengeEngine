namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class ChallengeClubRelation
    {
        public ChallengeClubRelation()
        {
            UserChallengeEnrollments = new HashSet<UserChallengeEnrollment>();
        }

        public int ChallengeClubRelationId { get; set; }

        public int ChallengeId { get; set; }

        public int ClubId { get; set; }

        [JsonIgnore]
        public virtual Challenge Challenge { get; set; }

        [JsonIgnore]
        public virtual Club Club { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserChallengeEnrollment> UserChallengeEnrollments { get; set; }
    }
}
