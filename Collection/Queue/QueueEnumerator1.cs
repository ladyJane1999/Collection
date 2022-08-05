using ConsoleApp1.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Queue
{
	public class QueueEnumerator1<T> : IEnumerator<T>
	{
		Queue1<T> queue;
		QueueItem1<T> currentItem;
                int count;
		public QueueEnumerator1(Queue1<T> queue)
		{
			this.queue = queue;
			this.currentItem = null;
			count=queue.Count;
		}

		public T? Current
		{
			get { return currentItem.Value; }
		}

		public bool MoveNext()
		{
		       if (count != queue.Count)
                {
			throw new InvalidOperationException("count < queue.Count");
                }
			if (currentItem == null)
				currentItem = queue.Head;
			else
				currentItem = currentItem.Next;
				count=queue.Count;
			return currentItem != null;
		}

		public void Dispose()
		{

		}
		object? System.Collections.IEnumerator.Current
		{
			get { return Current; }
		}
		public void Reset()
		{

		}
	}
}
