using System;
using System.Collections.Generic;
using System.Text;
using TimeForChorein.Enums;

namespace TimeForChorein.Models
{
    public class ChoreSession
    {
        public ChoreSession()
        {

        }

        public int SessionLength { get; set; }

        public SessionStatus Status { get; set; }
    }
}
