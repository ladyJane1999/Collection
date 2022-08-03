using ConsoleApp1.Queue;
using System.Collections;

namespace QueueTask.Test
{
    public interface IQueue<T>  : IEnumerable
     
    {
        public int Count { get; }
        public void Enqueue(T item);
        public T Dequeue();
    }

}