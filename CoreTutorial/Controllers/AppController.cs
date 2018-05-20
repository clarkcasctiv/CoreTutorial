using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTutorial.Data;
using CoreTutorial.Services;
using CoreTutorial.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CoreTutorial.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService _mailService;
        private readonly IArtRepository _repository;

        public AppController(INullMailService mailService, IArtRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("pujanisme@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message:{model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public IActionResult Shop()
        {
            //var results = _context.Products.
            //    OrderBy(p => p.Category).ToList();
            //return View();

            //var results = from p in _context.Products
            //              orderby p.Category
            //              select p;

            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}