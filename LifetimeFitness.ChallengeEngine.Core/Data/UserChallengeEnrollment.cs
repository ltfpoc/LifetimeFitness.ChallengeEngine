namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class UserChallengeEnrollment
    {
        public int UserChallengeEnrollmentId { get; set; }

        public int UserId { get; set; }

        public int? ChallengeId { get; set; }

        public int? ChallengeClubRelationId { get; set; }

        [JsonIgnore]
        public virtual ChallengeClubRelation ChallengeClubRelation { get; set; }

        [JsonIgnore]
        public virtual Challenge Challenge { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
