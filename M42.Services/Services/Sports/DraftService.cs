using M42.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace M42.Sports
{
    public class DraftService : IService<Draft>
    {
        M42Context _m42;
        public DraftService(M42Context m42)
        {
            _m42 = m42;
        }
        public List<Draft> Get()
        {
            throw new MethodUnsupportedException();
        }
        public Draft Get(int id)
        {
            var draftData = GetDraft(id);

            var draft = BuildDraft(draftData);

            return draft;
        }
        public Draft Get(string identifier)
        {
            throw new MethodUnsupportedException();
        }
        public void Post(Draft draft)
        {
            throw new MethodUnsupportedException();
        }
        public void Put(int id, Draft draft)
        {
            throw new MethodUnsupportedException();
        }

        #region Get Methods

        private M42.Data.Models.Draft GetDraft(int id)
        {
            var draftData = _m42.Drafts
                .Include(x => x.Season)
                .Include(x => x.Season.League)
                .SingleOrDefault(x => x.Id == id);

            if (draftData == null)
            {
                throw new EntityNotFoundException();
            }

            return draftData;
        }

        #endregion

        #region Build Methods

        private Draft BuildDraft(M42.Data.Models.Draft draftData)
        {
            var draft = new Draft
            {
                Id = draftData.Id,
                Identifier = draftData.Season.Identifier,
                Season = new Season
                {
                    Id = draftData.Season.Id,
                    Identifier = draftData.Season.Identifier,
                    Name = draftData.Season.ToString()
                }
            };

            return draft;
        }

        #endregion
    }
}
