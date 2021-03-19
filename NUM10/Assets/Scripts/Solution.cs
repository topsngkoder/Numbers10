using System;
using System.Collections.Generic;
using System.Text;


public class Solution
{
    public int Answer;
    public List<int> Numbers;
    public List<Operator> Operators;

    public Solution()
    {
        Numbers = new List<int>();
        Operators = new List<Operator>();
        Answer = 0;
    }
    
    public Solution(Solution solution)
    {
        Numbers = new List<int>(solution.Numbers);
        Operators = new List<Operator>(solution.Operators);
        Answer = solution.Answer;
    }

    private readonly Dictionary<Operator, char> _MapOperatorsChar = new Dictionary<Operator, char>
    {
        [Operator.Sum]='+',
        [Operator.Div]='/',
        [Operator.Mul]='x',
        [Operator.Sub]='-'
    };

    private char OperToChar(Operator op)
    {
        return _MapOperatorsChar[op];
    }
    
    
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(Answer.ToString()+'=');
        for (int i = 0; i < Numbers.Count; i++)
        {

            if (i != Numbers.Count - 1)
            {
                sb.Append($"{Numbers[i]} {OperToChar(Operators[i])}");
            }
            else
            {
                sb.Append($"{Numbers[i]}");
            }
        }
        return sb.ToString(); 
    }

    
    
    
    public void SetAnswer(int answer)
    {
        Answer = answer;
    }

    public void AddNumber(int number)
    {
        Numbers.Add(number);
    }
    
    public void AddOperator(Operator op)
    {
        Operators.Add(op);
    }

    public string PrintSolution()
    {
        var solution = Answer.ToString() + "--->";
        
        for (var i = 0; i < Operators.Count-1; i++)
        {
            solution += Numbers[i].ToString();
            solution += Operators[i].ToString();
        }

        solution += Numbers[Numbers.Count - 1];



        return solution;
    }

    
    
    

}