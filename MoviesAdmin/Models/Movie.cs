namespace MoviesAdmin.Models
{
    public class Movie //id needed
    {
        public string Title { get; set; } = string.Empty;// The Title of the movie

        public string Rating { get; set; } = string.Empty;// The rating for the movie like pg 13+

        public string Description { get; set; } = string.Empty;// A small description for the movie

        public string Genre { get; set; } = string.Empty;// The genre for the movie

        public int Runtime { get; set; }// Movie's runtime

        public DateTime Releases {  get; set; } = DateTime.Now;// The date the movie came out


    }
}
