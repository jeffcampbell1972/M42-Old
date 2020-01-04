using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace M42.Sports
{
    public class FranchiseService : IService<Franchise>
    {
        M42Context _m42;
        public FranchiseService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Franchise> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Franchise Get(int id)
        {
            var franchiseData = GetFranchise(id);
            var teamsData = GetTeams(id);
            var franchisePeopleData = GetFranchisePeople(id);
            var currentTeamData = GetCurrentTeam(teamsData);
            var currentTeamPeopleData = GetCurrentTeamPeople(currentTeamData.Id);
            var hofersData = GetHofers();

            var franchise = new Franchise
            {
                Id = franchiseData.Id,
                Identifier = franchiseData.Organization.Identifier,
                Name = String.Format("{0} {1}", currentTeamData.City, currentTeamData.Name),
                YearEstablished = franchiseData.Organization.YearEstablished ,
                YearEnded = franchiseData.Organization.YearEnded , 
                League = new League { Id = currentTeamData.Season.League.Id, Abbreviation = currentTeamData.Season.League.Abbreviation } ,
                Owner = BuildOwner(currentTeamPeopleData) ,
                HeadCoach = BuildHeadCoach(currentTeamPeopleData) ,
                Teams = BuildTeams(id, teamsData, currentTeamData.Id) ,
                HallOfFamers = BuildHOFers(franchisePeopleData, hofersData)
            };

            return franchise;
        }
        public Franchise Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Franchise franchise)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Franchise franchise)
        {
            throw new MethodUnsupportedException();
        }

        #region Get Methods

        private M42.Data.Models.Franchise GetFranchise(int id)
        {
            var franchiseData = _m42.Franchises
                .Include(x => x.Organization)
                .SingleOrDefault(x => x.Id == id);

            if (franchiseData == null)
            {
                throw new EntityNotFoundException();
            }

            return franchiseData;
        }
        private List<M42.Data.Models.Team> GetTeams(int id)
        {
            var teamsData = _m42.Teams
                .Include(x => x.Season)
                .Include(x => x.Season.League)
                .Where(x => x.FranchiseId == id)
                .OrderByDescending(x => x.Season.Year)
                .ToList();

            return teamsData;
        }
        private List<M42.Data.Models.Person> GetFranchisePeople(int id)
        {
            var franchisePeopleData = _m42.TeamPeople
                .Include(x => x.Person)
                .Include(x => x.Team)
                .Include(x => x.Team.Franchise)
                .Where(x => x.Team.FranchiseId == id)
                .Select(x => x.Person)
                .Distinct()
                .ToList();

            return franchisePeopleData;
        }
        public M42.Data.Models.Team GetCurrentTeam(List<M42.Data.Models.Team> teamsData)
        {
            var currentTeamData = teamsData
                .OrderByDescending(x => x.Season.Year)
                .FirstOrDefault();

            if (currentTeamData == null)
            {
                throw new Exception();
            }

            return currentTeamData;
        }
        public List<M42.Data.Models.TeamPerson> GetCurrentTeamPeople(int currentTeamId)
        {
            var currentTeamPeopleData = _m42.TeamPeople
               .Where(x => x.TeamId == currentTeamId)
               .ToList();

            return currentTeamPeopleData;
        }
        public List<M42.Data.Models.HOFer> GetHofers()
        { 
            var hofersData = _m42.HOFers
                .Include(x => x.HOF)
                .Include(x => x.HOF.Organization)
                .ToList();

            return hofersData;
        }

        #endregion

        #region Build Methods

        private List<Team> BuildTeams(int id, List<M42.Data.Models.Team> teamsData, int currentTeamId)
        {
            
            var teams = teamsData
                .Where(x => x.Id != currentTeamId)
                .OrderByDescending(x => x.Season.Year)
                .Select(x => new Team
                {
                    Id = x.Id ,
                    Identifier = x.Identifier ,
                    Name = string.Format("{0} {1}", x.Season.Year, x.Name)
                })
                .ToList();

            return teams;
        }
        private Person BuildOwner(List<M42.Data.Models.TeamPerson> currentTeamPeopleData)
        {
            var ownerData = currentTeamPeopleData.SingleOrDefault(x => x.TeamRoleId == M42.Data.Models.TeamRole.Owner.Id);

            if (ownerData == null)
            {
                return null;
            }

            return new Person { Id = ownerData.PersonId, Name = ownerData.Person.ToString() };
        }
        private Person BuildHeadCoach(List<M42.Data.Models.TeamPerson> currentTeamPeopleData)
        {
            var coachData = currentTeamPeopleData.SingleOrDefault(x => x.TeamRoleId == M42.Data.Models.TeamRole.HeadCoach.Id);

            if (coachData == null)
            {
                return null;
            }

            return new Person { Id = coachData.PersonId, Name = coachData.Person.ToString() };
        }
        private List<HallOfFamer> BuildHOFers(List<M42.Data.Models.Person> franchisePeopleData, List<M42.Data.Models.HOFer> hofersData)
        {
            var franchiseHOFers = new List<HallOfFamer>();

            foreach (var person in franchisePeopleData)
            {
                var hofs = hofersData.Where(x => x.PersonId == person.Id).ToList();

                foreach (var hof in hofs)
                {
                    var hallOfFamer = new HallOfFamer
                    {
                        Id = person.Id,
                        
                        Person = new Person
                        {
                            Id = person.Id,
                            Name = person.ToString()
                        },
                        HallOfFame = new HallOfFame
                        {
                            Id = hof.HOF.Id,
                            Name = hof.HOF.Organization.Name
                        }
                    };

                    franchiseHOFers.Add(hallOfFamer);
                }
            }

            return franchiseHOFers;
        }
        
        #endregion
    }
}
