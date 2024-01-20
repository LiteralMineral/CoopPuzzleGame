using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces
{
    /// <summary>
    /// interface to enforce methods that manage interactivity between puzzle elements
    /// </summary>
    public interface IPassivePuzzleElement<T> : IMutableState
        where T : PuzzleElement
    {


        /// <summary>
        /// Based on data specific to the class, write instructions for how to calculate what obstacles are active.
        /// </summary>
        public void UpdateSuppressedState();

    }
}
