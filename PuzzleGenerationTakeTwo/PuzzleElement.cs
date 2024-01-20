using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{
    /// <summary>
    /// Plan to use enum to dictate behavior when interacting with different types of puzzleElements......
    /// 
    /// </summary>
    public abstract class PuzzleElement : IEquatable<PuzzleElement>, IComparable<PuzzleElement>
    {



        // static classes
        public class RandomComparer : IComparer<PuzzleElement>
        {
            public int Compare(PuzzleElement x, PuzzleElement y)
            {
                throw new NotImplementedException();
            }
        }
        public class IdComparer : IComparer<PuzzleElement>
        {
            public int Compare(PuzzleElement x, PuzzleElement y)
            {
                return (x.ElementID).CompareTo(y.ElementID);
            }
        }

        public class PuzzleElementIdAssigner
        {
            int currentIdVal;

            public PuzzleElementIdAssigner()
            {
                currentIdVal = 0;
            }

            public int nextId()
            {
                return currentIdVal++;
            }
        }


        // static fields
        public static PuzzleElementIdAssigner idSource = new PuzzleElementIdAssigner();
        public static Random rand = new Random();
        public static RandomComparer RandomSorter = new RandomComparer();
        public static IdComparer IdSorter= new IdComparer();

        // instance fields
        int _elementID;
        int _randomNum;
        ObstacleCode _obstacles;
        //PuzzleElement []




        //getters and setters
        public int ElementID { get { return _elementID; } set { _elementID = value; } }
        public int RandomNum { get { return _randomNum; } set { _randomNum = value; } }
        public ObstacleCode Obstacles { get { return _obstacles; } }


        // constructor

        public PuzzleElement()
        {
            this._elementID = idSource.nextId();
            _randomNum = rand.Next();
            _obstacles = new ObstacleCode(); // should have state of 0. So, nothing required to pass this puzzle element

        }

        // inherited methods
        public bool Equals(PuzzleElement other)
        {
            return this.ElementID == other.ElementID;
            throw new NotImplementedException();
        }

        public int CompareTo(PuzzleElement other)
        {
            return this.ElementID.CompareTo(other.ElementID);
            throw new NotImplementedException();
        }

    }
}
