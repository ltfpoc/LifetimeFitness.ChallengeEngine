namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    

    public class ChallengeType
    {
        public ChallengeType()
        {
            Challenges = new HashSet<Challenge>();
        }

        public int ChallengeTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChallengeTypeTitle { get; set; }

        public string ChallengeTypeDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<Challenge> Challenges { get; set; }
    }
}
