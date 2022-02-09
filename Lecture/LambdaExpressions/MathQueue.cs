namespace LambdaExpressions
{
    public class MathQueue
    {


        public void Queue(int left, double right, Func<int, double, double> operation)
        {
            double result = operation(left, right);


           
        }
    }
    }
}