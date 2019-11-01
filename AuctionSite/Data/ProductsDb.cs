using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Models;

namespace AuctionSite.Data
{
    public class ProductsDb
    {

        public Product Add(Product p, ApplicationDbContext context)
        {
            context.Add(p);
            context.SaveChanges();
            return p;        
        }
    }
}
