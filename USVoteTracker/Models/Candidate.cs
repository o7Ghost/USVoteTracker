using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USVoteTracker.Models
{
    public class Candidate
    {
        public string Name
        {
            get;
            set;
        }

        public string Party
        {
            get;
            set;
        }

        public int Votes
        {
            get;
            set;
        }
    }
}