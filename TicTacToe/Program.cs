using System;
using System.Runtime.InteropServices;
namespace TicTacToe
{
#if WINDOWS || LINUX
    

   
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AllocConsole();
            int n;
            do
            {
                Console.Title = "Введите размерность (19<N<41)";
                n = int.Parse(Console.ReadLine());
            } while (n < 20 || n > 40); // пока вводится некорректное значение будем показывать консоль

            using (var game = new Game1(n))
                game.Run();
        }
    }
#endif
}