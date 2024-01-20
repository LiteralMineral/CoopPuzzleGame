using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGeneration
{
    public class Character : PuzzleElement
    {
        // The abilities given to players. Will later be stored as objects themselves, so they can be passed around
        //private static int ability0 = 0;
        //private static int ability1 = 1;
        //private static int ability2 = 2;
        //private static int ability3 = 3;
        //private static int ability4 = 4;
        //private static int ability5 = 5;
        //private static int ability6 = 6;
        // ... and so on


        // TODO: change id datatypes to uint

        //int _intrinsicAbility;
        //int _attachableAbility;
        //bool _materiality;
        //int _personalityID;

        // for starting location!!!
        uint _locationID;
        // tracks what obstacles the character can counter
        List<int> _trivialObstacles;

        public List<int> TrivialObstacles
        { get => _trivialObstacles; }



        //public Character(int intrinsicAbility, int attachableAbility, int personality)
        public Character(int id, int[] obstacles) : base(id)
        {
            //this._intrinsicAbility = intrinsicAbility;
            //this._materiality = true;
            //this._attachableAbility = attachableAbility;
            //this._personalityID = personality;

            _trivialObstacles = new List<int>();


        }

        public  bool Equals(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        public  int CompareTo(PuzzleElement other)
        {
            throw new NotImplementedException();
        }
    }
}
