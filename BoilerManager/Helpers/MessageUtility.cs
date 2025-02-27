using BoilerManager.Model;

namespace BoilerManager.Helpers
{
    public static class MessageUtility
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--{Message}--");
            Console.WriteLine("------------------------------\n\n");
            Console.ResetColor();
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void ActionFailedNotifier(object Message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{Message}");
            Console.WriteLine("------------------------------\n\n");
            Console.ResetColor();
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ActionTitleWriter(string actionTitle)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------------------------");
            Console.WriteLine($"-- {actionTitle} --");
            Console.WriteLine("------------------------------\n\n");
            Console.ResetColor();
        }
        public static string? GetInput()
        {
            string? Input = Console.ReadLine();
            return Input;
        }
        public static void BoilerStatusWriter(BoilerStateData boilerStateData)
        {
            Console.WriteLine($": Boiler State: {boilerStateData.BoilerState}, Switch State: {boilerStateData.InterLockSwitchState}, Occurred at {boilerStateData.StateTime}:");
        }
    }
}
