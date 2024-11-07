using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal class Salad : Dish
    {
        public override void Cook()
        {
            Console.WriteLine("смешиваем ингридиенты и поливаем соусом");
        }

        public override void PrepareIngridients()
        {
            Console.WriteLine("Помыть овощи и нарезать");
        
        }

        public override void Serving()
        {
            Console.WriteLine("выкладываем салат в салатник");
        }

        public override void Topping()
        {
            Console.WriteLine("Ро желанию пользователя добавляем соус сырный или майнез");
        }
    }
}
