using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace PacManv1
{
    class Program
    {       

        static void Main(string[] args)
        {
            #region Declaration
            Map mapforghost = SelecMapForGhost(1);
            Map map1 = SelectMap(1);
            PacManPlayer p1 = new PacManPlayer(13, 1, 0, false, true);
            map1.GetMap[p1.GetPosX, p1.GetPosY] = 5;
            Ghost g1 = new Ghost(11, 11, false, p1, map1, mapforghost);
            Ghost g2 = new Ghost(11, 16, false, p1, map1, mapforghost);
            Ghost g3 = new Ghost(14, 11, false, p1, map1, mapforghost);
            Ghost g4 = new Ghost(14, 16, false, p1, map1, mapforghost);
            bool finish = false;
            #endregion
            #region Thread Declaration
            Thread multipleGhost2 = new Thread(new ThreadStart(() => MutipleGhostThread(g1, g2, g3, g4, map1, p1)));
            Thread thPrintv2 = new Thread(new ThreadStart(() => ToPrintMain2(map1, p1, g1, g2, g3, g4, finish)));
            #endregion
            BeforeStartToPrint();
            thPrintv2.Start();
            multipleGhost2.Start();
            while (p1.GetAlive == true && p1.GetHasWon == false)
            {
                DeplacementMain(map1, p1, g1, g2, g3, g4);
                if (CheckEnd(map1) == true) p1.GetHasWon = true;
            }
            Console.Clear();
            if (CheckEnd(map1) == true)
            {
                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" __     __   ____    _    _              __          __  _____   _   _ \n \\ \\   / /  / __ \\  | |  | |             \\ \\        / / |_   _| | \\ | |\n  \\ \\_/ /  | |  | | | |  | |              \\ \\  /\\  / /    | |   |  \\| |\n   \\   /   | |  | | | |  | |               \\ \\/  \\/ /     | |   | . ` |\n    | |    | |__| | | |__| |                \\  /\\  /     _| |_  | |\\  |\n    |_|     \\____/   \\____/                  \\/  \\/     |_____| |_| \\_|");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t __     ______  _    _      _      ____   ____   _____ ______ \n\t \\ \\   / / __ \\| |  | |    | |    / __ \\ / __ \\ / ____|  ____|\n\t  \\ \\_/ | |  | | |  | |    | |   | |  | | |  | | (___ | |__   \n\t   \\   /| |  | | |  | |    | |   | |  | | |  | |\\___ \\|  __|  \n\t    | | | |__| | |__| |    | |___| |__| | |__| |____) | |____ \n\t    |_|  \\____/ \\____/     |______\\____/ \\____/|_____/|______|");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadKey();
        }

        #region DISPLAY
        /// <summary>
        /// This fonction permits to display the main menu ("Start?" --> Press Enter --> Countdown)
        /// </summary>
        static void BeforeStartToPrint()
        {
            ConsoleManager.SetFullScreen();
            Console.WriteLine("MAKE SURE THAT YOU ARE IN FULLSCREEN");
            #region START ?
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   _____ _______       _____ _______   ___  \n  / ____|__   __|/\\   |  __ |__   __| |__ \\ \n | (___    | |  /  \\  | |__) | | |       ) |\n  \\___ \\   | | / /\\ \\ |  _  /  | |      / / \n  ____) |  | |/ ____ \\| | \\ \\  | |     |_|  \n |_____/   |_/_/    \\_|_|  \\_\\ |_|     (_)  ");
            #endregion
            Console.WriteLine("\n\n\n\n");
            #region Press Enter
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  _____                           ______         _              \n |  __ \\                         |  ____|       | |             \n | |__) |_ __  ___  ___  ___     | |__    _ __  | |_  ___  _ __ \n |  ___/| '__|/ _ \\/ __|/ __|    |  __|  | '_ \\ | __|/ _ \\| '__|\n | |    | |  |  __/\\__ \\\\__ \\    | |____ | | | || |_|  __/| |   \n |_|    |_|   \\___||___/|___/    |______||_| |_| \\__|\\___||_|   ");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
            Console.ReadKey();
            Console.Clear();
            #region GOOD LUCK, then , 3,2,1
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.WriteLine("   _____  ____   ____  _____       _     _    _  _____ _  __\n  / ____|/ __ \\ / __ \\|  __ \\     | |   | |  | |/ ____| |/ /\n | |  __| |  | | |  | | |  | |    | |   | |  | | |    | ' / \n | | |_ | |  | | |  | | |  | |    | |   | |  | | |    |  <  \n | |__| | |__| | |__| | |__| |    | |___| |__| | |____| . \\ \n  \\_____|\\____/ \\____/|_____/     |______\\____/ \\_____|_|\\_\\ ");
            Thread.Sleep(1000);
            Console.Clear();
            // 3
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t  ____  \n\t\t\t\t\t\t |___ \\ \n\t\t\t\t\t\t   __) |\n\t\t\t\t\t\t  |__ < \n\t\t\t\t\t\t  ___) |\n\t\t\t\t\t\t |____/  ");
            Thread.Sleep(1000);
            Console.Clear();
            //2
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t  ___  \n\t\t\t\t\t\t |__ \\ \n\t\t\t\t\t\t    ) |\n\t\t\t\t\t\t   / /\n\t\t\t\t\t\t  / /_\n\t\t\t\t\t\t |____|       ");
            Thread.Sleep(1000);
            Console.Clear();
            //1
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t  __ \n\t\t\t\t\t\t /_ |\n\t\t\t\t\t\t  | |\n\t\t\t\t\t\t  | |\n\t\t\t\t\t\t  | |\n\t\t\t\t\t\t  |_| ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
            #endregion
        }

        static void ToPrintMain(Map map1,PacManPlayer p1, Ghost g1, Ghost g2, Ghost g3, Ghost g4, bool finish)
        {
            do
            {
                Console.Clear();
                //for (int i = 0; i < 100; i++)
                //{
                //    Console.WriteLine("\n");
                //}
                #region Title
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t  _____          _____    __  __            _   _  \n\t\t |  __ \\  /\\    / ____|  |  \\/  |    /\\    | \\ | | \n\t\t | |__) |/  \\  | |       | \\  / |   /  \\   |  \\| | \n\t\t |  ___// /\\ \\ | |       | |\\/| |  / /\\ \\  | . ` | \n\t\t | |   / ____ \\| |____   | |  | | / ____ \\ | |\\  | \n\t\t |_|  /_/    \\_\\\\_____|  |_|  |_|/_/    \\_\\|_| \\_| \n ");
                Console.ForegroundColor = ConsoleColor.White;
                #endregion
                Console.SetWindowSize(100, 50);
                map1.ToPrintMap(p1, g1,g2,g3,g4);
                //g1.GetMapforGhost.ToPrintMap(p1,g1,g2);
                //Console.WriteLine($"SCORE : {p1.GetScore}\n");
                #region Score
                //Console.WriteLine("   _____  _____ ____  _____  ______ \n  / ____|/ ____/ __ \\|  __ \\|  ____|\n | (___ | |   | |  | | |__) | |__   \n  \\___ \\| |   | |  | |  _  /|  __|  \n  ____) | |___| |__| | | \\ \\| |____ \n |_____/ \\_____\\____/|_|  \\_|______|");
                for (int i = 0; i < 6; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (i == 0) Console.Write("   _____  _____ ____  _____  ______ \t\t");
                    if (i == 1) Console.Write("  / ____|/ ____/ __ \\|  __ \\|  ____|\t\t");
                    if (i == 2) Console.Write(" | (___ | |   | |  | | |__) | |__   \t\t");
                    if (i == 3) Console.Write("  \\___ \\| |   | |  | |  _  /|  __|  \t\t");
                    if (i == 4) Console.Write("  ____) | |___| |__| | | \\ \\| |____ \t\t");
                    if (i == 5) Console.Write(" |_____/ \\_____\\____/|_|  \\_|______|\t\t");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    switch ((p1.GetScore % 100000) / 10000)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore%10000) / 1000)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore%1000) / 100)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }

                    switch ((p1.GetScore%100)/10)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }

                    switch ((p1.GetScore % 100) % 10)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }


                #endregion
                if (p1.GetScore == 236) p1.GetHasWon = true;
                Console.WriteLine($"GetMode P1 : {p1.GetMode}\nGetMode G1 : {g1.GetMode}\nGetAlive P1 : {p1.GetAlive}");
                Thread.Sleep(100);
            }
            while(p1.GetAlive == true && p1.GetHasWon == false);
            
        }

        /// <summary>
        /// Display the title, the map, and the score, and it refresh every 0.1 with Pacman's and the ghosts' new positions, and it stops either when pacman is dead or when a has eaten every pellets on the map
        /// </summary>
        /// <param name="map1">The map that contains the pellets and pacman</param>
        /// <param name="p1">Pacman</param>
        /// <param name="g1">Ghost 1</param>
        /// <param name="g2">Ghost 2</param>
        /// <param name="g3">Ghost 3</param>
        /// <param name="g4">Ghost 4</param>
        /// <param name="finish">Condition to know if the game is finished</param>
        static void ToPrintMain2(Map map1, PacManPlayer p1, Ghost g1, Ghost g2, Ghost g3, Ghost g4, bool finish)
        {
            map1.ToPrintMapv2() ;
            do
            {
                for (int i = 0; i < map1.GetMap.GetLength(0); i++)
                {
                    for (int j = 0; j < map1.GetMap.GetLength(1); j++)
                    {
                        
                        if (map1.GetMap[i,j]==1)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" o ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (map1.GetMap[i, j] == 10)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ¤ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (map1.GetMap[i, j] == 0)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == 10 && (j == 13 || j == 14))
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i==p1.GetPosX && j==p1.GetPosY)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ☺ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g1.GetPosX && j == g1.GetPosY && g1.GetMode==false && g1.GetIsAlive==true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g1.GetPosX && j == g1.GetPosY && g1.GetMode == true && g1.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g1.GetPosX && j == g1.GetPosY  && g1.GetIsAlive == false)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g2.GetPosX && j == g2.GetPosY && g2.GetMode==false && g2.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g2.GetPosX && j == g2.GetPosY && g2.GetMode == true && g2.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g2.GetPosX && j == g2.GetPosY && g2.GetIsAlive == false)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g3.GetPosX && j == g3.GetPosY && g3.GetMode==false && g3.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g3.GetPosX && j == g3.GetPosY && g3.GetMode == true && g3.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g3.GetPosX && j == g3.GetPosY && g3.GetIsAlive == false)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g4.GetPosX && j == g4.GetPosY && g4.GetMode==false && g4.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g4.GetPosX && j == g4.GetPosY && g4.GetMode==true && g4.GetIsAlive == true)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i == g4.GetPosX && j == g4.GetPosY && g4.GetIsAlive == false)
                        {
                            Console.SetCursorPosition(j * 3 + 1, i + 1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("^W^");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if(i==13 && (j==10 || j == 16))
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("   ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                    }
                }

                Console.SetCursorPosition( 10, 40);
                for (int i = 0; i < 6; i++)
                {
                    
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(50, 35 + i);
                    switch ((p1.GetScore % 100000) / 10000)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore % 10000) / 1000)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore % 1000) / 100)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore % 100) / 10)
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    switch ((p1.GetScore % 10))
                    {
                        case 0:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | | | |");
                            if (i == 3) Console.Write(" | | | |");
                            if (i == 4) Console.Write(" | |_| |");
                            if (i == 5) Console.Write("  \\___/ ");

                            break;
                        case 1:
                            if (i == 0) Console.Write("  __ ");
                            if (i == 1) Console.Write(" /_ |");
                            if (i == 2) Console.Write("  | |");
                            if (i == 3) Console.Write("  | |");
                            if (i == 4) Console.Write("  | |");
                            if (i == 5) Console.Write("  |_|");
                            break;
                        case 2:
                            if (i == 0) Console.Write("  ___  ");
                            if (i == 1) Console.Write(" |__ \\ ");
                            if (i == 2) Console.Write("    ) |");
                            if (i == 3) Console.Write("   / / ");
                            if (i == 4) Console.Write("  / /_ ");
                            if (i == 5) Console.Write(" |____|");
                            break;
                        case 3:
                            if (i == 0) Console.Write("  ____  ");
                            if (i == 1) Console.Write(" |___ \\ ");
                            if (i == 2) Console.Write("   __) |");
                            if (i == 3) Console.Write("  |__ < ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 4:
                            if (i == 0) Console.Write("  _  _   ");
                            if (i == 1) Console.Write(" | || |  ");
                            if (i == 2) Console.Write(" | || |_ ");
                            if (i == 3) Console.Write(" |__   _|");
                            if (i == 4) Console.Write("    | |  ");
                            if (i == 5) Console.Write("    |_|  ");
                            break;
                        case 5:
                            if (i == 0) Console.Write("  _____ ");
                            if (i == 1) Console.Write(" | ____|");
                            if (i == 2) Console.Write(" | |__  ");
                            if (i == 3) Console.Write(" |___ \\ ");
                            if (i == 4) Console.Write("  ___) |");
                            if (i == 5) Console.Write(" |____/ ");
                            break;
                        case 6:
                            if (i == 0) Console.Write("    __  ");
                            if (i == 1) Console.Write("   / /  ");
                            if (i == 2) Console.Write("  / /_  ");
                            if (i == 3) Console.Write(" | '_ \\ ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 7:
                            if (i == 0) Console.Write("  ______ ");
                            if (i == 1) Console.Write(" |____  |");
                            if (i == 2) Console.Write("     / / ");
                            if (i == 3) Console.Write("    / /  ");
                            if (i == 4) Console.Write("   / /   ");
                            if (i == 5) Console.Write("  /_/    ");
                            break;
                        case 8:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  > _ < ");
                            if (i == 4) Console.Write(" | (_) |");
                            if (i == 5) Console.Write("  \\___/ ");
                            break;
                        case 9:
                            if (i == 0) Console.Write("   ___  ");
                            if (i == 1) Console.Write("  / _ \\ ");
                            if (i == 2) Console.Write(" | (_) |");
                            if (i == 3) Console.Write("  \\__, |");
                            if (i == 4) Console.Write("    / / ");
                            if (i == 5) Console.Write("   /_/  ");
                            break;
                    }
                    Console.Write("    ");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
                if (p1.GetAlive == false) finish = true;
                if (CheckEnd(map1) == true) finish = true;
                Thread.Sleep(50);

            }
            while (finish == false) ;

        }

        #endregion

        #region GHOST
        /// <summary>
        /// Release the ghost with a 10 seconds intervals between each
        /// </summary>
        /// <param name="g1">Ghost 1</param>
        /// <param name="g2">Ghost 2</param>
        /// <param name="g3">Ghost 3</param>
        /// <param name="g4">Ghost 4</param>
        /// <param name="map1">Map for Pacman and pellets</param>
        /// <param name="p1">Pacman</param>
        static void MutipleGhostThread(Ghost g1, Ghost g2, Ghost g3, Ghost g4, Map map1, PacManPlayer p1)
        {
            Thread thGhost1 = new Thread(new ThreadStart(() => GhostMovementMain(g1, map1, p1)));
            Thread thGhost2 = new Thread(new ThreadStart(() => GhostMovementMain(g2, map1, p1)));
            Thread thGhost3 = new Thread(new ThreadStart(() => GhostMovementMain(g3, map1, p1)));
            Thread thGhost4 = new Thread(new ThreadStart(() => GhostMovementMain(g4, map1, p1)));
            Thread.Sleep(10000);
            thGhost1.Start();
            Thread.Sleep(10000);
            thGhost2.Start();
            Thread.Sleep(10000);
            thGhost3.Start();
            Thread.Sleep(10000);
            thGhost4.Start();
        }

        /// <summary>
        /// Allows the ghost to move on the map according to pacman's position on the board
        /// </summary>
        /// <param name="g1">Ghost 1</param>
        /// <param name="map1">Map for pacman and pellets</param>
        /// <param name="p1">Pacman</param>
        static void GhostMovementMain(Ghost g1,Map map1, PacManPlayer p1)
        {

            #region Find the shortest path
            bool start = false;
            bool touchPacMan = false;
            do
            {
                g1.RecursivMovementGhost(p1.GetPosX, p1.GetPosY, 60, start);
                #endregion
                string direction = "";

                if (g1.GetMapforGhost.GetMap[g1.GetPosX - 1, g1.GetPosY] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX - 1, g1.GetPosY] < g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode==false)
                {
                    direction = "up";
                }
                else
                {
                    if(g1.GetMapforGhost.GetMap[g1.GetPosX - 1, g1.GetPosY] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX - 1, g1.GetPosY] > g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode == true) direction = "up";
                }


                if (g1.GetMapforGhost.GetMap[g1.GetPosX + 1, g1.GetPosY] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX + 1, g1.GetPosY] < g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode==false)
                {
                    direction = "down";
                }
                else
                {
                    if (g1.GetMapforGhost.GetMap[g1.GetPosX + 1, g1.GetPosY] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX + 1, g1.GetPosY] > g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode == true) direction = "down";
                }


                if (g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY - 1] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY - 1] < g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode==false)
                {
                    direction = "left";
                }
                else
                {
                    if (g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY - 1] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY - 1] > g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode == true) direction = "left";
                }


                if (g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY + 1] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY + 1] < g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode==false)
                {
                    direction = "right";
                }
                else
                {
                    if (g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY + 1] != -1 && g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY + 1] > g1.GetMapforGhost.GetMap[g1.GetPosX, g1.GetPosY] && g1.GetMode == true) direction = "right";
                }


                switch (direction)
                {
                    case "up":
                        g1.GetPosX -= 1;
                        break;
                    case "down":
                        g1.GetPosX += 1;
                        break;
                    case "right":
                        g1.GetPosY += 1;
                        break;
                    case "left":
                        g1.GetPosY -= 1;
                        break;
                }
                //if (g1.GetMode == false) Thread.Sleep(300);
                //else Thread.Sleep(600);

                if(g1.GetMode==false)
                {
                    for (int x = 0; x < 30; x++)
                    {
                        if (g1.GetPosX == p1.GetPosX && g1.GetPosY == p1.GetPosY && g1.GetMode == false && g1.GetIsAlive == true)
                        {
                            touchPacMan = true;
                            p1.GetAlive = false;
                        }
                        if (touchPacMan == true) break;
                        Thread.Sleep(10);
                    }
                }
                else Thread.Sleep(600);

                for (int i = 0; i < g1.GetMapforGhost.GetMap.GetLength(0); i++)
                {
                    for (int j = 0; j < g1.GetMapforGhost.GetMap.GetLength(1); j++)
                    {
                        if (g1.GetMapforGhost.GetMap[i, j] != -1)
                        {
                            g1.GetMapforGhost.GetMap[i, j] = 0;
                        }
                    }
                }
                if (g1.GetPosX == p1.GetPosX && g1.GetPosY == p1.GetPosY && g1.GetMode==false && g1.GetIsAlive==true) touchPacMan = true;
                if (g1.GetIsAlive == false)
                {
                    
                    g1.GetPosX = 12;
                    g1.GetPosY = 12;
                    Thread.Sleep(5000);
                    g1.GetMode = false;
                    g1.GetIsAlive = true;
                    GhostMovementMain(g1, map1, p1);
                }

                
            }
            while (touchPacMan == false);
            p1.GetAlive = false;
            
        }
        #endregion

        #region PACMAN
        /// <summary>
        /// Main fonction allowing pacman to move (without using threads) by taking into account the keys entered by the player
        /// </summary>
        /// <param name="map1">Map for Pacman and pellets</param>
        /// <param name="p1">Pacman</param>
        /// <param name="g1">Ghost 1</param>
        /// <param name="g2">Ghost 2</param>
        /// <param name="g3">Ghost 3</param>
        /// <param name="g4">Ghost 4</param>
        static void DeplacementMain(Map map1, PacManPlayer p1,Ghost g1, Ghost g2,Ghost g3, Ghost g4)
        {
            ConsoleKeyInfo keyEnter = Console.ReadKey();
            if (keyEnter.Key == ConsoleKey.UpArrow)
            {
                if (PossibilityToMove(map1,p1,"up") == true) Deplacement(map1,p1,"up",g1,g2,g3,g4);

            }
            if (keyEnter.Key == ConsoleKey.DownArrow)
            {
                if (PossibilityToMove(map1, p1, "down") == true) Deplacement(map1, p1, "down",g1, g2, g3, g4);
            }
            if (keyEnter.Key == ConsoleKey.LeftArrow)
            {
                if (PossibilityToMove(map1, p1, "left") == true) Deplacement(map1, p1, "left",g1, g2, g3, g4);
            }
            if (keyEnter.Key == ConsoleKey.RightArrow)
            {
                if (PossibilityToMove(map1, p1, "right") == true)
                {
                    Deplacement(map1, p1, "right",g1, g2, g3, g4);
                }
            }
        }

        /// <summary>
        /// Check if pacman can move according to the direction given by the parameters
        /// </summary>
        /// <param name="map1">Map for Pacman and pellets</param>
        /// <param name="p1">Pacman</param>
        /// <param name="s1">Given direction (up, down, left or right)</param>
        /// <returns>Return true if pacman can move, false if not</returns>
        static bool PossibilityToMove(Map map1,PacManPlayer p1,string s1)
        {
            bool possibility = false;
            switch(s1)
            {
                case "up":
                    if (map1.GetMap[p1.GetPosX - 1, p1.GetPosY] != -1) possibility = true;
                    break;
                case "down":
                    if (map1.GetMap[p1.GetPosX + 1, p1.GetPosY] != -1 ) possibility = true;
                    if (p1.GetPosX + 1 == 10 && (p1.GetPosY == 13 || p1.GetPosY == 14)) possibility = false;
                    break;
                case "right":
                    if (map1.GetMap[p1.GetPosX , p1.GetPosY+1] != -1) possibility = true;
                    break;
                case "left":
                    if (map1.GetMap[p1.GetPosX, p1.GetPosY-1] != -1) possibility = true;
                    break;
            }
            return possibility;
        }

        /// <summary>
        /// Carry out a move in a given direction until pacman doesn't have any other possibilty to move, increase Pacman's score for each pellets eaten, allows the passage in "super mode" when he eats a super pellet, and verify whether Pacman is eaten or eating when he collides with a Ghost
        /// </summary>
        /// <param name="map1">Map for Pacman and pellets</param>
        /// <param name="p1">Pacman</param>
        /// <param name="movement">Direction</param>
        /// <param name="g1">Ghost 1</param>
        /// <param name="g2">Ghost 2</param>
        /// <param name="g3">Ghost 3</param>
        /// <param name="g4">Ghost 4</param>
        static void Deplacement(Map map1, PacManPlayer p1, string movement, Ghost g1, Ghost g2, Ghost g3, Ghost g4)
        {
            Thread mode1;
            Thread mode2;
            Thread mode3;
            Thread mode4;
            int compteurMode = 1;
            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
            {
                p1.GetScore += 200;
                g1.GetIsAlive = false;
            }
            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
            {
                p1.GetScore += 200;
                g2.GetIsAlive = false;
            }
            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
            {
                p1.GetScore += 200;
                g3.GetIsAlive = false;
            }
            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
            {
                p1.GetScore += 200;
                g4.GetIsAlive = false;
            }
            switch (movement)
            {
                case "up":
                    if (map1.GetMap[p1.GetPosX - 1, p1.GetPosY] == 1) p1.GetScore+=10;
                    if (map1.GetMap[p1.GetPosX - 1, p1.GetPosY] == 10)
                    {
                        switch(compteurMode)
                        {
                            case 1:
                                mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode1.Start();
                                break;
                            case 2:
                                mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode2.Start();
                                break;
                            case 3:
                                mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode3.Start();
                                break;
                            case 4:
                                mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode4.Start();
                                break;
                        }
                        compteurMode+=1;
                        p1.GetScore+=50;
                    }
                    map1.GetMap[p1.GetPosX - 1, p1.GetPosY] = 5;
                    map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                    p1.GetPosX += -1;

                    while(PossibilityToMove(map1,p1,"right")==false && PossibilityToMove(map1, p1, "left") == false)
                    {
                        Thread.Sleep(200);
                        if (map1.GetMap[p1.GetPosX - 1, p1.GetPosY] == 1) p1.GetScore+=10;
                        if (map1.GetMap[p1.GetPosX - 1, p1.GetPosY] == 10)
                        {
                            switch (compteurMode)
                            {
                                case 1:
                                    mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode1.Start();
                                    break;
                                case 2:
                                    mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode2.Start();
                                    break;
                                case 3:
                                    mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode3.Start();
                                    break;
                                case 4:
                                    mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode4.Start();
                                    break;
                            }
                            compteurMode += 1;
                            p1.GetScore+=50;
                        }
                        map1.GetMap[p1.GetPosX - 1, p1.GetPosY] = 5;
                        map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                        p1.GetPosX += -1;
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                        {
                            p1.GetScore += 200;
                            g1.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                        {
                            p1.GetScore += 200;
                            g2.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                        {
                            p1.GetScore += 200;
                            g3.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                        {
                            p1.GetScore += 200;
                            g4.GetIsAlive = false;
                        }
                        if (((p1.GetPosX - 1 == g1.GetPosX &&p1.GetPosY==g1.GetPosY && g1.GetIsAlive== true) || (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY && g2.GetIsAlive == true) || (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY && g3.GetIsAlive == true) || (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY && g4.GetIsAlive == true)) && p1.GetMode == false ) p1.GetAlive = false;
                    }
                    Thread.Sleep(200);
                    break;
                case "down":
                    if (map1.GetMap[p1.GetPosX + 1, p1.GetPosY] == 1) p1.GetScore+=10;
                    if (map1.GetMap[p1.GetPosX + 1, p1.GetPosY] == 10)
                    {
                        switch (compteurMode)
                        {
                            case 1:
                                mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode1.Start();
                                break;
                            case 2:
                                mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode2.Start();
                                break;
                            case 3:
                                mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode3.Start();
                                break;
                            case 4:
                                mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode4.Start();
                                break;
                        }
                        compteurMode+=1;
                        p1.GetScore+=50;
                    }
                    map1.GetMap[p1.GetPosX + 1, p1.GetPosY] = 5;
                    map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                    p1.GetPosX +=1;

                    while (PossibilityToMove(map1, p1, "right") == false && PossibilityToMove(map1, p1, "left") == false)
                    {
                        Thread.Sleep(200);
                        if (map1.GetMap[p1.GetPosX + 1, p1.GetPosY] == 1) p1.GetScore+=10;
                        if (map1.GetMap[p1.GetPosX + 1, p1.GetPosY] == 10)
                        {
                            switch (compteurMode)
                            {
                                case 1:
                                    mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode1.Start();
                                    break;
                                case 2:
                                    mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode2.Start();
                                    break;
                                case 3:
                                    mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode3.Start();
                                    break;
                                case 4:
                                    mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode4.Start();
                                    break;
                            }
                            compteurMode += 1;
                            p1.GetScore+=50;
                        }
                        map1.GetMap[p1.GetPosX + 1, p1.GetPosY] = 5;
                        map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                        p1.GetPosX += 1;
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                        {
                            p1.GetScore += 200;
                            g1.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                        {
                            p1.GetScore += 200;
                            g2.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                        {
                            p1.GetScore += 200;
                            g3.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                        {
                            p1.GetScore += 200;
                            g4.GetIsAlive = false;
                        }
                        if (((p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY && g1.GetIsAlive == true) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY && g2.GetIsAlive == true) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY && g3.GetIsAlive == true) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY && g4.GetIsAlive == true)) && p1.GetMode == false) p1.GetAlive = false;
                    }
                    Thread.Sleep(200);
                    break;
                case "right":
                    if (p1.GetPosX == 13 && p1.GetPosY == 27)
                    {
                        p1.GetPosY = 0;
                        map1.GetMap[p1.GetPosX, 27] = 0;
                        map1.GetMap[p1.GetPosX, 0] = 5;
                    }
                    if (map1.GetMap[p1.GetPosX, p1.GetPosY+1] == 1) p1.GetScore+=10;
                    if (p1.GetPosY + 1 != 28 && map1.GetMap[p1.GetPosX, p1.GetPosY+1] == 10)
                    {
                        switch (compteurMode)
                        {
                            case 1:
                                mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode1.Start();
                                break;
                            case 2:
                                mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode2.Start();
                                break;
                            case 3:
                                mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode3.Start();
                                break;
                            case 4:
                                mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode4.Start();
                                break;
                        }
                        compteurMode+=1;
                        p1.GetScore+=50;
                    }
                    map1.GetMap[p1.GetPosX, p1.GetPosY+1] = 5;
                    map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                    p1.GetPosY +=1;
                    if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                    {
                        p1.GetScore += 200;
                        g1.GetIsAlive = false;
                    }
                    if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                    {
                        p1.GetScore += 200;
                        g2.GetIsAlive = false;
                    }
                    if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                    {
                        p1.GetScore += 200;
                        g3.GetIsAlive = false;
                    }
                    if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                    {
                        p1.GetScore += 200;
                        g4.GetIsAlive = false;
                    }
                    while (PossibilityToMove(map1, p1, "up") == false && PossibilityToMove(map1, p1, "down") == false)
                    {
                        Thread.Sleep(200);
                        if (p1.GetPosX == 13 && p1.GetPosY == 27)
                        {
                            p1.GetPosY = 0;
                            map1.GetMap[p1.GetPosX, 27] = 0;
                            map1.GetMap[p1.GetPosX, 0] = 5;
                        }
                        
                        if (map1.GetMap[p1.GetPosX, p1.GetPosY + 1] == 1) p1.GetScore+=10;
                        if (p1.GetPosY + 1 != 27 && map1.GetMap[p1.GetPosX, p1.GetPosY + 1] == 10)
                        {
                            switch (compteurMode)
                            {
                                case 1:
                                    mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode1.Start();
                                    break;
                                case 2:
                                    mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode2.Start();
                                    break;
                                case 3:
                                    mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode3.Start();
                                    break;
                                case 4:
                                    mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode4.Start();
                                    break;
                            }
                            compteurMode+=1;
                            p1.GetScore+=50;
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                            {
                                p1.GetScore += 200;
                                g1.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                            {
                                p1.GetScore += 200;
                                g2.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                            {
                                p1.GetScore += 200;
                                g3.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                            {
                                p1.GetScore += 200;
                                g4.GetIsAlive = false;
                            }
                            if (((p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX==g1.GetPosX && g1.GetIsAlive == true) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX && g2.GetIsAlive == true) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX && g3.GetIsAlive == true) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX && g4.GetIsAlive == true)) && p1.GetMode == false) p1.GetAlive = false;
                        }
                        map1.GetMap[p1.GetPosX, p1.GetPosY + 1] = 5;
                        map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                        if(p1.GetPosX == 13 && p1.GetPosY==27)
                        {
                            p1.GetPosY = 0;
                        }
                        else
                        {
                            p1.GetPosY += 1;
                        }

                        

                    }
                    Thread.Sleep(200);
                    break;
                case "left":
                    if(p1.GetPosX == 13 && p1.GetPosY == 0)
                    {
                        p1.GetPosY = 27;
                        map1.GetMap[p1.GetPosX, 27] = 5;
                        map1.GetMap[p1.GetPosX, 0] = 0;
                    }
                    if (map1.GetMap[p1.GetPosX, p1.GetPosY - 1] == 1) p1.GetScore+=10;
                    if (p1.GetPosY - 1 != 0 && map1.GetMap[p1.GetPosX, p1.GetPosY - 1] == 10)
                    {
                        switch (compteurMode)
                        {
                            case 1:
                                mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode1.Start();
                                break;
                            case 2:
                                mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode2.Start();
                                break;
                            case 3:
                                mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode3.Start();
                                break;
                            case 4:
                                mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                mode4.Start();
                                break;
                        }
                        compteurMode += 1;
                        p1.GetScore+=50;
                    }
                    map1.GetMap[p1.GetPosX, p1.GetPosY - 1] = 5;
                    map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                    p1.GetPosY -= 1;

                    while (PossibilityToMove(map1, p1, "up") == false && PossibilityToMove(map1, p1, "down") == false)
                    {
                        if (p1.GetPosX == 13 && p1.GetPosY == 0)
                        {
                            p1.GetPosY = 27;
                            map1.GetMap[p1.GetPosX, 27] = 5;
                            map1.GetMap[p1.GetPosX, 0] = 0;
                        }
                        Thread.Sleep(200);
                        if (map1.GetMap[p1.GetPosX, p1.GetPosY - 1] == 1) p1.GetScore+=10;
                        if (p1.GetPosY - 1 != 0 && map1.GetMap[p1.GetPosX, p1.GetPosY - 1] == 10)
                        {
                            switch (compteurMode)
                            {
                                case 1:
                                    mode1 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode1.Start();
                                    break;
                                case 2:
                                    mode2 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode2.Start();
                                    break;
                                case 3:
                                    mode3 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode3.Start();
                                    break;
                                case 4:
                                    mode4 = new Thread(new ThreadStart(() => ModeTrue(p1, g1, g2, g3, g4)));
                                    mode4.Start();
                                    break;
                            }
                            compteurMode += 1;
                            p1.GetScore+=50;
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                            {
                                p1.GetScore += 200;
                                g1.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                            {
                                p1.GetScore += 200;
                                g2.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                            {
                                p1.GetScore += 200;
                                g3.GetIsAlive = false;
                            }
                            if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                            {
                                p1.GetScore += 200;
                                g4.GetIsAlive = false;
                            }
                        }
                        map1.GetMap[p1.GetPosX, p1.GetPosY -1] = 5;
                        map1.GetMap[p1.GetPosX, p1.GetPosY] = 0;
                        if (p1.GetPosX == 13 && p1.GetPosY == 0)
                        {
                            p1.GetPosY = 27;
                        }
                        else
                        {
                            p1.GetPosY -= 1;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosX + 1 == g1.GetPosX && p1.GetPosY == g1.GetPosY) || (p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY + 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX) || (p1.GetPosY == g1.GetPosY && p1.GetPosX == g1.GetPosX))
                        {
                            p1.GetScore += 200;
                            g1.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosX + 1 == g2.GetPosX && p1.GetPosY == g2.GetPosY) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY + 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX) || (p1.GetPosY == g2.GetPosY && p1.GetPosX == g2.GetPosX))
                        {
                            p1.GetScore += 200;
                            g2.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosX + 1 == g3.GetPosX && p1.GetPosY == g3.GetPosY) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY + 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX) || (p1.GetPosY == g3.GetPosY && p1.GetPosX == g3.GetPosX))
                        {
                            p1.GetScore += 200;
                            g3.GetIsAlive = false;
                        }
                        if (p1.GetPosY - 1 >= 0 && p1.GetPosY + 1 <= 27 && p1.GetMode == true && (p1.GetPosX - 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosX + 1 == g4.GetPosX && p1.GetPosY == g4.GetPosY) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY + 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX) || (p1.GetPosY == g4.GetPosY && p1.GetPosX == g4.GetPosX))
                        {
                            p1.GetScore += 200;
                            g4.GetIsAlive = false;
                        }
                        if (((p1.GetPosY - 1 == g1.GetPosY && p1.GetPosX == g1.GetPosX && g1.GetIsAlive == true) || (p1.GetPosY - 1 == g2.GetPosY && p1.GetPosX == g2.GetPosX && g2.GetIsAlive == true) || (p1.GetPosY - 1 == g3.GetPosY && p1.GetPosX == g3.GetPosX && g3.GetIsAlive == true) || (p1.GetPosY - 1 == g4.GetPosY && p1.GetPosX == g4.GetPosX && g4.GetIsAlive == true)) && p1.GetMode == false) p1.GetAlive = false;
                    }
                    Thread.Sleep(200);
                    break;
            }
            
        }

        /// <summary>
        /// Swith the mode of pacman in super mode and the ghost in hunted mode for 5 seconds
        /// </summary>
        /// <param name="p1">Pacman</param>
        /// <param name="g1">Ghost 1</param>
        /// <param name="g2">Ghost 2</param>
        /// <param name="g3">Ghost 3</param>
        /// <param name="g4">Ghost 4</param>
        static void ModeTrue(PacManPlayer p1, Ghost g1, Ghost g2, Ghost g3, Ghost g4) 
        {
            p1.GetMode = true;
            g1.GetMode = true;
            g2.GetMode = true;
            g3.GetMode = true;
            g4.GetMode = true;
            Thread.Sleep(5000);
            p1.GetMode = false;
            g1.GetMode = false;
            g2.GetMode = false;
            g3.GetMode = false;
            g4.GetMode = false;
        }
        #endregion

        #region MAP
        /// <summary>
        /// Allows to choose the map 
        /// </summary>
        /// <param name="number">Number of the map</param>
        /// <returns>Return the chosen map</returns>
        static Map SelectMap(int number)
        {
            Map map;
            switch(number)
            {
                case 1:
                    int[,] mapInt = {
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}, 
{-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1}, 
{-1,10,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,10,-1}, 
{-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},  
{-1, 1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1, 1,-1}, 
{-1, 1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1, 1,-1}, 
{-1, 1, 1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1, 1, 1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1,-1,-1, 0, 0,-1,-1,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 1,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 1,-1,-1,-1,-1,-1,-1},
{-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
{-1, 1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1, 1,-1},
{-1, 1,-1,-1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1, 1,-1,-1,-1,-1, 1,-1},
{-1,10, 1, 1,-1,-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1,-1, 1, 1,10,-1},
{-1,-1,-1, 1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1, 1,-1,-1,-1},
{-1,-1,-1, 1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1, 1,-1,-1,-1},
{-1, 1, 1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1,-1,-1, 1, 1, 1, 1, 1, 1,-1},
{-1, 1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1},
{-1, 1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,-1},
{-1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
};
                    map = new Map(mapInt);
                    break;
                default:
                    mapInt = new int[32, 32];
                    for (int i = 0; i < mapInt.GetLength(0); i++)
                    {
                        for (int j = 0; j < mapInt.GetLength(1); j++)
                        {
                            mapInt[i, j] = 1;
                        }
                    }
                    map = new Map(mapInt);
                    break;
            }
            return map;
        }

        /// <summary>
        /// Allows to choose the map (for the ghosts) (must be the same as the first chosen map)
        /// </summary>
        /// <param name="number">number of the map</param>
        /// <returns>Return the chosen map</returns>
        static Map SelecMapForGhost(int number)
        {
            Map map;
            switch (number)
            {
                case 1:
                    int[,] mapInt = {
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
{-1, 0,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1, 0,-1}, 
{-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1}, 
{-1, 0,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1, 0,-1}, 
{-1, 0,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1, 0,-1}, 
{-1, 0, 0, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0, 0, 0,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1, 0, 0,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1, 0, 0, 0, 0, 0, 0,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1},
{-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
{-1, 0,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1, 0,-1},
{-1, 0,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1, 0,-1},
{-1, 0, 0, 0,-1,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1,-1, 0, 0, 0,-1},
{-1,-1,-1, 0,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1, 0,-1,-1,-1},
{-1,-1,-1, 0,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1, 0,-1,-1,-1},
{-1, 0, 0, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0,-1,-1, 0, 0, 0, 0, 0, 0,-1},
{-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1},
{-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1},
{-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
};

                    map = new Map(mapInt);
                    break;
                default:
                    mapInt = new int[32, 32];
                    for (int i = 0; i < mapInt.GetLength(0); i++)
                    {
                        for (int j = 0; j < mapInt.GetLength(1); j++)
                        {
                            mapInt[i, j] = 1;
                        }
                    }
                    map = new Map(mapInt);
                    break;
            }
            return map;
        }

        /// <summary>
        /// Check if there are remaining pellets on the map
        /// </summary>
        /// <param name="map1">chosen map</param>
        /// <returns>return true if there are no pellets left, and false if there still are</returns>
        static bool CheckEnd(Map map1)
        {
            bool check = true;
            for (int i = 0; i < map1.GetMap.GetLength(0); i++)
            {
                for (int j = 0; j < map1.GetMap.GetLength(1); j++)
                {
                    if (check == false) break;
                    if (map1.GetMap[i, j] == 1 || map1.GetMap[i, j] == 10) check = false;
                    
                }
            }
            return check;
        }
        #endregion

        static void DeplacementThread(Map map1,PacManPlayer p1,Ghost g1, Ghost g2, Ghost g3, Ghost g4)
        {
            Thread.Sleep(50);
            DeplacementMain(map1, p1, g1, g2, g3, g4);
        }
        
        
        

    }
}

