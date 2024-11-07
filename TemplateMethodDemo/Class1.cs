using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal class Shawarma: Dish
    {
        public override void Cook()
        {
            Console.WriteLine("Собираем шаурму");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("жарим мясо, режем овощи");
        }

        public override void Serving()
        {
            Console.WriteLine("рисуем сердечко кутчупом");
        }

        public override void Topping()
        {
            Console.WriteLine("Добовляем по желанию пользователя сырный или классический соус");
        }
    }
}
