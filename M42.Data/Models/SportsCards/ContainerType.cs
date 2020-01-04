using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("ContainerTypes", Schema = "SportsCards")]
    public class ContainerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        private static List<ContainerType> values;
        public static List<ContainerType> Values
        {
            get
            {
                if (values != null)
                {
                    return values;
                }
                else
                {
                    values = new List<ContainerType>() {
                        Binder ,
                        TopLoaderBox2 ,
                        TopLoaderBox3 ,
                        Storage3000ct ,
                        Storage5000ct ,
                        GradedBox ,
                        DisplayCase
                    };
                }
                return values;
            }
        }

        static private ContainerType binder;
        static private ContainerType toploaderbox2;
        static private ContainerType toploaderbox3;
        static private ContainerType storage3000ct;
        static private ContainerType storage5000ct;
        static private ContainerType gradedbox;
        static private ContainerType displaycase;

        static public ContainerType Binder { get { return binder ?? (binder = new ContainerType { Id = 1, Name = "Binder", Identifier = "Binder" }); } }
        static public ContainerType TopLoaderBox2 { get { return toploaderbox2 ?? (toploaderbox2 = new ContainerType { Id = 2, Name = "Top Loader Box (2 column)", Identifier = "TopLoaderBox2" }); } }
        static public ContainerType TopLoaderBox3 { get { return toploaderbox3 ?? (toploaderbox3 = new ContainerType { Id = 3, Name = "Top Loader Box (3 colum)", Identifier = "TopLoaderBox3" }); } }
        static public ContainerType Storage3000ct { get { return storage3000ct ?? (storage3000ct = new ContainerType { Id = 4, Name = "Card Storage (3000 count)", Identifier = "Storage3000ct" }); } }
        static public ContainerType Storage5000ct { get { return storage5000ct ?? (storage5000ct = new ContainerType { Id = 5, Name = "Card Storage (5000 count)", Identifier = "Storage5000ct" }); } }
        static public ContainerType GradedBox { get { return gradedbox ?? (gradedbox = new ContainerType { Id = 6, Name = "Graded Card Box", Identifier = "GradedBox" }); } }
        static public ContainerType DisplayCase { get { return displaycase ?? (displaycase = new ContainerType { Id = 7, Name = "Display Case", Identifier = "DisplayCase" }); } }
    }
}