using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class HelmetDecorator : Decorator
    {
        public HelmetDecorator(Character chars) : base(chars){}
        public override void Equip()
        {
            Console.WriteLine("Salmas");

            base.Equip();
        }
    }
}