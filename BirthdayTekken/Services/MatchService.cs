using BirthdayTekken.Data;
using BirthdayTekken.Data.Base;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTekken.Services
{
    public class MatchService : EntityBaseRepository<Match>, IMatchService
    {
        private readonly AppDbContext _context;

        public MatchService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMatchAsync(NewMatchVm newMatchVm)
        {
            var newMatch = new Match
            {
                RoundNumber = newMatchVm.RoundNumber,
                WinnerId = newMatchVm.WinnerId
            };

            _context.Matches.Add(newMatch);
            await _context.SaveChangesAsync();

            var participantMatches = newMatchVm.ParticipantsIds.Select(participantId => new Participant_Match
            {
                MatchId = newMatch.Id,
                ParticipantId = participantId
            });

            _context.Participants_Matches.AddRange(participantMatches);
            await _context.SaveChangesAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            var matchDetails = await _context.Matches
                .Include(am => am.Participant_Matches)
                .ThenInclude(a => a.Participant)
                .FirstOrDefaultAsync(n => n.Id == id);

            return matchDetails;
        }

        public async Task<NewMatchDropdownsVM> GetNewMatchDropdownsValies()
        {
            var response = new NewMatchDropdownsVM()
            {
                Participants = await _context.Participants
                .OrderBy(n => n.Name)
                .ToListAsync()
            };

            return response;
        }

        public async Task<NewMatchDropdownsVM> GetRandomizedParticipantsList()
        {
            Random random = new Random();

            var response = new NewMatchDropdownsVM()
            {
                Participants = _context.Participants
                    .AsEnumerable()
                    .OrderBy(p => random.Next())
                    .ToList()
            };

            return response;
        }

        public async Task RemoveParticipantAsync(int participantId)
        {
            var participant = await _context.Matches.FindAsync(participantId);
            if (participant != null)
            {
                _context.Matches.Remove(participant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            var matches = await _context.Matches
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
        }

        public async Task AddRandomMatchAsync()
        {
            var participants = await GetRandomizedParticipantsList();

            if (participants.Participants.Count < 2)
            {
                throw new InvalidOperationException("There should be at least 2 participants in the database.");
            }

            var participant1 = participants.Participants[0];
            var participant2 = participants.Participants[1];

            var newMatch = new NewMatchVm()
            {
                RoundNumber = 1,
                WinnerId = 0,
                ParticipantsIds = new List<int> { participant1.Id, participant2.Id }
            };

            await AddNewMatchAsync(newMatch);
        }

        public async Task MakeTournamentLadder()
        {
            var participants = await GetRandomizedParticipantsList();

            if (participants.Participants.Count < 2)
            {
                throw new InvalidOperationException("There should be at least 2 participants in the database.");
            }

            if (participants.Participants.Count % 2 != 0)
            {
                throw new InvalidOperationException("The number of participants should be even.");
            }

            int numberOfMatches = participants.Participants.Count / 2;

            for (int i = 0; i < numberOfMatches; i++)
            {
                var participant1 = participants.Participants[i * 2];
                var participant2 = participants.Participants[i * 2 + 1];

                var newMatch = new NewMatchVm()
                {
                    RoundNumber = 1,
                    WinnerId = 0,
                    ParticipantsIds = new List<int> { participant1.Id, participant2.Id }
                };

                await AddNewMatchAsync(newMatch);
            }


        }

        public async Task<List<Match>> GetMatchesForSelectionAsync(int roundNumber)
        {
            var matches = await _context.Matches
                .Where(m => m.RoundNumber == roundNumber)
                .Include(m => m.Participant_Matches)
                .ThenInclude(pm => pm.Participant)
                .ToListAsync();

            return matches;
        }



    }
}
