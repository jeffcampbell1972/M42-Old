using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;

namespace M42.Data.Initializer
{
    public class HistoryInitializer
    {
        public void Seed(M42Context context)
        {
            SeedPresidents(context);
            SeedBritishMonarchs(context);
        }
        protected void SeedPresidents(M42Context context)
        {
            context.People.Add(new Person { Identifier = "GeorgeWashington", LastName = "Washington", FirstName = "George" });
            context.People.Add(new Person { Identifier = "JohnAdams", LastName = "Adams", FirstName = "John" });
            context.People.Add(new Person { Identifier = "ThomasJefferson", LastName = "Jefferson", FirstName = "Thomas" });
            context.People.Add(new Person { Identifier = "JamesMadison", LastName = "Madison", FirstName = "James" });
            context.People.Add(new Person { Identifier = "JamesMonroe", LastName = "Monroe", FirstName = "James" });
            context.People.Add(new Person { Identifier = "JohnQuincyAdams", LastName = "Adams", FirstName = "John", MiddleName = "Quincy", Nickname = "John Quincy" });
            context.People.Add(new Person { Identifier = "AndrewJackson", LastName = "Jackson", FirstName = "Andrew" });
            context.People.Add(new Person { Identifier = "MartinVanBueren", LastName = "Van Bueren", FirstName = "Martin" });
            context.People.Add(new Person { Identifier = "WilliamHenryHarrison", LastName = "Harrison", FirstName = "William", MiddleName = "Henry", Nickname = "William Henry" });
            context.People.Add(new Person { Identifier = "JohnTyler", LastName = "Tyler", FirstName = "John" });
            context.People.Add(new Person { Identifier = "JamesPolk", LastName = "Polk", FirstName = "James" });
            context.People.Add(new Person { Identifier = "ZacharyTaylor", LastName = "Taylor", FirstName = "Zachary" });
            context.People.Add(new Person { Identifier = "MillardFillmore", LastName = "Fillmore", FirstName = "Millard" });
            context.People.Add(new Person { Identifier = "FranklinPierce", LastName = "Pierce", FirstName = "Franklin" });
            context.People.Add(new Person { Identifier = "JamesBuchannon", LastName = "Buchanon", FirstName = "James" });
            context.People.Add(new Person { Identifier = "AbrahamLincoln", LastName = "Lincoln", FirstName = "Abraham" });
            context.People.Add(new Person { Identifier = "AndrewJohnson", LastName = "Johnson", FirstName = "Andrew" });
            context.People.Add(new Person { Identifier = "UlyssesSGrant", LastName = "Grant", FirstName = "Ulysses" });
            context.People.Add(new Person { Identifier = "RutherfordBHayes", LastName = "Hayes", FirstName = "Rutherford" });
            context.People.Add(new Person { Identifier = "JamesGarfield", LastName = "Garfield", FirstName = "James" });
            context.People.Add(new Person { Identifier = "ChesterAArthur", LastName = "Arthur", FirstName = "Chester" });
            context.People.Add(new Person { Identifier = "GroverCleveland", LastName = "Cleveland", FirstName = "Grover" });
            context.People.Add(new Person { Identifier = "BenjaminHarrison", LastName = "Harrison", FirstName = "Benjamin" });
            context.People.Add(new Person { Identifier = "WilliamMcKinley", LastName = "McKinley", FirstName = "William" });
            context.People.Add(new Person { Identifier = "TheodoreRoosevelt", LastName = "Roosevelt", FirstName = "Theodore", Nickname = "Teddy" });
            context.People.Add(new Person { Identifier = "WilliamHowardTaft", LastName = "Taft", FirstName = "William" });
            context.People.Add(new Person { Identifier = "WoodrowWilson", LastName = "Wilson", FirstName = "Woodrow" });
            context.People.Add(new Person { Identifier = "WarrenHarding", LastName = "Harding", FirstName = "Warren" });
            context.People.Add(new Person { Identifier = "CalvinCoolidge", LastName = "Coolidge", FirstName = "Calivin" });
            context.People.Add(new Person { Identifier = "HerbertHoover", LastName = "Hoover", FirstName = "Herbert" });
            context.People.Add(new Person { Identifier = "FranklinRoosevelt", LastName = "Roosevelt", FirstName = "Franklin" });
            context.People.Add(new Person { Identifier = "HarryTruman", LastName = "Truman", FirstName = "Harry" });
            context.People.Add(new Person { Identifier = "DwightEisenhower", LastName = "Eisenhower", FirstName = "Dwight" });
            context.People.Add(new Person { Identifier = "JohnFKennedy", LastName = "Kennedy", FirstName = "John" });
            context.People.Add(new Person { Identifier = "LyndonJohnson", LastName = "Johnson", FirstName = "Lyndon" });
            context.People.Add(new Person { Identifier = "RichardNixon", LastName = "Christie", FirstName = "Agatha" });
            context.People.Add(new Person { Identifier = "GeraldFord", LastName = "Ford", FirstName = "Gerald" });
            context.People.Add(new Person { Identifier = "JimmyCarter", LastName = "Carter", FirstName = "Jimmy" });
            context.People.Add(new Person { Identifier = "RonaldReagan", LastName = "Reagan", FirstName = "Ronald" });
            context.People.Add(new Person { Identifier = "GeorgeBush", LastName = "Bush", FirstName = "George" });
            context.People.Add(new Person { Identifier = "BillClinton", LastName = "Clinton", FirstName = "William", MiddleName = "Jefferson", Nickname = "Bill" });
            context.People.Add(new Person { Identifier = "GeorgeWBush", LastName = "Christie", FirstName = "Agatha", MiddleName = "Walker", Nickname = "George W" });
            context.People.Add(new Person { Identifier = "BarrackObama", LastName = "Obama", FirstName = "Barrack" });
            context.People.Add(new Person { Identifier = "DonaldTrump", LastName = "Trump", FirstName = "Donald" });
        }
        protected void SeedBritishMonarchs(M42Context context)
        {
            context.People.Add(new Person { Identifier = "Aethelred", FirstName = "Aethelred" });
            context.People.Add(new Person { Identifier = "Swayne", FirstName = "Swayne" });
            context.People.Add(new Person { Identifier = "Cnute", FirstName = "Cnute" });
            context.People.Add(new Person { Identifier = "EdwardTheConfessor", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "HenryGodwinson", LastName = "Godwinson", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "WilliamI", LastName = "Norman", FirstName = "William" });
            context.People.Add(new Person { Identifier = "WilliamII", LastName = "Norman", FirstName = "William" });
            context.People.Add(new Person { Identifier = "HenryI", LastName = "Norman", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "MatildaI", LastName = "Norman", FirstName = "Matilda" });
            context.People.Add(new Person { Identifier = "StephenI", LastName = "Blois", FirstName = "Stephen" });
            context.People.Add(new Person { Identifier = "HenryII", LastName = "Plantagenet", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "RichardI", LastName = "Plantagenet", FirstName = "Richard" });
            context.People.Add(new Person { Identifier = "JohnI", LastName = "Plantagenet", FirstName = "John" });
            context.People.Add(new Person { Identifier = "HenryIII", LastName = "Plantagenet", FirstName = "Hery" });
            context.People.Add(new Person { Identifier = "EdwardI", LastName = "Plantagenet", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "EdwardII", LastName = "Plantagenet", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "EdwardIII", LastName = "Plantagenet", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "RichardI", LastName = "Plantagenet", FirstName = "Richard" });
            context.People.Add(new Person { Identifier = "HenryIV", LastName = "Bowlingbrook", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "HenryV", LastName = "Plantagenet", FirstName = "John" });
            context.People.Add(new Person { Identifier = "HenryVI", LastName = "Lanchaster", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "EdwardIV", LastName = "York", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "EdwardV", LastName = "York", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "RichardIII", LastName = "York", FirstName = "Richard" });
            context.People.Add(new Person { Identifier = "HenryVII", LastName = "Tudor", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "HenryVIII", LastName = "Tudor", FirstName = "Henry" });
            context.People.Add(new Person { Identifier = "EdwardVI", LastName = "Tudor", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "MaryI", LastName = "Tudor", FirstName = "Mary" });
            context.People.Add(new Person { Identifier = "ElizabethI", LastName = "Tudor", FirstName = "Elizabeth" });
            context.People.Add(new Person { Identifier = "JamesI", LastName = "Stuart", FirstName = "James" });
            context.People.Add(new Person { Identifier = "CharlesI", LastName = "Stuart", FirstName = "Charles" });
            context.People.Add(new Person { Identifier = "OliverCromwell", LastName = "Cromwell", FirstName = "Oliver" });
            context.People.Add(new Person { Identifier = "CharlesII", LastName = "Tudor", FirstName = "Charles" });
            context.People.Add(new Person { Identifier = "JamesII", LastName = "Stuart", FirstName = "James" });
            context.People.Add(new Person { Identifier = "WilliamIII", LastName = "Orange", FirstName = "William" });
            context.People.Add(new Person { Identifier = "MaryII", LastName = "Orange", FirstName = "Mary" });
            context.People.Add(new Person { Identifier = "AnneI", LastName = "Orange", FirstName = "Anne" });
            context.People.Add(new Person { Identifier = "GeorgeI", LastName = "Hanover", FirstName = "George" });
            context.People.Add(new Person { Identifier = "GeorgeII", LastName = "Hanover", FirstName = "George" });
            context.People.Add(new Person { Identifier = "GeorgeIII", LastName = "Hanover", FirstName = "George" });
            context.People.Add(new Person { Identifier = "VictoriaI", LastName = "Hanover", FirstName = "Victoria" });
            context.People.Add(new Person { Identifier = "EdwardVII", LastName = "Saxe-Coberg", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "GeorgeV", LastName = "Saxe-Coberg", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "EdwardVIII", LastName = "Windsor", FirstName = "Edward" });
            context.People.Add(new Person { Identifier = "GeorgeVI", LastName = "Windsor", FirstName = "George" });
            context.People.Add(new Person { Identifier = "ElizabethII", LastName = "", FirstName = "Elizabeth" });
        }

    }
}