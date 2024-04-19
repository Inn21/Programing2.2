using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Teacher: LibraryUser
    {
        public string Subject;

        public Teacher(string name, string subject) : base(name)
        {
            Subject = subject;
        }
    }
}
