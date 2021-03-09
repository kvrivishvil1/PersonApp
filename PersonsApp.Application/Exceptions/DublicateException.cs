using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Exceptions
{
    public class DublicateException : ApplicationException
    {
        public DublicateException(string message) : base(message)
        {

        }
    }
}
