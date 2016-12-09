namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ClubLevel
    {
        public ClubLevel()
        {
            Challenges = new HashSet<Challenge>();
            Clubs = new HashSet<Club>();
        }

        public int ClubLevelId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClubLevelDescription { get; set; }

        public virtual ICollection<Challenge> Challenges { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
    }
}
