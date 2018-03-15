using CourseManager.BOL.Model;
using Sellers.BOL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.WebUI.Controllers
{
    public class CourseController : Controller
    {
        IBolService<CourseDTO> courseService;

        public CourseController(IBolService<CourseDTO> DICourseService)
        {
            courseService = DICourseService;
        }
        
        // GET: Course
        public ActionResult Index()
        {
            var model = courseService.GetAll();
            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            CourseDTO model = (id == 0) ? new CourseDTO() : courseService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CourseDTO editCourse)
        {
            if (ModelState.IsValid)
            {
                courseService.AddOrUpdate(editCourse);
                return RedirectToAction("Index");
            }
            return View(editCourse);
        }
    }
}