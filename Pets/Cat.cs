using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    class Cat : Pet
    {

        public Cat( string name, string owner, double weight) : base("cat", name, owner, weight)
        {
            
            this.name = name;
            this.owner = owner;
            this.weight = weight;
        }
        public string meow(int count)
        {
            string result = "";
            for (int i = 0; i <= count - 1; i++)
            {
                result += "meow.\t";
            }

            return result;
        }
    }
}
