using System;
using System.Collections.Generic;
using LogicDenisKo;
using UnityEngine;

public class MainRoot : MonoBehaviour
{
    private void Start()
    {
        var logic = new LogicDenisKo.LogicDenisKo();
        var filter = new SolutionFilters();
        var target = 10;
        
        
        
        
        
        var operatorsList = new List<Operator>
        {
            Operator.Div, Operator.Mul, Operator.Sub, Operator.Sum
        };
        
        //var tasksList = TaskOptions.GenerateTaskOptions(4);

        var spisokIsChetyrexCifr = new List<int> {5,7,6,2};


        var result = logic.FindAllSolutions(spisokIsChetyrexCifr,operatorsList);


        foreach (var elSolution in result)
        {
            Debug.Log(elSolution);
        }





    }
}