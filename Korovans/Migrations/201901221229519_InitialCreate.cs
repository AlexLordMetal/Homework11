namespace Korovans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fighters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HP = c.Int(nullable: false),
                        ATK = c.Int(nullable: false),
                        STR = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Class = c.Int(nullable: false),
                        BetweenAbility = c.Int(nullable: false),
                        AbilityRecoveryCounter = c.Int(nullable: false),
                        Faction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.Faction_Id)
                .Index(t => t.Faction_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fighters", "Faction_Id", "dbo.Factions");
            DropIndex("dbo.Fighters", new[] { "Faction_Id" });
            DropTable("dbo.Fighters");
            DropTable("dbo.Factions");
        }
    }
}
