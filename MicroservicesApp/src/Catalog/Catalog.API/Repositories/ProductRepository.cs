// -----------------------------------------------------------------------
// <copyright file="ProductRepository.cs" company="SaberMotamedi">
// Copyright (c) SaberMotamedi. All rights reserved.  Developed with 🖤
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext context;

        public ProductRepository(ICatalogContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this.context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await this.context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await this.context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Id, id);

            var resultDelte = await this.context
                                    .Products
                                    .DeleteOneAsync(filter);

            return resultDelte.IsAcknowledged 
                    && resultDelte.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, categoryName);
            return await this.context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await this.context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await this.context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
