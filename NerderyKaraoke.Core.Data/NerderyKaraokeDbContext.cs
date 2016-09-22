using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class NerderyKaraokeDbContext : DbContext
	{
		static NerderyKaraokeDbContext()
		{
			Database.SetInitializer<NerderyKaraokeDbContext>(null);
		}

		public NerderyKaraokeDbContext()
				: base("name=NerderyKaraokeDb")
		{
		}

		public IDbSet<SongRequest> Songs { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
