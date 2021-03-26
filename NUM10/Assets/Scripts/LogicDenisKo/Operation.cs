namespace LogicDenisKo
{
    public class Operation
    {
        public int A { get; }
        public int B { get; }

        public int? Result
        {
            get
            {
                switch (Operator)
                {
                    case Operator.Sum:
                        return A + B;
                    case Operator.Sub:
                        return A - B;
                    case Operator.Div:
                        if (B != 0 && A % B == 0)
                            return A / B;
                        return null;
                    case Operator.Mul:
                        return A * B;
                    default:
                        return null;
                }
            }
            
        }

        public bool GotResult => Result != null;

        

        public Operator Operator { get; }
        public Operation Clone => new Operation(A, Operator, B);

        public Operation(int a, Operator @operator, int b)
        {
            A = a;
            B = b;
            Operator = @operator;
        }
        
        public override string ToString()
        {
            return $"{A}{Operator.ConvertToString()}{B} = {Result}";
        }
    }
}