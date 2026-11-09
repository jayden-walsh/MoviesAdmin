using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MoviesAdmin.Models
{
    public class catlogs
    {
        [Key]
        public int catlogId {  get; set; }

        // navigation property
        [ValidateNever]
        public List<Movie> Movies { get; set; } = new List<Movie>();

        [Required]
        public string Title { set; get; } = string.Empty;
        public int? ReivewsId { get; internal set; }
    }
}
