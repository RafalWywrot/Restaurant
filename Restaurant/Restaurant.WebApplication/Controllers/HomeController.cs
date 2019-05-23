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
        
        public HomeController(ITestService testService)
        {
            _testService = testService;
            
        }

        public ActionResult Index()
        {
            var tests = Mapper.Map<List<TestViewModel>>(_testService.aa());
            return View();
        }
    }
}