using System.Formats.Asn1;
using System.IO;
using BoilerManager.Helpers;
using BoilerManager.Helpers.Enums;
using BoilerManager.Model;

namespace BoilerManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            BoilerStateData newBoiler = new BoilerStateData(BoilerStates.Lockout, SwitchState.Open);
            BoilerDataLogger boilerDataLogger = new BoilerDataLogger();
            BoilerStateHandler boilerStateHandler = new BoilerStateHandler(newBoiler, boilerDataLogger);
            BoilerManager boilerManager = new BoilerManager(newBoiler, boilerStateHandler);

            boilerStateHandler.OnStateChange += boilerDataLogger.Write;
            bool closeAppFlag = false;
            while (!closeAppFlag)
            {
                Console.Clear();
                try
                {
                    MessageWriterUtility.DialogWriter(new MainMenuOptions());
                    MainMenuOptions UserChoice = (MainMenuOptions)UserDataFetchUtility.GetChoice(Enum.GetNames(typeof(MainMenuOptions)).Length);
                    closeAppFlag = boilerManager.Run(UserChoice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    closeAppFlag = boilerManager.Run(MainMenuOptions.Reset_Lockout);
                    MessageWriterUtility.ActionCompleteNotifier("Boiler RESET Successfully");
                }
            }
        }
    }
}
