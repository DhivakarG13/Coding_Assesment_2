using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerManager.Helpers
{
    public static class MessageReaderUtility
    {
        public static string? GetInput()
        {
            string? Input = Console.ReadLine();
            return Input;
        }
    }
}
