using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces
{
    /// <summary>
    /// Interface to enforce that some PuzzleElement classes can act on other PuzzleElement objects' obstacles.
    /// </summary>
    public interface IActivePuzzleElement<T> where T : PuzzleElement
    {

        //public ObstacleCode ProvideSuppressorCode();



        /// <summary>
        /// Using SendSuppressionSignal(IPassivePuzzleElement passiveElement) :
        /// cycle through passiveElements and tell them to change their state in some fashion.
        /// </summary>
        public void SuppressAllDependants();


        /// <summary>
        /// prompts passiveElement to update its state
        /// This should detect the most constraining type of passiveElement and change its state accordingly.
        /// </summary>
        /// <param name="passiveElement"></param>
        public void SendSuppressionSignal(T passiveElement);
    }
}
