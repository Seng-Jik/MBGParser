using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser.Event
{
    public struct Condition
    {
        public struct Expression
        {
            public enum OpType
            {
                Greater,
                Less,
                Equals
            }

            public string LValue;
            public OpType Operator;
            public double RValue;

            internal static Expression ParseFrom(string c)
            {
                Expression e;

                if (c.Contains('>'))
                    e.Operator = OpType.Greater;
                else if (c.Contains('<'))
                    e.Operator = OpType.Less;
                else if (c.Contains('='))
                    e.Operator = OpType.Equals;
                else
                    throw new ParserException("未能解析表达式");

                var values = c.Split('>', '<', '=');
                e.LValue = values[0];
                e.RValue = double.Parse(values[1]);

                return e;
            }
        }

        public struct SecondCondition
        {
            public enum LogicOpType
            {
                And,
                Or
            };

            public LogicOpType LogincOp;
            public Expression Expr;
        }

        public Expression First;
        public SecondCondition? Second;

        internal static Condition ParseFrom(string c)
        {
            SecondCondition.LogicOpType? op = null;

            if (c.Contains('且')) op = SecondCondition.LogicOpType.And;
            else if (c.Contains('或')) op = SecondCondition.LogicOpType.Or;

            Condition condition;
            if (op == null)
            {
                condition.First = Expression.ParseFrom(c);
                condition.Second = null;
            }
            else
            {
                var exprs = c.Split('且', '或');
                condition.First = Expression.ParseFrom(exprs[0]);
                condition.Second = new SecondCondition
                {
                    LogincOp = op.Value,
                    Expr = Expression.ParseFrom(exprs[1])
                };
            }




            return condition;
        }
    }
}
