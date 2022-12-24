using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Service;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        
        /*
        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }
        */

        // GET: Movies
        public async Task<IActionResult> Index(string searchString)
        {
            MovieService movie = new MovieService();
            var result = await movie.GetALL();
            //return View(result);

            if (!String.IsNullOrEmpty(searchString))
            { 
                var movies1 = await movie.SearchMovie(searchString);
                //movies = movies.Where(s => s.Title!.Contains(searchString));
                return View(movies1);
            }
            return View(result);
            

        }
        
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            MovieService detil = new MovieService();
            var hasil = await detil.DetailMovie(id);
            
            
            
            //if (id == null || _context.Movie == null)
            //{
            //    return NotFound();
            //}

            //var detil = await _context.Movie
            //     .FirstOrDefaultAsync(m => m.Id == id);
            if (detil == null)
            {
                return NotFound();
            }

            return View(hasil);
            
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            MovieService detil = new MovieService();
            MovieService film = new MovieService();
            await film.InsertMovie(movie);
            return RedirectToAction("Index");
        }

        // GET: Movies/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {

            //if (id == null || _context.movie == null)
            //{
            //    return notfound();
            //}

            //var movie = await _context.movie.findasync(id);
            //if (movie == null)
            //{
            //    return notfound();
            //}
            MovieService detil = new MovieService();
            var hasil = await detil.DetailMovie(id);
            return View(hasil);

        }
        

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            //if (id != movie.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(movie);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MovieExists(movie.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(movie);
            MovieService film2 = new MovieService();
            await film2.EditMovie(id, movie);
            return RedirectToAction("Index");

        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Movie == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movie
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //return View(movie);
            MovieService detil3 = new MovieService();
            var hasil3 = await detil3.DetailMovie(id);
            return View(hasil3);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Movie == null)
            //{
            //    return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            //}
            //var movie = await _context.Movie.FindAsync(id);
            //if (movie != null)
            //{
            //    _context.Movie.Remove(movie);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            MovieService film5 = new MovieService();
            await film5.DeleteMovie(id);
            return RedirectToAction("Index");

        }

        private bool MovieExists(int id)
        {
          return _context.Movie.Any(e => e.Id == id);
        }
        
    }
}
