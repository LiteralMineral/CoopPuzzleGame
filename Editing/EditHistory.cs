using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopPuzzleGame.Editing
{
    // This is going to help define the boilerplate for the capability of undoing and redoing edits
    internal abstract class EditHistory<T>
    {
        Stack<Action<T, bool>> _history;
        public Stack<Action<T, bool>> History { get { return _history; } }
        Stack<Action<T, bool>> _future;
        public Stack<Action<T, bool>> Future { get { return _future; } }

        public EditHistory()
        {
            _history = new Stack<Action<T, bool>>();
            _future = new Stack<Action<T, bool>>();
        }

        /// <summary>
        /// Returns the previous edit without moving it. You are responsible for not 
        /// </summary>
        /// <returns></returns>
        public Action<T, bool> prevEdit()
        {
            return _history.Peek();
        }

        public Action<T, bool> nextEdit()
        {
            return _future.Peek();
        }


        public  Action<T, bool> undo()
        {
            // put the last edit done on the future stack
            _future.Push(_history.Pop());
            // return the first edit on the future stack
            return _future.Peek();
        }

        public abstract Action<T, bool> redo();

        // how an edit is inverted is really dependent upon what the edit was.
        public abstract Action<T, bool> inverseEdit(Action<T> action);

        public void recordEdit(Action<T, bool> edit, bool erase_future = true)
        {
            _history.Push(edit);
            if (erase_future)
            {
                _future.Clear();

            }
        }

    }

}
