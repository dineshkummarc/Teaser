using System.Collections.Generic;
using Stable.Core.Domain;

namespace Fragile.Core.Services
{
	public interface IProductRepository
	{
		IEnumerable<Product> FindAll();
		Product GetById(int id);
		void Save(Product product);
	}
}