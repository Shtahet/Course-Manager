using CourseManager.BOL.Model;
using Sellers.BOL.Abstract;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CourseManager.WebUI.Controllers
{
    public class ScheduleController : Controller
    {
        IBolService<ScheduleDTO> scheduleService;
        
        public ScheduleController(IBolService<ScheduleDTO> DIScheduleService)
        {
            scheduleService = DIScheduleService;
        }
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScheduleList (int courseID)
        {
            IEnumerable<ScheduleDTO> model = scheduleService.FindBy(s => s.CoursID == courseID);
            return PartialView(model);
        }
    }
}