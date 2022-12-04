using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedApp
{
    public class BusMessageWriterThreadsafe
	{
		public void SendMessage()
		{
			SendMessageAsync();
		}
		//private readonly IBusConnection _connection;
		private readonly MemoryStream _buffer = new();
		int _count = 0;
		// how to make this method thread safe?
		public async Task SendMessageAsync()
		{
			await Task.Run(() =>
			{
				Write2Buffer(_count);
				_count++;
				if (_count > 10)
				{
					Publish();
				}
			});
		}
		private void Publish()
		{
			Console.WriteLine("???????????????????" + " " + (int)AppDomain.GetCurrentThreadId());
			_count = 0;
		}

		private void Write2Buffer(int i)
		{
			Console.WriteLine(i + " " + (int)AppDomain.GetCurrentThreadId());
		}
		//private void Publish()
		//{
		//	Publish();//_connection.PublishAsync(_buffer.ToArray());
		//	_count = 0;
		//}
	}
}
