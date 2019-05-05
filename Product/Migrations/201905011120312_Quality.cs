namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quality : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Qualities", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Qualities", "Caption", c => c.Int(nullable: false));
        }
    }
}
