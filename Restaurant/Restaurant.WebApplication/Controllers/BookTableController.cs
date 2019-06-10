using AutoMapper;
using Restaurant.Domain.Services.Abstract;
using Restaurant.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    public class BookTableController : Controller
    {
        private IBookTableService bookTableService { get; }
        public BookTableController(IBookTableService bookTableService)
        {
            this.bookTableService = bookTableService;
        }


        // GET: BookTable
        public ActionResult Index()
        {
            var model = new DiningTableFormViewModel()
            {
                ChairsOptions = Mapper.Map<List<SelectListItem>>(bookTableService.GetChairsOptions().OrderBy(x => x))
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DiningTableFormViewModel model)
        {
            var startDate = new DateTime(model.StartDate.Year, model.StartDate.Month, model.StartDate.Day, model.StartTime.Hour, model.StartTime.Minute, 0);
            var endDate = new DateTime(model.StartDate.Year, model.StartDate.Month, model.StartDate.Day, model.EndTime.Hour, model.EndTime.Minute, 0);
            var availableTables = bookTableService.GetAvailableTables(model.SelectedNumberOfChairs, startDate, endDate);
            model.ChairsOptions = Mapper.Map<List<SelectListItem>>(bookTableService.GetChairsOptions());
            model.AvailableTables = Mapper.Map<List<DiningTableViewModel>>(availableTables);
            foreach (var avalaibleTable in model.AvailableTables)
            {
                avalaibleTable.StartDate = startDate;
                avalaibleTable.EndDate = endDate;
            }
            return View(model);
        }

        //add view to confirm reservation and update ReservationDiningTable in HttpPost
        [HttpGet]
        public ActionResult ReserveTable(int id, DateTime startDate, DateTime endDate)
        {
            bookTableService.ReserveTable(id, startDate, endDate);
            
            return RedirectToAction("Index");
        }
    }
}