using System;


namespace matrix
{
    class Program
    {
        static Random rand = new Random();

        static char Async
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    return (char)('A' + rand.Next(10));

                else if (t <= 4)
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    return (char)('1' + rand.Next(27));
                else
                    return (char)(rand.Next(60, 91));
            }
        }

        static void Main()
        {
          

            int width, height;
            int[] y;

            Initialize(out width, out height, out y);


            while (true)
                Update(width, height, y);
        }


        private static void Update(int width, int height, int[] y)
        {
            int x;

            for (x = 0; x < width; ++x)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(Async);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, YPosition(temp, height));
                Console.Write(Async);

                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, YPosition(temp1, height));
                Console.Write(' ');

                y[x] = YPosition(y[x] + 1, height);
            }

            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initialize(out width, out height, out y);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }

        public static int YPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            y = new int[width];

            Console.Clear();
            for (int x = 0; x < width; ++x)
            {
                y[x] = rand.Next(height);
            }
        }
    }
}
