﻿using CourseManager.BOL.Model;
using CourseManager.WebUI.Models;
using Sellers.BOL.Abstract;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CourseManager.WebUI.Controllers
{
    public class ScheduleController : Controller
    {
        IBolService<ScheduleDTO> scheduleService;
        IBolService<CourseDTO> courseService;

        public ScheduleController(IBolService<ScheduleDTO> DIScheduleService, IBolService<CourseDTO> DICourseService)
        {
            scheduleService = DIScheduleService;
            courseService = DICourseService;
        }
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScheduleList(int courseID)
        {
            IEnumerable<ScheduleDTO> model = scheduleService.FindBy(s => s.CoursID == courseID);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Edit(int CourseID, int id = 0)
        {
            ScheduleDTO schedule = (id == 0) ? new ScheduleDTO() { CoursID = CourseID } : scheduleService.Get(id);
            WebSchedule model = new WebSchedule()
            {
                CoursID = schedule.CoursID,
                EndDate = schedule.EndDate,
                ScheduleID = schedule.ScheduleID,
                StartDate = schedule.StartDate
            };

            //Prepare DropDown list for days
            ViewBag.DayDDL = new SelectList(getWeekDays(), "DayNumber", "DayName", model.DayOfWeek);

            //Prepare DropDown list for hours
            ViewBag.HoursSLI = getHours();

            //Prepare DropDown list for minutes
            ViewBag.MinutesSLI = new[]
            {
                new SelectListItem{Value = "0", Text = "00" },
                new SelectListItem{Value = "15", Text = "15"},
                new SelectListItem{Value = "30", Text = "30"},
                new SelectListItem{Value = "45", Text = "45"}
            };

            //Information about course
            ViewBag.Course = courseService.Get(CourseID);

            return View(model);
        }

        [HttpPost]
        public string Edit(WebSchedule schedule)
        {
            return "Model is ready";
        }

        private List<DayWeek> getWeekDays()
        {
            List<DayWeek> tmpList = new List<DayWeek>();
            for (int i = 0; i < 7; ++i)
            {
                tmpList.Add(new DayWeek() { DayNumber = i });
            }
            return tmpList;
        }

        private List<SelectListItem> getHours()
        {
            List<SelectListItem> tmpList = new List<SelectListItem>();
            for (int i = 9; i <= 18; ++i)
            {
                SelectListItem currItem = new SelectListItem();
                currItem.Value = i.ToString();
                String itemText = "00" + i.ToString();
                currItem.Text = itemText.Substring(itemText.Length - 2);
                tmpList.Add(currItem);
            }

            return tmpList;
        }
    }
}