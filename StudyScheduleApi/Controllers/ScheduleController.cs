using BAL.services;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyScheduleApi.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;
        private readonly IRepository<Schedule> _Schedule;

        public ScheduleController(ScheduleService scheduleService, IRepository<Schedule> Schedule)
        {
            _scheduleService = scheduleService;
            _Schedule = Schedule;
        }
        [HttpPost("generateschedule")]
        public IActionResult GenerateSchedule([FromBody] Schedule schedule)
        {
            try
            {
                return Ok(_scheduleService.GenerateSchedule(schedule));
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
