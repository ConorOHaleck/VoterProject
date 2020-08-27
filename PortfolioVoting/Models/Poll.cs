using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioVoting.Models
{
    public class Poll
    {

        public int PollID { get; set; }

        public string PollTitle { get; set; }

        public virtual ICollection<PollAccount> PollVoters { get; set; }
    }
}
