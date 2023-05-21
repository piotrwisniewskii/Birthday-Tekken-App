using BirthdayTekken.Enums;
using BirthdayTekken.Models;
using BirthdayTekken.Models.ViewModel;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace BirthdayTekken.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Participants
                if (!context.Participants.Any())
                {
                    context.Participants.AddRange(new List<Participant>()
                    {
                        new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\piotyr.jpg"),
                            Name = "Piotr",
                            Surname = "Wisniewski",
                            Champion = Champion.JIN,
                            TournamentsWon = 1,
                        },
                         new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\MartaTekken.jpg"),
                            Name = "Marta",
                            Surname = "Tomczak",
                            Champion = Champion.PANDA,
                            TournamentsWon = 0,
                        },
                          new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\angelika.jpg"),
                            Name = "Angelika",
                            Surname = "Maciejewska",
                            Champion = Champion.EDDY,
                            TournamentsWon = 0,
                        },
                            new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\iwo.jpg"),
                            Name = "Iwo",
                            Surname = "Brzyski",
                            Champion = Champion.BRYAN,
                            TournamentsWon = 1,
                        },
                              new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\wonz.jpg"),
                            Name = "Filip",
                            Surname = "Wonz",
                            Champion = Champion.ANNA,
                            TournamentsWon = 1,
                        },
                                new Participant()
                        {
                            ProfilePicture =System.IO.File.ReadAllBytes("wwwroot\\img\\łykasz.jpg"),
                            Name = "Łykasz",
                            Surname = "Martyński",
                            Champion = Champion.HWOARANG,
                            TournamentsWon = 1,
                        },
                    }) ;
                    context.SaveChanges();
                }


                //Tournaments
                if (!context.Tournaments.Any())
                {
                    context.Tournaments.AddRange(new List<Tournament>()
                    {
                        new Tournament()
                        {
                            Name = "Piotr's Birthday",
                            TournamentDate = DateTime.Now,
                            WinnerId = 1,
                        },
                        new Tournament()
                        {
                            Name = "Party At Mazury",
                            TournamentDate = DateTime.Now.AddDays(-10),
                            WinnerId = 2,
                        },
                });
                    context.SaveChanges();
                }


                //Participants & Tournamnents
                if (!context.Participants_Tournaments.Any())
                {
                    context.Participants_Tournaments.AddRange(new List<Participant_Tournament>()
                    {
                        new Participant_Tournament()
                        {
                            TournamentId = 1,
                            ParticipantId = 1,
                        },
                        new Participant_Tournament()
                        {
                            TournamentId = 1,
                            ParticipantId = 2,
                        },
                        new Participant_Tournament()
                        {
                            TournamentId = 1,
                            ParticipantId = 3,
                        },
                        new Participant_Tournament()
                        {
                            TournamentId = 2,
                            ParticipantId = 3,
                        },
                        new Participant_Tournament()
                        {
                            TournamentId = 2,
                            ParticipantId = 4,
                        },
                    }) ;
                    context.SaveChanges();
                }
            }
        }

    }
}
