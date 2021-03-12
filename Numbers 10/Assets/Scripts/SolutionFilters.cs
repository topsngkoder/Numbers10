using System.Collections.Generic;


    public class SolutionFilters
    {
        
        
        
        
        public List<Solution> RemoveOnlySum(List<Solution> list, int target)
        {
            var listWithoutOnlySum = new List<Solution>();
        
            foreach (var solution in list)
            {
                var sum = 0;
            
                foreach (var number in solution.Numbers)
                {
                    sum += number;
                }

                if (sum==target)
                    continue;
            
                listWithoutOnlySum.Add(solution);
            }

            return listWithoutOnlySum;
        }
    }
