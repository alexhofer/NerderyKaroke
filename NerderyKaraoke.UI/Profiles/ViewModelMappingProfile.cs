using AutoMapper;

using NerderyKaraoke.Core.Data.Models;
using NerderyKaraoke.UI.Models.SongRequest;

namespace NerderyKaraoke.UI.Profiles
{
	public class ViewModelMappingProfile : Profile
	{
		public ViewModelMappingProfile()
		{
			CreateMap<SongRequest, CreateViewModel>()
				.ReverseMap();
			CreateMap<SongRequest, EditViewModel>()
				.ReverseMap();
			CreateMap<SongRequest, DeleteViewModel>()
				.ReverseMap();
		}
	}
}