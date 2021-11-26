using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetStoreSunshine.Models;
using PetStoreSunshine.Data;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreSunshine.Controllers
{
    public class NewDataController : Controller
    {
        private readonly DbClassContext _cc;
        public NewDataController(DbClassContext cc)
        {
            _cc = cc;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Animal animal)
        //{
        //    _cc.Add(animal);

        //    _cc.SaveChanges();

        //    return View();
        //}

    }
}
