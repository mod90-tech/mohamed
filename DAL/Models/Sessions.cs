using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Sessions
    {
        [Key]
        public int Id { get; set; }
        public string SesstionDay { get; set; }
        public string SessionDate { get; set; }
        public int TotalSessions { get; set; }
        public int SessionsPerChapter { get; set; }

        public Sessions(int id,string sessionDay, string sessionDate, int Total, int _SessionsPerChapter)
        {
            Id = id;
            SesstionDay = sessionDay;
            SessionDate = sessionDate;
            TotalSessions = Total;
            SessionsPerChapter = _SessionsPerChapter;
        }
    }
}
