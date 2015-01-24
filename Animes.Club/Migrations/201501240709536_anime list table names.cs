namespace Animes.Club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class animelisttablenames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Completeds", newName: "Completed");
            RenameTable(name: "dbo.Droppeds", newName: "Dropped");
            RenameTable(name: "dbo.Todoes", newName: "Todo");
            RenameTable(name: "dbo.Watchings", newName: "Watching");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Watching", newName: "Watchings");
            RenameTable(name: "dbo.Todo", newName: "Todoes");
            RenameTable(name: "dbo.Dropped", newName: "Droppeds");
            RenameTable(name: "dbo.Completed", newName: "Completeds");
        }
    }
}
