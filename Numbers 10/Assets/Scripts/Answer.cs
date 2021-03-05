using System.Collections.Generic;

public class Answer
{
    private string _solution;
    private int _answer;
    private List<int> _elementsList;

    public void AddElement(int element)
    {
        _elementsList.Add(element);
    }

    public List<int> GetElements()
    {
        return _elementsList;
    }

    public string GetSolution()
    {
        return _solution;
    }

    public void SupplementSolution(string supplement)
    {
        _solution += supplement;
    }

    public Answer()
    {
        _answer = 0;
        _solution = "";
        _elementsList = new List<int>();
    }

    public Answer(int answer, List<int> elementsList, string solution)
    {
        _answer = answer;
        _elementsList = new List<int>(elementsList);
        _solution = solution;
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
        
        
}