using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    internal class Puzzle2
    {
        // classes that will be instantiated statically

        // static fields

        // instance fields


        /*
         * mapping of keys to locks/locks to keys
         * characters, each with information about what they have access to.
         * base graph and player graphs 
         * when an edge has been traversed, increase its traversalCount. endeavor to find short paths, so there's some even traversal of the graph
         * 
         */

        // getters and setters

        // constructor

        /*
         * 1. generate locations
         * 2. generate keys
         * 3. generate steps (lists of keys, powers, and character combos that will be required at each stage)
         * 4. map the steps to locks
         * 5. place the locks
         * 6. iterate over the steps
         * 7. for each step, compute where the required keys could be placed. (intersection of required player combos. Add node if necessary)
         * 8. place keys at ideal location
         * 9. ... error correction???
         */

        // instance methods

        // static methods

        // inherited methods
    }
}
