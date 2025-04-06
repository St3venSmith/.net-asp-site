using System.Diagnostics;
using InClass6s.Models;
using Microsoft.AspNetCore.Mvc;

namespace InClass6s.Controllers
{
    public class AdminController : Controller
    {
        private InClass6s.Models.SmithContext smithContext { get; set; }
        public AdminController(InClass6s.Models.SmithContext smithContext) => this.smithContext = smithContext;

        public IActionResult Index()
        {
            List<Activitys> activities = smithContext.Activities.OrderBy(a => a.activityName).ToList();
            return View(activities);
        }

        // Add
        [HttpGet]
        public IActionResult Add()
        {
            return View("AddEdit", new Activitys());
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Activitys activity = smithContext.Activities.Find(id);
            return View("AddEdit", activity);
        }

        [HttpPost]
        public IActionResult AddEdit(Activitys activity)
        {
            if (ModelState.IsValid)
            {
                if (activity.activityID == 0)
                {
                    // adds new activity
                    smithContext.Activities.Add(activity);
                    TempData["Message"] = "Activity added successfully!";
                }
                else
                {
                    smithContext.Activities.Update(activity);
                    TempData["Message"] = "Activity updated successfully!";
                }
                smithContext.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Log model state errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Debug.WriteLine(error.ErrorMessage);
                }
            }
            return View(activity);
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Activitys activity = smithContext.Activities.Find(id);
            return View(activity);
        }

        [HttpPost]
        public IActionResult Delete(Activitys activity)
        {
            smithContext.Activities.Remove(activity);
            smithContext.SaveChanges();
            TempData["Message"] = "Activity deleted successfully!";
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
