using Migrator.Framework;
using System.Data;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(3)]
    public class _003_AddGameTable : Migrator.Framework.Migration
    {
        private const string table = "Game";

        override public void Up()
        {
            Database.AddTable(table,
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("HomeTeamId", DbType.Int32),
                new Column("AwayTeamId", DbType.Int32),
                new Column("Date", DbType.Date),
                new Column("Line", DbType.Int32),
                new Column("HomeScore", DbType.Int32),
                new Column("AwayScore", DbType.Int32),
                new Column("WeekId", DbType.Int32)
            );
            Database.AddForeignKey("FK_HomeTeam_Game", table, "HomeTeamId", "ProTeam", "Id");
            Database.AddForeignKey("FK_AwayTeam_Game", table, "AwayTeamId", "ProTeam", "Id");
            Database.AddForeignKey("FK_Week_Game", table, "WeekId", "Week", "Id");
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
            string[] h = { "Id", "HomeTeamId", "AwayTeamId", "Date", "Line", "HomeScore", "AwayScore", "WeekId"};
            Database.Insert(table, h, new string[] { "1", "1", "2", "1/1/2010", "-6", "14", "28", "1"});

        }
    }
}
