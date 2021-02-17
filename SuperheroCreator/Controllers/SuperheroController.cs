using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperheroCreator.Data;
using SuperheroCreator.Models;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var superheroes = _context.Superheroes;
            return View(superheroes);
        }

        //HttpGet

        public IActionResult Create()
        {
            return View();
        }

        //HttpPost
        [HttpPost]
        public IActionResult Create(Superhero superhero)
        {
            _context.Superheroes.Add(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
