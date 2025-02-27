using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerManager.Helpers.Exceptions
{
    public class  BoilerFailureException : Exception
    {
        int StatusCode;
        public BoilerFailureException(string message = "Invalid User Input Exception is thrown")
        : base(message)
        {

        }
        public BoilerFailureException(string message, Exception innerException)
        : base(message, innerException)
        {

        }
        public BoilerFailureException(string message , int statusCode): base(message) 
        {
            StatusCode = statusCode;
        }
        public BoilerFailureException(string message , int statusCode , Exception innerException) : base(message , innerException) 
        {
            StatusCode = statusCode;
        }

        
    }
}
