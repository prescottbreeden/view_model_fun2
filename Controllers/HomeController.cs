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
    // controller methods so you have some data to work with              //
    //....................................................................//

    private static List<Person> AllPeople { get; set; } = new List<Person>()
    {
      new Person(1, "Bob", "Ross"),
      new Person(2, "Rob", "Boss")
    };

    private static List<Movie> AllMovies { get; set; } = new List<Movie>()
    {
      new Movie(1, "The Rock", "Action", 1996),
      new Movie(2, "The Empire Strikes Back", "Science Fiction", 1980),
      new Movie(3, "When Harry Met Sally", "Comedy", 1989)
    };

    [HttpGet("")]
    public IActionResult Index()
    {
      Dashboard dash = BuildDash();
      return View(dash);
    }

    [HttpGet("person/{personId}")]
    public IActionResult Person(int personId)
    {
      foreach (Person person in AllPeople)
      {
        if (person.PersonId == personId)
          return View("People", person);
      }
      return RedirectToAction("Index");
    }

    [HttpGet("movie/{movieId}")]
    public IActionResult Movie(int movieId)
    {
      foreach (Movie movie in AllMovies)
      {
        if (movie.MovieId == movieId)
          return View("Movies", movie);
      }
      return RedirectToAction("Index");
    }

    [HttpPost("newMovie")]
    public IActionResult NewMovie(Movie movie)
    {
      if (ModelState.IsValid)
      {
        int count = AllMovies.Count;
        movie.MovieId = ++count;
        AllMovies.Add(movie);
        return RedirectToAction("Index");
      }
      Dashboard dash = BuildDash();
      return View("Index", dash);
    }

    [HttpPost("newPerson")]
    public IActionResult NewPerson(Person person)
    {
      if (ModelState.IsValid)
      {
        int count = AllPeople.Count;
        person.PersonId = ++count;
        AllPeople.Add(person);
        return RedirectToAction("Index");
      }
      Dashboard dash = BuildDash();
      return View("Index", dash);
    }

    private Dashboard BuildDash()
    {
      return new Dashboard()
      {
        People = AllPeople,
        Movies = AllMovies,
        PersonId = AllPeople.Count,
        MovieId = AllMovies.Count,
        PersonForm = new Person()
        {
          Movies = AllMovies
        }
      };

    }
  }
}
