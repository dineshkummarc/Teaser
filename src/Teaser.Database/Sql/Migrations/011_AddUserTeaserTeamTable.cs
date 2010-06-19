

using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;
using System;


namespace Teaser.Database.Sql.Migrations
{
    [Migration(11)]
    public class _011_AddUserTeaserTeamTable : Migrator.Framework.Migration
    {
        string table = "User_TeaserTeam";

        override public void Up()
        {
            Database.AddTable(table,
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("SiteUserId", DbType.Int32),
                new Column("TeaserTeamId", DbType.Int32) 
            );

            Database.AddForeignKey("FK_SiteUser_UserTeaserTeam", table, "SiteUserId", "SiteUser", "Id");
            Database.AddForeignKey("FK_TeaserTeam_UserTeaserTeam", table, "TeaserTeamId", "TeaserTeam", "Id");
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
            string[] h = { "Id", "SiteUserId", "TeaserTeamId"  };

            IUserTeaserTeamRepository repo = new FakeUserTeaserTeamRepository(
                new FakeSiteUserRepository(), 
                new FakeTeaserTeamRepository());
            var list = repo.Get();
            foreach (UserTeaserTeam i in list)
            {
                Database.Insert(table, h, new string[] 
                { 
                    i.Id.ToString(), 
                    (i.SiteUserId.ToString() )   , 
                    (i.TeaserTeamId.ToString()   )  
                });
            }
        }



    }
}
/*
        public int SiteUserId { get; set; } 
        public string Identifier { get; set; }
        public string ProviderName { get; set; } 
        public string DisplayName { get; set; }
        public string PreferredUsername { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string UtcOffset { get; set; }
        public string Email { get; set; }
        public string VerifiedEmail { get; set; }

        public string Url { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string LimitedData { get; set; }
        public string JsonData { get; set; } */