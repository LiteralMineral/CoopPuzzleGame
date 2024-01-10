using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGeneration
{

    // This is just locks/keys
    public class PuzzleElement : IEquatable<PuzzleElement>, IComparable<PuzzleElement>
    {
        int _id;
        int ID { get { return _id; } }

        public PuzzleElement(int id)
        {
            _id = id;
        }

        public bool Equals(PuzzleElement other)
            => _id == other.ID;
        public int CompareTo(PuzzleElement other)
            => _id.CompareTo(other._id);

    }


}
