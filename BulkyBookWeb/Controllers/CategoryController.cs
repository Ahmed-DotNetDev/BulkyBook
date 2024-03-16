using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            //strong typed
            IEnumerable<Category> ojbCategoryList = _db.categories;

            return View(ojbCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Not Allowed name exact like display order");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category is created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var selectedCategory = _db.categories.Find(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }
            return View(selectedCategory);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Not Allowed name exact like display order");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category is updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //---------
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var selectedCategory = _db.categories.Find(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }
            return View(selectedCategory);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var selectedCategory = _db.categories.Find(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }

            _db.categories.Remove(selectedCategory);
            _db.SaveChanges();
            TempData["success"] = "Category is removed successfully";
            return RedirectToAction("Index");

        }


    }
}
