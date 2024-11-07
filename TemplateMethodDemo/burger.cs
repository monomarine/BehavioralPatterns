using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal class Burger : Dish
    {
        public override void Cook()
        {
            Console.WriteLine("Подготоваливаем овощи");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("Жарим катлетку");
        }

        public override void Serving()
        {
            Console.WriteLine("Собираем бургер");
        }
    }
}
