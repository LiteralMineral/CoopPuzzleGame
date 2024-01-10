using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs;
using DataStructures.Graphs;
using DataStructures.Heaps;
using QuickGraph.Serialization.DirectedGraphML;

namespace CoopPuzzleGame.PuzzleGeneration
{

    public class Puzzle
    {

        private class IdAssigner
        {
            int currentIdVal;

            public IdAssigner()
            {
                currentIdVal = 0;
            }

            public int nextId()
            {
                return currentIdVal++;
            }
        }


        static Random random = new Random();
        static IdAssigner idSource = new IdAssigner();







        // PuzzleElement instance Fields

        List<PuzzleKey> _keys;
        List<PuzzleLock> _locks;
        List<Location> _locations;
        List<Character> _characters;
        List<string> _obstacles;


        // PuzzleTopology
        IWeightedGraph<Location> _baseGraph;
        Dictionary<Character, DirectedSparseGraph<int>> _characterAccessGraphs;


        // Predetermined solution
        List<PuzzleKey> _solution;


        // Properties of Puzzle for access
        //public Dictionary<int, PuzzleKey> Keys;
        //public Dictionary<int, PuzzleLock> Locks;
        public Dictionary<int, Location> Locations;
        public Dictionary<int, Character> Characters;
        public IWeightedGraph<int> BaseGraph;
        public Dictionary<int, IWeightedGraph<int>> CharacterAccessGraphs;
        public Dictionary<int, string> Obstacles;
        public List<int> Solution;
        public int NumPlayers { get { return _characters.Count(); } }



        // Literally just instantiate the info necessary
        /// <summary>
        /// Initialize the information that is necessary for the algorithm to run
        /// </summary>
        /// <param name="numPlayers"> The number of players this puzzle has been generated for. </param>
        /// <param name="numSteps"> The number of steps that will be in the solution. </param>
        /// <param name="graphSize"> The number of vertices that will be present in the graph. </param>
        /// <param name="numLockKeyPairs"> The number of lock-key systems there will be. </param>
        /// <param name="obstacleTypes"></param>
        public Puzzle(int numPlayers, int numSteps, int graphSize, int numLockKeyPairs, string[] obstacleTypes)
        {
            // the number of keys should probably never be more than 2 times the number of vertices in the graph. Or maybe even less.

            // numSteps >= numLockKeyPairs. We'll randomly assign the first |numLockKeyPairs| steps, then insert duplicates

            // graphSize.... don't balloon this, dude.

            // also don't balloon the edges...

            // |obstacleTypes| will be kept pretty small for now.

            int currId;

            // make the components
            _obstacles = new Dictionary<int, string>();
            _characters = new Dictionary<int, Character>();
            _keys = new Dictionary<int, PuzzleKey>();
            _locks = new Dictionary<int, PuzzleLock>();
            _locations = new Dictionary<int, Location>();

            _locations.




            _baseGraph = new DirectedWeightedSparseGraph<int>(graphSize);
            _characterAccessGraphs = new Dictionary<int, DirectedSparseGraph<int>>();


            // adding all the location ids to the 
            //_baseGraph.AddVertices(_locations.Keys.ToArray());





        }






        // Helper functions

        public void InitializeObstacles(string[] obstacles)
        {


        }


        public void InitializeCharacters(string[] obstacles)
        {


        }

        public void InitializeLocations()
        {


        }


        /// <summary>
        /// Here you will initialize the lock-key dependencies that will drive the puzzle layout solver.
        /// You need:
        ///     When a lock is created with a list of obstacles, there must be key(s) that can unlock it.
        ///     Either create new keys or use old keys or a combo to cover the requirements.
        ///     We'll alter the function to map multiple locks to keys later.
        /// </summary>
        public void InitializeLockKeySystems(int numSystems)
        {


            while (numSystems >= 0)
            {


                numSystems--;
            }
            // load the lock and keys
            // 


            // pair them up



        }
        public void InitializeGraphs()
        {





        }

        // make a minimum spanning tree of complete graph, then introduce some cycles using paths of a certain length
        public void LoadKruskalMSTPlus()
        {

            // assumes the graph started as a sparse one, but has all of its vertices
            BinaryMinHeap<WeightedEdge<int>> edges = new BinaryMinHeap<WeightedEdge<int>>();
            List<int> vertexKeys = _locations.Keys.ToList();

            List<int> lockIDs = _locks.Keys.ToList(); // get the list of lockIDs

            int numEdges = vertexKeys.Count * vertexKeys.Count;
            int j = 0;




            int srcID;
            int dstID;
            int len = vertexKeys.Count;
            foreach (int lockID in lockIDs)
            {
                srcID = vertexKeys.ElementAt(random.Next(len));
                dstID = (srcID + random.Next(len - 1)) % len;
                edges.Add(new WeightedEdge<int>(srcID, dstID, lockID)); // add edge
            }




            // add the locks to the graph
            while (edges.Count > 0)
            {

            }









            return null;
        }






    }


}
