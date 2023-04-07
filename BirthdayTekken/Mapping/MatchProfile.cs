using AutoMapper;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Match, NewMatchVm>()
        //    .ForMember(dest => dest.MatchId, opt => opt.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.ParticipantNames, opt => opt.MapFrom(src => src.Participant_Matches.Select(pm => pm.Participant.Name + " " + pm.Participant.Surname).ToList()));

        CreateMap<Match, NewMatchVm>()
        .ForMember(dest => dest.ParticipantNames,
               opt => opt.MapFrom(src => src.Participant_Matches.Select(pm => pm.Participant.Name + " " + pm.Participant.Surname).ToList()));
    }
}
