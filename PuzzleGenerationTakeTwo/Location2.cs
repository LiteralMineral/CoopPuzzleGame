using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    /// <summary>
    /// Needs to track....? numTimes a key is operable from it
    /// Needs to be sortable by Id, RandomNum, 
    /// </summary>
    public class Location2 : PuzzleElement
    {

        // static classes
        // any???

        // static fields

        // instance fields
        Dictionary<BaseKey, int> _timelyKeyAccessibility;
        Dictionary<Character2, int> _numVisits;
        List<PuzzleElement> _itemsContained;


        // getters and setters
        public Dictionary<BaseKey, int> TimelyKeyAccessibility { get { return _timelyKeyAccessibility; } }
        public Dictionary<Character2, int> NumVisits { get { return _numVisits; } }
        public List<PuzzleElement> ItemsContained { get { return _itemsContained; } }

        // constructor

        public Location2()
        {
            _timelyKeyAccessibility = new Dictionary<BaseKey, int>();
            _numVisits = new Dictionary<Character2, int>();
            _itemsContained = new List<PuzzleElement>();
        }

        // instance methods



        // static methods

        // inherited methods
    }
}
