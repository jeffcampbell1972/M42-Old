using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializer
{
    public static class PeopleInitializer
    {
        public static void Seed(M42Context m42)
        {
            SeedPeople(m42);
        }
        private static void SeedPeople(M42Context context)
        {
            string nflPeopleFileName = System.IO.Path.Combine(Constants.InitFilesFolder, "People.csv");
            string[] lines = File.ReadAllLines(nflPeopleFileName);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                string Identifier = values[0];
                string FirstName = values[1];
                string LastName = values[2];
                string MiddleName = null;
                string Suffix = null;
                string PreferredName = null;
                string Nickname = null;
                string BirthDate = null;
                string DeathDate = null;

                if (values[3] != "") MiddleName = values[3];
                if (values[4] != "") Suffix = values[4];
                if (values[5] != "") PreferredName = values[5];
                if (values[6] != "") Nickname = values[6];
                if (values[7] != "") BirthDate = values[7];
                if (values[8] != "") DeathDate = values[8];

                DataService.AddPerson(context, Identifier, LastName, FirstName, PreferredName, MiddleName, Nickname, BirthDate, DeathDate);
            }
        }

    }

}