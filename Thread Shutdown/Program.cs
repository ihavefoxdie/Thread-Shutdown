namespace Testing
{
    public class Program
    {
        private static ManualResetEvent event1 = new(false);

        public static void Waiting()
        {
            event1.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} is shutting down...");
            Thread.Sleep(new Random().Next(1000, 10000));
        }

        public static void Main()
        {
            for (int i = 1; i < 4; i++)
            {
                Thread thread = new(Waiting)
                {
                    Name = "Thread " + i.ToString(),
                };
                thread.Start();
            }

            Console.ReadLine();
            event1.Set();
        }
    }
}