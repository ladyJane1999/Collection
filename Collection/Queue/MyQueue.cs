using QueueTask.Test;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Queue
{
    public class MyQueue<T> : IQueue<T>
    {
        private int count = 0;
        private class Node
        {

            public Node(Node next, T value)
            {
                Next = next;
                Value = value;
            }

            public Node Next { get; internal set; }
            public T Value { get; }
        }

        public int Count
        {
            get
            {
                if (m_Head == null)
                {
                    count = 0;
                }

                return count;
            }
        }

        private Node m_Head;
        private Node m_Tail;


        public T Dequeue()
        {
            if (m_Head == null)
                throw new InvalidOperationException("Queue is empty");

            T item = m_Head.Value;
            
            if (m_Head == m_Tail)
            {
                m_Head = null;
                m_Tail = null;
            }
            else
            {
                m_Head = m_Head.Next;
            }

            count--;

            return item;

        }

        public void Enqueue(T item)
        {
            Node node = new Node(null, item);

            if (m_Head == null)
            {
                m_Head = node;
            }
            else
            {
                m_Tail.Next = node;
            }

            m_Tail = node;

            count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (Node? item = m_Head; item != null; item = item.Next)
            {
                yield return item.Value;
            }
        }


        class AEnumerator : IEnumerator
        {
            private IQueue<T> parent;
            private int position = -1;
         

            public AEnumerator(IQueue<T> parent)
            {
                this.parent = parent;
            }

            public object Current
            {
                get
                {
                    return parent;
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < parent.Count);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
