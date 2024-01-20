using CoopPuzzleGame.CriteriaMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGeneration
{
    public class BasePuzzleKey : PuzzleElement, IComparer<PuzzleElement>
    {

        
        public BasePuzzleKey(int id) : base(id)
        {
        }

        int locationID
        { get; set; }

        ObstacleProfile _obstacles;
        public ObstacleProfile Obstacles { get { return _obstacles; } }


        public int CompareTo(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        public  bool Equals(PuzzleElement other)
        {
            throw new NotImplementedException();
        }

        int IComparer<PuzzleElement>.Compare(PuzzleElement x, PuzzleElement y)
        {

            throw new NotImplementedException();
        }



    }
}
