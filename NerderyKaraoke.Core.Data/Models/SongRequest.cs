using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaraoke.Core.Data.Models
{
    public class SongRequest : IHasId
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Singer Name(s)")]
        [MaxLength(70)]
        public string SingerName { get; set; }

        [Required]
        [DisplayName("SongRequest Title")]
        [MaxLength(100)]
        public string SongTitle { get; set; }

				[DisplayName("YouTube link")]
				[MaxLength(1024)]
				public string YouTubeUrl { get; set; }

				[Required]
				public int RequestOrder { get; set; }
    }
}