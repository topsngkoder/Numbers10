using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace LogicDenisKo
{
    public class SolutionsFinder : IFindSolutions
    {
        public List<Solution> FindAllSolutions(List<int> numbers, List<Operator> operators)
        {
            var combinations = new List<Solution>();
            var numbersPermutations = GetPermutations(numbers);
            var operatorsCombinations = GetCombinations(operators, numbers.Count - 1);

            foreach (var numbersPermutation in numbersPermutations)
            foreach (var operatorsPermutation in operatorsCombinations)
            {
                var solution = new Solution(numbersPermutation, operatorsPermutation);
                combinations.Add(solution);
            }

            return combinations;
        }

        private List<List<T>> GetPermutations<T>(List<T> list)
        {
            var permutations = new Permutations<T>(list, GenerateOption.WithRepetition);
            return permutations.Select(permutation => permutation.ToList()).ToList();
        }

        private List<List<T>> GetCombinations<T>(List<T> list, int length)
        {
            var permutations = new Combinations<T>(list, length, GenerateOption.WithRepetition);
            return permutations.Select(permutation => permutation.ToList()).ToList();
        }

        // private  List<List<T>> GetPermutations<T>(List<T> list, int length)
        // {
        //     
        //     if (length == 1)
        //     {
        //         var res = list.Select(t => new[] {t}.ToList()).ToList();
        //         return res;
        //     }
        //
        //     var getPerm = GetPermutations(list, length - 1);
        //     var selMany = getPerm.SelectMany(t => list.Where(e => !t.Contains(e)),
        //         (t1, t2) => t1.Concat(new[] {t2}).ToList()).ToList();;
        //     return selMany;
        //     
        //     return GetPermutations(list, length - 1)
        //         .SelectMany(t => list.Where(e => !t.Contains(e)),
        //             (t1, t2) => t1.Concat(new[] {t2}).ToList()).ToList();
        // }
        //
        // private IEnumerable<List<T>> CombinationsWithRepetitionIEnum<T>(IEnumerable<T> input, int length)
        // {
        //     if (length <= 0)
        //         yield return new List<T>();
        //     else
        //     {
        //         foreach (var i in input)
        //         foreach (var c in CombinationsWithRepetitionIEnum(input, length - 1))
        //         {
        //             c.Add(i);
        //             yield return c;
        //         }
        //     }
        // }
        //
        //
        // private List<List<T>> CombinationsWithRepetition<T>(IEnumerable<T> input, int length)
        // {
        //     return CombinationsWithRepetitionIEnum(input, length).ToList();
        // }
    }
}