using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class Mixed : AttackAlgorithm
    {
        public Mixed(float damage) : base(damage) {}

        public override void Attack(float x, float y)
        {

        }
    }
}