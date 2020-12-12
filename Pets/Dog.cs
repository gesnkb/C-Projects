using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    class Dog: Pet
    {
       
        public Dog(string name, string owner, double weight):base("dog", name, owner, weight)
        {
            this.name = name;
            this.owner = owner;
            this.weight = weight;

        }
        public string bark(int count)
        {
            string result = "";
            for (int i = 0; i <= count - 1; i++)
            {
                result += "bark!\t";
            }

            return result;
        }
    }
}
