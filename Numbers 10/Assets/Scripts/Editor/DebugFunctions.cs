using System.Collections.Generic;
using LogicDenisKo;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class DebugFunctions
    {
        [MenuItem("Debug/Functions/Find solutions")]
        private static void RunFindOperations()
        {
            var solutionsFinder = new SolutionsFinder();
            var numbers = new List<int>{1,2,3,4};
            var operators = new List<Operator>{Operator.Sum,Operator.Sub,Operator.Mul,Operator.Sub};
            var solutions = solutionsFinder.FindAllSolutions(numbers,operators);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
        }
    }
}