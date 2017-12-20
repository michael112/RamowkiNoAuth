using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RamowkiNoAuth.DTO;
using RamowkiNoAuth.Services.ScheduleService;
using RamowkiNoAuth.Models;

namespace RamowkiNoAuth.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {

        private readonly IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpPost]
        public void CreateSchedule([FromBody]ScheduledProgrammeWrapper schedule, [FromQuery] String programme = null)
        {
            if( programme != null )
            {
                this.scheduleService.CreateSchedule(schedule.ToScheduledProgrammeJson(), programme);
            }
            else
            {
                this.scheduleService.CreateScheduleAndProgramme(schedule.ToScheduledProgrammeJson(), schedule.Programme);
            }
        }

        [HttpPut("{scheduleID}")]
        public void UpdateSchedule(string scheduleID, [FromBody] ScheduledProgrammeJson programme, [FromQuery(Name = "programme")] String programmeID = null)
        {
            if( ( programmeID == null ) && ( programme != null ) )
            {
                this.scheduleService.UpdateSchedule(scheduleID, programme);
                Console.WriteLine(programme.BeginTime.Hours + ":" + programme.BeginTime.Minutes);
            }
            else if( ( programmeID != null ) && ( programme == null ) )
            {
                this.scheduleService.SwitchProgramme(scheduleID, programmeID);
            }
            /*
            else
            {
                return BadRequest(); // na razie nie działa, bo cholerstwo musiałoby zwracać określone typy
            }
            */
        }

        [HttpDelete("{scheduleID}")] 
        public void DeleteSchedule(string scheduleID)
        {
            this.scheduleService.DeleteSchedule(scheduleID);
        }

        [HttpGet("{scheduleID}")]
        public ScheduledProgramme GetScheduledProgramme(string scheduleID)
        {
            return this.scheduleService.GetScheduledProgramme(scheduleID);
        }

        [HttpGet]
        public IEnumerable<ScheduledProgramme> GetScheduledProgrammeList([FromQuery(Name = "day")] int? dayNumber = null, [FromQuery] String date = null)
        {
            if (date != null)
            {
                return this.scheduleService.GetScheduledProgrammeListByDate(date);
            }
            else if (dayNumber != null)
            {
                return this.scheduleService.GetScheduledProgrammeListByWeekDay((int)dayNumber);
            }
            else return null;
        }
    }
}
