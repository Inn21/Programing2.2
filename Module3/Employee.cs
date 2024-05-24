using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module3
{
    public class Employee
    {
        public Employee() { }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Position: {Position} HireDate: {HireDate}";
        }

    }
}
