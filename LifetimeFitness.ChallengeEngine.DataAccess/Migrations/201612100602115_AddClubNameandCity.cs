namespace LifetimeFitness.ChallengeEngine.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClubNameandCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChallengeClubRelations",
                c => new
                    {
                        ChallengeClubRelationId = c.Int(nullable: false, identity: true),
                        ChallengeId = c.Int(nullable: false),
                        ClubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChallengeClubRelationId)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .Index(t => t.ChallengeId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        ChallengeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(),
                        ChallengeTypeId = c.Int(nullable: false),
                        ChallengeClubLevelId = c.Int(),
                        IsOganizationLevel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChallengeId)
                .ForeignKey("dbo.ChallengeTypes", t => t.ChallengeTypeId)
                .ForeignKey("dbo.ClubLevels", t => t.ChallengeClubLevelId)
                .Index(t => t.ChallengeTypeId)
                .Index(t => t.ChallengeClubLevelId);
            
            CreateTable(
                "dbo.ChallengeTypes",
                c => new
                    {
                        ChallengeTypeId = c.Int(nullable: false, identity: true),
                        ChallengeTypeTitle = c.String(nullable: false, maxLength: 50, unicode: false),
                        ChallengeTypeDescription = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ChallengeTypeId);
            
            CreateTable(
                "dbo.ClubLevels",
                c => new
                    {
                        ClubLevelId = c.Int(nullable: false, identity: true),
                        ClubLevelDescription = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ClubLevelId);
            
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(nullable: false, maxLength: 50),
                        Address1 = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address2 = c.String(maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2, unicode: false),
                        Zip = c.String(nullable: false, maxLength: 5, unicode: false),
                        PhoneNumber = c.String(maxLength: 15, unicode: false),
                        ClubLevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId)
                .ForeignKey("dbo.ClubLevels", t => t.ClubLevelId)
                .Index(t => t.ClubLevelId);
            
            CreateTable(
                "dbo.UserClubEnrollments",
                c => new
                    {
                        UserClubEnrollmentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserClubEnrollmentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .Index(t => t.UserId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        RoleId = c.Int(),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserRoles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Height = c.Int(),
                        weight = c.Int(),
                        bodyfatpercent = c.Decimal(precision: 6, scale: 3),
                        WeighInDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsQuestionable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MeasurementId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserChallengeEnrollments",
                c => new
                    {
                        UserChallengeEnrollmentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ChallengeId = c.Int(),
                        ChallengeClubRelationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserChallengeEnrollmentId)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId)
                .ForeignKey("dbo.ChallengeClubRelations", t => t.ChallengeClubRelationId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ChallengeId)
                .Index(t => t.ChallengeClubRelationId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clubs", "ClubLevelId", "dbo.ClubLevels");
            DropForeignKey("dbo.UserClubEnrollments", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserClubEnrollments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserChallengeEnrollments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserChallengeEnrollments", "ChallengeClubRelationId", "dbo.ChallengeClubRelations");
            DropForeignKey("dbo.UserChallengeEnrollments", "ChallengeId", "dbo.Challenges");
            DropForeignKey("dbo.Measurements", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChallengeClubRelations", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Challenges", "ChallengeClubLevelId", "dbo.ClubLevels");
            DropForeignKey("dbo.Challenges", "ChallengeTypeId", "dbo.ChallengeTypes");
            DropForeignKey("dbo.ChallengeClubRelations", "ChallengeId", "dbo.Challenges");
            DropIndex("dbo.UserChallengeEnrollments", new[] { "ChallengeClubRelationId" });
            DropIndex("dbo.UserChallengeEnrollments", new[] { "ChallengeId" });
            DropIndex("dbo.UserChallengeEnrollments", new[] { "UserId" });
            DropIndex("dbo.Measurements", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.UserClubEnrollments", new[] { "ClubId" });
            DropIndex("dbo.UserClubEnrollments", new[] { "UserId" });
            DropIndex("dbo.Clubs", new[] { "ClubLevelId" });
            DropIndex("dbo.Challenges", new[] { "ChallengeClubLevelId" });
            DropIndex("dbo.Challenges", new[] { "ChallengeTypeId" });
            DropIndex("dbo.ChallengeClubRelations", new[] { "ClubId" });
            DropIndex("dbo.ChallengeClubRelations", new[] { "ChallengeId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserChallengeEnrollments");
            DropTable("dbo.Measurements");
            DropTable("dbo.Users");
            DropTable("dbo.UserClubEnrollments");
            DropTable("dbo.Clubs");
            DropTable("dbo.ClubLevels");
            DropTable("dbo.ChallengeTypes");
            DropTable("dbo.Challenges");
            DropTable("dbo.ChallengeClubRelations");
        }
    }
}
