using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

using RamowkiAPIMockedNoSQL.Models;

namespace RamowkiAPIMockedNoSQL.DTO
{
    public class DayWrapper
    {
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int? WeekDay { get; set; }
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public String Date { get; set; }

        public Day ToDay()
        {
            if( this.Date == null )
            {
                return ( this.WeekDay != null ) ? ( new WeekDay( (int) this.WeekDay ) ) : null;
            }
            else
            {
                return new DateDay(this.Date);
            }
        }

        public DayWrapper() {}
        public DayWrapper(int weekDay)
        {
            this.WeekDay = weekDay;
        }
        public DayWrapper(string date)
        {
            this.Date = date;
        }
    }
}
