namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
