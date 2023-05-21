using AutoMapper;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Match, NewMatchVm>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RoundNumber, opt => opt.MapFrom(src => src.RoundNumber))
            .ForMember(dest => dest.ParticipantsIds, opt => opt.MapFrom(src => src.Participant_Matches.Select(p => p.ParticipantId)))
            .ForMember(dest => dest.ParticipantNames, opt => opt.MapFrom(src => src.Participant_Matches.Select(p => p.Participant.Name)));

        CreateMap<Tournament, TournamentMatchesViewModel>()
            .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches));
    }
}
