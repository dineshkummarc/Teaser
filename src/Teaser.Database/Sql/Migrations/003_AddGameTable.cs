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
            string[] h = { "Id", "HomeTeamId", "AwayTeamId", "Date", "Line", "HomeScore", "AwayScore", "WeekId" };
            int Id = 1;
            int teamId = 1;
            for (int i = 1; i <= 16; i++) //week 1
            {
                string id = Id++.ToString();
                string homeId = teamId++.ToString();
                string awayId = teamId++.ToString();
                if (teamId > 32) teamId = 1;
                string date = "1/1/2010"; //(i > 16) ? "1/7/2010" : "1/1/2010";
                string weekId = "1";  //(i > 16) ? "2" : "1"; 
                string line = (i % 4 == 1) ? "12" : (i % 4 == 2) ? "-14" : (i % 4 == 3) ? "24" : "-6";
                string homeScore = (i % 3 == 1) ? "9" : (i % 3 == 2) ? "14" : "24";
                string awayScore = (i % 5 == 1) ? "14" : (i % 5 == 2) ? "31" : (i % 5 == 3) ? "3" : "16"; 
                Database.Insert(table, h, new string[] { id, homeId, awayId, date, line, homeScore, awayScore, weekId });
            }
            teamId = 1;
            for (int i = 1; i <= 16; i++) //week 2
            {
                string id = Id++.ToString();
                string homeId = teamId.ToString();
                teamId = teamId + 2;
                string awayId = teamId.ToString();
                teamId = (teamId % 2 == 0) ? teamId + 1 : teamId - 1;
                string date = "1/7/2010";  
                string weekId = "2";
                string line = (i % 4 == 1) ? "3" : (i % 4 == 2) ? "-1" : (i % 4 == 3) ? "14" : "-13";
                string homeScore = (i % 3 == 1) ? "6" : (i % 3 == 2) ? "10" : "23";
                string awayScore = (i % 5 == 1) ? "7" : (i % 5 == 2) ? "21" : (i % 5 == 3) ? "3" : "28"; 
                Database.Insert(table, h, new string[] { id, homeId, awayId, date, line, homeScore, awayScore, weekId });
            }
        }
    }
}
