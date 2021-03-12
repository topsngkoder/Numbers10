using System;
using System.Collections.Generic;
using UnityEngine;

public class MainRoot : MonoBehaviour
{
    private void Start()
    {
        var logic = new Logic();
        
        var operatorsList = new List<Operator>
        {
            Operator.Div, Operator.Mul, Operator.Sub, Operator.Sum
        };
        
        var numbersList = new List<int>
        {
            7,2,9,8
        };

        var aaaa = TaskOptions.GenerateTaskOptions(4);

        var findAllSolutions = logic.FindAllSolutions(numbersList, operatorsList, 10);

        foreach (var solution in findAllSolutions)
        {
            //Debug.Log(solution);
        }
        
        
    }
}