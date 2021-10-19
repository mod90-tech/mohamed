using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.services
{
    public class ScheduleService
    {
        private readonly IRepository<Schedule> _schedule;

        public ScheduleService(IRepository<Schedule> schedule)
        {
            _schedule = schedule;
        }
        public Sessions[] GenerateSchedule(Schedule _object)
        {
            try
            {
                return _schedule.Generate(_object);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
