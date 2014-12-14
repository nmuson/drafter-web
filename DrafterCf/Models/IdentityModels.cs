using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DrafterCf.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<DrafterCf.Models.League> Leagues { get; set; }

        public System.Data.Entity.DbSet<DrafterCf.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<DrafterCf.Models.Family> Families { get; set; }

    }

    public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            AddSeedData(context);
            base.Seed(context);
        }

        private void AddSeedData(ApplicationDbContext context)
        {
            context.Leagues.Add(new League { Name = "M70" });
            context.SaveChanges();
            var league = context.Leagues.First();

            var rndId = new Random(Environment.TickCount);
            var musonFamily = new Family { Name = "Muson" };
            var lohmanFamily = new Family { Name = "Lohman" };
            var bieberFamily = new Family { Name = "Bieber" };
            var quixoteFamily = new Family { Name = "Quixote" };
            var panzoFamily = new Family { Name = "Panzo" };
            var piranhaFamily = new Family { Name = "Piranha" };
            var organsFamily = new Family { Name = "Organs" };
            
            var nick = new Coach
            {
                FirstName = "Nick",
                LastName = "Muson",
                League = league,
                Family = musonFamily,
                Role = CoachRole.HC,
            };
            var diederik = new Coach
            {
                FirstName = "Diederik",
                LastName = "Lohman",
                League = league,
                Family = lohmanFamily,
                Role = CoachRole.AC,
            };
            var scott = new Coach
            {
                FirstName = "Scott",
                LastName = "Bieber",
                League = league,
                Family = bieberFamily,
                Role = CoachRole.Third
            };
            var donQ = new Coach
            {
                FirstName = "Don",
                LastName = "Quixote",
                League = league,
                Family = quixoteFamily,
                Role = CoachRole.HC,
            };
            var sancho = new Coach
            {
                FirstName = "Sancho",
                LastName = "Panzo",
                League = league,
                Family = panzoFamily,
                Role = CoachRole.AC,
            };
            var doug = new Coach
            {
                FirstName = "Doug",
                LastName = "Piranha",
                League = league,
                Family = piranhaFamily,
                Role = CoachRole.HC
            };
            var harry = new Coach
            {
                FirstName = "Harry",
                LastName = "Organs",
                League = league,
                Family = piranhaFamily,
                Role = CoachRole.AC
            };

            league.Coaches = new List<Coach>(6){ nick, diederik, scott, donQ, sancho, doug, harry };

            league.Players = new List<Player>(13)
            {
                new Player
                {
                    FirstName = "Oliver",
                    LastName = "Muson",
                    Age = 13,
                    DraftScore = 6.65,
                    Family = musonFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Rupert",
                    LastName = "Muson",
                    Age = 12,
                    DraftScore = 5.67,
                    Family = musonFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Kieran",
                    LastName = "Lohman",
                    Age = 13,
                    DraftScore = 7.5,
                    Family = lohmanFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Jonah",
                    LastName = "Bieber",
                    Age = 13,
                    DraftScore = 5.66,
                    Family = bieberFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Fozzie",
                    LastName = "Bear",
                    Age = 13,
                    DraftScore = 4.02,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Pepe",
                    LastName = "Quixote",
                    Age = 13,
                    DraftScore = 8.99,
                    Family = quixoteFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Pepe",
                    LastName = "Panzo",
                    Age = 13,
                    DraftScore = 5.64,
                    Family = panzoFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Beetle",
                    LastName = "Bailey",
                    Age = 13,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Cheezy",
                    LastName = "Poof",
                    Age = 13,
                    DraftScore = 6.33,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Dinsdale",
                    LastName = "Piranha",
                    Age = 13,
                    DraftScore = 9.51,
                    Family = piranhaFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Rotting",
                    LastName = "Organs",
                    Age = 13,
                    DraftScore = 3,
                    Family = organsFamily,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Drew",
                    LastName = "Sinclair",
                    Age = 13,
                    DraftScore = 5.55,
                    League = league,
                    PlayerId = rndId.Next(10000)
                },
                new Player
                {
                    FirstName = "Baby-Face",
                    LastName = "Finster",
                    Age = 12,
                    DraftScore = 9.223,
                    League = league,
                    PlayerId = rndId.Next(10000)
                }
            };
        }

        private void InitializeIdentityForEF(DbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            const string name = "Admin";
            const string password = "123456";
            const string test = "test";

            //Create Role Test and User Test
            RoleManager.Create(new IdentityRole(test));
            UserManager.Create(new ApplicationUser() { UserName = test });

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }

            //Create User=Admin with password=123456
            var user = new ApplicationUser {UserName = name};
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
        }
    }

}