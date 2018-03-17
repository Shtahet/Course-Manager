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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CourseDTO tmpCourse = courseService.Get(id);
            if (tmpCourse != null)
            {
                try
                {
                    courseService.Delete(tmpCourse.CoursID);
                    return Json("OK");
                }
                catch (Exception ex)
                {
                    Exception firstEx = ex;
                    while (firstEx.InnerException != null)
                    {
                        firstEx = firstEx.InnerException;
                    }
                    if (firstEx is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.Conflict;
                        return Json(new
                        {
                            status = System.Net.HttpStatusCode.Conflict,
                            exeption = "Ошибка удаления",
                            message = "Невозможно удалить запись, так как на нее ссылаются другие источники"
                        });
                    }
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Conflict, ex.Message);
                }

            }

            return Json("BAD");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            CourseDTO model = courseService.Get(id);
            return View(model);
        }
    }
}