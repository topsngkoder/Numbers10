using System;
using System.Collections.Generic;
using LogicDenisKo;
using UnityEngine;

public class MainRoot : MonoBehaviour
{
    private void Start()
    {
        var logic = new LogicDenisKo.SolutionsFinder();
        var filter = new SolutionFilters();
        var target = 10;
        
        
        
        
        
        var operatorsList = new List<Operator>
        {
            Operator.Div, Operator.Mul, Operator.Sub, Operator.Sum
        };
        
        
       // var spisokIsChetyrexCifr = new List<int> {5,7,6,2};


        //var result = logic.FindAllSolutions(spisokIsChetyrexCifr,operatorsList);


        





    }
}