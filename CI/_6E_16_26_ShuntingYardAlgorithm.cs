using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_26_ShuntingYardAlgorithm
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = "2*3+5/6*3+15";
            var result = PArseRpnForResult(ParseInfixToRpn(input));
            Assert.IsTrue(Math.Abs(result - 23.5) < double.Epsilon);
        }


        private double PArseRpnForResult(IEnumerable<IFoo> input)
        {
            var stack = new Stack<double>();
            foreach (var foo in input)
            {
                if (foo is Operator)
                {
                    var y = stack.Pop();
                    var x = stack.Pop();
                    var result = (foo as Operator).Operation.Invoke(x, y);
                    stack.Push(result);
                }
                else if (foo is Wrapper)
                {
                    stack.Push((foo as Wrapper).Value);
                }
                else throw new Exception("???");
            }
            return stack.Peek();
        }

        private List<IFoo> ParseInfixToRpn(string input)
        {
            var operators = new[] {'-', '+', '*', '/'};
            var tokenisedString = input.Split(operators);
            var list = new List<IFoo>();
            var stack = new Stack<Operator>();
            var n = 0;
            foreach (var c in input)
            {
                if (operators.Contains(c))
                {
                    list.Add(new Wrapper {Value = double.Parse(tokenisedString[n])});
                    var newOperator = new Operator(c);
                    while (stack.Count>0 && newOperator.Precedence <= stack.Peek().Precedence)
                    {
                        list.Add(stack.Pop());
                    }
                    stack.Push(new Operator(c));
                    n++;
                }
            }
            list.Add(new Wrapper {Value = double.Parse(tokenisedString[n])});
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
            return list;
        }

        private interface IFoo
        {
        }

        private class Wrapper : IFoo
        {
            public double Value { get; set; }
            public override string ToString()
            {
                return Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private class Operator : IFoo
        {
            public Func<double, double, double> Operation { get; }
            public int Precedence { get; }
            private Func<string> _toString;

            public override string ToString()
            {
                return _toString.Invoke();
            }

            public Operator(char o)
            {
                switch (o)
                {
                    case '-':
                        Operation = (x, y) => x - y;
                        _toString = () => "-";
                        break;
                    case '+':
                        Operation = (x, y) => x + y;
                        _toString = () => "+";
                        break;
                    case '*':
                        Operation = (x, y) => x*y;
                        _toString = () => "*";
                        Precedence = 1;
                        break;
                    case '/':
                        Operation = (x, y) => x/y;
                        _toString = () => "/";
                        Precedence = 1;
                        break;
                    default:
                        throw new Exception("Invalid operator");
                }
            }
        }
    }
}