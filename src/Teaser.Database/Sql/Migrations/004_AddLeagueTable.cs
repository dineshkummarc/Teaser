using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;


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

            ILeagueRepository repo = new FakeLeagueRepository();
            var list = repo.Get();
            foreach (League i in list)
            {
                Database.Insert(table, h, new string[] { i.Id.ToString(), i.Name});
            }  
        }
    }
}
