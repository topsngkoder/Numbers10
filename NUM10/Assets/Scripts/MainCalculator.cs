public class MainCalculator
{
    public int? Calculate(int a, Operator @operator, int b)
    {
        {
            switch (@operator)
            {
                case Operator.Sum:
                    return a + b;
                case Operator.Sub:
                    return a - b;
                case Operator.Div:
                    if (b != 0 && a % b == 0)
                        return a / b;
                    return null;
                case Operator.Mul:
                    return a * b;
                default:
                    return null;
            }
        }
            
    }
    
    
}