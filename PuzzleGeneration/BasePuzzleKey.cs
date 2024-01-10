using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGeneration
{
    public class PuzzleKey : PuzzleElement, IComparer<PuzzleElement>
    {
        int locationID
        { get; set; }

        ObstacleProfile

        List<int> operandIDs = new List<int>();

        public override int CompareTo(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        int IComparer<PuzzleElement>.Compare(PuzzleElement x, PuzzleElement y)
        {

            throw new NotImplementedException();
        }
    }
}
