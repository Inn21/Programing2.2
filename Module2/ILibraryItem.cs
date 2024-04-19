using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{    internal interface ILibraryItem
    {
        public bool isFree();

        public void Give();

        public void Return();

    }
}
