using Collection.Queue;
using QueueTask.Test;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Queue
{ 
	public class Queue1<T> : IQueue<T>
	{
		public IEnumerator<T> GetEnumerator()
		{
			return new QueueEnumerator1<T>(this);
		}

		private int count = 0;

		public int Count
		{
			get
			{
				if (Head == null)
				{
					count = 0;
				}
				return count;
			}
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public QueueItem1<T>? Head { get; private set; }
		QueueItem1<T>? tail;

		public bool IsEmpty { get { return Head == null; } }

		public void Enqueue(T value)
		{
			if (value == null)
				throw new InvalidOperationException("Value is null");

			if (IsEmpty)
				tail = Head = new QueueItem1<T> { Value = value, Next = null };
			else
			{
				var item = new QueueItem1<T> { Value = value, Next = null };
				tail.Next = item;
				tail = item;
			}
		
			count++;
		}

		public T Dequeue()
		{
			if (Head == null)
				throw new InvalidOperationException("Queue is empty");
			if (count == 0)
				throw new InvalidOperationException("Queue is empty");
			T item = Head.Value;

			if (Head == tail)
			{
				Head = null;
				tail = null;
			
			}
			else
			{
				Head = Head.Next;		
			}

			count--;

			return item;
		}
	}
}
