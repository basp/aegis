namespace Aegis.Cfg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Datasets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkspaceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workspaces", t => t.WorkspaceId, cascadeDelete: true)
                .Index(t => new { t.WorkspaceId, t.Name }, unique: true, name: "IX_WorkspaceId_DatasetName");
            
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatasetId = c.Int(nullable: false),
                        Name = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Datasets", t => t.DatasetId, cascadeDelete: true)
                .Index(t => new { t.DatasetId, t.Name }, unique: true, name: "IX_DatasetId_LayerName");
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Index = c.Int(nullable: false),
                        LayerId = c.Int(nullable: false),
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
                        Name = c.String(maxLength: 32),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LayerId, t.Index })
                .ForeignKey("dbo.Layers", t => t.LayerId, cascadeDelete: true)
                .Index(t => new { t.LayerId, t.Name }, unique: true, name: "IX_LayerId_FieldName");
            
            CreateTable(
                "dbo.FieldValues",
                c => new
                    {
                        LayerId = c.Int(nullable: false),
                        FeatureIndex = c.Int(nullable: false),
                        FieldIndex = c.Int(nullable: false),
                        Double = c.Double(),
                        Int64 = c.Long(),
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
                        Name = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Datasets", "WorkspaceId", "dbo.Workspaces");
            DropForeignKey("dbo.FieldValues", new[] { "FeatureIndex", "FieldIndex" }, "dbo.Features");
            DropForeignKey("dbo.Layers", "DatasetId", "dbo.Datasets");
            DropForeignKey("dbo.Fields", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Features", "LayerId", "dbo.Layers");
            DropIndex("dbo.Workspaces", new[] { "Name" });
            DropIndex("dbo.FieldValues", new[] { "FeatureIndex", "FieldIndex" });
            DropIndex("dbo.Fields", "IX_LayerId_FieldName");
            DropIndex("dbo.Features", new[] { "LayerId" });
            DropIndex("dbo.Layers", "IX_DatasetId_LayerName");
            DropIndex("dbo.Datasets", "IX_WorkspaceId_DatasetName");
            DropTable("dbo.Workspaces");
            DropTable("dbo.FieldValues");
            DropTable("dbo.Fields");
            DropTable("dbo.Features");
            DropTable("dbo.Layers");
            DropTable("dbo.Datasets");
        }
    }
}
