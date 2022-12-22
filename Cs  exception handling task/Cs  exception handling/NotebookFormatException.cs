using System;
using System.Collections.Generic;
using System.Text;

namespace Cs__exception_handling
{
    internal class NotebookFormatException:Exception
    {
        public NotebookFormatException(string message):base(message) 
        {

        }
    }
}
