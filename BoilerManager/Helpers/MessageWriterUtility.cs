namespace BoilerManager.Helpers
{
    public static class MessageWriterUtility
    {
        public static void DialogWriter(Enum Dialog)
        {
            foreach (var option in Enum.GetValues(Dialog.GetType()))
            {
                Console.WriteLine($"   [{(int)option}]  {option}");
            }
        }
        public static void PrintWarning(string? WarningMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{WarningMessage}");
            Console.ResetColor();
        }
        public static void ActionCompleteNotifier(string? Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"--{Message}--");
            Console.WriteLine("------------------------------\n\n");

            Console.ResetColor();
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }
        internal static void ActionFailedNotifier(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Message}");
            Console.WriteLine("------------------------------\n\n");

            Console.ResetColor();
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }
    }
}
