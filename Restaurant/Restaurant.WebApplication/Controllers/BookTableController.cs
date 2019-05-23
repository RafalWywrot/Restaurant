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
            var booktables = bookTableService.GetAll();
            return View(Mapper.Map<List<DiningTableViewModel>>(booktables));
        }
    }
}