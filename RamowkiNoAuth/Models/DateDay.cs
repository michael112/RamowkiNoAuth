using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamowkiNoAuth.Models
{
    public class DateDay : Day
    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value.Date;
            }
        }

        public DateDay() {}
        public DateDay(string date)
        {
            this.Date = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
