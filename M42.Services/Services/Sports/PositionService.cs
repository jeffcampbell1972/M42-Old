using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class PositionService : IService<Position>
    {
        M42Context _m42;
        public PositionService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Position> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Position Get(int id)
        {
            var positionData = GetPosition(id);
            var positionPeople = _m42.TeamPlayerPositions.Where(x => x.PositionId == id).Select(x => x.TeamPerson.Person).Distinct().ToList();

            var position = new Position
            {
                Id = positionData.Id,
                Identifier = positionData.Identifier ,
                Name = positionData.Name ,
                Sport = new Sport { Id = positionData.Sport.Id, Name = positionData.Sport.Name } ,
                People = positionPeople.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Select(x => new Person { Id = x.Id, Name = x.ToString() }).ToList()
            };

            return position;
        }
        public Position Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Position position)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Position position)
        {
            throw new MethodUnsupportedException();
        }

        #region Get Methods

        public M42.Data.Models.Position GetPosition (int id)
        {
            var positionData = _m42.Positions
                .Include(x => x.Sport)
                .SingleOrDefault(x => x.Id == id);

            if (positionData == null)
            {
                throw new EntityNotFoundException();
            }

            return positionData;
        }
        #endregion


        #region Build methods
        #endregion
    }
}
