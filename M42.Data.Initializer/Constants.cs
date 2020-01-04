using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace M42.Data.Initializer
{
    public static class Constants
    {
        public static string M42Folder = @"C:\Users\jeffc\source\repos\M42";
        public static string InitializerFolder = Path.Combine(M42Folder, "M42.Data.Initializer");
        public static string InitFilesFolder = Path.Combine(InitializerFolder, "InitFiles");

        public static string ScriptsFolder = Path.Combine(InitializerFolder, "SQL");

        public static string NFLFolder = Path.Combine(InitFilesFolder, "NFL");
        public static string NFLTeamsFolder = Path.Combine(NFLFolder, "Teams");
        public static string NFLDraftsFolder = Path.Combine(NFLFolder, "Drafts");
        public static string NFLSeasonsFolder = Path.Combine(NFLFolder, "Seasons");

        public static string MLBFolder = Path.Combine(InitFilesFolder, "MLB");
        public static string MLBTeamsFolder = Path.Combine(MLBFolder, "Teams");
        public static string MLBDraftsFolder = Path.Combine(MLBFolder, "Drafts");

        public static string NBAFolder = Path.Combine(InitFilesFolder, "NBA");
        public static string NBATeamsFolder = Path.Combine(NBAFolder, "Teams");
        public static string NBADraftsFolder = Path.Combine(NBAFolder, "Drafts");

        public static string NHLFolder = Path.Combine(InitFilesFolder, "NHL");
        public static string NHLTeamsFolder = Path.Combine(NHLFolder, "Teams");
        public static string NHLDraftsFolder = Path.Combine(NHLFolder, "Drafts");


        public static string SportsCardFolder = Path.Combine(InitFilesFolder, "SportsCards");
    }
}
