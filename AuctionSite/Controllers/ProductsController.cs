using AuctionSite.Data;
using AuctionSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server;

namespace AuctionSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //Passes DBcontext to controller with conttructor
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index(int? id)
        {
            List<Product> products = await ProductsDb.GetAllProducts(_context);
            return View(products);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: User/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product p, IFormFile Image)
        {
            try
            {
                string path = UploadImage(Image);
                if (path.Equals("-1"))
                {

                }
                else 
                {

                    await ProductsDb.Add(p, _context);
                    ViewBag.msg="Data added";
                }
                // TODO: Add insert logic here
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public string UploadImage(IFormFile file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.Length > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg")
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.WriteAsync("<script>alert('Only jpg, jpeg or png formats are accepted'); </script>");
                }
            }
            else
            {
                Response.WriteAsync("<script>alert('Please select a file'); </script>");
                path = "-1";
            }

            return path;


        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}