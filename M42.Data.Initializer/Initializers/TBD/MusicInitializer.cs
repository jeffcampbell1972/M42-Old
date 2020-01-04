using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializer
{
    public class MusicInitializer
    {
        public void Seed(M42Context context)
        {
            SeedMusicalInstruments(context);
            SeedMusicians(context);
        }
        protected void SeedMusicians(M42Context context)
        {
            context.People.Add(new Person { Identifier = "ElvisPresley", LastName = "Presley", FirstName = "Elvis" });
            context.People.Add(new Person { Identifier = "JohnLennon", LastName = "Presley", FirstName = "Elvis" });
            context.People.Add(new Person { Identifier = "PaulMcCartney", LastName = "Presley", FirstName = "Elvis" });
            context.People.Add(new Person { Identifier = "GeorgeHarrison", LastName = "Presley", FirstName = "Elvis" });
            context.People.Add(new Person { Identifier = "RingoStarr", LastName = "Presley", FirstName = "Elvis" });
            context.People.Add(new Person { Identifier = "MickJagger", LastName = "Osbourne", FirstName = "Ozzy" });
            context.People.Add(new Person { Identifier = "KeithRichards", LastName = "Osbourne", FirstName = "Ozzy" });
            context.People.Add(new Person { Identifier = "OzzyOsbourne", LastName = "Osbourne", FirstName = "Ozzy" });
            context.People.Add(new Person { Identifier = "TonyIommi", LastName = "Iommi", FirstName = "Tony" });
            context.People.Add(new Person { Identifier = "BillWard", LastName = "Ward", FirstName = "Bill" });
            context.People.Add(new Person { Identifier = "GeezerButler", LastName = "Butler", FirstName = "Geezer" });
            context.People.Add(new Person { Identifier = "StevieRayVaughn", LastName = "Vaughn", FirstName = "Steve", PreferredName = "Stevie Ray" });
            context.People.Add(new Person { Identifier = "VanceBockis", LastName = "Bockis", FirstName = "Vance" });
            context.People.Add(new Person { Identifier = "TeddyFeldman", LastName = "Feldman", FirstName = "Teddy" });

        }
        protected void SeedMusicalInstruments(M42Context context)
        {
            context.Instruments.Add(new Instrument { Name = "Vocals" });
            context.Instruments.Add(new Instrument { Name = "Lead Guitar" });
            context.Instruments.Add(new Instrument { Name = "Rythem Guitar" });
            context.Instruments.Add(new Instrument { Name = "Bass Guitar" });
            context.Instruments.Add(new Instrument { Name = "Slide Guitar" });
            context.Instruments.Add(new Instrument { Name = "Pedal Steel Guitar" });
            context.Instruments.Add(new Instrument { Name = "Organ" });
            context.Instruments.Add(new Instrument { Name = "Piano" });
            context.Instruments.Add(new Instrument { Name = "Drums" });

            context.SaveChanges();
        }
    }
}