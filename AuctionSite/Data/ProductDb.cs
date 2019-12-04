using AuctionSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Data
{
    public static class ProductDb
    {

        /// <summary>
        /// Adds a Product to the database
        /// </summary>
        /// <param name="p">The product to add</param>
        /// <param name="context">The Db context to use</param>
        /// <returns></returns>
        public static async Task<Product> Add(Product p, ApplicationDbContext context)
        {
            await context.AddAsync(p);
            await context.SaveChangesAsync();
            return p;
        }
    }
}
