using System;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class SelectExpression : IExpression
    {
        readonly IExpression functionName;

        public string npcType { get; private set; }

        public SelectExpression(IExpression functionName)
        {
            this.functionName = functionName;
        }

        public bool Interpret(string context)
        {
            string[] temp = context.Split(' ');

            if (temp.Length != 2)
                return false;

            if (!functionName.Interpret(temp[0]))
                return false;

            return true;
        }
    }
}