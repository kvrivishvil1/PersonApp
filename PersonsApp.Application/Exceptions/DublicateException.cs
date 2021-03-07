using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Exceptions
{
    public class DublicateException : ApplicationException
    {
        public DublicateException() : base($"Allready Exists")
        {

        }
    }
}
