using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teaser.Entities.Base
{
    [Serializable]
    public abstract class BaseItem
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
