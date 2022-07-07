using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class DbNotExistException : Exception
    {
        public DbNotExistException(string message)
           : base(message)
        {

        }
    }
}
