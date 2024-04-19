using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Student : LibraryUser
    {
        public uint Grade;

        public Student(string name, uint grade) : base(name)
        {
            Grade = grade;
        }
    }
}
