namespace MoviesAdmin.Models
{
    public class Movie
    {
        public string Title { get; set; } = string.Empty;// The Title of the movie

        public string rating { get; set; } = string.Empty;// The rating for the movie like pg 13+

        public string description { get; set; } = string.Empty;// A small description for the movie

        public string genre { get; set; } = string.Empty;// The genre for the movie

        public float runtime { get; set; }// Movie's runtime

        public DateTime releases {  get; set; } = DateTime.Now;// The date the movie came out 


    }
}
