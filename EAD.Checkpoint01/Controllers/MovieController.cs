using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using EAD.Checkpoint01.Models;

namespace EAD.Checkpoint01.Controllers
{
    public class MovieController : Controller
    {
        private static readonly List<Movie> _db = new List<Movie>();
        private static int _id;

        public IActionResult Index()
        {
            return View(_db);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
                return View();

            movie.Id = ++_id;
            _db.Add(movie);
            TempData["msg"] = "Filme Cadastrado com sucesso! :D";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_db.Find(m => m.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
                return View();

            _db[_db.FindIndex(m => m.Id == movie.Id)] = movie;
            TempData["msg"] = "Filme atualizado com sucesso! :D";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.RemoveAll(m => m.Id == id);
            TempData["msg"] = "Filme removido com sucesso! :D";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_db.Find(m => m.Id == id));
        }

        [HttpGet]
        public IActionResult Search(int category)
        {
            var movies = Enum.IsDefined(typeof(Category), category) ? _db.Where(m => m.Category == (Category)category).ToList() : _db;
            return View("Index", movies);
        }
    }
}
