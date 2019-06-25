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
    public class MenuController : Controller
    {
        private IMenuService menuService { get; }

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        // GET: Menu
        public ActionResult Index()
        {
            var menu = menuService.Get();
            return View();
        }
    }
}