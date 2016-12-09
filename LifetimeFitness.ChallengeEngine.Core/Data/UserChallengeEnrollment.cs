namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserChallengeEnrollment
    {
        public int UserChallengeEnrollmentId { get; set; }

        public int UserId { get; set; }

        public int? ChallengeId { get; set; }

        public int? ChallengeClubRelationId { get; set; }

        public virtual ChallengeClubRelation ChallengeClubRelation { get; set; }

        public virtual Challenge Challenge { get; set; }

        public virtual User User { get; set; }
    }
}
