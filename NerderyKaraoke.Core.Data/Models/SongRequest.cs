using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NerderyKaraoke.Core.Data.Models
{
		public class SongRequest : IHasId
		{
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public Guid Id { get; set; }

			[Required]
			[MaxLength(70)]
			public string SingerName { get; set; }

			[Required]
			[MaxLength(100)]
			public string SongTitle { get; set; }

			[MaxLength(1024)]
			public string YouTubeUrl { get; set; }

			[Required]
			public int RequestOrder { get; set; }

			[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
			public DateTime CreateDateTime { get; set; }
		}
}