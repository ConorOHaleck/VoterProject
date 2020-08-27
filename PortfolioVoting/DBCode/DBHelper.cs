using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioVoting.Models;

namespace PortfolioVoting.DBCode
{
    public class DBHelper
    {
        public async void AddPoll(VoteContext context, Poll poll)
        {
            context.Polls.Add(poll);
            await context.SaveChangesAsync();
        }

        public async void AddPoll(VoteContext context, Poll[] polls)
        {
            context.Polls.AddRange(polls);
            await context.SaveChangesAsync();
        }

        public async void AddAccount(VoteContext context, Account account)
        {
            context.Accounts.Add(account);
            await context.SaveChangesAsync();
        }

        public async void AddAccount(VoteContext context, Account[] accounts)
        {
            context.Accounts.AddRange(accounts);
            await context.SaveChangesAsync();
        }

        public async void AddAnonPoll(VoteContext context, AnonPoll anonpoll)
        {
            context.AnonPolls.Add(anonpoll);
            await context.SaveChangesAsync();
        }

        public async void AddAnonPoll(VoteContext context, AnonPoll[] anonpolls)
        {
            context.AnonPolls.AddRange(anonpolls);
            await context.SaveChangesAsync();
        }

        public async void AddToPoll(VoteContext context, Account[] ToAdd, Poll poll)
        {
            try
            {
                for (int i = 0; i < ToAdd.Length; i++)
                {
                    PollAccount pa = new PollAccount()
                    {
                        Account = ToAdd[i],
                        Poll = poll
                    };

                    context.PollAccounts.Add(pa);
                }

                await context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
