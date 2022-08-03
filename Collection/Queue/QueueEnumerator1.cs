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

		public QueueEnumerator1(Queue1<T> queue)
		{
			this.queue = queue;
			//В самом начале перечислитель не смотрит ни на какой элемент
			//Чтобы посмотреть на первый элемент, его нужно сначала переместить.
			this.currentItem = null;
		}

		public T? Current
		{
			get { return currentItem.Value; }
		}

		public bool MoveNext()
		{
			//Если мы еще никуда не смотрим - посмотреть на голову очереди
			if (currentItem == null)
				currentItem = queue.Head;
			//В противном случае, посмотреть на следующий элемент
			else
				currentItem = currentItem.Next;
			//Вернуть true, если нам удалось перейти на следующий элемент, 
			//или false, если не удалось и из foreach нужно выйти
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
