using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace M42.Sports
{
    public class LeagueService : IService<League>
    {
        M42Context _m42;
        public LeagueService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<League> Get()
        {
            throw new MethodUnsupportedException();
        }
        public League Get(int id)
        {
            var leagueData = GetLeague(id);
            var seasonsData = GetLeagueSeasons(id);

            var currentSeasonData = GetCurrentSeason(seasonsData);
            var teamsData = GetCurrentSeasonTeams(currentSeasonData);
            var draftPicksData = GetDraftPicks(currentSeasonData);
            var awardsData = GetAwards();

            var league = new League
            {
                Id = leagueData.Id,
                Identifier = leagueData.Organization.Identifier,
                Name = leagueData.Organization.Name,
                Abbreviation = leagueData.Abbreviation,
                YearEstablished = leagueData.Organization.YearEstablished,
                YearEnded = leagueData.Organization.YearEnded,
                NumFranchises = currentSeasonData.NumTeams,
                NumGames = currentSeasonData.NumGames,
                Commissioner = BuildCommissioner(currentSeasonData),
                Sport = BuildSport(leagueData),
                Seasons = BuildSeasons(seasonsData, currentSeasonData),
                Conferences = BuildConferences(teamsData),
                Franchises = BuildLeagueFranchises(teamsData),
                Championships = BuildChampionships(id),
                Draft = BuildDraft(currentSeasonData, draftPicksData)
            };

            return league;
        }
        public League Get(string identifier)
        {
            var league = _m42.Leagues.Include(x => x.Organization).SingleOrDefault(x => x.Organization.Identifier == identifier);

            if (league == null)
            {
                throw new Exception("Invalid League Identifier ");
            }

            //return Get(league.Id);

            return new League { Id = league.Id, Name = league.Abbreviation };
        }
        public void Post(League league)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, League league)
        {
            throw new MethodUnsupportedException();
        }

        #region Data Retrieval

        public M42.Data.Models.League GetLeague(int id)
        {
            var leagueData = _m42.Leagues
                .Include(x => x.Organization)
                .Include(x => x.Sport)
                .SingleOrDefault(x => x.Id == id);

            if (leagueData == null)
            {
                throw new EntityNotFoundException();
            }

            return leagueData;
        }
        public List<M42.Data.Models.Season> GetLeagueSeasons(int id)
        {
            var seasonsData = _m42.Seasons
                .Include(x => x.Commissioner)
                .Where(x => x.LeagueId == id)
                .OrderByDescending(x => x.Year)
                .ToList();

            return seasonsData;
        }
        public M42.Data.Models.Season GetCurrentSeason(List<M42.Data.Models.Season> seasonsData)
        {
            var currentSeasonData = seasonsData.FirstOrDefault();

            return currentSeasonData;
        }
        public List<M42.Data.Models.Team> GetCurrentSeasonTeams(M42.Data.Models.Season currentSeasonData)
        {
            if (currentSeasonData == null)
            { 
                return null;
            }
            var teamsData = _m42.Teams
                .Include(x => x.Franchise)
                .Include(x => x.Franchise.Organization)
                .Include(x => x.Conference)
                .Include(x => x.Division)
                .Include(x => x.Division.Conference)
                .Where(x => x.SeasonId == currentSeasonData.Id)
                .ToList();

            return teamsData;
        }
        public List<M42.Data.Models.Draft> GetLeagueDrafts(int id)
        {
            var draftsData = _m42.Drafts
                  .Include("Season")
                  .Where(x => x.Season.LeagueId == id)
                  .OrderBy(x => x.Season.Year)
                  .ToList();

            return draftsData;

        }
        public List<M42.Data.Models.DraftPick> GetDraftPicks(M42.Data.Models.Season currentSeasonData)
        {
            if (currentSeasonData == null)
            {
                return new List<M42.Data.Models.DraftPick>();
            }

            var draftPicks = _m42.DraftPicks
                .Include(x => x.Person)
                .Include(x => x.Team)
                .Include(x => x.Team.Franchise)
                .Include(x => x.Draft)
                .Where(x => x.DraftId == currentSeasonData.Id)
                .OrderBy(x => x.Pick)
                .ToList();

            return draftPicks;
        }
        public List<M42.Data.Models.SeasonAward> GetAwards()
        {
            var awardsData = _m42.SeasonAwards
                .Include(x => x.Season)
                .Include(x => x.Person)
                .ToList();

            return awardsData;
        }
        
        #endregion

        #region Build Results
        public Sport BuildSport(M42.Data.Models.League leagueData)
        {
            var sport = new Sport
            {
                Id = leagueData.Sport.Id,
                Identifier = leagueData.Sport.Name,
                Name = leagueData.Sport.Name
            };

            return sport;
        }
        public List<Franchise> BuildLeagueFranchises(List<M42.Data.Models.Team> teamsData)
        {
            if (teamsData == null || teamsData.Count == 0)
            {
                return new List<Franchise>();
            }
            var franchises = teamsData
               .OrderBy(x => x.City)
               .Select(x => new Franchise
               {
                   Id = x.FranchiseId,
                   Identifier = x.Franchise.Organization.Identifier,
                   Name = String.Format("{0} {1}", x.City, x.Name)
               })
               .ToList();

            return franchises;
        }
        public Person BuildCommissioner(M42.Data.Models.Season currentSeasonData)
        {
            if (currentSeasonData == null)
            {
                return null;
            }
            Person commissioner = null;
            if (currentSeasonData.Commissioner != null)
            {
                commissioner = new Person
                {
                    Id = currentSeasonData.Commissioner.Id,
                    Identifier = currentSeasonData.Commissioner.Identifier,
                    Name = currentSeasonData.Commissioner.ToString()
                };
            }

            return commissioner;
        }
        public List<Season> BuildSeasons(List<M42.Data.Models.Season> seasonsData, M42.Data.Models.Season currentSeason)
        {
            if (seasonsData == null || seasonsData.Count == 0)
            {
                return new List<Season>();
            }
            var seasons = seasonsData
               .Select(x => new Season
               {
                   Id = x.Id,
                   Identifier = x.Identifier,
                   Year = x.Year
               })
               .ToList();

            return seasons;
        }
        private List<Championship> BuildChampionships(int id)
        {
            var championshipsData = _m42.Games
                .Include(x => x.Season)
                .Include(x => x.WinningTeam)
                .Include(x => x.LosingTeam)
                .Where(x =>
                    x.Season.LeagueId == id &&
                    (
                        x.GameTypeId == M42.Data.Models.GameType.SuperBowl.Id ||
                        x.GameTypeId == M42.Data.Models.GameType.LeagueChampionship.Id
                    ))
                .ToList();

            if (championshipsData == null || championshipsData.Count == 0)
            {
                return new List<Championship>();
            }

            var championships = championshipsData
                .OrderByDescending(x => x.Season.Year)
                .Select(x => new Championship
                {
                    Year = x.Season.Year ,
                    WinningTeam = new Team
                    {
                        Id = x.WinningTeam.Id ,
                        Identifier = x.WinningTeam.Identifier,
                        Name = x.WinningTeam.Name
                    },
                    LosingTeam = new Team
                    {
                        Id = x.LosingTeam.Id ,
                        Identifier = x.LosingTeam.Identifier,
                        Name = x.LosingTeam.Name
                    }
                })
                .ToList();

            return championships;
        }
        private List<Conference> BuildConferences(List<M42.Data.Models.Team> teamsData)
        {
            if (teamsData == null || teamsData.Count == 0)
            {
                return new List<Conference>();
            }

            var conferences = teamsData
                .Select(x => x.Division.Conference)
                .Distinct()
                .Select(x => new Conference 
                { 
                    Id = x.Id, 
                    Identifier = x.Identifier, 
                    Name = x.Name ,
                    Franchises = new List<Franchise>() ,
                    Divisions = new List<Division>()
                })
                .ToList();

            foreach (var team in teamsData.OrderBy(x => x.Division.Conference.SortOrder).ThenBy(x => x.Division.SortOrder).ThenByDescending(x => x.Wins).ThenBy(x => x.Losses))
            {
                var conference = conferences.Single(x => x.Id == team.Division.Conference.Id);

                conference.Franchises.Add(new Franchise { Id = team.Franchise.Id, Name = string.Format("{0} {1}", team.City, team.Name) });

                var division = conference.Divisions.SingleOrDefault(x => x.Id == team.Division.Id);

                if (division == null)
                {
                    division = new Division 
                    { 
                        Id = team.Division.Id, 
                        Identifier = team.Division.Identifier, 
                        Name = team.Division.Name, 
                        SortOrder = team.Division.SortOrder ,
                        Franchises = new List<Franchise>() 
                    };

                    conference.Divisions.Add(division);
                }
                division.Franchises.Add(new Franchise 
                { 
                    Id = team.Franchise.Id, 
                    Name = string.Format("{0} {1}", team.City, team.Name) ,
                    Wins = team.Wins ,
                    Losses = team.Losses ,
                    Ties = team.Ties
                });
            }
           

            return conferences;
        }
        private Draft BuildDraft(M42.Data.Models.Season seasonData, List<M42.Data.Models.DraftPick> draftPicksData)
        {
            if (draftPicksData.Count == 0)
            {
                return null;
            }

            var draftData = draftPicksData.First().Draft;

            var draft = new Draft
            {
                Id = draftData.Id,
                Identifier = seasonData.Identifier,
                Name = seasonData.ToString(),
                Rounds = BuildDraftRounds(draftPicksData),
            };

            return draft;

        }
        private List<DraftRound> BuildDraftRounds(List<M42.Data.Models.DraftPick> draftPicksData)
        {
            var draftRounds = new List<DraftRound>();

            int currRoundNumber = 0;

            DraftRound draftRound = null;

            foreach (var draftPickData in draftPicksData)
            {
                if (draftPickData.Round != currRoundNumber)
                {
                    if (draftRound != null)
                    {
                        draftRounds.Add(draftRound);
                    }
                    draftRound = new DraftRound
                    {
                        Identifier = string.Format(" - Round {0}", draftPickData.Round),
                        Label = string.Format(" - Round {0}", draftPickData.Round),
                        Number = draftPickData.Round,
                        Picks = new List<DraftPick>()
                    };
                    currRoundNumber = draftPickData.Round;
                }

                var draftPick = new DraftPick
                {
                    Id = draftPickData.Id,
                    Identifier = draftPickData.Id.ToString(),
                    Pick = draftPickData.Pick,
                    Team = new Team 
                    { 
                        Id = draftPickData.Team.Id, 
                        Name = draftPickData.Team.Name ,
                        Franchise = new Franchise { Id = draftPickData.Team.FranchiseId, Name = draftPickData.Team.Name }
                    },
                    Person = new Person { Id = draftPickData.Person.Id, Name = draftPickData.Person.ToString() }
                };

                draftRound.Picks.Add(draftPick);
            }

            if (draftRound != null)
            {
                draftRounds.Add(draftRound);
            }

            return draftRounds;
        }

        #endregion
    }
}
