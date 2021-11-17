using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class LegArmorDecorator : Decorator
    {
        public LegArmorDecorator(Character chars) : base(chars){}
        public override void Equip()
        {
            Console.WriteLine("Koju sarvai");

            base.Equip();
        }
    }
}