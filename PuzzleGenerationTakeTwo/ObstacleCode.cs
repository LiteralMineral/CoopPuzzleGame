using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo
{










    /// <summary>
    /// facilitates the computation of obstacles and obstacle suppression.
    /// 
    /// A representation of the properties given to an obstacle as a bitmask.
    /// This implementation allows for 10 different values, each with a maximum of 8 possible states
    /// </summary>
    public class ObstacleCode : IEquatable<ObstacleCode>
    {
        // the base for functionality surrounding the states that are

        static readonly uint BASE_NUMERAL = 8;
        static readonly uint OCTAL_BITMASK = 0b_00_000_000_000_000_000_000_000_000_000_111;
        //static readonly uint BITMASK = BASE_NUMERAL-1;
        //static readonly uint FULL_MASK = 0b_00_111_111_111_111_111_111_111_111_111_111;
        static readonly uint FULL_MASK = 0b_11_111_111_111_111_111_111_111_111_111_111;



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



        uint _state;
        public uint State { 
            get { return _state; }
            set { _state = value; }
        }

        public ObstacleCode(uint state)
        {
            _state = state;
        }

        public ObstacleCode()
        {
            _state = 0;
        }

        public void clearNthProperty(int n)
        {
            // mask everything but the target category
            _state = _state & (~NTH_POWER_MASKS[n]);
        }
        public uint GetNthProperty(int n)
        {
            return NTH_POWER_MASKS[n] >> (n * 3); // return the actual value of the thing.

        }
        public void SetNthProperty(int n, uint val)
        {
            if (val >= BASE_NUMERAL) throw new Exception("Not within the range that can be represented by three bits");
            uint remainingBits = (~NTH_POWER_MASKS[n]) & this._state;
            uint new_bits = (NTH_POWER_MASKS[n] & (val << (3 * n)));

            this._state = remainingBits | new_bits;

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
/*
        public static Func<ObstacleCode, ObstacleCode, ObstacleCode> AGGREGATE_OR = (a, b) => { return new ObstacleCode(a.State | b.State); };
        //public static ObstacleCode AGGREGATE_OR(ObstacleCode a, ObstacleCode b)
        //{
        //    return new ObstacleCode(a.State | b.State);
        //}

        public static Func<ObstacleCode, ObstacleCode, ObstacleCode> AGGREGATE_TOGGLE = (a, b) => { return new ObstacleCode(a.State ^ b.State); };
        //public static ObstacleCode AGGREGATE_TOGGLE(ObstacleCode a, ObstacleCode b)
        //{
        //    return new ObstacleCode(a.State ^ b.State);

        //}

        public static Func<ObstacleCode, ObstacleCode, ObstacleCode> AGGREGATE_AND = (a, b) => { return new ObstacleCode(a.State & b.State); };
        //public static ObstacleCode AGGREGATE_AND(ObstacleCode a, ObstacleCode b)
        //{
        //    return new ObstacleCode(a.State & b.State);
        //}

        public static Func<ObstacleCode, ObstacleCode> AGGREGATE_NEG = (a) => { return new ObstacleCode(~a.State); };
        //public static ObstacleCode AGGREGATE_NEG(ObstacleCode a)
        //{
        //    return new ObstacleCode( ~a.State);

        //}
*/

        //public static void Suppress(ObstacleCode suppressor, ObstacleCode suppressand)
        //{
            
        //}


        public static uint Suppress(uint suppressand, uint suppressor)
        {
            uint result = 0;
            uint suppressionAttempt = suppressor ^ suppressand; // XOR, toggles bits
            for (int i = 0; i < NTH_POWER_MASKS.Count(); i++)
            {
                // if the suppression didn't suppress this category...
                if ((suppressionAttempt & NTH_POWER_MASKS[i]) != 0)
                {
                    // position should have 0 at this point, so...
                    result += suppressor & NTH_POWER_MASKS[i];
                }
            }
            return result;
        }


        public static uint SuppressList(uint suppressand, List<uint> suppressors)
        {
            uint result = suppressand;
            return suppressors.Aggregate(suppressand, (a,b) => Suppress(a,b));
        
        }


        public static void swapNthObstacle(ObstacleCode a, ObstacleCode b, int n)
        {

            // just a little swaperoo
            uint temp = a.GetNthProperty(n);
            a.SetNthProperty(n, b.GetNthProperty(n));
            b.SetNthProperty(n, temp);

        }


        //public bool ObstaclesSuppressed(List<ObstacleCode> suppressors)
        //{

        //    // ~(a | b) & this.State
        //    uint suppressedState = this._state & NEG(suppressors.Aggregate((x, y) => new ObstacleCode(OR(x, y))));


        //    // if all of the obstacles presented collectively by the key(s) and/or person
        //    // suppress the obstacles, then the suppressed state should have the empty or "zero" obstacles
        //    return suppressedState == 0;
        //}



        public bool Equals(ObstacleCode other)
        {
            return this._state == other.State;
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// This class takes responsibility for translating/assigning
    /// human-readable strings describing obstacles into uint values
    /// that will be encoded in a bitwise representation in ObstacleCode.
    /// There should only be one of these per Puzzle
    /// </summary>
    public class ObstacleEncoder
    {
        private static readonly int NUM_CATEGORIES = 10;
        private static readonly int[] MAX_OPTIONS = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 };
        // maps string descriptor to number representation
        Dictionary<string, ObstacleCode> _obstacleLexicon;
        int[] _numOptions;


        public int[] NumOptions { get { return _numOptions; } }
        public Dictionary<string, ObstacleCode> ObstacleLexicon { get { return _obstacleLexicon; } }


        /// <summary>
        ///  initialize the dictionary, and record the 
        /// </summary>
        /// <param name="obstacleGroups"> List of Lists of strings naming obstacles.</param>
        public ObstacleEncoder(List<List<string>> obstacleGroups, int[] maxOptions = null)
        {

            _numOptions = (maxOptions == null) ? MAX_OPTIONS : maxOptions;
            _obstacleLexicon = new Dictionary<string, ObstacleCode>();

            
            // array storing how many options per category. Maximum of 8.
            // 
            _numOptions = new int [NUM_CATEGORIES];

            List<string> currObstacleCategory;
            ObstacleCode currObstacleCode;
            // iterate over categories, adding obstacles to obstacle lexicon as needed.
            for (int i = 0; i < NUM_CATEGORIES; i++)
            {
                currObstacleCategory = obstacleGroups[i];
                // iterate over obstacles in current category, adding value
                for (int j = 0; j < NumOptions[i]; j++)
                {
                    currObstacleCode = new ObstacleCode();
                    currObstacleCode.SetNthProperty(i, (uint) j);
                    // assign the string describing the obstacle to the obstacle code
                    _obstacleLexicon.Add(currObstacleCategory[j], currObstacleCode);
                }

            }

            // obstacle names have been mapped to their codes in the dictionary.

        }

        /// <summary>
        /// obstacles
        /// </summary>
        /// <param name="obstacles"> array of strings mapping to obstacle codes </param>
        /// <returns></returns>
        public ObstacleCode EncodeObstacles(List<string> obstacles)
        {
            // Make a new, blank ObstacleCode. Iteratively add new obstacles to it.
            // Throw an exception if the obstacle is not found in the dictionary
            ObstacleCode code = new ObstacleCode();



            // assumes that obstacles never fit in more than 1 category.
            for (int i = 0; i < obstacles.Count; i++)
            {
                // find the code for the obstacle. If the `code`
                // combine fresh obstacle code with obstacle codes mapped to obstacle names.
                code.State = ObstacleCode.OR(code, _obstacleLexicon[obstacles[i]]);

            }

            return code;

        }

        





    }

    #region ObstacleCodesTake2

    public class ObstacleCode2 : IEquatable<ObstacleCode2>
    {

        private static byte CATEGORY_MASK = 7 << 3;
        private static byte VALUE_MASK = 7;
        private static string CODE_TO_STRING_PATH = Path.Combine(System.Environment.CurrentDirectory, "GameData\\obstacles_by_code.json");
        private static string STRING_TO_CODE_PATH = Path.Combine(System.Environment.CurrentDirectory, "GameData\\obstacles_by_name.json");

        static Dictionary<string, byte> STRING_TO_CODE_MAP = new Dictionary<string, byte>();
        static Dictionary<byte, Dictionary<byte, string>> CODE_TO_STRING_MAP
            = JsonConvert.DeserializeObject<Dictionary<byte, Dictionary<byte, string>>>(File.ReadAllText(CODE_TO_STRING_PATH));




        HashSet<byte> _state;

        public static Dictionary<byte, Dictionary<byte, string>> CodeToStringMap { get { return CODE_TO_STRING_MAP; } }

        public HashSet<byte> State { get { return _state; } }
        public static Dictionary<string, byte> StringToCodeMap { get { return STRING_TO_CODE_MAP; } }

        public ObstacleCode2()
        {
            if (STRING_TO_CODE_MAP.Count == 0)
            {
                for (int i = 0; i < (8 << 3); i += (1 << 3))
                {
                    for (int j = 0; j < 8; j++)
                    {
                        STRING_TO_CODE_MAP.Add(CODE_TO_STRING_MAP[(byte)i][(byte)j], (byte)(i + j));


                    }

                }

                File.WriteAllText(STRING_TO_CODE_PATH, JsonConvert.SerializeObject(STRING_TO_CODE_MAP, Formatting.Indented));







            }

        }

        /// <summary>
        /// This ObstacleCode2 suppressing the suppressand
        /// </summary>
        /// <param name="suppressand"></param>
        /// <returns></returns>
        public ObstacleCode2 SuppressCode(ObstacleCode2 suppressand)
        {
            return null;
        }

        // extracts category, tests if equal.
        public Func<int, byte, bool> IsInCategory = (cat, val) => (cat == (val & CATEGORY_MASK)); 



        public bool Equals(ObstacleCode2 other)
        {
            throw new NotImplementedException();
        }
    }


    #endregion
}
