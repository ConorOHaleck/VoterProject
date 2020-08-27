using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioVoting.Models
{
    public class PollAccount
    {

        public int PollID { get; set; }
        public int AccountID { get; set; }

        public Poll Poll { get; set; }
        public Account Account { get; set; }


    }
}
