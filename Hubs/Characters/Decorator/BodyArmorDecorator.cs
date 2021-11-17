using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class BodyArmorDecorator : Decorator
    {
        public BodyArmorDecorator(Character chars) : base(chars){}
        public override void Equip()
        {
            Console.WriteLine("Kuno sarvai");

            base.Equip();
        }
    }
}