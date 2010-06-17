using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;
using System;


namespace Teaser.Database.Sql.Migrations
{
    [Migration(10)]
    public class _010_AddRpxUserTable : Migrator.Framework.Migration
    {

        override public void Up()
        {
            Database.AddTable("RpxUser",
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("SiteUserId", DbType.Int32),
                new Column("Email", DbType.AnsiString),
                new Column("DisplayName", DbType.AnsiString),
                new Column("JsonData", DbType.AnsiString, Int32.MaxValue )
            );
             
            Database.AddForeignKey("FK_SiteUser_RpxUser", "RpxUser", "SiteUserId", "SiteUser", "Id"); 
             
        }

        override public void Down()
        {
            Database.RemoveTable("RpxUser");
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