using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Character
{
    public enum MoveType
    {
        Stand,
        Walk,
        Fly
    }
    public abstract class MoveAlgorithm
    {
        public abstract void Move(ref float x, ref float y, float speed);
    }
}