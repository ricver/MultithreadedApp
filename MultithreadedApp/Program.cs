using MultithreadedApp;

Console.WriteLine("Start unsafe send");

BusMessageWriter BMW = new BusMessageWriter();

for (int i = 0; i < 101; i++)
{
    Thread thr = new Thread(new ThreadStart(BMW.SendMessage));
    thr.Start();
}


Console.WriteLine("Start safe send");
BusMessageWriterThreadsafe BMWTThreathsafe = new BusMessageWriterThreadsafe();

for (int i = 0; i < 101; i++)
{
    Thread thr = new Thread(new ThreadStart(BMWTThreathsafe.SendMessage));
    thr.Start();
}