using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaraoke.UI.Models.Shared
{
	public class SongRequestViewModel
	{
		public Guid Id { get; set; }

		[Required]
		[DisplayName("Singer Name(s)")]
		public string SingerName { get; set; }

		[Required]
		[DisplayName("Song Title")]
		public string SongTitle { get; set; }

		[DisplayName("YouTube link")]
		public string YouTubeUrl { get; set; }

		public int RequestOrder { get; set; }
	}
}