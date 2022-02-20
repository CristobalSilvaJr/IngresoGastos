namespace IngresoGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaIngresoGastos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngresoGastosModels", "FechaIngreso", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IngresoGastosModels", "FechaIngreso");
        }
    }
}
