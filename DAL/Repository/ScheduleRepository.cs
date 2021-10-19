using DAL.Data;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        ApplicationDbContext _dbContext;
        public ScheduleRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public Sessions[] Generate(Schedule _object)
        {
            int ChaptersNo = 30;
            int id = 1;
            int TotalSessions = _object.ChapterSessionsNo * ChaptersNo;
            int SessionsPerChapter = _object.ChapterSessionsNo;
            CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime Date = DateTime.ParseExact(_object.StartingDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
            //  DateTime StartingDate = DateTime.ParseExact(_object.StartingDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
            DateTime Date = Convert.ToDateTime(_object.StartingDate, CultureInfo.InvariantCulture);
            string StartDate = string.Format("{0:dd/MM/yyyy}", Date); 
            string[] DateArr = StartDate.Split("/");            
            string[] Sessions = new string[TotalSessions];            
            string[] WeekDays = { "Friday","Saturday", "Sunday","Monday","Tuesday","Wednesday","Thursday"};
            int StudyDaysTotal = _object.StudyWeekDays.Length;
            string[] StudyDays = new string[7];//array for studying days
            bool found = false; // check session exist in studyDays array or not
            var sessions = new Sessions[TotalSessions]; 
            // fill studying days array.
            for(int i=0; i < StudyDaysTotal; i++)
            {
                int index = _object.StudyWeekDays[i];
                StudyDays[i] = WeekDays[index];
            }
           
              string day = Date.DayOfWeek.ToString();
            for (int i = 0; i < TotalSessions; i++)
            {
                for (int j = 0; j < StudyDays.Length; j++)
                {
                    if (StudyDays.Contains(day))
                    {
                        Sessions[i] = Date.Date.ToString("dd/MM/yyyy");
                        var session = new Sessions(id, day, Sessions[i], TotalSessions, SessionsPerChapter);
                        sessions[i] = session;
                        id++;
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                        continue;
                    }
                }
                if (found == false)
                {

                    int Day = Int32.Parse(DateArr[0]);
                    Day++;
                    int Month = Int32.Parse(DateArr[1]);
                    int days = DateTime.DaysInMonth(2021, Month);
                    if (Day > days)
                    {
                        Day = 1;
                        Month++;
                        if(Month > 12)
                        {
                            Month = 1;
                            int year = Int32.Parse(DateArr[2])+1;
                            string NextDate = "0" + Day + "/" + "0"+Month + "/" + year;
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                        else if (Month > 10)
                        {
                            string NextDate = "0" + Day + "/" + Month + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        } 
                        else
                        {
                            string NextDate = "0" + Day + "/" + "0"+Month + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }    
                    }
                    else
                    {
                        if(Day < 10)
                        {
                            string NextDate = "0"+Day + "/" + DateArr[1] + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }   
                        else
                        {
                            string NextDate = Day + "/" + DateArr[1] + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }                       
                    }
                    i--;
                }
                else
                {                   
                    int Day = Int32.Parse(DateArr[0]);
                    Day++;
                    int Month = Int32.Parse(DateArr[1]);
                    int days = DateTime.DaysInMonth(2021, Month);
                    if (Day > days)
                    {
                        Day = 1;
                        Month++;
                        if (Month > 12)
                        {
                            Month = 1;
                            int year = Int32.Parse(DateArr[2]) + 1;
                            string NextDate = "0" + Day + "/" + "0" + Month + "/" + year;
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                        else if (Month > 10)
                        {
                            string NextDate = "0" + Day + "/" + Month + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                         else
                        {
                            string NextDate = "0" + Day + "/" + "0" + Month + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                    }
                    else
                    {
                        if (Day < 10)
                        {
                            string NextDate = "0" + Day + "/" + DateArr[1] + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                        else
                        {
                            string NextDate = Day + "/" + DateArr[1] + "/" + DateArr[2];
                            Date = DateTime.ParseExact(NextDate, new string[] { "dd/MM/yyyy" }, provider, DateTimeStyles.None);
                            day = Date.DayOfWeek.ToString();
                            DateArr = NextDate.Split("/");
                        }
                    }                   
                }
            }
               return sessions;
        }
        public async Task<Schedule> Create(Schedule _object)
        {
            throw new NotImplementedException();
        }

        public void Delete(Schedule _object)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Schedule> GetAll()
        {
            throw new NotImplementedException();
        }

        public Schedule GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Schedule _object)
        {
            throw new NotImplementedException();
        }
    }
}
