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
        public void Start()
        {
            if(_boiler.InterLockSwitchState == SwitchState.Open)
            {
                Console.WriteLine("Your InterLock Switch is Open please Close it to continue");
            }
            if (_boiler.InterLockSwitchState == SwitchState.Close && _boiler.BoilerState == BoilerStates.Lockout)
            {
                _boiler.BoilerState = BoilerStates.Ready;
                BoilerEventOccurred();

                while (_boiler.InterLockSwitchState == SwitchState.Close && _boiler.BoilerState != BoilerStates.Lockout)
                {
                    Thread.Sleep(3000);
                    if (_boiler.BoilerState == BoilerStates.Operational)
                    {
                        Console.WriteLine("Your Boiler reached the operational state");
                        break;
                    }
                    _boiler.BoilerState = _boiler.BoilerState + 1;
                    Console.WriteLine($"New State = {_boiler.BoilerState.ToString()}");
                    BoilerEventOccurred();
                    //Trigger the Event
                }
            }
            else
            {
                Console.WriteLine("Your boiler is in running state already");
            }
        }

        public void ResetBoiler()
        {
            _boiler.InterLockSwitchState = SwitchState.Open;
            _boiler.BoilerState = BoilerStates.Lockout;
        }

        public void ToggleInterLockSwitchState()
        {
            if(_boiler.InterLockSwitchState == SwitchState.Open)
            {
                _boiler.InterLockSwitchState = SwitchState.Close;
            }
            else if(_boiler.InterLockSwitchState != SwitchState.Open)
            {
                _boiler.InterLockSwitchState = SwitchState.Open;
            }
        }

        public void Stop()
        {
            _boiler.InterLockSwitchState = SwitchState.Open;
            _boiler.BoilerState = BoilerStates.Lockout;
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
