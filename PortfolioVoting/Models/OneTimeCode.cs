using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioVoting.Models
{
    public class OneTimeCode
    {
        public int OTCID { get; set; }

        public string Code { get; set; }

        public static OneTimeCode generateCode(AnonPoll poll)
        {

        }

        public static OneTimeCode[] generateCode(int codeCount, AnonPoll poll)
        {
            OneTimeCode[] otc = new OneTimeCode[codeCount];

            for(int i = 0; i < codeCount; i++)
            {
                otc[i] = generateCode(poll);
            }

            return otc;

        }

        public override string ToString()
        {
            return Code;
        }
    }
}
