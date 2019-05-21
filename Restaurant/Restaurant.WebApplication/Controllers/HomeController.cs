using AutoMapper;
using Restaurant.Database;
using Restaurant.Domain.Services.Abstract;
using Restaurant.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ITestService _testService { get; }
        private IMapper _mapper { get; }

        public HomeController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var tests = _mapper.Map<List<TestViewModel>>(_testService.aa());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}