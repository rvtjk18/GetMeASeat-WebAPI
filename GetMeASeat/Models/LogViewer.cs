using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetMeASeat.Models
{
    public class LogViewer
    {
        public DateTime TimeStamp { get; set; }
        public DateTime DateofShow { get; set; }
        public int ShowId { get; set; }
        public int ActiveViewers { get; set; }
        public int TotalViewers { get; set; }
        public int ViewersBooked { get; set; }
    }
}