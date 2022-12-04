using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedApp
{
    public class BusMessageWriter
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
			Console.WriteLine(_count + " " + (int)AppDomain.GetCurrentThreadId());
			_count++;
			
			if (_count > 10)
			{
				await PublishAsync();//_connection.PublishAsync(_buffer.ToArray());
				_count = 0;
			}
		}
		public async Task PublishAsync()
		{
			await Task.Run(() =>
			{
				Console.WriteLine("???????????????????" + " " + (int)AppDomain.GetCurrentThreadId());
				Task.Delay(100).Wait();
			});
		}
	}
}
