using CoopPuzzleGame.CriteriaMatcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGeneration
{
    // This will be the 
    public class BasePuzzleLock : PuzzleElement, IConstraint<BasePuzzleLock>
    {


        // somewhere else define hazard codes and such

        // TODO: figure out better way of tracking the possible obstacle states of a lock.

        // keys that match to this lock
        List<int> _keyIDs;


        ObstacleProfile _obstacles;
        public ObstacleProfile Obstacles { get { return _obstacles; } }
        public List<int> ActiveObstacles { get { return _obstacles.ActiveProfile; } }



        // This class generates gatekeeper functions. useful for updating the criteria for traversibility
        //static class GatekeeperDispatch
        //{
        //    public static Func<Character, bool> dispatch(PuzzleLock lk)
        //    {
        //        // extract active obstacles
        //        List<int> activeObs = lk._obstacle;

        //        return p =>
        //        {
        //            if (!activeObs.Any())
        //            {
        //                return true;
        //            }
        //            else
        //            {

        //                // if there is an obstacle active on this lock, then the character must be able to counter it
        //                // The intersection of these two sets must be the same as the set.
        //                // That is, activeObs must be completely contained in TrivialObstacles
        //                return (p.TrivialObstacles.Intersect(activeObs).Count() == activeObs.Count);
        //            }

        //        };
        //    }
        //}




        // gatekeeper function that assesses whether a player can traverse the puzzle lock
        /*
        

        Func<Character, bool> _gatekeeper;
        public Func<Character, bool> GateKeeper
        {
            get { return _gatekeeper; }
        }
        
        /// <summary>
        /// Gets a new gatekeeper based on the PuzzleLock list of active obstacles
        /// </summary>
        public void updateGatekeeper()
        {
            _gatekeeper = GatekeeperDispatch.dispatch(this);
        }


        */


        public PuzzleLock(int id, List<int> keyIds) : base(id)
        {


        }




        // just pass along the data
        public void UpdateActiveObstacles(ObstacleProfile incomingSuppression)
        {
            _obstacles.UpdateActiveProfile(incomingSuppression);


        }

        public Func<BasePuzzleLock, bool> Rule()
        {
            throw new NotImplementedException();
        }

        public Func<BasePuzzleLock, bool> Rule(int ruleId)
        {
            throw new NotImplementedException();
        }
    }
}
