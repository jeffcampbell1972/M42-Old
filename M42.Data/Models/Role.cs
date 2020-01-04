using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        private static List<Role> values;
        public static List<Role> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<Role>() {
                        Owner ,
                        President ,
                        VicePresident ,
                        GM ,
                        HeadCoach ,
                        Manager ,
                        Coach ,
                        Player ,
                        Commissioner ,
                        Referee
                    };
                }
                return values;
            }
        }

        static private Role owner;
        static private Role president;
        static private Role vicepresident;
        static private Role gm;
        static private Role headcoach;
        static private Role manager;
        static private Role coach;
        static private Role player;
        static private Role commissioner;
        static private Role referee;

        static public Role Owner { get { return owner ?? (owner = new Role { Id = 1, Identifier = "Owner", Name = "Owner" }); } }
        static public Role President { get { return president ?? (president = new Role { Id = 2, Identifier = "President", Name = "President" }); } }
        static public Role VicePresident { get { return vicepresident ?? (vicepresident = new Role { Id = 3, Identifier = "Owner", Name = "Vice President" }); } }
        static public Role GM { get { return gm ?? (gm = new Role { Id = 4, Identifier = "GM", Name = "GM" }); } }
        static public Role HeadCoach { get { return headcoach ?? (headcoach = new Role { Id = 5, Identifier = "HeadCoach", Name = "Head Coach" }); } }
        static public Role Manager { get { return manager ?? (manager = new Role { Id = 6, Identifier = "Manager", Name = "Manager" }); } }
        static public Role Coach { get { return coach ?? (coach = new Role { Id = 7, Identifier = "Coach", Name = "Coach" }); } }
        static public Role Player { get { return player ?? (player = new Role { Id = 8, Identifier = "Player", Name = "Player" }); } }
        static public Role Commissioner { get { return commissioner ?? (commissioner = new Role { Id = 9, Identifier = "Commissioner", Name = "Commissioner" }); } }
        static public Role Referee { get { return referee ?? (referee = new Role { Id = 10, Identifier = "Referee", Name = "Referee" }); } }

    }
}