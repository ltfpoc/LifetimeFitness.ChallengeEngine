namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            Measurements = new HashSet<Measurement>();
            UserChallengeEnrollments = new HashSet<UserChallengeEnrollment>();
            UserClubEnrollments = new HashSet<UserClubEnrollment>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int? RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; }

        public virtual ICollection<UserChallengeEnrollment> UserChallengeEnrollments { get; set; }

        public virtual ICollection<UserClubEnrollment> UserClubEnrollments { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
