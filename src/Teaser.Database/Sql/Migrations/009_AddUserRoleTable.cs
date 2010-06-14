using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{


    [Migration(9)]
    public class _009_AddUserRoleTable : Migrator.Framework.Migration
    {

        override public void Up()
        {
            Database.AddTable("SiteUser_Role",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("SiteUserId", DbType.Int32),
                new Column("RoleId", DbType.Int32)
            );


            Database.AddForeignKey("FK_SiteUser_SiteUser_Role", "SiteUser_Role", "SiteUserId", "SiteUser", "Id");
            Database.AddForeignKey("FK_Role_SiteUser_Role", "SiteUser_Role", "RoleId", "Role", "Id");



            AddSampleData();
        }

        override public void Down()
        {
            Database.RemoveTable("SiteUser_Role");
        }





        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT SiteUser_Role ON");
            AddSiteUsers();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT SiteUser_Role OFF");
        }

        private void AddSiteUsers()
        {
            string[] h = { "Id", "SiteUserId", "RoleId" };

            ISiteUserRoleRepository repo = new FakeSiteUserRoleRepository(
                new FakeSiteUserRepository(), 
                new FakeRoleRepository());
            var list = repo.Get();
            foreach (SiteUserRole i in list)
            {
                Database.Insert("SiteUser_Role", h, new string[] 
                { 
                    i.Id.ToString(),  
                    i.SiteUserId.ToString(), 
                    i.RoleId.ToString()
                });
            }
        }
    } 
     
}