using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._5_Reflection
{
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [NonSerialized]
        private int screenPosition;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            screenPosition = 0;
        }
    }
}
