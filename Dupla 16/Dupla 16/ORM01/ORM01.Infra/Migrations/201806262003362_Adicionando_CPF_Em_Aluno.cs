namespace ORM01.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionando_CPF_Em_Aluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBAluno", "CPF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBAluno", "CPF");
        }
    }
}
