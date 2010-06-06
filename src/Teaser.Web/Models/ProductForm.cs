using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teaser.Web.Models
{

    public class ProductForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public string Price { get; set; }
    }
}
