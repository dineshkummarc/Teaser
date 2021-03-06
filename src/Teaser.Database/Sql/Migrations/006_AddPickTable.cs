﻿using Migrator.Framework;
using System.Data;
using Teaser.DataAccess.Interfaces;
using Teaser.DataAccess.Fake;
using Teaser.Entities;

namespace Teaser.Database.Sql.Migrations
{

    [Migration(6)]
    public class _006_AddPickTable : Migrator.Framework.Migration
    {
        private const string table = "Pick";

        override public void Up()
        {
            Database.AddTable(table,
                new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("GameId", DbType.Int32),
                new Column("TeaserTeamId", DbType.Int32),
                new Column("ProTeamId", DbType.Int32)
                //,new Column("TeaserLine", DbType.Int32) 
                //,new Column("Score", DbType.Int32)
            );
            Database.AddForeignKey("FK_TeaserTeam_Pick", table, "TeaserTeamId", "TeaserTeam", "Id");
            Database.AddForeignKey("FK_Game_Pick", table, "GameId", "Game", "Id");
            Database.AddForeignKey("FK_ProTeam_Pick", table, "ProTeamId", "ProTeam", "Id");
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
            string[] h = { "Id", "GameId", "TeaserTeamId", "ProTeamId" };

            IPickRepository repo = new FakePickRepository();
            var list = repo.Get();
            foreach (Pick i in list)
            {
                Database.Insert(table, h, new string[] 
                { 
                    i.Id.ToString(), 
                    i.GameId.ToString(), 
                    i.TeaserTeamId.ToString(), 
                    i.ProTeamId.ToString() 
                });
            }  
            /*
            int id = 1;
            for (int i = 1; i <= 52; i++)
            {
                Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "1" });
                Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "3" });
                Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "5" });
                Database.Insert(table, h, new string[] { id++.ToString(), "1", i.ToString(), "7" }); 
            } */
        }                  
    }
} 