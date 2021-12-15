using System;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class CreateGroupExpression : IExpression
    {
        readonly IExpression functionName;

        public CreateGroupExpression(IExpression functionName)
        {
            this.functionName = functionName;
        }

        public bool Interpret(string context)
        {
            string[] temp = context.Split(' ');

            if (temp.Length != 4) // Too many arguments
                return false;

            if (!functionName.Interpret(context))
                return false;

            return true;
        }
    }
}