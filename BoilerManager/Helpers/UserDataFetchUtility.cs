using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerManager.Helpers
{
    public static class UserDataFetchUtility
    {
        public static int GetChoice(int TotalProducts)
        {
            string? Choice = null;
            bool IsValidChoice = false;
            while (!IsValidChoice)
            {
                Console.Write("Enter Your Choice:");
                Choice = MessageReaderUtility.GetInput();
                IsValidChoice = ValidationServiceUtility.ValidateChoice(Choice, TotalProducts);
                Console.WriteLine();
            }
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            return ParsedChoice;
        }
    }
}
