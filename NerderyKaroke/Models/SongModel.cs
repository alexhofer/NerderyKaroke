using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaroke.Models
{
    public class SongModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Singer Name(s)")]
        [MaxLength(70)]
        public string SingerName { get; set; }

        [Required]
        [DisplayName("Song Title")]
        [MaxLength(100)]
        public string SongTitle { get; set; }
    }
}