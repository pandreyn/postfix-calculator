using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        //calculator.exe 5 6 4 * + 1 -

        static void Main(string[] args)
        {
            // The stack of integers not yet operated on
            Stack<int> values = new Stack<int>();

            string expression = "";
            foreach (string arg in args)
            {
                expression += arg + " ";
            }

            Console.WriteLine("Expression: {0}", expression);

            foreach (string token in args)
            {
                // if the value is an integer...
                int value;
                if (int.TryParse(token, out value))
                {
                    // ... push it to the stack
                    values.Push(value);
                }
                else
                {
                    // otherwise evaluate the expression ...
                    int rhs = values.Pop();
                    int lhs = values.Pop();

                    // ... and pop the result back tj the stack
                    switch (token)
                    {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "%":
                            values.Push(lhs % rhs);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unregognized token: {0}", token));

                    }
                }
            }
            Console.WriteLine("Result: {0}", values.Pop());
            Console.WriteLine();
            Console.WriteLine("Press [Return] to exit...");
            Console.ReadLine();
        }

    }
}
