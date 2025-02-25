using BoilerManager.Helpers.Enums;

namespace BoilerManager.Model
{
    public class BoilerStateData
    {
        public BoilerStates BoilerState { get; set; }

        public SwitchState InterLockSwitchState { get; set; }

        public DateTime? StateTime { get; set; }

        public BoilerStateData(BoilerStates boilerState, SwitchState interLockSwitchState)
        {
            BoilerState = boilerState;
            InterLockSwitchState = interLockSwitchState;
            StateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{BoilerState},{InterLockSwitchState},{StateTime}";
        }
    }
}
