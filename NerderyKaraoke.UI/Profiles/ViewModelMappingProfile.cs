using AutoMapper;

using NerderyKaraoke.Core.Data.Models;
using NerderyKaraoke.UI.Models.Shared;

namespace NerderyKaraoke.UI.Profiles
{
	public class ViewModelMappingProfile : Profile
	{
		public ViewModelMappingProfile()
		{
			CreateMap<SongRequest, SongRequestViewModel>()
				.ReverseMap();
		}
	}
}