using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.PuzzleGenerationTakeTwo.AgencyInterfaces
{
    /// <summary>
    /// mandates that inheriting classes update their obstacle codes
    /// </summary>
    public interface IMutableState
    {
        /// <summary>
        /// update the current state of the obstacle codes. Used more for Keys which
        /// can change what obstacle suppression code is being applied to its dependents.
        /// </summary>
        public void UpdateState();

    }
}
