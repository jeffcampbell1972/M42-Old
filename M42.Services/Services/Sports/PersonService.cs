using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M42.Sports
{
    public class PersonService : IService<Person>
    {
        M42Context _m42;
        public PersonService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Person> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Person Get(int id)
        {
            var personData = GetPerson(id);
            var teamPeopleData = GetTeamPeople(id);
            var leagueCommissionerSeasonsData = _m42.Seasons
                .Include(x => x.League)
                .Where(x => x.CommissionerId == id).ToList();

            var leagueCommissionerSeasons = leagueCommissionerSeasonsData.OrderBy(x => x.Year).Select(x => new Season { Id = x.Id, Name = x.ToString() }).ToList();
            var draftPicksData = _m42.DraftPicks
                .Include(x => x.Draft)
                .Include(x => x.Draft.Season)
                .Include(x => x.Draft.Season.League)
                .Where(x => x.PersonId == id).ToList();

            var draftPicks = draftPicksData.Select(x => new DraftPick
            {
                Id = x.Id,
                Description = string.Format("Round {0} Pick #{1}", 
                    x.Round, 
                    x.Pick ) ,
                
                Team = new Team {  
                    Id = x.Team.Id , 
                    Name = x.Team.ToString() 
                }
            })
            .ToList();

            var person = new Person
            {
                Id = personData.Id,
                Identifier = personData.Identifier,
                DOB = personData.BirthDate ,
                DOD = personData.DeathDate ,
                Name = personData.ToString() ,
                FullName = BuildFullName(personData),
                PlayerTeams = BuildPlayerTeams(teamPeopleData),
                CoachTeams = BuildCoachTeams(teamPeopleData),
                OwnerTeams = BuildOwnerTeams(teamPeopleData) ,
                LeagueCommissionerSeasons = leagueCommissionerSeasons ,
                Drafts = draftPicks
            };

            return person;
        }
        public Person Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Person person)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Person person)
        {
            throw new MethodUnsupportedException();
        }

        #region Get methods

        public M42.Data.Models.Person GetPerson(int id)
        {
            var personData = _m42.People
               .SingleOrDefault(x => x.Id == id);

            if (personData == null)
            {
                throw new EntityNotFoundException();
            }

            return personData;
        }
        public List<M42.Data.Models.TeamPerson> GetTeamPeople(int personId)
        {
            var teamPeople = _m42.TeamPeople
                .Include(x => x.Team)
                .Include(x => x.Team.Season)
                .Include(x => x.Person)
                .Include(x => x.TeamRole)
                .Where(x => x.PersonId == personId)
                .ToList();

            return teamPeople;
        }

        #endregion

        #region Build methods

        public string BuildFullName(M42.Data.Models.Person personData)
        {
            var nameBuilder = new StringBuilder();

            if (personData.FirstName != "")
            {
                nameBuilder.Append(personData.FirstName);
            }
            if (personData.MiddleName != "")
            {
                if (nameBuilder.ToString() != "")
                {
                    nameBuilder.Append(" ");
                }
                nameBuilder.Append(personData.MiddleName);
            }
            if (personData.LastName != "")
            {
                if (nameBuilder.ToString() != "")
                {
                    nameBuilder.Append(" ");
                }
                nameBuilder.Append(personData.LastName);
            }

            return nameBuilder.ToString();
        }
        public List<Team> BuildPlayerTeams(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var teams = teamPeopleData
                .Where(x => x.TeamRoleId == M42.Data.Models.TeamRole.Player.Id)
                .OrderBy(x => x.Team.Season.Year)
                .Select(x => new Team
                {
                    Id = x.TeamId ,
                    Identifier = x.Team.Identifier ,
                    Name = x.Team.ToString()
                })
                .ToList();

            return teams;
        }
        public List<Team> BuildCoachTeams(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var teams = teamPeopleData
                .Where(x => x.TeamRoleId == M42.Data.Models.TeamRole.HeadCoach.Id)
                .OrderBy(x => x.Team.Season.Year)
                .Select(x => new Team
                {
                    Id = x.TeamId,
                    Identifier = x.Team.Identifier,
                    Name = x.Team.ToString()
                })
                .ToList();

            return teams;
        }
        public List<Team> BuildOwnerTeams(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var teams = teamPeopleData
                .Where(x => x.TeamRoleId == M42.Data.Models.TeamRole.Owner.Id)
                .OrderBy(x => x.Team.Season.Year)
                .Select(x => new Team
                {
                    Id = x.TeamId,
                    Identifier = x.Team.Identifier,
                    Name = x.Team.ToString()
                })
                .ToList();

            return teams;
        }

        #endregion
    }
}
