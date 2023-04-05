﻿using BirthdayTekken.Data;
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

        public async Task AddNewMatchAsync(NewMatchVm data)
        {
            var newMatch = new Match()
            {
                RoundNumber = data.RoundNumber,
                WinnerId = data.WinnerId,
            };
            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();

            foreach (var participantId in data.ParticipantsIds)
            {
                var newParticipantMatch = new Participant_Match()
                {
                    MatchId = newMatch.Id,
                    ParticipantId = participantId
                };
                await _context.Participants_Matches
                    .AddAsync(newParticipantMatch);
            }
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
    }
}
