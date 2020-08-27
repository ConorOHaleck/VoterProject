using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioVoting.Models;

namespace PortfolioVoting.DBCode
{
    public class VoteContext : DbContext
    {
        public VoteContext(DbContextOptions<VoteContext> options) : base(options)
        {

        }

        public VoteContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VotingDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Declare many-to-many relaitonship between Accounts and Polls
            modelBuilder.Entity<PollAccount>().HasKey(x => new { x.AccountID, x.PollID });
            modelBuilder.Entity<PollAccount>().HasOne(pa => pa.Account).WithMany(a => a.PollEnrollment);
            modelBuilder.Entity<PollAccount>().HasOne(pa => pa.Poll).WithMany(p => p.PollVoters);
        }

        //DBSet Properties go here vvvvvv

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAccount> PollAccounts { get; set; }

        public DbSet<AnonPoll> AnonPolls { get; set; }

        public DbSet<OneTimeCode> OneTimeCodes { get; set; }


    }
}
