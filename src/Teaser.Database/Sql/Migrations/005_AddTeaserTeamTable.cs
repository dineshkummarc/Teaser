using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(5)]
    public class _005_AddTeaserTeamTable : Migrator.Framework.Migration
    {
        private const string table = "TeaserTeam";

        override public void Up()
        {
            Database.AddTable(table,
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("LeagueId", DbType.Int32),
                new Column("Name", DbType.String, 50)  
            );
            Database.AddForeignKey("FK_League_TeaserTeam", table, "LeagueId", "League", "Id");
            AddSampleData();
        }

        override public void Down()
        {
            Database.RemoveTable(table);
        }

         



        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT " + table + " ON");
            AddRows();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT " + table + " OFF");
        }

        private void AddRows()
        {
            string[] h = { "Id", "LeagueId", "Name" };
            ITeaserTeamRepository repo = new FakeTeaserTeamRepository();
            var list = repo.Get();
            foreach (TeaserTeam i in list)
            {
                Database.Insert(table, h, new string[] { i.Id.ToString(), i.LeagueId.ToString(), i.Name});
            }  
             
        }                                                       
    }
} 