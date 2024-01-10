using System;
using System.Collections.Generic;

public partial class TopologyGenerator
{

    // Stack of undo_edits and redo_edits.

    // Build a graph with locks, and generate matching keys which make all the locks operable.

    // From that underlying graph, build one graph per player which will reflect what they could potentially access at a given point.

    // generate the puzzle's solution: a sequence of which keys must
    // be operated for the players to all exit.
    
    // track which player last operated a key/lock. This player has their
    // latest accessibility much more restricted.
    // (all edges on their accessibility graph are cleared, then readded)

    // Keep a queue of which edges' states have changed in the base
    // graph. This will tell you what edges need to be adjusted in
    // the individual players' accessibility graphs.

    // Iterate through the steps to solve the puzzle. This involves changing the state of the locks on the base graph

    // when the state of the base graph has been changed, iterate through the locks were changed
    // Reflect those state changes in the individual players' accessiblity graphs.

    // For the player who last operated a key/lock, calculate their new restricted accessiblity entirely.
    // For the other players, simply add potentially accessible areas.

    // Each vertex tracks the number of times it has been a potential
    // placement for the necessary key, at the right time in the solution.
    // Update this count every time a step in the solution has been taken.

    // After calculating the number of times a vertex has met the conditions to supply the key for the puzzle....
    // If the number of times it has been accessible is equal to the number of
    // times the key was required, you can place the key at that vertex.
    // If the number of times it as accessible is less than the number of times
    // it was required, add that key to the queue of keys that need additional or corrected placements

    // perform conflict resolution on the key/lock pairs that need correcting for solvability. (AS YOU DESCRIBED IN YOUR DISCORD NOTES)

    // The final lock/key situation: add a vertex that has the exit.
    // Make a special set of locks going to the exit that goes to a closed
    // state whenever another key is operated, so it enforces that it's the LAST key/lock pair operated
    // Decide how that lock will be operated. 
    // place its key(s) in a region so it's accessible by the player(s?) who can operate it.
    // connect the location of the keys to the exit vertex

    // The puzzle structure is now solvable and well-defined!!





}
