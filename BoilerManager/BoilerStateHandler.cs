using BoilerManager.Helpers;
using BoilerManager.Helpers.Enums;
using BoilerManager.Model;

public delegate void RecordData(BoilerStateData boilerData);

namespace BoilerManager
{
    public class BoilerStateHandler
    {
        BoilerStateData _boiler;
        BoilerDataLogger _boilerDataLogger;
        public event RecordData? OnStateChange;

        public BoilerStateHandler(BoilerStateData boiler, BoilerDataLogger boilerDataLogger)
        {
            _boiler = boiler;
            _boilerDataLogger = boilerDataLogger;
        }

        public void StartBoiler()
        {
            if (_boiler.InterLockSwitchState == SwitchState.Open)
            {
                Console.WriteLine("Your InterLock Switch is Open please Close it to continue");
                MessageUtility.ActionFailedNotifier("Couldn't start your Boiler :( ");
            }
            else if (_boiler.InterLockSwitchState == SwitchState.Close && _boiler.BoilerState == BoilerStates.Ready)
            {
                MessageUtility.ActionTitleWriter("Running Boiler");
                while (_boiler.InterLockSwitchState == SwitchState.Close && _boiler.BoilerState != BoilerStates.Lockout)
                {
                    _boiler.BoilerState = _boiler.BoilerState + 1;
                    _boiler.StateTime = DateTime.Now;
                    BoilerEventOccurred();
                    if (_boiler.BoilerState == BoilerStates.Operational)
                    {
                        Console.WriteLine("Your Boiler reached the operational state");
                        MessageUtility.ActionCompleteNotifier("Boiler Run SUCCESSFULLY");
                        break;
                    }
                    int timer = 0;
                    while (timer++ != 10)
                    {
                        Console.Write(timer + " ");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Your boiler is in running state already");
            }
        }

        public void Stop()
        {
            if (_boiler.BoilerState != BoilerStates.Lockout && _boiler.InterLockSwitchState != SwitchState.Open)
            {
                _boiler.InterLockSwitchState = SwitchState.Open;
                _boiler.BoilerState = BoilerStates.Lockout;
                _boiler.StateTime = DateTime.Now;
                BoilerEventOccurred();
                MessageUtility.ActionCompleteNotifier("Boiler stop SUCCESSFULLY");
            }
            else
            {
                MessageUtility.ActionFailedNotifier("Boiler not yet started");
            }

        }

        public void ResetBoiler()
        {
            _boiler.InterLockSwitchState = SwitchState.Open;
            _boiler.BoilerState = BoilerStates.Lockout;
            _boiler.StateTime = DateTime.Now;
            BoilerEventOccurred();
            MessageUtility.ActionCompleteNotifier("Boiler Reset SUCCESSFULLY");
        }

        public void ToggleInterLockSwitchState()
        {
            if (_boiler.InterLockSwitchState == SwitchState.Open)
            {
                _boiler.InterLockSwitchState = SwitchState.Close;
                _boiler.BoilerState = BoilerStates.Ready;
            }
            else if (_boiler.InterLockSwitchState != SwitchState.Open)
            {
                _boiler.InterLockSwitchState = SwitchState.Open;
            }
            _boiler.StateTime = DateTime.Now;
            BoilerEventOccurred();
            MessageUtility.ActionCompleteNotifier("Inter Lock Switch Toggled SUCCESSFULLY");
        }

        public void PrintLog()
        {
            _boilerDataLogger.Read();
        }

        public void BoilerEventOccurred()
        {
            if (OnStateChange != null)
            {
                OnStateChange(_boiler);
            }
        }

    }
}
