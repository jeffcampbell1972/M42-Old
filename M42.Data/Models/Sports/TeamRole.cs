using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("TeamRoles", Schema = "Sports")]
    public class TeamRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<TeamRole> values;
        public static List<TeamRole> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<TeamRole>() {
                        Owner ,
                        President,
                        VicePresident,
                        GM ,
                        HeadCoach ,
                        Manager ,
                        Coach ,
                        Player
                    };
                }
                return values;
            }
        }

        static private TeamRole owner;
        static private TeamRole president;
        static private TeamRole vicepresident;
        static private TeamRole gm;
        static private TeamRole headcoach;
        static private TeamRole manager;
        static private TeamRole coach;
        static private TeamRole player;


        static public TeamRole Owner { get { return owner ?? (owner = new TeamRole { Id = 1, Name = "Owner" }); } }
        static public TeamRole President { get { return president ?? (president = new TeamRole { Id = 2, Name = "President" }); } }
        static public TeamRole VicePresident { get { return vicepresident ?? (vicepresident = new TeamRole { Id = 3, Name = "Vice President" }); } }
        static public TeamRole GM { get { return gm ?? (gm = new TeamRole { Id = 4, Name = "GM" }); } }
        static public TeamRole HeadCoach { get { return headcoach ?? (headcoach = new TeamRole { Id = 5, Name = "HeadCoach" }); } }
        static public TeamRole Manager { get { return manager ?? (manager = new TeamRole { Id = 6, Name = "Manager" }); } }
        static public TeamRole Coach { get { return coach ?? (coach = new TeamRole { Id = 7, Name = "Coach" }); } }
        static public TeamRole Player { get { return player ?? (player = new TeamRole { Id = 8, Name = "Player" }); } }


    }
}