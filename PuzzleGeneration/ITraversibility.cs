using System;

namespace CoopPuzzleGame.PuzzleGeneration
{
    // must provide a function that returns a delegate that works as a predicate
    public interface ITraversibility
    {
        /// <summary>
        /// This function dispatches a delegate to check whether 
        /// a player can traverse it in its current state.
        /// has criteria that match the pattern.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public Func<Character, bool> canTraverse();


        /// <summary>
        /// Needs to update the gatekeeping delegate.
        /// </summary>
        public void updateCriteria();


    }

}