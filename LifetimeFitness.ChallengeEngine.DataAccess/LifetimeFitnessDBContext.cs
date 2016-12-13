namespace LifetimeFitness.ChallengeEngine.DataAccess
{
    using System.Data.Entity;
    using Core;

    public partial class LifetimeFitnessDBContext : DbContext
    {
        public LifetimeFitnessDBContext()
            : base("name=LifetimeFitnessDBContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<ChallengeClubRelation> ChallengeClubRelations { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<ChallengeType> ChallengeTypes { get; set; }
        public virtual DbSet<ClubLevel> ClubLevels { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<UserChallengeEnrollment> UserChallengeEnrollments { get; set; }
        public virtual DbSet<UserClubEnrollment> UserClubEnrollments { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Challenge>()
                .HasMany(e => e.ChallengeClubRelations)
                .WithRequired(e => e.Challenge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChallengeType>()
                .Property(e => e.ChallengeTypeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ChallengeType>()
                .Property(e => e.ChallengeTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ChallengeType>()
                .HasMany(e => e.Challenges)
                .WithRequired(e => e.ChallengeType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubLevel>()
                .Property(e => e.ClubLevelDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ClubLevel>()
                .HasMany(e => e.Challenges)
                .WithOptional(e => e.ClubLevel)
                .HasForeignKey(e => e.ChallengeClubLevelId);

            modelBuilder.Entity<ClubLevel>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.ClubLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ChallengeClubRelations)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.UserClubEnrollments)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Measurement>()
                .Property(e => e.bodyfatpercent)
                .HasPrecision(6, 3);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserRole)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserChallengeEnrollments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserClubEnrollments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
