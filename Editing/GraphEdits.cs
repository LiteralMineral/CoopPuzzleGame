using DataStructures.Graphs;
//using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.Editing
{
    internal class GraphEdits<T> : IEditHistory<T>
    {
        private delegate Action<T> AddVertex(T v);
        
        public override Action<T> inverseEdit(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public override Action<T> nextEdit()
        {
            throw new NotImplementedException();
        }

        public override Action<T> prevEdit()
        {
            throw new NotImplementedException();
        }

        public override Action<T> undo()
        {
            throw new NotImplementedException();
        }

        public override Action<T> redo()
        {
            throw new NotImplementedException();
        }

    }
}
