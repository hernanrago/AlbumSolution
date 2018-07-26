namespace AlbumApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Album : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        NumberOfTracks = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Artist_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonArtists",
                c => new
                    {
                        Person_Id = c.Guid(nullable: false),
                        Artist_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Artist_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.PersonArtists", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.PersonArtists", new[] { "Artist_Id" });
            DropIndex("dbo.PersonArtists", new[] { "Person_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropTable("dbo.PersonArtists");
            DropTable("dbo.People");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
