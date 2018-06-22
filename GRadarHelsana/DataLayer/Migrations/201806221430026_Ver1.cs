namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DBO.BAGData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Canton = c.String(),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Week = c.Int(nullable: false),
                        Population = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Suspects = c.Int(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("DBO.BAGData");
        }
    }
}
