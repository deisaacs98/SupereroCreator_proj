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
            return View("List", superheroes);
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

        //HttpGet
        public IActionResult Delete(int id)
        {
            Superhero superhero=_context.Superheroes.Find(id);
            return View(superhero);
        }

        //HttpPost
        [HttpPost]
        public IActionResult Delete(Superhero superhero)
        {
            _context.Superheroes.Remove(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //HttpGet
        public IActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        //HttpPost
        [HttpPost]
        public IActionResult Edit(Superhero superhero)
        {
            _context.Superheroes.Update(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //HttpGet
        public IActionResult Details(int id)
        {
            Superhero superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }

        //HttpPost
        [HttpPost]
        public IActionResult Details(Superhero superhero)
        {
            return RedirectToAction("Index");
        }

    }
}
