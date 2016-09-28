using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaraoke.UI.Models.SongRequest
{
	public class CreateViewModel
	{
		[Required]
		[DisplayName("Singer Name(s)")]
		public string SingerName { get; set; }

		[Required]
		[DisplayName("Song Title")]
		public string SongTitle { get; set; }

		[DisplayName("YouTube link")]
		public string YouTubeUrl { get; set; }
	}
}