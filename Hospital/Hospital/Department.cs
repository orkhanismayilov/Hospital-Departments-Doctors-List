using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Department
    {
        public string Name { get; set; }
        public List<Doctors> Docs = new List<Doctors>();

        public Department(string Name)
        {
            this.Name = Name;
        }

        
    }
}
