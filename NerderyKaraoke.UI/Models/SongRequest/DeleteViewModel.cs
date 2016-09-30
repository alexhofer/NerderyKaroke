using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaraoke.UI.Models.SongRequest
{
	public class DeleteViewModel
	{
		[Required]
		public Guid Id { get; set; }

		[DisplayName("Singer Name(s)")]
		public string SingerName { get; set; }

		[DisplayName("Song Title")]
		public string SongTitle { get; set; }

		[DisplayName("YouTube link")]
		public string YouTubeUrl { get; set; }
	}
}