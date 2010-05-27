using Migrator.Framework;
using System.Data;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(4)]
    public class _004_AddLeagueTable : Migrator.Framework.Migration
    {
        private const string table = "League";

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
            Database.Insert(table, h, new string[] { "1", "NTL" });
            Database.Insert(table, h, new string[] { "2", "Stu Season" });

        }
    }
}
