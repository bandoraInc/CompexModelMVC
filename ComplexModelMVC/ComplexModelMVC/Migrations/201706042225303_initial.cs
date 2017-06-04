namespace ComplexModelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slogan = c.String(),
                        Country_Id = c.Int(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Managers", t => t.Manager_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        FlagURL = c.String(nullable: false, maxLength: 25),
                        Federation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Federations", t => t.Federation_Id)
                .Index(t => t.Federation_Id);
            
            CreateTable(
                "dbo.Federations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Slogan = c.String(nullable: false, maxLength: 25),
                        BelongsTo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Federations", t => t.BelongsTo_Id)
                .Index(t => t.BelongsTo_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Certificate = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        BirthDate = c.DateTime(nullable: false),
                        Photo = c.String(nullable: false, maxLength: 100),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        TransferAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FromClub_Id = c.Int(),
                        ToClub_Id = c.Int(),
                        Manager_Id = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clubs", t => t.FromClub_Id)
                .ForeignKey("dbo.Clubs", t => t.ToClub_Id)
                .ForeignKey("dbo.Managers", t => t.Manager_Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.FromClub_Id)
                .Index(t => t.ToClub_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        BirthDate = c.DateTime(nullable: false),
                        Photo = c.String(nullable: false, maxLength: 100),
                        Club_Id = c.Int(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clubs", t => t.Club_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Club_Id)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Players", "Club_Id", "dbo.Clubs");
            DropForeignKey("dbo.Clubs", "Manager_Id", "dbo.Managers");
            DropForeignKey("dbo.Transfers", "Manager_Id", "dbo.Managers");
            DropForeignKey("dbo.Transfers", "ToClub_Id", "dbo.Clubs");
            DropForeignKey("dbo.Transfers", "FromClub_Id", "dbo.Clubs");
            DropForeignKey("dbo.Managers", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Federation_Id", "dbo.Federations");
            DropForeignKey("dbo.Federations", "BelongsTo_Id", "dbo.Federations");
            DropForeignKey("dbo.Clubs", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Players", new[] { "Country_Id" });
            DropIndex("dbo.Players", new[] { "Club_Id" });
            DropIndex("dbo.Transfers", new[] { "Player_Id" });
            DropIndex("dbo.Transfers", new[] { "Manager_Id" });
            DropIndex("dbo.Transfers", new[] { "ToClub_Id" });
            DropIndex("dbo.Transfers", new[] { "FromClub_Id" });
            DropIndex("dbo.Managers", new[] { "Country_Id" });
            DropIndex("dbo.Federations", new[] { "BelongsTo_Id" });
            DropIndex("dbo.Countries", new[] { "Federation_Id" });
            DropIndex("dbo.Clubs", new[] { "Manager_Id" });
            DropIndex("dbo.Clubs", new[] { "Country_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Transfers");
            DropTable("dbo.Managers");
            DropTable("dbo.Federations");
            DropTable("dbo.Countries");
            DropTable("dbo.Clubs");
        }
    }
}
