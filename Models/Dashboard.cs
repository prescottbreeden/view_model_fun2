using System.Collections.Generic;

namespace vmf2.Models
{
  public class Dashboard
  {
    public List<Movie> Movies { get; set; }
    public List<Person> People { get; set; }
    public Movie MovieForm { get; set; }
    public Person PersonForm { get; set; }
    public int PersonId { get; set; }
    public int MovieId { get; set; }
  }
}