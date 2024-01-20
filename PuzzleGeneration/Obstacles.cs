using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopPuzzleGame.CriteriaMatcher;
using Godot;

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
    public class ObstacleProfile
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


    }
    /// <summary>
    /// A representation of the properties given to an obstacle as a bitmask.
    /// This implementation allows for 10 different values, each with a maximum of 8 possible states
    /// </summary>
    public class ObstacleCode : IEquatable<ObstacleCode>
    {
        // the base for functionality surrounding the states that are accepted
        //public static int 
        static readonly uint BASE_NUMERAL = 8;
        static readonly uint OCTAL_BITMASK = 0b_00_000_000_000_000_000_000_000_000_000_111;
        static readonly uint FULL_MASK = 0b_00_111_111_111_111_111_111_111_111_111_111;

        // with this setup, we only have 
        static readonly uint[] NTH_POWER_MASKS = { OCTAL_BITMASK << 0,
                                                    OCTAL_BITMASK << (1 * 3),
                                                    OCTAL_BITMASK << (2 * 3),
                                                    OCTAL_BITMASK << (3 * 3),
                                                    OCTAL_BITMASK << (4 * 3),
                                                    OCTAL_BITMASK << (5 * 3),
                                                    OCTAL_BITMASK << (6 * 3),
                                                    OCTAL_BITMASK << (7 * 3),
                                                    OCTAL_BITMASK << (8 * 3),
                                                    OCTAL_BITMASK << (9 * 3),
                                                    OCTAL_BITMASK << (10 * 3)   };
        private uint state;

        public uint State { get => state; set => state = value; }


        public ObstacleCode()
        {
            State = 0;
        }

        public ObstacleCode(uint state)
        {
            State = state;
        }


        public uint GetNthProperty(int n)
        {
            return NTH_POWER_MASKS[n] >> (n * 3); // return the actual value of the thing.

        }
        public void SetNthProperty(int n, uint val)
        {
            if (val >= 8) throw new Exception("Not within the range that can be represented by three bits");
            uint remainingBits = (~NTH_POWER_MASKS[n]) & this.State;
            uint new_bits = (NTH_POWER_MASKS[n] & (val << (3 * n)));

            this.State = remainingBits | new_bits;

        }

        public static uint OR(ObstacleCode a, ObstacleCode b)
        {
            return (a.State | b.State);
        }

        public static uint TOGGLE(ObstacleCode a, ObstacleCode b)
        {
            return (a.State ^ b.State);

        }

        public static uint AND(ObstacleCode a, ObstacleCode b)
        {
            return (a.State & b.State);
        }

        public static uint NEG(ObstacleCode a)
        {
            return ~a.State;
        }

        public bool ObstaclesSuppressed(List<ObstacleCode> suppressors)
        {

            // ~(a | b) & this.State
            uint suppressedState = this.State & NEG(suppressors.Aggregate((x, y) => new ObstacleCode(OR(x, y))));

            // if all of the obstacles presented collectively by the key(s) and/or person
            // suppress the obstacles, then the suppressed state should have the empty or "zero" obstacles
            return suppressedState == 0;
        }

        public bool Equals(ObstacleCode other)
        {
            return this.State == other.State;
            throw new NotImplementedException();
        }
    }
}
