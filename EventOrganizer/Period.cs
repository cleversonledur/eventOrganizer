using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    public class Period
    {
        public List<Speech> eventList = new List<Speech>();

        DateTime start;
        DateTime end;
        DateTime specialend;
        string specialend_name;

        private int totalTime;


        public int TotalTime
        {
            get
            {
                return totalTime;
            }

            set
            {
                totalTime = value;
            }
        }

        public DateTime Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public DateTime Specialend
        {
            get
            {
                return specialend;
            }

            set
            {
                specialend = value;
            }
        }

        public string Specialend_name
        {
            get
            {
                return specialend_name;
            }

            set
            {
                specialend_name = value;
            }
        }

        public Period(string st, string en, string ee, string ee_name)
        {
            Start = DateTime.Parse(st);
            end = DateTime.Parse(en);
            Specialend = DateTime.Parse(ee);
            Specialend_name = ee_name;
            totalTime = (int)(end - Start).TotalMinutes;

        }
        public int emptyTime()
        {
            int sum = 0;
            foreach (var i in eventList)
            {
                sum += i.Time;
            }
            return TotalTime - sum;
        }
        public bool Validate()
        {
            foreach (var item in eventList)
            {
                if (item.Name == "")
                {
                    return false;
                }
                if (item.Time.GetHashCode() == 0)
                {
                    return false;
                }
                if (item.Title == "")
                {
                    return false;
                }
            }
            if (start.GetHashCode() == 0)
            {
                return false;
            }
            if (end.GetHashCode() == 0)
            {
                return false;
            }
            if (specialend.GetHashCode() == 0)
            {
                return false;
            }
            if (Specialend_name == "")
            {
                return false;
            }
            return true;
        }
    }
}
