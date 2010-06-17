using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{


    [Migration(8)]
    public class _008_AddSiteUserTable : Migrator.Framework.Migration
    {

        override public void Up()
        {
            Database.AddTable("SiteUser",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, 50)
            );

            AddSampleData();
        }

        override public void Down()
        {
            Database.RemoveTable("SiteUser");
        }





        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT SiteUser ON");
            AddSiteUsers();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT SiteUser OFF");
        }

        private void AddSiteUsers()
        {
            string[] h = { "Id", "Name"  };

            ISiteUserRepository repo = new FakeSiteUserRepository();
            var list = repo.Get();
            foreach (SiteUser i in list)
            {
                Database.Insert("SiteUser", h, new string[] 
                { 
                    i.Id.ToString(), 
                    i.Name.ToString()  
                });
            }
        }
    } 
}