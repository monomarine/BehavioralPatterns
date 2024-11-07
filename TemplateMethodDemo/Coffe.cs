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
            Console.WriteLine("варим в турке кофе");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("измельчаем кофе в дробилке");
        }

        public override void Serving()
        {
            Console.WriteLine("рисуем сердечко корицей красиво");
        }
    }
}
