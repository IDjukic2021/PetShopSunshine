using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetStoreSunshine.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetStoreSunshine.Data;

namespace PetStoreSunshine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbClassContext _context;


        public HomeController(ILogger<HomeController> logger, DbClassContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var aFood = _context.AnimalFood.ToList();

            //return View(aFood);
           
                List<Order> Order = _context.Order.ToList();
                List<Animal> Animal = _context.Animal.ToList();
                List<AnimalFood> AnimalFood = _context.AnimalFood.ToList();

                var employeeRecord = from e in Order
                                     join d in Animal on e.AnimalsId equals d.AnimalsId into table1
                                     from d in table1.ToList()
                                     join i in AnimalFood on e.AnimalFoodId equals i.AnimalFoodId into table2
                                     from i in table2.ToList()
                                     select new ViewModel
                                     {
                                         Order = e,
                                         Animal = d,
                                         AnimalFood = i
                                     };
                return View(employeeRecord);
            
        }


        public IActionResult Customer()
        {
            var korisnici = _context.User.ToList();
            return View(korisnici);

        }
        public IActionResult AnimalData()
        {
            var animals = _context.Animal.ToList();

            return View(animals);
            //return View();

        }
        public IActionResult Create(Animal obj)
        {
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Animal obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(obj.AnimalsId == 0)
                    {
                        _context.Add(obj);


                      await  _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("AnimalData");
                }
                return View(obj);
            }
            catch(Exception ex) 
            {
                return RedirectToAction("AnimalData");
            }         
        }
        public ActionResult Delete(int AnimalsId)
        {
            if (AnimalsId > 0)
            {
                var AnimalById = _context.Animal.Where(x => x.AnimalsId == AnimalsId).FirstOrDefault();
                if (AnimalById != null)
                {
                    _context.Entry(AnimalById).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AnimalData");
        }


/// Hrana za zivotinje dodavanje, edit i brisanje
        public IActionResult AnimalFood()
        {
            var aFood = _context.AnimalFood.ToList();

            return View(aFood);
            //return View();

        }
        public IActionResult CreateAnimalFood(AnimalFood obj)
        {
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnimalFoodAsync(AnimalFood obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.AnimalFoodId == 0)
                    {
                        _context.Add(obj);


                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("AnimalFood");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                return RedirectToAction("AnimalFood");
            }
        }

        public ActionResult DeleteAnimalFood(int AnimalFoodId)
        {
            if (AnimalFoodId > 0)
            {
                var AnimalFoodById = _context.AnimalFood.Where(x => x.AnimalFoodId == AnimalFoodId).FirstOrDefault();
                if (AnimalFoodById != null)
                {
                    _context.Entry(AnimalFoodById).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AnimalFood");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
