using System.Collections.Generic;
using UnityEditor.SceneManagement;

namespace Specifications
{
    public class Filter<T>
    {
        public IEnumerable<T> Find(IEnumerable<T> from, params ISpecification<T>[] specs)
        {
            if (specs == null || specs.Length == 0)
            {
                foreach (var e in from)
                    yield return e;
            }
            else
            {
                foreach (var entry in from)
                {
                    var add = true;
                    foreach (var spec in specs)
                        if (!spec.IsSatisfied(entry))
                        {
                            add = false;
                            break;
                        }


                    if (add)
                        yield return entry;
                }
            }
        }
    }

    public interface ISpecification<in T>
    {
        bool IsSatisfied(T instance);
    }

    public class SolutionResultSpec : ISpecification<LogicDenisKo.Solution>
    {
        private readonly int m_TargetResult;

        public SolutionResultSpec(int targetResult)
        {
            m_TargetResult = targetResult;
        }

        public bool IsSatisfied(LogicDenisKo.Solution instance)
        {
            return m_TargetResult == instance.Result;
        }
    }

    public class SolutionExcludeErrorSpec : ISpecification<LogicDenisKo.Solution>
    {
        public bool IsSatisfied(LogicDenisKo.Solution instance)
        {
            return instance.Result != null;
        }
    }

    public class SolutionWithoutOnlySum : ISpecification<LogicDenisKo.Solution>
    {
        public bool IsSatisfied(LogicDenisKo.Solution instance)
        {
            var allIsSum = false;
            foreach (Operator @operator in instance.Operators)
            {
                if (@operator == Operator.Sum) continue;
                allIsSum = true;
                break;
            }
    
            return allIsSum;
        }
    }
}