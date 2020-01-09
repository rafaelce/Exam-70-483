using System;

namespace Skill_1._4_Action_Delegate
{
    class Alarm
    {
        public Action OnAlarmeRaised { get; set; }

        public void RaiseAlarm() {
            if (OnAlarmeRaised != null) {
                OnAlarmeRaised();
            }
        }
    }
}
