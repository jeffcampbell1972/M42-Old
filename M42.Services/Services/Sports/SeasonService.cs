using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class SeasonService : IService<Season>
    {
        M42Context _m42;
        public SeasonService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Season> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Season Get(int id)
        {
            var seasonData = GetSeason(id);
            var playoffGamesData = GetSeasonPlayoffGames(id);
            var draftPicksData = GetDraftPicks(id);
            var teamsData = GetTeams(id);
            var hofersData = _m42.HOFers
                .Include(x => x.Person)
                .Where(x => x.HOFId == seasonData.League.HOFId && x.YearInducted == seasonData.Year)
                .OrderBy(x => x.Person.LastName)
                .ThenBy(x => x.Person.FirstName)
                .ToList();

            var hofers = hofersData
                .Select(x => new HallOfFamer 
                { 
                    Person = new Person { Id = x.Person.Id, Name = x.Person.ToString() } 
                })
                .ToList();
            var seasonAwards = GetSeasonAwards(id);

            var prevSeasonData = _m42.Seasons.SingleOrDefault(x => x.Year == seasonData.Year - 1 && x.LeagueId == seasonData.LeagueId);
            var nextSeasonData = _m42.Seasons.SingleOrDefault(x => x.Year == seasonData.Year + 1 && x.LeagueId == seasonData.LeagueId);

            var season = new Season
            {
                Id = seasonData.Id,
                Identifier = seasonData.Identifier,
                Name = seasonData.ToString(),
                Year = seasonData.Year ,
                League = BuildLeague(seasonData),
                NumTeams = seasonData.NumTeams,
                NumGames = seasonData.NumGames,
                MVP = BuildAward(seasonAwards, Award.MVP.Id) ,
                OffensiveROY = BuildAward(seasonAwards, Award.ROYOffense.Id),
                DefensiveROY = BuildAward(seasonAwards, Award.ROYDefense.Id),
                Commissioner = BuildCommissioner(seasonData),
                Draft = BuildDraft(seasonData, draftPicksData),
                Conferences = BuildConferences(teamsData),
                Playoffs = BuildSeasonPlayoffGames(playoffGamesData) ,
                Championship = BuildChampionship(playoffGamesData) ,
                HallOfFamers = hofers ,
                NextSeason = nextSeasonData != null ? new Season {  Id = nextSeasonData.Id , Name = nextSeasonData.Year.ToString() } : null,
                PrevSeason = prevSeasonData != null ? new Season { Id = prevSeasonData.Id, Name = prevSeasonData.Year.ToString() } : null
            };

            return season;
        }
        public Season Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Season season)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Season season)
        {
            throw new MethodUnsupportedException();
        }

        #region Data Retrieval

        public M42.Data.Models.Season GetSeason(int id)
        {
            var seasonData = _m42.Seasons
                .Include(x => x.League)
                .Include(x => x.League.HOF)
                .Include(x => x.League.HOF.Organization)
                .Include(x => x.Commissioner)
                .SingleOrDefault(x => x.Id == id);

            if (seasonData == null)
            {
                throw new EntityNotFoundException();
            }

            return seasonData;
        }
        public List<M42.Data.Models.DraftPick> GetDraftPicks(int id)
        {
            var draftPicks = _m42.DraftPicks
                .Include(x => x.Person)
                .Include(x => x.Team)
                .Include(x => x.Draft)
                .Where(x => x.DraftId == id)
                .OrderBy(x => x.Pick)
                .ToList();

            return draftPicks;
        }
        private List<M42.Data.Models.Game> GetSeasonPlayoffGames(int id)
        {
            var gamesData = _m42.Games
                .Include(x => x.WinningTeam)
                .Include(x => x.LosingTeam)
                .Include(x => x.GameType)
                .Where(x => x.SeasonId == id && x.GameTypeId != M42.Data.Models.GameType.RegularSeason.Id).ToList();

            return gamesData;
        }
        private List<M42.Data.Models.Team> GetTeams(int id)
        {
            var teamsData = _m42.Teams
                .Include(x => x.Division)
                .Include(x => x.Division.Conference)
                .Where(x => x.SeasonId == id)
                .ToList();

            return teamsData;
        }
        private List<M42.Data.Models.SeasonAward> GetSeasonAwards(int id)
        {
            var seasonAwards = _m42.SeasonAwards
                .Include(x => x.Person)
                .Where(x => x.SeasonId == id)
                .ToList();

            return seasonAwards;
        }
        
        #endregion

        #region private Build() methods

        private League BuildLeague(M42.Data.Models.Season seasonData)
        {
            var league = new League 
            { 
                Id = seasonData.League.Id, 
                Name = seasonData.League.Abbreviation, 
                HallOfFame = new HallOfFame 
                { 
                    Id = seasonData.League.HOF.Id, 
                    Name = seasonData.League.HOF.Organization.Name 
                } 
            };

            return league;
        }
        private Person BuildCommissioner(M42.Data.Models.Season seasonData)
        {
            if (seasonData == null || seasonData.Commissioner == null)
            {
                return null;
            }
            var commissioner = new Person 
            { 
                Id = seasonData.Commissioner.Id, 
                Name = seasonData.Commissioner.ToString() }
            ;

            return commissioner;
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
                 Id = draftData.Id ,
                 Identifier = seasonData.Identifier ,
                 Name = seasonData.ToString() ,
                 Rounds = BuildDraftRounds(draftPicksData) ,
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
                    Pick = draftPickData.Pick , 
                    Team = new Team { Id = draftPickData.Team.Id , Name = draftPickData.Team.Name } ,
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
        private List<Game> BuildSeasonPlayoffGames(List<M42.Data.Models.Game> gamesData)
        {
            var games = gamesData
               .OrderBy(x => x.GameType.SortOrder)
               .Select(x => new Game
               {
                   Id = x.Id,
                   Identifier = x.Id.ToString(),
                   Name = x.Title ,
                   WinningTeam = new Team { Id = x.WinningTeam.Id, Name = string.Format("{0} {1}", x.WinningTeam.City, x.WinningTeam.Name) },
                   LosingTeam = new Team { Id = x.LosingTeam.Id, Name = string.Format("{0} {1}", x.LosingTeam.City, x.LosingTeam.Name) },
                   Score = string.Format("{0} - {1} {2}", x.WinningScore, x.LosingScore, x.OvertimeCount > 0 ? string.Format("({0} OT)", x.OvertimeCount) : "") ,
                   WinningScore = x.WinningScore,
                   LosingScore = x.LosingScore
               })
               .ToList();

            return games;
        }
        private List<Conference> BuildConferences(List<M42.Data.Models.Team> teamsData)
        {
            var conferences = teamsData
                .Select(x => x.Division.Conference)
                .Distinct()
                .Select(x => new Conference
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name,

                    Divisions = new List<Division>()
                })
                .ToList();

            foreach (var team in teamsData.OrderBy(x => x.Division.Conference.SortOrder).ThenBy(x => x.Division.SortOrder).ThenByDescending(x => x.Wins).ThenBy(x => x.Losses))
            {
                var conference = conferences.Single(x => x.Id == team.Division.Conference.Id);

                var division = conference.Divisions.SingleOrDefault(x => x.Id == team.Division.Id);

                if (division == null)
                {
                    division = new Division
                    {
                        Id = team.Division.Id,
                        Identifier = team.Division.Identifier,
                        Name = team.Division.Name,
                        SortOrder = team.Division.SortOrder,
                        Teams = new List<Team>()
                    };

                    conference.Divisions.Add(division);
                }
                division.Teams.Add(new Team
                {
                    Id = team.Id,
                    Name = string.Format("{0} {1}", team.City, team.Name),
                    Wins = team.Wins,
                    Losses = team.Losses,
                    Ties = team.Ties
                });
            }


            return conferences;
        }
        private Championship BuildChampionship(List<M42.Data.Models.Game> gamesData)
        {
            var championshipGameData = gamesData.SingleOrDefault(x => x.GameTypeId == GameType.SuperBowl.Id || x.GameTypeId == GameType.LeagueChampionship.Id);

            if (championshipGameData == null)
            {
                return null;
            }

            var championship = new Championship
            {
                Year = championshipGameData.Season.Year,
                Score = string.Format("{0} - {1}", championshipGameData.WinningScore, championshipGameData.LosingScore),
                WinningTeam = new Team { Id = championshipGameData.WinningTeam.Id, Name = championshipGameData.WinningTeam.Name },
                LosingTeam = new Team { Id = championshipGameData.LosingTeam.Id, Name = championshipGameData.LosingTeam.Name },
                Title = championshipGameData.GameTypeId == GameType.SuperBowl.Id ? string.Format("Super Bowl {0}", BuildSuperBowlNumber(championshipGameData)) : string.Format("{0} Championship", championshipGameData.Season.Year)
            };

            return championship;
        }
        private string BuildSuperBowlNumber(M42.Data.Models.Game game)
        {
            int superBowlNumber = game.Season.Year - 1965;

            switch (superBowlNumber)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "IX";
                case 10: return "X";
                case 11: return "XI";
                case 12: return "XII";
                case 13: return "XIII";
                case 14: return "XIV";
                case 15: return "XV";
                case 16: return "XVI";
                case 17: return "XVII";
                case 18: return "XVIII";
                case 19: return "XIX";
                case 20: return "XX";
                case 21: return "XXI";
                case 22: return "XXII";
                case 23: return "XXIII";
                case 24: return "XXIV";
                case 25: return "XXV";
                case 26: return "XXVI";
                case 27: return "XXVII";
                case 28: return "XXVIII";
                case 29: return "XXIX";
                case 30: return "XXX";
                case 31: return "XXXI";
                case 32: return "XXXII";
                case 33: return "XXXIII";
                case 34: return "XXXIV";
                case 35: return "XXXV";
                case 36: return "XXXVI";
                case 37: return "XXXVII";
                case 38: return "XXXVIII";
                case 39: return "XXXIX";
                case 40: return "XL";
                case 41: return "XLI";
                case 42: return "XLII";
                case 43: return "XLIII";
                case 44: return "XLIV";
                case 45: return "XLV";
                case 46: return "XLVI";
                case 47: return "XLVII";
                case 48: return "XLVIII";
                case 49: return "XLIX";
                case 50: return "L";
                case 51: return "LI";
                case 52: return "LII";
                case 53: return "LIII";
                case 54: return "LIV";
                case 55: return "LV";
                case 56: return "LVI";
                case 57: return "LVII";
                case 58: return "LVIII";
                case 59: return "LIX";
                case 60: return "LX";
                case 61: return "LXI";
                case 62: return "LXII";
                case 63: return "LXIII";
                case 64: return "LXIV";
                case 65: return "LXV";
                case 66: return "LXVI";
                case 67: return "LXVII";
                case 68: return "LXVIII";
                case 69: return "LXIX";
                case 70: return "LXX";
                case 71: return "LXXI";
                case 72: return "LXXII";
                case 73: return "LXXIII";
                case 74: return "LXXIV";
                case 75: return "LXXV";
                case 76: return "LXXVI";
                case 77: return "LXXVII";
                case 78: return "LXXVIII";
                case 79: return "LXXIX";
                case 80: return "LXXX";
                case 81: return "LXXXI";
                case 82: return "LXXXII";
                case 83: return "LXXXIII";
                case 84: return "LXXXIV";
                case 85: return "LXXXV";
                case 86: return "LXXXVI";
                case 87: return "LXXXVII";
                case 88: return "LXXXVIII";
                case 89: return "LXXXIX";
                case 90: return "XC";
                case 91: return "XCI";
                case 92: return "XCII";
                case 93: return "XCIII";
                case 94: return "XCIV";
                case 95: return "XCV";
                case 96: return "XCVI";
                case 97: return "XCVII";
                case 98: return "XCVIII";
                case 99: return "XCIX";
                case 100: return "C";
            }

            throw new Exception("Invalid Super Bowl");
        }
        private Person BuildAward(List<M42.Data.Models.SeasonAward> seasonAwards, int awardId)
        {
            var seasonAward = seasonAwards.SingleOrDefault(x => x.AwardId == awardId);

            if (seasonAward == null)
            {
                return null;
            }

            var person = new Person
            {
                Id = seasonAward.Person.Id,
                Name = seasonAward.Person.ToString()
            };

            return person;
        }
        
        #endregion
    }
}
