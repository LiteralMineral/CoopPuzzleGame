using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// models rules or constraints as predicates which test if some object follows the rules or not.
namespace CoopPuzzleGame.CriteriaMatcher
{
    public interface IConstraint<T>
    {
        // inheriting classes must implement a predicate generator for datatype T which expresses criteria
        public Func<T, bool> Rule();

        // allows different rules to be produced
        public Func<T, bool> Rule(int ruleId);




    }
}
