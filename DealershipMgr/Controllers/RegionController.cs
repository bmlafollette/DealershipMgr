using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealershipMgr.DAL;
using DealershipMgr.Models;
using DealershipMgr.ViewModels;
using System.Data.Entity.Infrastructure;

namespace DealershipMgr.Controllers
{
    public class RegionController : Controller
    {
        private DealerMgrContext db = new DealerMgrContext();

        // GET: Region
        public ActionResult Index(int? regionID, int? locationID)
        {
            var viewModel = new RegionIndexData();
            viewModel.Regions = db.Regions
                .Include(i => i.Locations.Select(c => c.Salespersons))
                .OrderBy(i => i.RegionName);

            if (regionID != null)
            {
                ViewBag.RegionID = regionID.Value;
                viewModel.Locations = viewModel.Regions.Where(
                    i => i.RegionID == regionID.Value).Single().Locations;
            }

            /*if (locationID != null)
            {
                ViewBag.LocationID = locationID.Value;
                // Lazy loading
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
                // Explicit loading
                var selectedLocation = viewModel.Locations.Where(x => x.LocationID == locationID).Single();
                db.Entry(selectedLocation).Collection(x => x.Enrollments).Load();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }*/

            return View(viewModel);
        }

        // GET: Region/Details/5
        public ActionResult Details(int? regionID)
        {
            if (regionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(regionID);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            var region = new Region();
            region.Locations = new List<Location>();
            PopulateAssignedLocationData(region);
            return View();
        }

        // POST: Region/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionID,RegionName,SalesYtd,SalesGoal,MetSalesGoal")] Region region)
        {
            /*if (selectedLocations != null)
            {
                region.Locations = new List<Location>();
                foreach (var location in selectedLocations)
                {
                    var locationToAdd = db.Locations.Find(int.Parse(location));
                    region.Locations.Add(locationToAdd);
                }
            }*/
            if (ModelState.IsValid)
            {
                db.Regions.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedLocationData(region);
            return View(region);
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int? regionID)
        {
            if (regionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions
                .Include(i => i.Locations)
                .Where(i => i.RegionID == regionID)
                .Single();
            PopulateAssignedLocationData(region);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // Provides info for the check box array using the AssignedCourseData view model class.
        private void PopulateAssignedLocationData(Region region)
        {
            var allLocations = db.Locations;
            var regionLocations = new HashSet<int>(region.Locations.Select(c => c.LocationID));
            var viewModel = new List<AssignedLocationData>();
            foreach (var location in allLocations)
            {
                viewModel.Add(new AssignedLocationData
                {
                    LocationID = location.LocationID,
                    LocationName = location.LocationName,
                    Assigned = regionLocations.Contains(location.LocationID)
                });
            }
            ViewBag.Courses = viewModel;
        }

        // POST: Region/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? regionID, string[] selectedLocations)
        {
            if (regionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var regionToUpdate = db.Regions
               .Include(i => i.Locations)
               .Where(i => i.RegionID == regionID)
               .Single();

            //if (TryUpdateModel(regionToUpdate, "",
            //   new string[] { "RegionName", "SalesYtd", "SalesGoal", "MetSalesGoal" }))
            //{
            //    try
            //    {
            //        if (String.IsNullOrWhiteSpace(regionToUpdate.Locations))
            //        {
            //            regionToUpdate.Locations = null;
            //        }

            //        UpdateRegionLocations(selectedLocations, regionToUpdate);

            //        db.SaveChanges();

            //        return RedirectToAction("Index");
            //    }
            //    catch (RetryLimitExceededException /* dex */)
            //    {
            //        //Log the error (uncomment dex variable name and add a line here to write a log.
            //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //    }
            //}
            PopulateAssignedLocationData(regionToUpdate);
            return View(regionToUpdate);
        }

        private void UpdateRegionLocations(string[] selectedLocations, Region regionToUpdate)
        {
            if (selectedLocations == null)
            {
                regionToUpdate.Locations = new List<Location>();
                return;
            }

            var selectedLocationsHS = new HashSet<string>(selectedLocations);
            var regionLocations = new HashSet<int>
                (regionToUpdate.Locations.Select(c => c.LocationID));
            foreach (var location in db.Locations)
            {
                if (selectedLocationsHS.Contains(location.LocationID.ToString()))
                {
                    if (!regionLocations.Contains(location.LocationID))
                    {
                        regionToUpdate.Locations.Add(location);
                    }
                }
                else
                {
                    if (regionLocations.Contains(location.LocationID))
                    {
                        regionToUpdate.Locations.Remove(location);
                    }
                }
            }
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Region/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = db.Regions
              .Where(i => i.RegionID == id)
              .Single();

            db.Regions.Remove(region);

            /*var department = db.Departments
                .Where(d => d.InstructorID == id)
                .SingleOrDefault();
            if (department != null)
            {
                department.InstructorID = null;
            }*/

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
