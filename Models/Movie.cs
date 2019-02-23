namespace vmf2.Models
{
  public class Movie
  {
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public Movie(int movieId, string title, string genre, int releaseYear)
    {
      MovieId = movieId;
      Title = title;
      Genre = genre;
      ReleaseYear = releaseYear;
    }
  }
}