using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("POST")]
    public class Movie : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDisLikes { get; set; }
        public int NumberOfViews { get; set; }
        public double PlayingTime { get; set; }

        public Movie()
        {
        }
        public Movie(int id, string title, int numberOfLikes, int numberOfDisLikes, int numberOfViews, double playingTime)
        {
            Id = id;
            Title = title;
            NumberOfLikes = numberOfLikes;
            NumberOfDisLikes = numberOfDisLikes;
            NumberOfViews = numberOfViews;
            PlayingTime = playingTime;
        }

        
    }
}
