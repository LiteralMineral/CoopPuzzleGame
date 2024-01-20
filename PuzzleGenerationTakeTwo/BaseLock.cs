using Advanced.Algorithms.Graph;
using CoopPuzzleGame.PuzzleGeneration;
using CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    /// <summary>
    /// This encodes the connections between locations in the puzzle
    /// This is basically functioning as an edge, so. We need it to be able to provide an edgeoperator.... potentially
    /// </summary>
    internal abstract class BaseLock : PuzzleElement, IPassivePuzzleElement<PuzzleElement>
    {

        // static classes
        #region InternallyUsedClasses
        /*
        * possible need for a shortestPathOperator somewhere in here
        */

        /*
         * Possible need for a comparer-by-edge-weight in here
         */

        #endregion


        #region StaticFields

        #endregion

        #region InstanceFields

        IActivePuzzleElement<PuzzleElement>[] _agents;

        ObstacleCode _suppressedState;      // tracks the obstacle code that reflects the current state of obstacles

        #endregion



        #region GettersAndSetters

        #endregion

        #region Constructors


        // TODO: implement

        /// <summary>
        /// initialize agents, then calculate code that is guaranteed to be 
        /// </summary>
        /// <param name="agents"></param>
        public BaseLock(IActivePuzzleElement<PuzzleElement> []  agents) : base()
        {

        }



        /// <summary>
        /// Merely for the ShortestPathOperator implementation later on, potentially.
        /// </summary>
        /// <param name="weight"></param>
        public BaseLock(int weight)
        {
            this.ElementID = -1;
            this.RandomNum = weight;
        }

        #endregion


        #region InstanceMethods

        #endregion



        #region StaticMethods

        #endregion
        #region InheritedMethods


        // From IPassivePuzzleElement
        public abstract void UpdateSuppressedState();
        public abstract void UpdateState();


        // Basic comparisons
        public int CompareTo(BaseLock other)
        {

            return this.RandomNum.CompareTo(other.RandomNum);
            throw new NotImplementedException();
        }

        #endregion


    }
}
