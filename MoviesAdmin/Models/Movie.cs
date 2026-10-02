using System.ComponentModel.DataAnnotations;


namespace MoviesAdmin.Models
{
    public class Movie //id needed
    {
        [Required]
        public int ID { get; set; }// the Id

        [Required]
        public string Title { get; set; } = string.Empty;// The Title of the movie

     
        public string Rating { get; set; } = string.Empty;// The rating for the movie like pg 13+


        [Required]
        public string Description { get; set; } = string.Empty;// A small description for the movie

        [Required] 
        public string Genre { get; set; } = string.Empty;// The genre for the movie

        [Required]
        public int Runtime { get; set; }// Movie's runtime

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        
        public DateTime Releases {  get; set; } = DateTime.Now;// The date the movie came out


    }
}
