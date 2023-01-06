using BirthdayTekken.Enums;
using BirthdayTekken.Models;
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
                            ProfilePictureURL = "https://scontent.fpoz4-1.fna.fbcdn.net/v/t39.30808-6/317092652_6019952008063791_4790077157218633592_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=N4kpUaICxcQAX-uLZ0w&tn=6QNwtw5lZpqp66CL&_nc_ht=scontent.fpoz4-1.fna&oh=00_AfCghPU2QI3cx14B6gX3A94GrAT3OhWgwXxTVv9OrB0vDQ&oe=63B0E51E",
                            Name = "Piotr",
                            Surname = "Wisniewski",
                            Champion = Champion.JIN,
                            TournamentsWon = 1,
                        },
                         new Participant()
                        {
                            ProfilePictureURL = "https://scontent.fpoz4-1.fna.fbcdn.net/v/t39.30808-6/316964349_6019952181397107_981474565724572958_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=lLUaOzwJ0NEAX_TgH02&_nc_oc=AQmxqpOp-WGugHgmBX2SiVMDQAaO2Zw06RB-75YMByytNHGn3bWYiM6sVF9WYeYNsEI&_nc_ht=scontent.fpoz4-1.fna&oh=00_AfDHyMulkwcdeefcV7-L4XYKbD-dLqNzTKiiFqbM03yBQQ&oe=63B104CE",
                            Name = "Marta",
                            Surname = "Tomczak",
                            Champion = Champion.PANDA,
                            TournamentsWon = 0,
                        },
                          new Participant()
                        {
                            ProfilePictureURL = "https://scontent.fpoz4-1.fna.fbcdn.net/v/t39.30808-6/316950728_6019952661397059_5730168144704513589_n.jpg?_nc_cat=102&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=EBI5Xcja_B0AX9PSWhF&_nc_ht=scontent.fpoz4-1.fna&oh=00_AfAfbDur58C2Mv35BN9I96ScVTVP9sxwOtCdKmVc0QKsug&oe=63B1B9CA",
                            Name = "Angelika",
                            Surname = "Maciejewska",
                            Champion = Champion.EDDY,
                            TournamentsWon = 0,
                        },
                            new Participant()
                        {
                            ProfilePictureURL = "https://scontent.fpoz4-1.fna.fbcdn.net/v/t39.30808-6/316960447_6019952801397045_6561104795038909566_n.jpg?stp=dst-jpg_p75x225&_nc_cat=109&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=JNpz4hqsCmwAX9EQ-Je&_nc_ht=scontent.fpoz4-1.fna&oh=00_AfAzFoieqPc6n1eDjpz9wKyjss_YB0fa9ztUx47g6gBdYA&oe=63B1D59C",
                            Name = "Iwo",
                            Surname = "Brzyski",
                            Champion = Champion.BRYAN,
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
                            PlayersNumber = 8
                        },
                        new Tournament()
                        {
                            Name = "Party At Mazury",
                            TournamentDate = DateTime.Now.AddDays(-10),
                            WinnerId = 2,
                            PlayersNumber = 16
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
                    });
                    context.SaveChanges();
                }
            }
        }

    }
}
