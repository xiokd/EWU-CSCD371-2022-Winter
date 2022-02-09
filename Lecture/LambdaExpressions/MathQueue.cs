namespace LambdaExpressions
{
    public delegate double MathOperation<TLeft>(TLeft left, double right, double more);

    public class MathQueue
    {
        List<( Func<int, double, double> Operation, int Left, double Right)> InternalQueue { get;  } = new();

        public void Queue(int left, double right, Func<int, double, double> operation)
        {
            InternalQueue.Add((operation, left, right));
        }

        public void Queue(int left, double right, MathOperation<double> operation)
        {
            double result = operation(left, right, 0);
        }

        public double Calculate()
        {
            double result = 0;
            foreach(
                (Func<int, double, double> Operation, int Left, double Right) item in InternalQueue)
            {

                result += item.Operation(item.Left, item.Right);
            }
            return result;
        }
    }
}