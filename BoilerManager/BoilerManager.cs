using BoilerManager.Helpers;
using BoilerManager.Helpers.Enums;
using BoilerManager.Model;

namespace BoilerManager
{
    public class BoilerManager
    {
        public BoilerStateData boilerData;
        public BoilerStateHandler boilerStateHandler;

        public BoilerManager(BoilerStateData _boiler, BoilerStateHandler stateHandler)
        {
            boilerData = _boiler;
            this.boilerStateHandler = stateHandler;
        }

        public bool Run(MainMenuOptions userChoice)
        {
            Console.Clear();
            switch (userChoice)
            {
                case MainMenuOptions.Start_Boiler:
                    boilerStateHandler.Start();
                    MessageWriterUtility.ActionCompleteNotifier("Boiler Run SUCCESSFULLY");
                    return false;

                case MainMenuOptions.Stop_Boiler:
                    boilerStateHandler.Stop();
                    MessageWriterUtility.ActionCompleteNotifier("Boiler stop SUCCESSFULLY");
                    return false;

                case MainMenuOptions.Simulate_Error:
                    if(boilerData.BoilerState == BoilerStates.Operational)
                    {
                        throw new Exception($"Error: [Error Description]. System in Lockout.");
                    }
                    return false;

                case MainMenuOptions.Toggle_Switch:
                    boilerStateHandler.ToggleInterLockSwitchState();
                    MessageWriterUtility.ActionCompleteNotifier("Inter Lock Switch Toggled SUCCESSFULLY");
                    return false;

                case MainMenuOptions.Reset_Lockout:
                    boilerStateHandler.ResetBoiler();
                    MessageWriterUtility.ActionCompleteNotifier("Boiler Reset SUCCESSFULLY");
                    return false;

                case MainMenuOptions.View_Event_Log:
                    boilerStateHandler.PrintLog();
                    MessageWriterUtility.ActionCompleteNotifier("Available Events Displayed");
                    return false;

                case MainMenuOptions.ExitApp:
                    return true;
            }
            Console.Clear();
            return false;
        }
    }
}
