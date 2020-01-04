using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class TeamService : IService<Team>
    {
        M42Context _m42;
        public TeamService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Team> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Team Get(int id)
        {
            var teamData = GetTeam(id);
            var gamesData = GetTeamGames(id);
            var playoffGamesData = GetPlayoffGames(gamesData);
            var teamPeopleData = GetTeamPeople(id);
            var teamDraftPicksData = GetTeamDraftPicks(id);
            var hofersData = GetHOFers();

            var regularSeason = _m42.Games
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.WinningTeam)
                .Include(x => x.LosingTeam)
                .Where(x => x.GameTypeId == GameType.RegularSeason.Id && (x.HomeTeamId == id || x.AwayTeamId == id))
                .OrderBy(x => x.SortOrder)
                .ToList()
                .Select(x => new TeamGame
                {
                    Game = new Game {  Id = x.Id } ,
                    Opponent = new Team { Id = x.HomeTeamId != id ? x.HomeTeamId : x.AwayTeamId, Name = x.HomeTeamId != id ? x.HomeTeam.Name : x.AwayTeam.Name } ,
                    HomeAwayIndicator = x.HomeTeamId != id ? "@" : "vs" ,
                    WinLossIndicator = x.WinningTeamId == id ? "W" : "L" ,
                    Score = string.Format("{0} - {1}", x.WinningScore, x.LosingScore)
                })
                .ToList();

            var team = new Team
            {
                Id = teamData.Id,
                Identifier = teamData.Identifier,
                Name = teamData.ToString(),
                Franchise = new Franchise { Id = teamData.Franchise.Id, Name = teamData.Franchise.Organization.ToString() } ,
                Season = new Season { Id = teamData.Season.Id, Name = teamData.Season.ToString() } ,
                HeadCoach = BuildHeadCoach(teamPeopleData) ,
                Owner = BuildOwner(teamPeopleData) ,
                RegularSeason = regularSeason ,
                PlayoffGames = BuildPlayoffs(playoffGamesData),
                Roster = BuildTeamRoster(teamPeopleData) ,
                DraftPicks = BuildDraftPicks(teamDraftPicksData) ,
                HallOfFamers = BuildHOFers(teamPeopleData, hofersData)
            };

            return team;
        }
        public Team Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Team team)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Team team)
        {
            throw new MethodUnsupportedException();
        }

        #region Data Retrieval methods

        private M42.Data.Models.Team GetTeam(int id)
        {
            var team = _m42.Teams
                .Include(x => x.Season)
                .Include(x => x.Season.League)
                .Include(x => x.Franchise)
                .Include(x => x.Franchise.Organization)
                .SingleOrDefault(x => x.Id == id);

            if (team == null)
            {
                throw new EntityNotFoundException();
            }

            return team;
        }
        private List<M42.Data.Models.Game> GetTeamGames(int id)
        {
            var games = _m42.Games
               .Include(x => x.WinningTeam)
               .Include(x => x.LosingTeam)
               .Include(x => x.GameType)
               .Where(x => x.WinningTeamId == id || x.LosingTeamId == id)
               .ToList();

            return games;
        }
        private List<M42.Data.Models.Game> GetPlayoffGames(List<M42.Data.Models.Game> gamesData)
        {
            var playoffGamesData = gamesData
                .Where(x => x.GameTypeId != M42.Data.Models.GameType.RegularSeason.Id)
                .ToList();

            return playoffGamesData;
        }
        private List<M42.Data.Models.TeamPerson> GetTeamPeople(int id)
        {
            var teamPeople = _m42.TeamPeople
                .Include(x => x.Team)
                .Include(x => x.Person)
                .Include(x => x.TeamRole)
                .Where(x => x.TeamId == id).ToList();

            return teamPeople;
        }
        private List<M42.Data.Models.DraftPick> GetTeamDraftPicks(int id)
        {
            var teamDraftPicks = _m42.DraftPicks
                .Include(x => x.Person)
                .Include(x => x.Team)
                .Include(x => x.Draft)
                .Include(x => x.Draft.Season)
                .Where(x => x.TeamId == id)
                .ToList();

            return teamDraftPicks;
        }
        private List<M42.Data.Models.HOFer> GetHOFers()
        {
            var hofersData = _m42.HOFers
                .Include(x => x.HOF)
                .Include(x => x.HOF.Organization)
                .ToList();

            return hofersData;
        }
        #endregion

        #region Build methods

        private List<Person> BuildTeamRoster(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var roster = teamPeopleData
                .Where(x => x.TeamRoleId == M42.Data.Models.TeamRole.Player.Id)
                .Select(x => new Person
                {
                    Id = x.PersonId ,
                    Identifier = x.Person.Identifier ,
                    Name = x.Person.ToString()
                })
                .ToList();

            return roster;
        }
        private List<Game> BuildPlayoffs(List<M42.Data.Models.Game> gamesData)
        {
            var playoffGames = gamesData
               .OrderBy(x => x.GameType.SortOrder)
               .Select(x => new Game
               {
                   Id = x.Id,
                   Identifier = x.Id.ToString(),
                   Name = x.Title,
                   WinningTeam = new Team { Id = x.WinningTeam.Id, Name = string.Format("{0} {1}", x.WinningTeam.City, x.WinningTeam.Name) },
                   LosingTeam = new Team { Id = x.LosingTeam.Id, Name = string.Format("{0} {1}", x.LosingTeam.City, x.LosingTeam.Name) },
                   Score = string.Format("{0} - {1} {2}", x.WinningScore, x.LosingScore, x.OvertimeCount > 0 ? string.Format("({0} OT)", x.OvertimeCount) : ""),
                   WinningScore = x.WinningScore,
                   LosingScore = x.LosingScore
               })
               .ToList();

            return playoffGames;
        }

        private List<DraftPick> BuildDraftPicks(List<M42.Data.Models.DraftPick> teamDraftPicksData)
        {
            var teamDraftPicks = teamDraftPicksData
                .OrderBy(x => x.Pick)
                .Select(x => new DraftPick {
                    Id = x.Id ,
                    Identifier = x.Id.ToString() ,
                    Team = new Team { Id = x.Team.Id , Name = x.Team.ToString() } ,
                    Person = new Person {  Id = x.Person.Id, Name = x.Person.ToString() } ,
                    Draft = new Draft { Id = x.Draft.Id , Name = x.Draft.ToString() } ,
                    Round = x.Round ,
                    Pick = x.Pick ,
                    RoundWithSuffix = GetDraftRoundWithSuffix(x.Round)
                })
                .ToList();

            return teamDraftPicks;
        }
        private string GetDraftRoundWithSuffix (int round)
        {
            if (round == 1) return "1st";
            else if (round == 2) return "2nd";
            else if (round == 3) return "3rd";

            return string.Format("{0}{1}", round.ToString(), "th");
        }
        private Person BuildOwner(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var ownerData = teamPeopleData.SingleOrDefault(x => x.TeamRoleId == M42.Data.Models.TeamRole.Owner.Id);

            if (ownerData == null)
            {
                return null;
            }

            return new Person { Id = ownerData.PersonId, Name = ownerData.Person.ToString() };
        }
        private Person BuildHeadCoach(List<M42.Data.Models.TeamPerson> teamPeopleData)
        {
            var coachData = teamPeopleData.SingleOrDefault(x => x.TeamRoleId == M42.Data.Models.TeamRole.HeadCoach.Id);

            if (coachData == null)
            {
                return null;
            }

            return new Person { Id = coachData.PersonId, Name = coachData.Person.ToString() };
        }
        private List<HallOfFamer> BuildHOFers(List<M42.Data.Models.TeamPerson> teamPeopleData, List<M42.Data.Models.HOFer> hofersData)
        {
            var teamHOFers = new List<HallOfFamer>();

            foreach (var teamPerson in teamPeopleData)
            {
                var hofs = hofersData.Where(x => x.PersonId == teamPerson.Person.Id).ToList();

                foreach (var hof in hofs)
                {
                    var hallOfFamer = new HallOfFamer
                    {
                        Id = teamPerson.Person.Id,
                        Person = new Person
                        {
                            Id = teamPerson.Person.Id,
                            Name = teamPerson.Person.ToString()
                        },
                        HallOfFame = new HallOfFame
                        {
                            Id = hof.HOF.Id,
                            Name = hof.HOF.Organization.Name
                        }
                    };

                    teamHOFers.Add(hallOfFamer);
                }
            }

            return teamHOFers;
        }

        #endregion
    }
}
