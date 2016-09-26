using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NerderyKaraoke.Core.Data.Models
{
	public class UserRole
	{
		[Key, Column(Order = 0)]
		public string UserName { get; set; }

		[Key, Column(Order = 1)]
		public string Role { get; set; }
	}
}
