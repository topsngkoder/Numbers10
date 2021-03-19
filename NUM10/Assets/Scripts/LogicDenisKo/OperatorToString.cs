using System.Collections.Generic;

namespace LogicDenisKo
{
    public static class OperatorToString
    {
        private static Dictionary<Operator, string> m_Map;

        static OperatorToString()
        {
            m_Map = new Dictionary<Operator, string>
            {
                [Operator.Sum] = "+",
                [Operator.Sub] = "-",
                [Operator.Div] = "/",
                [Operator.Mul] = "*",
            };
        }

        public static string ConvertToString(this Operator op)
        {
            if (m_Map.ContainsKey(op))
            {
                return m_Map[op];
            }

            return "Error";
        }
    }
}