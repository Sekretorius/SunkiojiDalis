using System;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class BehaviorExpression : IExpression
    {
        readonly IExpression functionName;
        readonly List<IExpression> behaviorTypes;

        public string npcType { get; private set; }

        public BehaviorExpression(IExpression functionName, List<IExpression> behaviorTypes)
        {
            this.functionName = functionName;
            this.behaviorTypes = behaviorTypes;
        }

        public bool Interpret(string context)
        {
            string[] temp = context.Split(' ');

            if (temp.Length != 2) // Too many arguments
                return false;

            if (!functionName.Interpret(temp[0]))
                return false;

            bool isNpc = false;
            foreach (IExpression npc in behaviorTypes)
                if (npc.Interpret(temp[1]))
                {
                    isNpc = true;
                    break;
                }

            if (!isNpc)
                return false;

            return true;
        }
    }
}