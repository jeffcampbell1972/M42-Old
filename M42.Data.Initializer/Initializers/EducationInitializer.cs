using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using System.IO;


namespace M42.Data.Initializer
{
    public static class EducationInitializer
    {
        //private M42Context _m42;

        //public EducationInitializer(M42Context m42)
        //{
        //    _m42 = m42;
        //}
        public static void Seed(M42Context m42)
        {
            SeedColleges(m42);
        }
        private static void SeedColleges(M42Context context)
        {
            string colleges = Path.Combine(Constants.InitFilesFolder, "Colleges.csv");
            string[] lines = File.ReadAllLines(colleges);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                string Identifier = values[0];
                string CollegeName = values[1];
                string NickName = values[2];
                string City = values[3];
                string State = values[4];
                string FootballConferenceIdentifier = values[5];
                string YearStarted = values[6];

                DataService.AddCollege(context, Identifier, CollegeName, NickName, true);            
            }

            context.SaveChanges();
        }

    }
}