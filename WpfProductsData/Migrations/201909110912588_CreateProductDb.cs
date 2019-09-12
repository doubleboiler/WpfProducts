namespace WpfProductsData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 2000),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ProductCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "ProductCode" });
            DropTable("dbo.Product");
        }
    }
}
