using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;
        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task DeleteBasket(string userName)
        {
            await _cache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            string res = await _cache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(res))
                return null;
            else
                return JsonConvert.DeserializeObject<ShoppingCart>(res);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await _cache.SetStringAsync(shoppingCart.Username, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.Username);
        }
    }
}
