using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioVoting.Models
{
    public class AnonPoll
    {

        public int AnonPollID { get; set; }
        public virtual ICollection<OneTimeCode> PollsterCodes { get; set; }
    }
}
