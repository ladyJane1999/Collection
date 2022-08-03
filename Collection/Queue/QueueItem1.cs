using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Queue
{
	public class QueueItem1<T>
	{
		public T? Value { get; set; }
		public QueueItem1<T>? Next { get; set; }
	}
}
