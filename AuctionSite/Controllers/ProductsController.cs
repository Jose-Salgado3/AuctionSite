using AuctionSite.Data;
using AuctionSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AuctionSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object _appEnvironment;

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
        public async Task<IActionResult> Add(Product p)
        {
            try
            {
                // TODO: Add insert logic here
                await ProductsDb.Add(p, _context);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Upload_Image()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload_Image(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("file not selected");
            }

            //Get path
            string path_Root = _appEnvironment.WebRootPath;
            string path_to_Images = path_Root + "\\User_Files\\Images\\" + file.FileName;

            //Copy File to target
            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //Output
            ViewData["FilePath"] = path_to_Images;
            return View();
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