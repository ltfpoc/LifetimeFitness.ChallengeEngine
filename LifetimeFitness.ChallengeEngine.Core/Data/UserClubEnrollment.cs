namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class UserClubEnrollment
    {
        public int UserClubEnrollmentId { get; set; }

        public int UserId { get; set; }

        public int ClubId { get; set; }

        [JsonIgnore]
        public virtual Club Club { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
