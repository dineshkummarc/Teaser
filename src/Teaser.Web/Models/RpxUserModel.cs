using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teaser.Entities;

namespace Teaser.Web.Models
{
    public class RpxUserModel
    {
        public int Id { get; set; }

        public string SiteUserName { get; set; }

        public int SiteUserId { get; set; }
        public string Identifier { get; set; }
        public string ProviderName { get; set; }
        public string DisplayName { get; set; } 
        public string JsonData { get; set; } 
    }
}
