namespace ControleVenda.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true, name: "Cpf_idx");
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataHora = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.VendaItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .ForeignKey("dbo.Venda", t => t.VendaId)
                .Index(t => t.ProdutoId)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaItem", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.VendaItem", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Venda", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.VendaItem", new[] { "VendaId" });
            DropIndex("dbo.VendaItem", new[] { "ProdutoId" });
            DropIndex("dbo.Venda", new[] { "ClienteId" });
            DropIndex("dbo.Cliente", "Cpf_idx");
            DropTable("dbo.Produto");
            DropTable("dbo.VendaItem");
            DropTable("dbo.Venda");
            DropTable("dbo.Cliente");
        }
    }
}
