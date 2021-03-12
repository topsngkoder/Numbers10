using System.Collections.Generic;

public class Answer
{
    private Solution _solution;

    private int _answer;
    /*{
        get => _solution.Answer;
        set => _solution.Answer = value;
    }*/
    
    private List<int> _elementsList;

    public void AddElement(int element)
    {
        _elementsList.Add(element);
    }

    public override string ToString()
    {
        return $"{nameof(_solution)}: {_solution}, {nameof(_elementsList)}: {_elementsList}, {nameof(_answer)}: {_answer}";
    }

    public List<int> GetElements()
    {
        return _elementsList;
    }

    public Solution GetSolution()
    {
        return _solution;
    }

    public void AddElementInSolution(int number)
    {
        _solution.AddNumber(number);
    }
    
    
    /*public void AddElementInSolution(Operator op)
    {
        _solution.AddOperator(op);
    }*/

    public Answer()
    {
        
        _solution = new Solution();
        _answer = 0;
        _elementsList = new List<int>();
    }

    public Answer(int answer, List<int> elementsList, Solution solution)
    {
        _elementsList = new List<int>(elementsList);
        _solution = solution;
        _answer = answer;

    }

    public Answer Copy()
    {
        var newAnswer = new Answer();
        newAnswer._answer = _answer;
        newAnswer._solution = _solution;
        
        foreach (var element in GetElements())
        {
            newAnswer._elementsList.Add(element);
        }

        return newAnswer;
    }
    public Answer(Answer answerCopy)
    {
        _answer = answerCopy._answer;
        _solution = answerCopy._solution;
        _elementsList = new List<int>(answerCopy._elementsList);
    }
    


    public void RemoveElementAtIndex(int index)
    {
        _elementsList.RemoveAt(index);
    }

    public int GetElementByIndex(int index)
    {
        return _elementsList[index];
    }

    public void SetAnswer(int answer)
    {
        _answer = answer;
    }


    public int ElementsCount()
    {
        return _elementsList.Count;
    }

    public int GetAnswer()
    {
        return _answer;
    }


    public void SetSolution(Solution solution)
    {
        _solution = new Solution(solution);
    }
}