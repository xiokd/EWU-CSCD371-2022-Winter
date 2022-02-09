using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LambdaExpressions.Tests
{
    [TestClass]
    public class MathQueueTests
    {


        [TestMethod]
        public void TestMethod1()
        {
            MathQueue mathQueue = new MathQueue();

            mathQueue.Queue(42, 4.2,  (MathOperation<double>) ((left, right, more) => left*right*more));

            mathQueue.Queue(42, 4.2, Add);

            Func<int, double, double> multiply = (left, right) => left * right;
            
            mathQueue.Queue(42, 4.2, multiply);

            mathQueue.Queue(42, 4.2,
                (left, right) => left/right
            );

            Func<int, int> oneParamAction = left => left;

            Action<int, double> doSomething = (left, right) =>
             {
                 double result = left+right;
                 Console.WriteLine(result*result);
             };

            mathQueue.Queue(42, 4.2,
                (left, right) =>
                {
                    double result= left+right;
                    return result*result;
                }
            ) ;

            // ???? Max (int left, int right) => left > right ? right : left;
        }

        private double Add(int left, double right)
            => left + right;

    }
}