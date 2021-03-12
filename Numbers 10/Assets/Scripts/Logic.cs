using System;
using System.Collections.Generic;
using System.Linq;

public partial class Logic
{
    public List<Solution> FindAllSolutions(List<int> numbers, List<Operator> operators, int target)
    {
        var answer = new Answer();
        foreach (var element in numbers)
        {
            answer.AddElement(element);
        }

        return MakeSolutionsList(answer, operators, target);
    }

    private List<Solution> MakeSolutionsList(Answer task, List<Operator> operators, int target)
    {
        var allSolutions = new List<Solution>();
        
        var answersList = FirstIteration(task);
        

        while (answersList[0].ElementsCount() > 0)
        {
            answersList = FindAllAnswers(answersList, operators);
        }


        for (var i = 0; i < answersList.Count - 1; i++)
        {
            if (answersList[i].GetAnswer() != target) continue;
            
            allSolutions.Add(answersList[i].GetSolution());
                
        }

        return allSolutions;
    }


    private List<Answer> FirstIteration(Answer answer)
    {
        var newAnswer = new List<Answer>();

        for (var i = 0; i < answer.ElementsCount(); i++)
        {
            var tempAnswer = new Answer(answer);
            

            tempAnswer.SetAnswer(tempAnswer.GetElementByIndex(i));
            
            tempAnswer.RemoveElementAtIndex(i);
            
            var solution = new Solution(answer.GetSolution());
            solution.SetAnswer(answer.GetElementByIndex(i));
            solution.AddNumber(answer.GetElementByIndex(i));

            tempAnswer.SetSolution(solution);
            
            
            
            newAnswer.Add(tempAnswer);
        }
        
        

        return newAnswer;
    }


    private List<Answer> AllOperations(Answer answer, List<Operator> _operatorsList)
    {
        var newAnswer = new List<Answer>();


        var ans = answer.GetAnswer();

        for (var i = 0; i < answer.ElementsCount(); i++)
        {
            var tempAnswer = answer.Copy();

            tempAnswer.RemoveElementAtIndex(i);


            foreach (var op in _operatorsList)
            {
                var value = Calculate(ans, op, answer.GetElementByIndex(i));

                if (value == null)
                {
                    continue;
                }
                
                var solution = new Solution(answer.GetSolution());
                solution.SetAnswer((int)value);
                solution.AddOperator(op);
                solution.AddNumber(answer.GetElementByIndex(i));

                
               

                
                
                newAnswer.Add(new Answer((int) value, tempAnswer.GetElements(),solution));
            }
        }

        return newAnswer;
    }


    private List<Answer> FindAllAnswers(List<Answer> originalList, List<Operator> operators)
    {
        var answersList = new List<Answer>();

        foreach (var elem in originalList)
        {
            foreach (var el in AllOperations(elem, operators))
            {
                answersList.Add(el);
            }
        }

        return answersList;
    }


    private readonly Dictionary<Operator, Func<int, Operator, int, int?>> _OperatorsMap;


    public Logic()
    {
        _OperatorsMap = new Dictionary<Operator, Func<int, Operator, int, int?>>
        {
            [Operator.Sum] = Sum,
            [Operator.Sub] = Sub,
            [Operator.Mul] = Mul,
            [Operator.Div] = Div,
        };
    }
    
    
    
    


    public int? Calculate(int a, Operator op, int b)
    {
        if (!_OperatorsMap.ContainsKey(op))
        {
            Console.WriteLine("Error");
            return null;
        }

        var func = _OperatorsMap[op];
        return func.Invoke(a, op, b);
    }

    private int? Div(int a, Operator op, int b)
    {
        if (a % b == 0)
        {
            return a / b;
        }

        return null;
    }

    private int? Mul(int a, Operator op, int b)
    {
        return a * b;
    }

    private int? Sub(int a, Operator op, int b)
    {
        return a - b;
    }

    private int? Sum(int a, Operator op, int b)
    {
        return a + b;
    }
    
    
    
    
    
    //Логика для всех комбинаций из цифр
}