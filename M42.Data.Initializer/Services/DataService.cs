using M42.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M42.Data.Initializer
{
    public static class DataService
    {       
        public static void AddCollege(M42Context context, string identifier, string name, string nickname, bool activeFlag)
        {
            var college = new College
            {
                Organization = new Organization { Name = name, ActiveFlag = activeFlag, Identifier = identifier },
                Nickname = nickname
            };

            context.Colleges.Add(college);
        }
        public static void AddLeague(M42Context context, string identifier, string name, string abbreviation, int sportId, int hofId, int yearEstablished, int? yearEnded = null)
        {
            context.Leagues.Add(
                new League
                {
                    Organization = new Organization
                    {
                        Identifier = identifier,
                        Name = name,
                        YearEstablished = yearEstablished,
                        YearEnded = yearEnded,
                        ActiveFlag = yearEnded == null
                    },
                    SportId = sportId,
                    HOFId = hofId ,
                    Abbreviation = abbreviation
                });

        }
        public static void AddConference(M42Context context, string identifier, int leagueId, string name, int sortOrder)
        {
            context.Conferences.Add(
                new Conference
                {
                    Identifier = identifier,
                    LeagueId = leagueId,
                    Name = name,
                    SortOrder = sortOrder
                });

        }
        public static void AddDivision(M42Context context, string identifier, string name, int conferenceId, int sortOrder, int startYear, int? endYear = null)
        {
            context.Divisions.Add(
                new Division
                {
                    Identifier = identifier,
                    Name = name,
                    ConferenceId = conferenceId,
                    SortOrder = sortOrder,
                    StartYear = startYear,
                    EndYear = endYear
                });
        }
        public static void AddFranchise(M42Context context, int sportId, bool isProfessional, string name, bool activeFlag, string identifier)
        {
            if (isProfessional)
            {
                context.Franchises.Add(
                    new Franchise
                    {
                        SportId = sportId,
                        IsProfessional = isProfessional,
                        Organization = new Organization
                        {
                            Name = name,
                            ActiveFlag = activeFlag,
                            Identifier = identifier
                        }
                    });
            }
            else
            {
                var college = context.Colleges.Include(x => x.Organization).SingleOrDefault(x => x.Organization.Identifier == identifier);

                if (college == null) return;

                context.Franchises.Add(
                   new Franchise
                   {
                       SportId = sportId,
                       IsProfessional = isProfessional,
                       Organization = college.Organization
                   });
            }
        }
        public static void AddPlayerLeague(M42Context context, int personId, int leagueId, List<string> positions)
        {
            var player = context.Players.SingleOrDefault(x => x.Id == personId);

            if (player == null)
            {
                AddLog(context, string.Format("AddPlayerLeague failed.  Could not find personId '{0}'", personId));

                return;
            }

            var playerLeague = context.PlayerLeagues.SingleOrDefault(x => x.LeagueId == leagueId && x.PlayerId == personId);

            if (playerLeague == null)
            {
                playerLeague = new PlayerLeague { PlayerId = player.Id, LeagueId = leagueId };
                context.PlayerLeagues.Add(playerLeague);

                context.SaveChanges();
            }
        }
        public static int GetFranchiseId(M42Context context, string Identifier)
        {
            var franchise = context.Franchises.SingleOrDefault(x => x.Organization.Identifier == Identifier);
            if (franchise == null)
            {
                return 0;
            }

            return franchise.Id;
        }
        public static int GetLeagueId(M42Context context, string Identifier)
        {
            var league = context.Leagues.SingleOrDefault(x => x.Abbreviation == Identifier);
            if (league == null)
            {
                return 0;
            }

            return league.Id;
        }
        public static void AddSeasonAward(M42Context context, int leagueId, int year, int awardId, string personIdentifier)
        {
            var person = context.People.SingleOrDefault(x => x.Identifier == personIdentifier);
            if (person == null)
            {
                AddLog(context, string.Format("AddSeasonAward could not Identifier '{0}'.", personIdentifier));

                return;
            }
            var season = context.Seasons.SingleOrDefault(x => x.LeagueId == leagueId && x.Year == year);
            if (season == null)
            {
                AddLog(context, string.Format("AddSeasonAward could not find Season for LeagueId={0} and Year={1}", leagueId, year));

                return;
            }
            var seasonAward = new SeasonAward
            {
                SeasonId = season.Id,
                PersonId = person.Id,
                AwardId = awardId
            };

            context.SeasonAwards.Add(seasonAward);
        }
        public static void AddSeason(M42Context context, int leagueId, int year, int numTeams, int numGames, string leagueNameOverride, string leagueAbbreviationOverride, int? presidentId, int? commisionerId, string identifier)
        {
            context.Seasons.Add(
                new Season
                {
                    Identifier = identifier,
                    LeagueId = leagueId,
                    Year = year,
                    NumTeams = numTeams,
                    NumGames = numGames,
                    LeagueNameOverride = leagueNameOverride,
                    LeagueAbbreviationOverride = leagueAbbreviationOverride,
                    PresidentId = presidentId ,
                    CommissionerId = commisionerId
                });

        }
        public static int GetPersonId(M42Context context, string Identifier)
        {
            var person = context.People.SingleOrDefault(x => x.Identifier == Identifier);

            if (person == null)
            {
                return 0;
            }

            return person.Id;
        }
        public static void AddPosition(M42Context context, string identifier, string name, string abbreviation, int sportId, int sortOrder)
        {
            context.Positions.Add(
                new Position
                {
                    Identifier = identifier,
                    Name = name,
                    Abbreviation = abbreviation,
                    SportId = sportId,
                    SortOrder = sortOrder
                });
        }
        public static void AddStatistic(M42Context context, string identifier, string name, string abbreviation, string unitOfMeasure, int sportId, int groupNumber, int sortOrder)
        {
            context.Statistics.Add(
                new Statistic
                {
                    Identifier = identifier ,
                    Name = name,
                    Abbreviation = abbreviation,
                    UnitOfMeasure = unitOfMeasure,
                    SportId = sportId ,
                    GroupNumber = groupNumber,
                    SortOrder = sortOrder
                });
        }
        public static void AddTeam(M42Context context, int leagueId, int franchiseId, int year, string city, string name, int? conferenceId = null, int? divisionId = null)
        {
            int seasonId = context.Seasons.Single(x => x.LeagueId == leagueId && x.Year == year).Id;
            string franchiseIdentifier = context.Organizations.Single(x => x.Id == franchiseId).Identifier;
            string teamIdentifier = string.Concat(year.ToString(), franchiseIdentifier);

            context.Teams.Add(new Team { FranchiseId = franchiseId, SeasonId = seasonId, Identifier = teamIdentifier, City = city, Name = name, ConferenceId = conferenceId, DivisionId = divisionId });
        }
        public static void AddTeamPerson(M42Context context, int personId, int franchiseId, int startYear, int endYear, int teamRoleId)
        {
            for (int year = startYear; year < endYear; year++)
            {
                var team = context.Teams.Include(x => x.Season).SingleOrDefault(x => x.Season.Year == year && x.FranchiseId == franchiseId);

                if (team == null)
                {
                    continue;
                }

                var teamPerson = new TeamPerson
                {
                    PersonId = personId,
                    TeamId = team.Id,
                    TeamRoleId = teamRoleId
                };

                context.TeamPeople.Add(teamPerson);
            }
        }
        public static void AddTeamPerson(M42Context context, string personIdentifier, int franchiseId, int startYear, int endYear, int teamRoleId)
        {
            int personId = GetPersonId(context, personIdentifier);

            if (personId == 0)
            {
                return;
            }
            AddTeamPerson(context, personId, franchiseId, startYear, endYear, teamRoleId);
        }
        public static void AddTeamPerson(M42Context context, string personIdentifier, string franchiseIdentifier, int startYear, int endYear, int teamRoleId)
        {
            int personId = GetPersonId(context, personIdentifier);
            int franchiseId = GetFranchiseId(context, franchiseIdentifier);

            if (personId == 0 || franchiseId == 0)
            {
                return;
            }

            AddTeamPerson(context, personId, franchiseId, startYear, endYear, teamRoleId);
        }
        public static void AddStadium(M42Context context, string identifier, string name, string abbreviation, string city, int countryId, int stateId)
        {
            context.Stadia.Add(
                new Stadium
                {
                    Name = name,
                    Abbreviation = abbreviation,
                    Address = new Address
                    {
                        City = city,
                        CountryId = countryId,
                        StateId = stateId
                    }
                });

        }
        public static void AddRelease(M42Context context, int year, string manufacturerIdentifier, string brandIdentifier, string leagueIdentifier, int numCards = 0)
        {
            var manufacturer = context.Manufacturers.SingleOrDefault(x => x.Organization.Identifier == manufacturerIdentifier);
            var brand = context.Brands.SingleOrDefault(x => x.Identifier == brandIdentifier);
            var league = context.Leagues.SingleOrDefault(x => x.Abbreviation == leagueIdentifier);

            if (manufacturer == null || brand == null || league == null)
            {

                return;
            }

            string releaseIdentifier = year.ToString() + brandIdentifier + leagueIdentifier;

            var existingRelease = context.Releases.SingleOrDefault(x => x.Identifier == releaseIdentifier);

            if (existingRelease != null)
            {
                return;
            }

            var release = new Release
            {
                Year = year,
                BrandId = Convert.ToInt32(brand.Id),
                ManufacturerId = Convert.ToInt32(manufacturer.Id),
                LeagueId = Convert.ToInt32(league.Id),
                Identifier = releaseIdentifier,
                BaseNumCards = numCards
            };
            context.Releases.Add(release);
            context.SaveChanges();
        }
        public static void AddLog(M42Context context, string message)
        {
            var log = new Log 
            { 
                Message = message 
            };
            context.Logs.Add(log);
            context.SaveChanges();
        }
        public static void AddContainer(M42Context context, string identifier, string name, int containerTypeId, int locationId)
        {
            context.Containers.Add(new Container
            {
                Identifier = identifier,
                Name = name != "" ? name : identifier,
                ContainerTypeId = containerTypeId ,
                LocationId = locationId
            });
        }
        public static void AddHofer(M42Context context, string personIdentifier, int hofId, int yearInducted)
        {
            var person = context.People.SingleOrDefault(x => x.Identifier == personIdentifier);

            if (person == null)
            {
                AddLog(context, string.Format("AddHofer failed. Identifier '{0}' does not exist.", personIdentifier));
                return;
            }

            var hofer = new HOFer
            {
                PersonId = person.Id,
                HOFId = hofId,
                YearInducted = yearInducted
            };

            context.HOFers.Add(hofer);
            context.SaveChanges();
        }
        public static void AddPerson(M42Context context,
           string identifier,
           string lastname,
           string firstname,
           string preferredname = null,
           string middlename = null,
           string nickname = null,
           string birthdate = null,
           string deathdate = null
           )
        {
            var existingPerson = context.People.SingleOrDefault(x => x.Identifier == identifier);

            if (existingPerson != null)
            {
                AddLog(context, string.Format("AddPerson failed. Identifier '{0}' already exists.", identifier));

                return;
            }

            DateTime? birthDate = null;
            if (birthdate != null) birthDate = Convert.ToDateTime(birthdate);

            DateTime? deathDate = null;
            if (deathDate != null) deathDate = Convert.ToDateTime(deathdate);

            var person = new Person
            {
                Identifier = identifier,
                FirstName = firstname,
                LastName = lastname,
                PreferredName = preferredname,
                MiddleName = middlename,
                Nickname = nickname,
                BirthDate = birthDate,
                DeathDate = deathDate
            };
            context.People.Add(person);
            context.SaveChanges();
        }
    }
}
