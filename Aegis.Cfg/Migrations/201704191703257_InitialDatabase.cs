namespace Aegis.Cfg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Datasets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkspaceId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
                .Index(t => t.WorkspaceId);
            
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatasetId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Datasets", t => t.DatasetId, cascadeDelete: true)
                .Index(t => t.DatasetId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Index = c.Int(nullable: false),
                        LayerId = c.Int(nullable: false),
                        Geometry = c.Geometry(nullable: false),
                    })
                .PrimaryKey(t => new { t.Index, t.LayerId })
                .ForeignKey("dbo.Layers", t => t.LayerId, cascadeDelete: true)
                .Index(t => t.LayerId);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        LayerId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LayerId, t.Index })
                .ForeignKey("dbo.Layers", t => t.LayerId, cascadeDelete: true)
                .Index(t => t.LayerId);
            
            CreateTable(
                "dbo.FieldValues",
                c => new
                    {
                        LayerId = c.Int(nullable: false),
                        FeatureIndex = c.Int(nullable: false),
                        FieldIndex = c.Int(nullable: false),
                        Double = c.Double(),
                        Long = c.Long(),
                        String = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LayerId, t.FeatureIndex, t.FieldIndex })
                .ForeignKey("dbo.Features", t => new { t.FeatureIndex, t.FieldIndex }, cascadeDelete: true)
                .Index(t => new { t.FeatureIndex, t.FieldIndex });
            
            CreateTable(
                "dbo.Workspaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Datasets", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.FieldValues", new[] { "FeatureIndex", "FieldIndex" }, "dbo.Features");
            DropForeignKey("dbo.Layers", "DatasetId", "dbo.Datasets");
            DropForeignKey("dbo.Fields", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Features", "LayerId", "dbo.Layers");
            DropIndex("dbo.FieldValues", new[] { "FeatureIndex", "FieldIndex" });
            DropIndex("dbo.Fields", new[] { "LayerId" });
            DropIndex("dbo.Features", new[] { "LayerId" });
            DropIndex("dbo.Layers", new[] { "DatasetId" });
            DropIndex("dbo.Datasets", new[] { "WorkspaceId" });
            DropTable("dbo.Workspaces");
            DropTable("dbo.FieldValues");
            DropTable("dbo.Fields");
            DropTable("dbo.Features");
            DropTable("dbo.Layers");
            DropTable("dbo.Datasets");
        }
    }
}
