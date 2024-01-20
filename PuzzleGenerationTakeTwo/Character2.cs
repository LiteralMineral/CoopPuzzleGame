using Advanced.Algorithms.DataStructures;
using Advanced.Algorithms.Search;
using CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    public abstract class Character2 : PuzzleElement, IActivePuzzleElement<PuzzleElement>, IPassivePuzzleElement<PuzzleElement>
    {

        // static classes

        public class LocationVisitsComparer: IComparer<Location2>
        {
            Character2 _thisChar;
            
            public LocationVisitsComparer(Character2 character)
            {
                _thisChar = character;
            }
            int IComparer<Location2>.Compare(Location2 x, Location2 y)
            {
                return x.NumVisits[_thisChar].CompareTo(y.NumVisits[_thisChar]);
                throw new NotImplementedException();
            }

        }



        // static fields

        // instance fields

        // Tracks the locationIds that were last visited/added to the region
        Queue<int> _regionBorderIds = new Queue<int>();
        List<Location2> _accessibleLocationsByNumVisits;


        // this will be limited to just the one powerup/overload
        //ObstacleCode tempPowerUp;



        // getters and setters
        public Queue<int> RegionBorderIds { get { return _regionBorderIds; } }
        public List<Location2> AccessibleLocationsByNumVisits { get { return _accessibleLocationsByNumVisits; } }





        // constructor

        // instance methods

        /*
         *      static methods
         */

        // inherited methods

        // From IActivePuzzleElement
        public abstract void SuppressAllDependants();
        public abstract void SendSuppressionSignal(PuzzleElement passiveElement);



        // From IPassivePuzzleElement, which inherits from IMutableState as well (UpdateState)
        public abstract void UpdateSuppressedState();
        public abstract void UpdateState();
    }
}
