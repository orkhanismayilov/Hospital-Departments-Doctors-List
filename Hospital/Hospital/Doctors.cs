using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Doctors
    {
        public string Fullname { get; set; }
        public string Shift { get; set; }
        public Department Dept { get; set; }

        public Doctors(string Fullname, string Shift)
        {
            this.Fullname = Fullname;
            this.Shift = Shift;
        }

        
    }
}
