using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using M42.Data.Models;

namespace M42.Data
{
    public class M42Context : DbContext
    {
        #region Art
        public DbSet<Artist> Artists { get; set; }
        #endregion

        #region Education
        public DbSet<College> Colleges { get; set; }
        #endregion

        #region Inventory
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        #endregion

        #region Music
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<MusicianGenre> MusicianGenres { get; set; }
        public DbSet<MusicianInstrument> MusicianInstruments { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        #endregion

        #region Sports
        public DbSet<Award> Awards { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<DraftPick> DraftPicks { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<HOF> HOFs { get; set; }
        public DbSet<HOFer> HOFers { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerLeague> PlayerLeagues { get; set; }
        public DbSet<PlayerLeagueStatistic> PlayerLeagueStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonAward> SeasonAwards { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Stadium> Stadia { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPerson> TeamPeople { get; set; }
        public DbSet<TeamPlayerPosition> TeamPlayerPositions { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }
        #endregion

        #region Sports Cards
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<CardPerson> CardPeople { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        #endregion

        #region Rolodex
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactEmailAddress> ContactEmailAddresses { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<State> States { get; set; }
        #endregion

        public DbSet<Log> Logs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationPerson> OrganizationPeople { get; set; }
        public DbSet<OrganizationPersonRole> OrganizationPersonRoles { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }

        public M42Context(DbContextOptions<M42Context> options) : base(options)
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Game
            modelBuilder.Entity<Game>()
                .HasOne(t => t.Season)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
               .HasOne(t => t.WinningTeam)
               .WithMany()
               .HasForeignKey(x => x.WinningTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
               .HasOne(t => t.LosingTeam)
               .WithMany()
               .HasForeignKey(x => x.LosingTeamId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
               .HasOne(t => t.HomeTeam)
               .WithMany()
               .HasForeignKey(x => x.HomeTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
               .HasOne(t => t.AwayTeam)
               .WithMany()
               .HasForeignKey(x => x.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region PlayerLeague
            modelBuilder.Entity<PlayerLeague>()
                .HasOne(bc => bc.Player)
                .WithMany(b => b.Leagues)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerLeague>()
                .HasOne(bc => bc.League)
                .WithMany(c => c.Players)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region PlayerLeagueStatistic
            modelBuilder.Entity<PlayerLeagueStatistic>()
               .HasOne(bc => bc.Player)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerLeagueStatistic>()
                .HasOne(bc => bc.League)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerLeagueStatistic>()
                .HasOne(bc => bc.Statistic)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Release
            modelBuilder.Entity<Release>()
                .HasOne(t => t.Manufacturer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Release>()
               .HasOne(t => t.Brand)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Team
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Franchise)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Season)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            modelBuilder.Entity<League>()
                .HasOne(bc => bc.HOF)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Role>().HasData(Role.Values);

            modelBuilder.Entity<ProductStatus>().HasData(ProductStatus.Values);
            modelBuilder.Entity<ProductCategory>().HasData(ProductCategory.Values);

            modelBuilder.Entity<Genre>().HasData(Genre.Values);

            modelBuilder.Entity<Country>().HasData(Country.Values);
            modelBuilder.Entity<State>().HasData(State.Values);
            modelBuilder.Entity<PhoneType>().HasData(PhoneType.Values);

            modelBuilder.Entity<Award>().HasData(Award.Values);

            modelBuilder.Entity<GameType>().HasData(GameType.Values);
            modelBuilder.Entity<TeamRole>().HasData(TeamRole.Values);

            modelBuilder.Entity<Sport>().HasData(Sport.Values);

            modelBuilder.Entity<CardType>().HasData(CardType.Values);
            modelBuilder.Entity<ContainerType>().HasData(ContainerType.Values);
            modelBuilder.Entity<Location>().HasData(Location.Values);

            base.OnModelCreating(modelBuilder);
        }
    }
}
