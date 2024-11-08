using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    internal abstract class Dish
    {
        public void OrderDish()
        {
            PrepareIngridients();
            Cook();
            Serving();
            PourInCup();
        }

        public abstract void PrepareIngridients();
        public abstract void Cook();
        public abstract void Serving();
        public abstract void PourInCup();
    }
}
