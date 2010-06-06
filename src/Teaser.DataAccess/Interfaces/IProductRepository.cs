using System;
using Teaser.Entities;
using System.Collections.Generic;
namespace Teaser.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll();
       Product GetById(int id);
        void Save(Product product);
    }
}
