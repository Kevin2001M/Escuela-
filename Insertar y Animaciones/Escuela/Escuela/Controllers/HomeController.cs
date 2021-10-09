﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;
using Escuela.Migrations;
using Escuela.Models;
using Escuela.Repositorio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourse icourse;

        public HomeController(ILogger<HomeController> logger, ICourse icourses)
        {
            this.icourse = icourses;
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

     
    public IActionResult Index(string Title, int Credits)
        {
            Course course = new Course();
            course.Title = Title;
            course.Credits = Credits;
            icourse.Insertar(course);

            //course.CouserId = 10;
            //course.Title = "POO";
            //course.Credits = 100;
            //icourse.Insertar(course);

            return View();
        }


        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();


            return Json(new { data = DandoFormatoJson });
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
