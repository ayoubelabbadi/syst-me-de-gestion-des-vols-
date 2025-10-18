namespace aspasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modele = c.String(nullable: false, maxLength: 50),
                        Capacite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(nullable: false, maxLength: 50),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false, maxLength: 20),
                        Adresse = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VilleDepart = c.String(nullable: false, maxLength: 100),
                        VilleArrivee = c.String(nullable: false, maxLength: 100),
                        DateVol = c.DateTime(nullable: false),
                        AvionId = c.Int(nullable: false),
                        PiloteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avions", t => t.AvionId)
                .ForeignKey("dbo.Pilotes", t => t.PiloteId)
                .Index(t => t.AvionId)
                .Index(t => t.PiloteId);
            
            CreateTable(
                "dbo.Passagers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumeroPasseport = c.String(nullable: false, maxLength: 20),
                        Nationalite = c.String(maxLength: 50),
                        FrequentFlyer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pilotes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LicenceNumber = c.String(nullable: false, maxLength: 20),
                        HeuresDeVol = c.Int(nullable: false),
                        DateEmbauche = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pilotes", "Id", "dbo.Personnes");
            DropForeignKey("dbo.Passagers", "Id", "dbo.Personnes");
            DropForeignKey("dbo.Vols", "PiloteId", "dbo.Pilotes");
            DropForeignKey("dbo.Vols", "AvionId", "dbo.Avions");
            DropIndex("dbo.Pilotes", new[] { "Id" });
            DropIndex("dbo.Passagers", new[] { "Id" });
            DropIndex("dbo.Vols", new[] { "PiloteId" });
            DropIndex("dbo.Vols", new[] { "AvionId" });
            DropTable("dbo.Pilotes");
            DropTable("dbo.Passagers");
            DropTable("dbo.Vols");
            DropTable("dbo.Personnes");
            DropTable("dbo.Avions");
        }
    }
}
