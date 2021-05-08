// -----------------------------------------------------------------------
// <copyright file="CatalogContext.cs" company="SaberMotamedi">
// Copyright (c) SaberMotamedi. All rights reserved.  Developed with 🖤
// </copyright>
// -----------------------------------------------------------------------

using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DataBaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DataBaseSettings:DatabaseName"));

            this.Products = database.GetCollection<Product>(configuration.GetValue<string>("DataBaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(this.Products);
        }
    }
}
