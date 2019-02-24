using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vmf2.Models
{
  public class Person
  {
    public int PersonId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public int MovieId { get; set; }
    public Movie FavoriteMovie { get; set; }
    public List<Movie> Movies { get; set; }
    public Person() { }
    public Person(int personId, string firstName, string lastName, int movieId)
    {
      PersonId = personId;
      FirstName = firstName;
      LastName = lastName;
      MovieId = movieId;
    }
  }
}