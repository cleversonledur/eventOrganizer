using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    
    public class Speech : Event
    {
        private string name;

        public Speech(string n,string t, int tm):base(t,tm)
        {
            this.Name = n;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}
