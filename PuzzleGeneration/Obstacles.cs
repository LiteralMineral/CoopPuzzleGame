using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopPuzzleGame.CriteriaMatcher;

namespace CoopPuzzleGame.PuzzleGeneration
{
    public static class Obstacles
    {
        static Dictionary<string, List<int>> _obstacleClasses; // 
        static Dictionary<int, string> _obstacleNames; // 
        public static Dictionary<int, string> ObstacleNames { get { return _obstacleNames; } }//

        public static string GetName(int obsCode)
        {
            return _obstacleNames[obsCode];
        }
        // This will be the thing that 



    }
    public class ObstacleProfile : IConstraint<ObstacleProfile>
    {
        List<int> _baseProfile;
        List<int> _activeProfile;
        public List<int> BaseProfile { get { return _baseProfile; } }
        public List<int> ActiveProfile { get { return _activeProfile; } }

        public List<string> ActiveProfileText
        {
            get { return _activeProfile.ConvertAll(x => Obstacles.ObstacleNames[x]); }
        }
        public ObstacleProfile(List<int> obstacles)
        {
            _baseProfile = obstacles;

        }


        public List<int> SetMinus(ObstacleProfile other)
        {
            return _baseProfile.Except(other.BaseProfile).ToList();
        }


        public static List<int> SetMinus(ObstacleProfile operand, ObstacleProfile removed)
        {
            return operand._baseProfile.Except(removed.BaseProfile).ToList();
        }



        public bool IsSubsetOf(ObstacleProfile other)
        {

            int intersectionSize = _baseProfile.Intersect(other.BaseProfile).Count();
            return intersectionSize == other._baseProfile.Count;
            //throw new NotImplementedException();
        }

        public void UpdateActiveProfile(ObstacleProfile suppressor)
        {
            _activeProfile = SetMinus(suppressor);
        }

        Func<ObstacleProfile, bool> IConstraint<ObstacleProfile>.Rule()
        {
            return p =>
            {
                this.
            }

            throw new NotImplementedException();
        }

        Func<ObstacleProfile, bool> IConstraint<ObstacleProfile>.Rule(int ruleId)
        {
            throw new NotImplementedException();
        }
    }
}
