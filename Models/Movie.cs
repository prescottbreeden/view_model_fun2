using System.ComponentModel.DataAnnotations;

namespace vmf2.Models
{
  public class Movie
  {
    public int MovieId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Range(1900, 2020)]
    public int ReleaseYear { get; set; }
    public Movie() { }
    public Movie(int movieId, string title, string genre, int releaseYear)
    {
      MovieId = movieId;
      Title = title;
      Genre = genre;
      ReleaseYear = releaseYear;
    }
  }
}