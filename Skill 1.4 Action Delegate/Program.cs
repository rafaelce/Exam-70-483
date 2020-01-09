using System;

namespace Skill_1._4_Action_Delegate
{
    class Program
    {
        static void AlarmListener1() {
            Console.WriteLine("Alarm listener 1 called.");
        }

        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called.");
        }

        static void Main(string[] args)
        {
            //create a new alarm
            Alarm alarm = new Alarm();

            //connect the two listener methods
            alarm.OnAlarmeRaised += AlarmListener1;
            alarm.OnAlarmeRaised += AlarmListener2;

            //raise the alarm
            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised");

            Console.ReadKey();

        }
    }
}
