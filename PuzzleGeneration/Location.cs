using CoopPuzzleGame.PuzzleGeneration;
using System;
using System.Collections.Generic;


namespace CoopPuzzleGame.PuzzleGeneration
{
    public class Location : PuzzleElement, IComparable<PuzzleElement>, IEquatable<PuzzleElement> 
    {

        int _id;
        public int Id { get { return _id; } }

        List<PuzzleElement> elements;

        public Location(int id) : base(id)
        {
        }

        /*	public ()
            {
                protected Vector<>
        }*/
        public int CompareTo(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

    }
}
