using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(8)]
    public class _008_AddUserTable : Migrator.Framework.Migration
    {

        override public void Up()
        { 
            Database.AddTable("User",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, 50),
                new Column("Password", DbType.String, 50),
                new Column("OpenId", DbType.String, 500)
            ); 

            AddSampleData();
        }

        override public void Down()
        { 
            Database.RemoveTable("User"); 
        }





        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT User ON");
            AddUsers();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT User OFF");
        }

        private void AddUsers()
        {
            string[] h = { "Id", "Name" , "Password", "OpenId"};

            IUserRepository repo = new FakeUserRepository();
            var list = repo.Get();
            foreach (User i in list)
            {
                Database.Insert("User", h, new string[] 
                { 
                    i.Id.ToString(), 
                    i.Name.ToString() 
                });
            }
        }
    }
}