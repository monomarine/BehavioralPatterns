using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal class Chai : Dish
    {
        public override void Cook()
        {
            Console.WriteLine("наливаем кипяток");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("завариваем чай");
        }

        public override void Serving()
        {
            Console.WriteLine("сыпим сахар");
        }
    }
}
