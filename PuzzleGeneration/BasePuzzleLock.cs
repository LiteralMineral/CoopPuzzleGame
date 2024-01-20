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
    public class BasePuzzleLock : PuzzleElement
    {


        // somewhere else define hazard codes and such

        // TODO: figure out better way of tracking the possible obstacle states of a lock.

        // keys that match to this lock
        List<int> _keyIDs;

        // store the state of the lock
        Dictionary<string, bool> _state;

        ObstacleCode _obstacles;



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


        public BasePuzzleLock(int id, List<int> keyIds, ObstacleCode obst) : base(id)
        {



        }

    }
}
