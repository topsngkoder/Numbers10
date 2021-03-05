using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Logic : MonoBehaviour
{
    [SerializeField] public int target;
    private void Awake()
    {
        var test = new Answer();
        
        test.AddElement(2);
        test.AddElement(6);
        test.AddElement(7);
        test.AddElement(1);
        //test.AddElement(9);

        List<Answer> TestAnswersList;

        
        TestAnswersList = FindAnswers(FirstIteration(test));
        while (TestAnswersList[0].ElementsCount()>0)
        {
            TestAnswersList = FindAnswers(TestAnswersList);
        }
        

        for (int i = 0; i < TestAnswersList.Count-1; i++)
        {
            if (TestAnswersList[i].GetAnswer()==target)
            {
                Debug.Log(TestAnswersList[i].GetSolution());
            }
        }
        
        
        
        

        /*foreach (var el in TestAnswersList)
        {
            Debug.Log(el.GetAnswer()+"----"+el.GetSolution());
        }*/
        

    }


    private List<Answer> FirstIteration(Answer answer)
    {
        var newAnswer = new List<Answer>();
            
        for (var i = 0; i < answer.ElementsCount(); i++)
        {
            var tempAnswer = answer.Copy();
            
            tempAnswer.SetAnswer(tempAnswer.GetElementByIndex(i));
            tempAnswer.SupplementSolution(tempAnswer.GetElementByIndex(i).ToString());
            
            tempAnswer.RemoveElementAtIndex(i);
            newAnswer.Add(tempAnswer);
        }
        
        return newAnswer;
    }

    private List<Answer> AllOperations(Answer answer)
    {
        var newAnswer = new List<Answer>();

        
        var ans = answer.GetAnswer();

        for (int i = 0; i < answer.ElementsCount(); i++)
        {
            var tempAnswer = answer.Copy();
            tempAnswer.RemoveElementAtIndex(i);
            newAnswer.Add(new Answer(ans+answer.GetElementByIndex(i),tempAnswer.GetElements(),answer.GetSolution()+'+'+answer.GetElementByIndex(i)));
            newAnswer.Add(new Answer(ans-answer.GetElementByIndex(i),tempAnswer.GetElements(),answer.GetSolution()+'-'+answer.GetElementByIndex(i)));
            newAnswer.Add(new Answer(ans*answer.GetElementByIndex(i),tempAnswer.GetElements(),answer.GetSolution()+'*'+answer.GetElementByIndex(i)));
            if (ans%answer.GetElementByIndex(i)==0)
            {
                newAnswer.Add(new Answer(ans/answer.GetElementByIndex(i),tempAnswer.GetElements(),answer.GetSolution()+'/'+answer.GetElementByIndex(i)));
            }
        }


        return newAnswer;
    }
    
    


    private List<Answer> FindAnswers(List<Answer> originalList)
    {
        List<Answer> answersList = new List<Answer>();

        foreach (var elem in originalList)
        {
            foreach (var el in AllOperations(elem))
            {
                answersList.Add(el);
            }
        }

        return answersList;
    }
    
    
    
    
    
    
    
    
}