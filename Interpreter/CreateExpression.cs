using System;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class CreateExpression : IExpression
    {
        readonly IExpression functionName;
        readonly List<IExpression> npcTypes;
        readonly int min;
        readonly int max;

        public string npcType { get; private set; }
        public int npcAmount { get; private set; }

        public CreateExpression(IExpression functionName, List<IExpression> npcTypes, int min, int max)
        {
            this.functionName = functionName;
            this.npcTypes = npcTypes;
            this.min = min >= 0 && min <= 100 ? min : 0;
            this.max = max > 0 && max <= 100 ? max : 100;
        }

        public bool Interpret(string context)
        {
            string[] temp = context.Split(' ');

            if (temp.Length != 5) // Too many arguments
                return false;

            if (!functionName.Interpret(context))
                return false;

            bool isNpc = false;
            foreach (IExpression npc in npcTypes)
                if (npc.Interpret(temp[3]))
                {
                    npcType = (npc as TerminalExpression).data;
                    isNpc = true;
                }

            if (!isNpc)
                return false;

            if (int.TryParse(temp[4], out int amount)) {
                if (min > amount)
                {
                    Console.WriteLine($"Amount was too small! Given {amount}, minimum value {min} ");
                    return false;
                }
                else if (max < amount)
                {
                    Console.WriteLine($"Amount was too large! Given {amount}, maximum value {max} ");
                    return false;
                }
                npcAmount = amount;
            }
            else
            {
                Console.WriteLine("Amount couldn't be parsed!");
                return false;
            }

            return true;
        }
    }
}