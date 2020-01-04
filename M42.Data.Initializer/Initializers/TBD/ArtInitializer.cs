using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializer
{
    public class ArtInitializer
    {
        public void Seed(M42Context context)
        {
            SeedArtists(context);
            SeedAuthors(context);
        }
        protected void SeedArtists(M42Context context)
        {
            context.People.Add(new Person { Identifier = "DavidLister", LastName = "Lister", FirstName = "David" });

        }
        protected void SeedAuthors(M42Context context)
        {
            context.People.Add(new Person { Identifier = "AgathaChristie", LastName = "Christie", FirstName = "Agatha" });
            context.People.Add(new Person { Identifier = "MichaelCrichton", LastName = "Chrichon", FirstName = "Michael" });
            context.People.Add(new Person { Identifier = "MichaelConnelly", LastName = "Connelly", FirstName = "Michael" });
            context.People.Add(new Person { Identifier = "DashellHammett", LastName = "Hammett", FirstName = "Dashell" });
            context.People.Add(new Person { Identifier = "JamesEllroy", LastName = "Ellroy", FirstName = "James" });
            context.People.Add(new Person { Identifier = "RaymondChandler", LastName = "Chandler", FirstName = "Raymond" });
            context.People.Add(new Person { Identifier = "MarioPuzo", LastName = "Puzo", FirstName = "Mario" });

        }
    }
}