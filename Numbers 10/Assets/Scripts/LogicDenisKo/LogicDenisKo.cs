using System.Collections.Generic;
using System.Linq;

namespace LogicDenisKo
{
    public class LogicDenisKo: IFindSolutions
    {
        public List<Solution> FindAllSolutions(List<int> numbers, List<Operator> operators)
        {
        
            var combinations = new List<Solution>();
            var numbersPermutations = GetPermutations(numbers, numbers.Count);
            var operatorsCombinations = CombinationsWithRepetition(operators, numbers.Count - 1).ToList();

            foreach (var numbersPermutation in numbersPermutations)
            foreach (var operatorsPermutation in operatorsCombinations)
            {
                var solution = new Solution(numbersPermutation, operatorsPermutation);
                if (solution.GotResult)
                    combinations.Add(solution);
            }

            return combinations;
        
        
        }
        
        private static List<List<T>>
            GetPermutations<T>(List<T> list, int length)
        {
            if (length == 1) return list.Select(t => new[] {t}.ToList()).ToList();

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new[] {t2}).ToList()).ToList();
        }
        
        static IEnumerable<List<T>> CombinationsWithRepetitionIEnum<T>(IEnumerable<T> input, int length)
        {
            if (length <= 0)
                yield return new List<T>();
            else
            {
                foreach (var i in input)
                foreach (var c in CombinationsWithRepetitionIEnum(input, length - 1))
                {
                    c.Add(i);
                    yield return c;
                }
            }
        }

        
        static List<List<T>> CombinationsWithRepetition<T>(IEnumerable<T> input, int length)
        {
            return CombinationsWithRepetitionIEnum(input, length).ToList();
        }
    }
}
    
    
        
        
        
 