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
    public int FavoriteMovie { get; set; }
    public List<Movie> Movies { get; set; }
    public Person() { }
    public Person(int personId, string firstName, string lastName)
    {
      PersonId = personId;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}