using BoilerManager.Helpers;
using BoilerManager.Helpers.Enums;
using BoilerManager.Helpers.Exceptions;
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
            switch (userChoice)
            {
                case MainMenuOptions.Toggle_Switch:
                    boilerStateHandler.ToggleInterLockSwitchState();
                    return false;
                case MainMenuOptions.Start_Boiler:
                    boilerStateHandler.Start();
                    return false;

                case MainMenuOptions.Stop_Boiler:
                    boilerStateHandler.Stop();
                    return false;

                case MainMenuOptions.Simulate_Error:
                    if(boilerData.BoilerState == BoilerStates.Operational)
                    {
                    throw new BoilerFailureException("Simulating Error");
                    }
                    return false;

                case MainMenuOptions.Reset_Lockout:
                    boilerStateHandler.ResetBoiler();
                    return false;

                case MainMenuOptions.View_Event_Log:
                    boilerStateHandler.PrintLog();
                    MessageUtility.ActionCompleteNotifier("Available Events Displayed");
                    return false;

                case MainMenuOptions.ExitApp:
                    return true;
            }
            return false;
        }
    }
}
