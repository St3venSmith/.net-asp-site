﻿using System.Diagnostics;
using InClass6s.Models;
using Microsoft.AspNetCore.Mvc;

namespace InClass6s.Controllers
{
    public class AdminController : Controller
    {
        private readonly SmithContext smithContext;
        private readonly SessionCookieHelper sessionCookieHelper;

        public AdminController(SmithContext smithContext, SessionCookieHelper sessionCookieHelper)
        {
            this.smithContext = smithContext;
            this.sessionCookieHelper = sessionCookieHelper;
        }

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
                    // Adds new activity
                    smithContext.Activities.Add(activity);
                    TempData["Message"] = "Activity added successfully!";
                }
                else
                {
                    // Updates existing activity
                    smithContext.Activities.Update(activity);
                    TempData["Message"] = "Activity updated successfully!";
                }

                smithContext.SaveChanges();

                // Update the LastEditedActivity cookie
                sessionCookieHelper.SetCookie("LastEditedActivity", activity.activityName, 30); // Expires in 30 minutes

                // Update the RecentActivities session
                var recentActivities = sessionCookieHelper.GetSession<List<Activitys>>("RecentActivities") ?? new List<Activitys>();

                // Add the current activity to the recent activities list
                recentActivities.Add(activity);

                // Limit the list to the last 5 activities
                if (recentActivities.Count > 5)
                {
                    recentActivities = recentActivities.Skip(recentActivities.Count - 5).ToList();
                }

                sessionCookieHelper.SetSession("RecentActivities", recentActivities);

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

        // Add to Favorites
        public IActionResult AddToFavorites(int id)
        {
            // Retrieve the favorites list from Session
            var favorites = sessionCookieHelper.GetSession<List<int>>("Favorites") ?? new List<int>();

            if (!favorites.Contains(id))
            {
                favorites.Add(id);
                sessionCookieHelper.SetSession("Favorites", favorites);
                TempData["Message"] = "Activity added to favorites!";
            }
            else
            {
                TempData["Message"] = "Activity is already in favorites!";
            }

            return RedirectToAction("Index");
        }

        // View Favorites
        public IActionResult ViewFavorites()
        {
            // Retrieve the favorites list from Session
            var favorites = sessionCookieHelper.GetSession<List<int>>("Favorites") ?? new List<int>();
            var favoriteActivities = smithContext.Activities.Where(a => favorites.Contains(a.activityID)).ToList();

            // Retrieve the recently added or edited activities from the session
            var recentActivities = sessionCookieHelper.GetSession<List<Activitys>>("RecentActivities") ?? new List<Activitys>();

            // Pass both lists to the view using ViewData
            ViewData["RecentActivities"] = recentActivities;

            return View(favoriteActivities);
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
