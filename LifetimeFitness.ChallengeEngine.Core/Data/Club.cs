namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Club
    {
        public Club()
        {
            ChallengeClubRelations = new HashSet<ChallengeClubRelation>();
            UserClubEnrollments = new HashSet<UserClubEnrollment>();
        }

        public int ClubId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClubName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string Zip { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int ClubLevelId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ChallengeClubRelation> ChallengeClubRelations { get; set; }

        [JsonIgnore]
        public virtual ClubLevel ClubLevel { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserClubEnrollment> UserClubEnrollments { get; set; }
    }
}
