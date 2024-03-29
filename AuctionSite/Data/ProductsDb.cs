﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Models;
using Microsoft.EntityFrameworkCore;

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


        public static void DeleteById(int id, ApplicationDbContext context)
        {
            Product p = new Product()
            {
                Id = id
            };
            context.Entry(p).State = EntityState.Deleted;
        }


        /// <summary>
        /// This method contacts the database and grabs every instance of product that it can find
        /// and stores them in a list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A List of products retrieved from the database</returns>
        public static async Task<List<Product>> GetAllProducts(ApplicationDbContext context)
        {
            //LINQ
            List<Product> products = await context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();

            return products;
        }
    }


}
