namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Challenge
    {
        public Challenge()
        {
            ChallengeClubRelations = new HashSet<ChallengeClubRelation>();
            UserChallengeEnrollments = new HashSet<UserChallengeEnrollment>();
        }

        public int ChallengeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Duration { get; set; }

        public int ChallengeTypeId { get; set; }

        public int? ChallengeClubLevelId { get; set; }

        public bool IsOganizationLevel { get; set; }

        [JsonIgnore]
        public virtual ICollection<ChallengeClubRelation> ChallengeClubRelations { get; set; }

        [JsonIgnore]
        public virtual ChallengeType ChallengeType { get; set; }

        [JsonIgnore]
        public virtual ClubLevel ClubLevel { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserChallengeEnrollment> UserChallengeEnrollments { get; set; }
    }
}
