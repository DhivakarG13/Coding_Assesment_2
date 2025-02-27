using BoilerManager.Helpers;
using BoilerManager.Helpers.Enums;
using BoilerManager.Helpers.Exceptions;
using BoilerManager.Model;

namespace BoilerManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            BoilerStateData newBoiler = new BoilerStateData(BoilerStates.Lockout, SwitchState.Open,DateTime.Now);
            BoilerDataLogger boilerDataLogger = new BoilerDataLogger();
            BoilerStateHandler boilerStateHandler = new BoilerStateHandler(newBoiler, boilerDataLogger);
            BoilerManager boilerManager = new BoilerManager(newBoiler, boilerStateHandler);
            boilerStateHandler.BoilerEventOccurred();
            boilerStateHandler.OnStateChange += boilerDataLogger.WriteToFile;
            boilerStateHandler.OnStateChange += boilerDataLogger.WriteToConsole;
            bool closeAppFlag = false;

            while (!closeAppFlag)
            {
                try
                {
                    MessageUtility.ActionTitleWriter("BOILER APP");
                    MessageUtility.DialogWriter(new MainMenuOptions());
                    MainMenuOptions UserChoice = (MainMenuOptions)UserDataFetchUtility.GetChoice(Enum.GetNames(typeof(MainMenuOptions)).Length);
                    closeAppFlag = boilerManager.Run(UserChoice);
                }
                catch (BoilerFailureException ex)
                {
                    Console.WriteLine(ex.Message);
                    closeAppFlag = boilerManager.Run(MainMenuOptions.Reset_Lockout);
                }
                catch (Exception ex)
                {
                    MessageUtility.ActionFailedNotifier("An error occurred while printing log");
                }
            }
        }
    }
}
