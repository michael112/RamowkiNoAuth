using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using RamowkiAPIMockedNoSQL.DTO;
using RamowkiAPIMockedNoSQL.Models;
using RamowkiAPIMockedNoSQL.Services.ProgrammeService;

namespace RamowkiAPIMockedNoSQL.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private ApplicationDbContext dbContext;
        private IProgrammeService programmeService;

        public void CreateSchedule(ScheduledProgrammeJson schedule, String programme)
        {
            ScheduledProgramme newSchedule = new ScheduledProgramme(this.programmeService.ReadProgramme(programme), schedule.Day.ToDay(), schedule.BeginTime);
            this.dbContext.Add(newSchedule);
            this.dbContext.SaveChanges();
        }
        public void CreateScheduleAndProgramme(ScheduledProgrammeJson schedule, ProgrammeJson programme)
        {
            string programmeID = this.programmeService.CreateProgrammeAndReturnId(programme);
            CreateSchedule(schedule, programmeID);
        }
        public void UpdateSchedule(string scheduleID, ScheduledProgrammeJson programme)
        {
            ScheduledProgramme scheduleToEdit = this.GetScheduledProgramme(scheduleID);
            scheduleToEdit.Day = programme.Day.ToDay();
            scheduleToEdit.BeginTime = programme.BeginTime;
            this.dbContext.SaveChanges();
        }
        public void SwitchProgramme(string scheduleID, string programmeID)
        {
            ScheduledProgramme scheduleToEdit = this.GetScheduledProgramme(scheduleID);
            Programme newProgramme = this.programmeService.ReadProgramme(programmeID);
            scheduleToEdit.Programme = newProgramme;
            this.dbContext.SaveChanges();
        }
        public void DeleteSchedule(string scheduleID)
        {
            this.dbContext.Remove(this.GetScheduledProgramme(scheduleID));
            this.dbContext.SaveChanges();
        }
        public ScheduledProgramme GetScheduledProgramme(string scheduleID)
        {
            return this.dbContext.ScheduledProgrammes.Include(s => s.Programme).Include(s => s.Day).Single(s => s.Id.ToString() == scheduleID);
        }
        public IEnumerable<ScheduledProgramme> GetScheduledProgrammeListByWeekDay(int dayNumber)
        {
            return this.dbContext.ScheduledProgrammes.Include(s => s.Programme).Include(s => s.Day).Where( s => ( s.Day is WeekDay ) && ( ( (WeekDay) s.Day ).Day.Equals(dayNumber) ) ).ToList();
        }
        public IEnumerable<ScheduledProgramme> GetScheduledProgrammeListByDate(string date)
        {
            DateTime seekDate = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            IEnumerable<ScheduledProgramme> dateList = this.dbContext.ScheduledProgrammes.Include(s => s.Programme).Include(s => s.Day).Where(s => ( s.Day is DateDay ) && ( ( (DateDay) s.Day ).Date.Equals(seekDate) ) ).ToList();
            if( dateList.Count() <= 0 )
            {
                return this.GetScheduledProgrammeListByWeekDay((int)seekDate.DayOfWeek);
            }
            else
            {
                return dateList;
            }
        }

        public ScheduleService(ApplicationDbContext dbContext, IProgrammeService programmeService)
        {
            this.dbContext = dbContext;
            this.programmeService = programmeService;
        }
    }
}
