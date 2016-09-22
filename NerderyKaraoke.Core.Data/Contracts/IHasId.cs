using System;
using System.ComponentModel.DataAnnotations;

namespace NerderyKaraoke.Core.Data
{
	public interface IHasId
	{
		[Key]
		Guid Id { get; set; }
	}
}