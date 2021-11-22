using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryData;

namespace ClassLibraryData
{
   public class Customer : IEmployee
    {
        public int GetMembers()
        {
            return 50;
        }
    }
}
