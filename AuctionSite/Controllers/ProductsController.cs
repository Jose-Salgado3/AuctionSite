using AuctionSite.Data;
using AuctionSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace AuctionSite.Controllers
{

    public class ProductsController : Controller
    {
        // Private field for the hosting environment
        private readonly IHostingEnvironment he;

        //Constructor for the hosting environment
        public ProductsController(IHostingEnvironment e)
        {
            he = e;
        }

        private readonly ApplicationDbContext _context;

        //Passes DBcontext to controller with conttructor
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Index(string Name, IFormFile pic)
        {
            ViewData["prodName"] = Name;
            if (pic != null)
            {
                // GetFileName is helping to extract just the filename of the pic
                var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
            }
            return View();
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
                await ProductDb.Add(p, _context);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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