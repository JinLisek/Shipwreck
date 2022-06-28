using System.Collections;
using System.Collections.Generic;

namespace Logic
{

public class CircularLinkedList<T> : LinkedList<T>
{
    public new IEnumerator<T> GetEnumerator()
    {
        return new CircularLinkedListEnumerator<T>(this);
    }


}

    public class CircularLinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> current;
        public T Current => current.Value;
        object IEnumerator.Current => Current;

        public CircularLinkedListEnumerator(LinkedList<T> list)
        {
            current = list.First;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if(current == null)
            {
                return false;
            }
            current = current.Next ?? current.List.First;
            return true;
        }

        public void Reset()
        {
            current = current.List.First;
        }
    }

    public static class CircularLinkedListExtensions
    {
        public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
        {
            if(node != null && node.List != null)
            {
                return node.Next ?? node.List.First;
            }

            return null;
        }

        public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
        {
            if(node != null && node.List != null)
            {
                return node.Previous ?? node.List.Last;
            }

            return null;
        }

    }

}