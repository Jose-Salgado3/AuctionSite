using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Models;

namespace AuctionSite.Data
{
    public class ProductsDb
    {

        public static async Task<Product> Add(Product p, ApplicationDbContext context)
        {
            context.Add(p);
            await context.SaveChangesAsync();
            return p;        
        }

        /// <summary>
        /// Uses 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Product> UpdateProduct(Product p, ApplicationDbContext context)
        {
            //Starts tracking to get to update
            context.Update(p);
            //Await because Db is being contacted
            await context.SaveChangesAsync();
            return p;
        }
    }


}
