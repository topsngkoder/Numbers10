using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicDenisKo
{
    public class Solution
    {
        public List<int> Numbers { get; }
        public List<Operator> Operators { get; }

        public int? Result => OperationsList.Count < Numbers.Count - 1 ? null : OperationsList.Last().Result;
        public bool GotResult => Result != null;
        private List<Operation> OperationsList
        {
            get
            {
                var result = new List<Operation>();
                var a = Numbers[0];
                for (var i = 0; i < Numbers.Count - 1; i++)
                {
                    var oper = Operators[i];
                    var b = Numbers[i + 1];
                    var operation = new Operation(a, oper, b);
                    result.Add(operation);
                    if (operation.Result == null)
                    {
                        break;
                    }

                    a = (int) operation.Result;
                }

                return result;
            }
        }


        public Solution(List<int> numbers, List<Operator> operators)
        {
            Numbers = numbers;
            Operators = operators;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Result == null ? "Error" : Result.ToString());
            sb.Append("=");
            for (var i = 0; i < Numbers.Count; i++)
            {
                sb.Append(Numbers[i]);
                if (i < Operators.Count)
                    sb.Append(Operators[i].ConvertToString());
            }

            return sb.ToString();
        }
    }
}