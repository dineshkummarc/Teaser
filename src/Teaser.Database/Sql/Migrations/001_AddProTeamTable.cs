using Migrator.Framework;
using System.Data;

namespace Teaser.Database.Sql.Migrations
{
    
    [Migration(1)]
    public class _001_AddProTeamTable: Migrator.Framework.Migration
    {
        private const string table = "ProTeam";

        override public void Up()
        {
            Database.AddTable("ProTeam",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("City", DbType.String, 50),
                new Column("Name", DbType.String, 50) 
            );
            AddSampleData();
        }

        override public void Down()
        {
            Database.RemoveTable("ProTeam");
        }
 







        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT " + table + " ON");
            AddRows();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT " + table + " OFF");
        }

        private void AddRows()
        {
            string[] h = { "Id", "City",  "Name" };
            Database.Insert(table, h, new string[] { "1", "Baltimore", "Ravens"});
            Database.Insert(table, h, new string[] { "2", "Cincinnati", "Bengals"});
            Database.Insert(table, h, new string[] { "3", "Cleveland", "Browns"});
            Database.Insert(table, h, new string[] { "4", "Pittsburgh", "Steelers"});
            Database.Insert(table, h, new string[] { "5", "Houston", "Texans"});
            Database.Insert(table, h, new string[] { "6", "Indianapolis", "Colts"});
            Database.Insert(table, h, new string[] { "7", "Jacksonville", "Jaguars"});
            Database.Insert(table, h, new string[] { "8", "Tennessee", "Titans"});
            Database.Insert(table, h, new string[] { "9", "Buffalo", "Bills"});
            Database.Insert(table, h, new string[] { "10", "Miami", "Dolphins"});
            Database.Insert(table, h, new string[] { "11", "New England", "Patriots"});
            Database.Insert(table, h, new string[] { "12", "New York", "Jets"});
            Database.Insert(table, h, new string[] { "13", "Denver", "Broncos"});
            Database.Insert(table, h, new string[] { "14", "Kansas City", "Chiefs"});
            Database.Insert(table, h, new string[] { "15", "Oakland", "Raiders"});
            Database.Insert(table, h, new string[] { "16", "San Diego", "Chargers"});
            Database.Insert(table, h, new string[] { "17", "Chicago", "Bears"});
            Database.Insert(table, h, new string[] { "18", "Detroit", "Lions"});
            Database.Insert(table, h, new string[] { "19", "Green Bay", "Packers"});
            Database.Insert(table, h, new string[] { "20", "Minnesota", "Vikings"});
            Database.Insert(table, h, new string[] { "21", "Atlanta", "Falcons"});
            Database.Insert(table, h, new string[] { "22", "Carolina", "Panthers"});
            Database.Insert(table, h, new string[] { "23", "New Orleans", "Saints"});
            Database.Insert(table, h, new string[] { "24", "Tampa Bay", "Buccaneers" });
            Database.Insert(table, h, new string[] { "25", "Dallas", "Cowboys" });
            Database.Insert(table, h, new string[] { "26", "New York", "Giants" });
            Database.Insert(table, h, new string[] { "27", "Philadelphia", "Eagles"});
            Database.Insert(table, h, new string[] { "28", "Washington", "Redskins" });
            Database.Insert(table, h, new string[] { "29", "Arizona", "Cardinals"});
            Database.Insert(table, h, new string[] { "30", "San Francisco", "49ers" });
            Database.Insert(table, h, new string[] { "31", "Seattle", "Seahawks" });
            Database.Insert(table, h, new string[] { "32", "St. Louis", "Rams" });

        }
    }
}
