using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teaser.Entities.Base
{
    [Serializable]
    public abstract class BaseItem
    {
        public BaseItem()
        {
            this.Id = -2; // if the Id is negative, the repository will know it is a new item.
        }


        public int Id { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string ModifiedBy { get; set; }
    }
}
