using AutoMapper;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Services.Abstract;
using Restaurant.WebApplication.Helpers;
using Restaurant.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private IReservationDiningTableService reservationDiningTableService { get; }

        private AuthenticationUserManager authenticationUserManager;

        //private AuthenticationUserManager authenticationUserManager { get; }
        public ReservationsController(IReservationDiningTableService reservationDiningTableService, AuthenticationUserManager authenticationUserManager)
        {
            this.reservationDiningTableService = reservationDiningTableService;
            this.authenticationUserManager = authenticationUserManager;
        }
        // GET: Reservations
        public ActionResult Index()
        {
            //Mapper.Map<List<ReservationDiningTableDTO>>(allReservations);
//var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());
            string userId = User.Identity.GetUserId();
            var model = new ReservationTableFormViewModel()
            {
                Reservations = Mapper.Map<List<ReservationViewModel>>(reservationDiningTableService.GetReservations(userId))
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CancelReservation(int reservationId)
        {
            var currentUser = authenticationUserManager.Users.First(x => x.Id == User.Identity.GetUserId());

            try
            {
                reservationDiningTableService.CancelReservation(reservationId);
                TempData["message"] = "Udało się usunąć rezerwację";
            }
            catch (Exception e)
            {
                TempData["error"] = "Błąd przy usunięciu rezerwacji";
            }

            return RedirectToAction("Index");
        }
        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
