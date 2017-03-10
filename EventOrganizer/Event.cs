using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    public class Event
    {
        private string title; //event name
        private int time;//time in minutes this takes

        
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public int Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public Event(string t, int tm)
        {
            Title = t;
            Time = tm;
        }
    }
}
