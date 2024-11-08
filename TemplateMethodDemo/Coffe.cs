using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal class Coffee : Dish
    {
        public override void Cook()
        {
            Console.WriteLine("варим в турке");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("измельчаем кофе");
        }

        public override void PourInCup()
        {
            Console.WriteLine("наливаем кофе в стакан");
        }
        public override void Serving()
        {
            Console.WriteLine("рисуем сердечко корицей");
        }

    }
}
