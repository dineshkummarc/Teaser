using Migrator.Framework;
using System.Data;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(2)]
    public class _002_AddWeekTable : Migrator.Framework.Migration
    {
        private const string table = "Week";

        override public void Up()
        {
            Database.AddTable(table,
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, 50)  
            );
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
            string[] h = { "Id", "Name" };
            Database.Insert(table, h, new string[] { "1", "Week 1" });
            Database.Insert(table, h, new string[] { "2", "Week 2" });
            Database.Insert(table, h, new string[] { "3", "Week 3" });
            Database.Insert(table, h, new string[] { "4", "Week 4" });
            Database.Insert(table, h, new string[] { "5", "Week 5" });
            Database.Insert(table, h, new string[] { "6", "Week 6" });
            Database.Insert(table, h, new string[] { "7", "Week 7" });
            Database.Insert(table, h, new string[] { "8", "Week 8" });
            Database.Insert(table, h, new string[] { "9", "Week 9" });
            Database.Insert(table, h, new string[] { "10", "Week 10" });
            Database.Insert(table, h, new string[] { "11", "Week 11" });
            Database.Insert(table, h, new string[] { "12", "Week 12" });
            Database.Insert(table, h, new string[] { "13", "Week 13" });
            Database.Insert(table, h, new string[] { "14", "Week 14" });
            Database.Insert(table, h, new string[] { "15", "Week 15" });
            Database.Insert(table, h, new string[] { "16", "Week 16" });
            Database.Insert(table, h, new string[] { "17", "Week 17" });
            Database.Insert(table, h, new string[] { "18", "Week 18" });
            Database.Insert(table, h, new string[] { "19", "Week 19" });
            Database.Insert(table, h, new string[] { "20", "Week 20" });

        }
    }
}
