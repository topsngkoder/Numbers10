using System;
using System.Collections.Generic;
using UnityEngine;

public class MainRoot : MonoBehaviour
{
    private void Start()
    {
        var logic = new Logic();
        var filter = new SolutionFilters();
        var target = 10;
        
        var operatorsList = new List<Operator>
        {
            Operator.Div, Operator.Mul, Operator.Sub, Operator.Sum
        };
        
        

        var aaaa = TaskOptions.GenerateTaskOptions(5);
        
        Debug.Log(DateTime.Now);

        var counter = 0;

        foreach (var task in aaaa)
        {
            var findAllSolutions = logic.FindAllSolutions(task, operatorsList, target);
            
            var solutionsWithoutOnlySum = filter.RemoveOnlySum(findAllSolutions,target);
           
            if (solutionsWithoutOnlySum.Count==0)
                continue; 
            
            counter++;
                
                Debug.Log("вар. "+ counter + " ---> " + findAllSolutions[0]);
                
            

            
        }
        

        
        
        
    }
}