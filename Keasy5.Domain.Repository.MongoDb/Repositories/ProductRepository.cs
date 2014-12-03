using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keasy5.Domain.Model;
using Keasy5.Domain.Repositories;
using MongoDB.Driver.Linq;

namespace Keasy5.Domain.Repository.MongoDb.Repositories
{
    /// <summary>
    /// 表示Product仓储的一个具体实现。
    /// </summary>
    public class ProductRepository : MongoDBRepository<Product>, IProductRepository
    {
        #region Ctor
        public ProductRepository(IRepositoryContext context) : base(context) { }
        #endregion

        #region IProductRepository Members
        /// <summary>
        /// 获取特色商品的列表。
        /// </summary>
        /// <param name="count">需要获取的特色商品的个数。默认值：0，表示获取所有特色商品。</param>
        /// <returns>特色商品列表。</returns>
        public IEnumerable<Product> GetFeaturedProducts(int count = 0)
        {
            var productCollection = MongoDBRepositoryContext.GetCollectionForType(typeof(Product));
            List<Product> products = null;
            if (count == 0)
                products = productCollection.AsQueryable<Product>().Where(p => p.IsFeatured).ToList();
            else
                products = productCollection.AsQueryable<Product>().Where(p => p.IsFeatured).Take(count).ToList();
            return products;
        }

        #endregion
    }
}
