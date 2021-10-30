using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First.API.Model
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("author")]
        [Required]
        public string Author { get; set; }

        [Column("launch_date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Column("price")]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }
    }
}
