using Migrator.Framework;
using System.Data;

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
            for (int i = 1; i <= 52; i++)
            {
                string si = i.ToString();
                string teamName = "Team " + si;
                string LeagueId = (i > 26) ? "2" : "1";
                Database.Insert(table, h, new string[] { si, LeagueId, teamName });
            } 
        }                                                       
    }
} 