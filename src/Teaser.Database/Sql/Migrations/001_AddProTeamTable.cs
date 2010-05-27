using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

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
            IProTeamRepository proTeamRepo = new FakeProTeamRepository();
            var list = proTeamRepo.Get();
            foreach (ProTeam proTeam in list)
            {
                Database.Insert(table, h, new string[] 
                { 
                    proTeam.Id.ToString(), proTeam.City, proTeam.Name 
                }); 
            }
        }
    }
}
