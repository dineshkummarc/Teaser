using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(7)]
    public class _007_AddRoleTable : Migrator.Framework.Migration
    { 

        override public void Up()
        {
            
            Database.AddTable("Role",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, 50)
            );
            //Database.AddTable("User",
            //    new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
            //    new Column("Name", DbType.String, 50),
            //    new Column("Password", DbType.String, 50),
            //    new Column("OpenId", DbType.String, 500)
            //);
            //Database.AddTable("User_Role",
            //    new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
            //    new Column("UserId", DbType.Int32),
            //    new Column("RoleId", DbType.Int32)
            //);
            //Database.AddForeignKey("FK_User_Role_Role", "User_Role", "RoleId", "Role", "Id");
            //Database.AddForeignKey("FK_User_Role_User", "User_Role", "UserId", "User", "Id");

            //Database.AddTable("User_TeaserTeam",
            //    new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
            //    new Column("TeaserTeamId", DbType.Int32)
            //);
            //Database.AddForeignKey("FK_User_TeaserTeam_User", "User_TeaserTeam", "UserId", "User", "Id");

             
            AddSampleData();
        }

        override public void Down()
        { 
            Database.RemoveTable("Role");
        }

         



        private void AddSampleData()
        {
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT Role ON");
            AddRoles();
            Database["SqlServer"].ExecuteNonQuery(@"SET IDENTITY_INSERT Role OFF");
        }

        private void AddRoles()
        {
            string[] h = { "Id", "Name"  };

            IRoleRepository repo = new FakeRoleRepository();
            Database["SqlServer"].ExecuteNonQuery(@"PRINT 'here'");
            var list = repo.Get();
            Database["SqlServer"].ExecuteNonQuery(@"PRINT 'here2'");
            foreach (Role i in list)
            {
                Database.Insert("Role", h, new string[] 
                { 
                    i.Id.ToString(), 
                    i.Name.ToString() 
                });
            }  
        }                  
    }
} 