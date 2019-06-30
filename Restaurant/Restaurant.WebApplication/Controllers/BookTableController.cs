using AutoMapper;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Services.Abstract;
using Restaurant.WebApplication.Helpers;
using Restaurant.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    [Authorize]
    public class BookTableController : Controller
    {
        private IBookTableService bookTableService { get; }       
        private AuthenticationUserManager authenticationUserManager { get; }
        public BookTableController(IBookTableService bookTableService, AuthenticationUserManager authenticationUserManager)
        {
            this.bookTableService = bookTableService;
            this.authenticationUserManager = authenticationUserManager;
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

        [HttpPost]
        public ActionResult ReserveTable(int tableId, DateTime startDate, DateTime endDate)
        {
            var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());

            try
            {
                bookTableService.ReserveTable(tableId, startDate, endDate, currentUser);
                TempData["message"] = "Udało się zarezerwować stolik";
            }
            catch (Exception e)
            {
                TempData["error"] = "Błąd przy zapisie rezerwacji";
            }       

            return RedirectToAction("Index");
        }
    }
}