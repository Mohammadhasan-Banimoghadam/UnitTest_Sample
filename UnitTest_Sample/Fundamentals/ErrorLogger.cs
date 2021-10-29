using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }
        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}
