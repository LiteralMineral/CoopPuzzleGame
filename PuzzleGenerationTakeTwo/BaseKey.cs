using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    /// <summary>
    /// A Key is both Active and Passive
    /// </summary>
    public abstract class BaseKey : PuzzleElement, IActivePuzzleElement<PuzzleElement>, IPassivePuzzleElement<PuzzleElement>
        // if I did this right, each element that is a Interface<PuzzleElement> will still
        // call the Active/Passive functions with the implementation of its most derived class.
    {

        // static classes

        /// <summary>
        /// This will provide a means of sorting the locations by whether or not a given key was operable.
        /// Such that each key can sort through a list of locations to find an optimal match.
        /// 
        ///  eventually you'll make it so the key includes some obstacle, as well.
        /// </summary>
        public class LocationOperableKeysComparer : IComparer<Location2>
        {
            BaseKey _thisKey;

            public LocationOperableKeysComparer(BaseKey key)
            {
                _thisKey = key;
            }
            int IComparer<Location2>.Compare(Location2 x, Location2 y)
            {
                return x.TimelyKeyAccessibility[_thisKey].CompareTo(y.TimelyKeyAccessibility[_thisKey]);
                throw new NotImplementedException();
            }

        }




        // static fields



        // instance fields

        /// <summary>
        /// Using terminology from linguistics, defining roles. Agents act on other objects, Patients are acted upon and change state.
        /// Might I suggest using an enum to mark possible ObstacleCodes?
        /// </summary>
        /// 

        IActivePuzzleElement<PuzzleElement> [] _agents;     // this will allow us to act on keys, characters, and locks alike
        IPassivePuzzleElement<PuzzleElement> [] _patients;  // this will allow this item to be acted on by keys and characters
        ObstacleCode _currentSuppressionState;              // this is what you update and check against
        LocationOperableKeysComparer _sorter;



        // getters and setters
        public LocationOperableKeysComparer Sorter { get { return _sorter; } }
        public IActivePuzzleElement<PuzzleElement>[] Agents { get { return _agents; } }
        public IPassivePuzzleElement<PuzzleElement>[] Patients { get { return _patients; } }
        public ObstacleCode CurrentSuppressionState { get { return _currentSuppressionState; } }



        // The following two shouldn't make a big difference but I want to enforce that these ARE Active or Passive PuzzleElement objects
        //public PuzzleElement[] Agents { get { return (PuzzleElement[])_agents.OfType<IActivePuzzleElement>(); } }
        //public PuzzleElement[] Patients { get { return (PuzzleElement[]) _patients.OfType<IPassivePuzzleElement>(); } } 


        // constructor

        public BaseKey(ObstacleCode[] possibleStates, int beginningStateId) : base()
        {
            /*
             * base() defined
             * 1. elementID
             * 2. randomID
             * 3. existence of ObstacleCode with null obstacles
             */

            this.Obstacles.State = possibleStates[beginningStateId].State; // copy over the state.
            
        }



        // instance methods

        // static methods

        // inherited methods

        public abstract void SuppressAllDependants();
        public abstract void SendSuppressionSignal(PuzzleElement passiveElement);
        public abstract void UpdateSuppressedState();
        public abstract void UpdateState();



    }
}
