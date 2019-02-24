using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vmf2.Models;

namespace vmf2.Controllers
{
  public class HomeController : Controller
  {
    //....................................................................//
    // Some default properties provided that can be accessed inside your  // 
    // controller methods so you have data to work with - this data will  //
    // persist until you restart the server - the CreatePersonId and      // 
    // CreateMovieId are properties that will provide an incremented Id   //
    // when adding to this hardcoded data.                                //                   //
    //....................................................................//

    private static List<Person> AllPeople { get; set; } = new List<Person>()
    {
      new Person(1, "Bob", "Ross", 3),
      new Person(2, "Rob", "Boss", 2)
    };
    private static List<Movie> AllMovies { get; set; } = new List<Movie>()
    {
      new Movie(1, "The Rock", "Action", 1996),
      new Movie(2, "The Empire Strikes Back", "Science Fiction", 1980),
      new Movie(3, "When Harry Met Sally", "Comedy", 1989)
    };
    private int CreatePersonId => AllPeople.Count + 1;
    private int CreateMovieId => AllMovies.Count + 1;

    [HttpGet("")]
    public IActionResult Index()
    {
      return View(BuildDash());
    }

    [HttpGet("person/{personId}")]
    public IActionResult Person(int personId)
    {
      Person person = AllPeople.FirstOrDefault(p => p.PersonId == personId);
      person.FavoriteMovie = AllMovies.FirstOrDefault(m => m.MovieId == person.MovieId);
      return View("People", person);
    }

    [HttpGet("movie/{movieId}")]
    public IActionResult Movie(int movieId)
    {
      Movie movie = AllMovies.FirstOrDefault(m => m.MovieId == movieId);
      movie.Favorites = AllPeople.Where(p => p.MovieId == movieId).ToList().Count;
      return View("Movies", movie);
    }

    [HttpPost("newMovie")]
    public IActionResult NewMovie(Movie movie)
    {
      if (ModelState.IsValid)
      {
        movie.MovieId = CreateMovieId;
        AllMovies.Add(movie);
        return RedirectToAction("Index");
      }
      return View("Index", BuildDash());
    }

    [HttpPost("newPerson")]
    public IActionResult NewPerson(Person person)
    {
      if (ModelState.IsValid)
      {
        person.PersonId = CreatePersonId;
        AllPeople.Add(person);
        return RedirectToAction("Index");
      }
      return View("Index", BuildDash());
    }

    private Dashboard BuildDash()
    {
      return new Dashboard()
      {
        People = AllPeople,
        Movies = AllMovies,
        PersonForm = new Person()
        {
          Movies = AllMovies
        }
      };

    }
  }
}
