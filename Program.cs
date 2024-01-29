using System;
using System.Drawing;
using System.Globalization;
using System.Transactions;

namespace Battleships;

class Program
{
    static void Main(string[] args)
    {
        Task.Delay(1000);
        ShowMenu();
    }

    static void cooltext()
    {
        Typewrite("milo tek - 2023");
        Console.WriteLine("         __                    __      __      __                      __        __                     ");
        Console.WriteLine("        /  |                  /  |    /  |    /  |                    /  |      /  |                    ");
        Console.WriteLine("        $$ |____    ______   _$$ |_  _$$ |_   $$ |  ______    _______ $$ |____  $$/   ______    _______ ");
        Console.WriteLine("        $$      \\  /      \\ / $$   |/ $$   |  $$ | /      \\  /       |$$      \\ /  | /      \\  /       |");
        Console.WriteLine("        $$$$$$$  | $$$$$$  |$$$$$$/ $$$$$$/   $$ |/$$$$$$  |/$$$$$$$/ $$$$$$$  |$$ |/$$$$$$  |/$$$$$$$/ ");
        Console.WriteLine("        $$ |  $$ | /    $$ |  $$ | __ $$ | __ $$ |$$    $$ |$$      \\ $$ |  $$ |$$ |$$ |  $$ |$$      \\ ");
        Console.WriteLine("        $$ |__$$ |/$$$$$$$ |  $$ |/  |$$ |/  |$$ |$$$$$$$$/  $$$$$$  |$$ |  $$ |$$ |$$ |__$$ | $$$$$$  |");
        Console.WriteLine("        $$    $$/ $$    $$ |  $$  $$/ $$  $$/ $$ |$$       |/     $$/ $$ |  $$ |$$ |$$    $$/ /     $$/ ");
        Console.WriteLine("        $$$$$$$/   $$$$$$$/    $$$$/   $$$$/  $$/  $$$$$$$/ $$$$$$$/  $$/   $$/ $$/ $$$$$$$/  $$$$$$$/  ");
        Console.WriteLine("                                                                                    $$ |                ");
        Console.WriteLine("                                                                                    $$ |                ");
        Console.WriteLine("                                                                                    $$/                 ");
    }


    
    
    
    ///  GAME FUNCTION ///
    
    static void game()
        {
            // cool ascii art :)
            Console.Clear();
            cooltext();

            
            
            
            // get user to enter ship #
            
            int shipsCount = 0;
            do
            {
                Typewrite("Enter number of ships per person [8~ RECOMMENDED]: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out shipsCount))
                {
                    if (shipsCount > 32 || shipsCount <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 32 [8~ RECOMMENDED].");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (shipsCount > 32 || shipsCount <= 0);

            
            
            
            /// INITIALIZATION ///
            
            char[,] playerGrid = createGrid();
            char[,] playerDisplay = createGrid();
            char[,] cpuGrid = createGrid();
            randomizeGrid(cpuGrid, shipsCount);
            
            int playerShipsLeft = shipsCount;
            int cpuShipsLeft = shipsCount;

            Random rnd = new Random();
            
            int cpuX;
            int cpuY;

            
            // let user decide to populate manually or automatically
            Typewrite("Aye... would ye like to have your ships placed at random or for you to put in yourself? \n" +
                      "1 - randomly \n" +
                      "2 - manually \n \n");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Typewrite("Invalid input. Please enter either 1 for random or 2 for manual. \n \n");
            }
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected RANDOM!");
                    randomizeGrid(playerGrid,shipsCount);
                    break;
                case 2:
                    Console.WriteLine("You selected MANUAL ENTERING");
                    populateGrid(playerGrid, shipsCount);
                    break;
            }
            
            
            
            
            
            /// GAME LOOP ///
            
            while (playerShipsLeft > 0 && cpuShipsLeft > 0)
            {
                // Clean up display, show da grids
                Console.Clear();
                
                Console.WriteLine("Your ships:");
                displayGrid(playerGrid);
                
                Console.Write("\n \n");
                
                Console.WriteLine("Opponent map:");
                displayGrid(playerDisplay);
                
                Console.WriteLine("\n \n YOUR TURN CAPTAIN! Enter coords: (ex: B4): \n \n");
                var fireCoords = formatToCoordinates(Console.ReadLine());
                int fireX = fireCoords.Item2;
                int fireY = fireCoords.Item1;

                if (fireX >= 1 && fireX <= 8 && fireY >= 1 && fireY <= 8) // check if within grid :p
                {
                    if (cpuGrid[fireX, fireY] == 'O')
                    {
                        Typewrite("Hit! You sank a ship!");
                        playerDisplay[fireX, fireY] = 'X';
                        cpuShipsLeft--;
                    }
                    else if (cpuGrid[fireX, fireY] == '~')
                    {
                        Typewrite("Miss! Try again.");
                        playerDisplay[fireX, fireY] = '*';
                    }
                    else
                    {
                        Console.WriteLine("You've already fired at these coordinates. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates. Try again.");
                }

                /// CPU CODE ///
                //
                // There's no reason for the CPU to actually have any code, honestly
                // it could just be {shipCount}/64 chance of randomly hitting one of your ships 
                // BUT ALAS. we ball...

                // tension builder lmao
                for (int i = 0; i < rnd.Next(7,15); i++)
                {
                    Console.Write('.');
                    Thread.Sleep(500);
                }
                
                // Actual "CPU" code
                
                cpuX = rnd.Next(1, 9);
                cpuY = rnd.Next(1, 9);

                while (playerGrid[cpuX, cpuY] == '~' )
                {
                    // regenerate random coordinates if the CPU has already fired there
                    cpuX = rnd.Next(1, 9);
                    cpuY = rnd.Next(1, 9);
                }

                switch (playerGrid[cpuX, cpuY])
                {
                    case 'O':
                        Typewrite("The opposing force has managed to sink one of our ships.");
                        playerGrid[cpuX, cpuY] = 'X';
                        cpuShipsLeft--;
                        break;

                    case '~':
                        Typewrite("The opponents missed any of our ships this time. Phew!");
                        playerGrid[cpuX, cpuY] = '*';
                        break;
                }




                
                Console.WriteLine("\nYour fleet: " + playerShipsLeft + " | CPU's fleet: " + cpuShipsLeft);
            }

            
            /// LOSE OR WIN ///
            
            if (playerShipsLeft == 0)
            {
                Typewrite("You LOST... \n" +
                                  "Your fleet is doomed. Hundreds of men have been lost, thanks to your incompetence \n" +
                                  "Now it is you who must decide... \n" +
                                  "...rematch this twisted, evil being, hellbent on destroying our fleet? \n");
                Rematch(); //offer rematch to loser
            }
            else
            {
                Typewrite("Well done solider. You have succeeded in your mission, and you live another day. \n" +
                                  "Dare you risk playing another manic game against this ruthless artificial intelligence...? \n" +
                                  "YES OR NO. \n");
                Rematch(); //offer another game to winner :D
            }

            Console.ReadKey();
        }
    


    
    
    
    
    
    
    
    
    
    
    
//                                            __                  _   _                 
//                                           / _|                | | (_)
//            __ _ __ _ _ __ ___   ___      | |_ _   _ _ __   ___| |_ _  ___  _ __  ___ 
//           / _` |/ _` | '_ ` _ \ / _ \    |  _| | | | '_ \ / __| __| |/ _ \| '_ \/ __|
//          | (_| | (_| | | | | | |  __/    | | | |_| | | | | (__| |_| | (_) | | | \__ \
//           \__, |\__,_|_| |_| |_|\___|    |_|  \__,_|_| |_|\___|\__|_|\___/|_| |_|___/
//            __/ |                                                                     
//           |___/                                                                      



    // GRID FUNCTIONS    

    static void displayGrid(char[,] grid)
    {
        for (int row = 0; row < 9; row++)
        {
            Console.Write("\n");
            Console.WriteLine(new String('-', grid.GetLength(0) * 2));
            for (int column = 0; column < 9; column++)
            {
                Console.Write("|");
                Console.Write(grid[row, column]);
            }
        }
    }

    static void randomizeGrid(char[,] grid, int shipsCount)
    {
        Random rnd = new Random();
        for (int count = 0; count < shipsCount; count++)
        {
            int posX = rnd.Next(2, 9);
            int posY = rnd.Next(2, 9);
            grid[posX, posY] = 'O';
        }
    }

    // COORDINATE NONSENSE FUNCTIONS
    
    static char[,] createGrid()
    {
        string alph = "ABCDEFGH";
        string nums = "12345678";

        // create empty grid
        char[,] grid = new char[9, 9]; 

        // fill grid with ~
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                grid[row, column] = '~';
            }
        }

        // make the row A-H
        for (int pee = 0; pee < 8; pee++)
        {
            grid[0, pee+1] = Convert.ToChar(alph.Substring(pee,1));
        }

        // make the column 1-8
        for (int poo = 0; poo < 8; poo++)
        {
            grid[poo + 1, 0] = Convert.ToChar(nums.Substring(poo, 1));
        }

        return grid;
    }
    static void populateGrid(char[,] grid, int shipsCount)
    {
        for (int count = 0; count < shipsCount; count++)
        {
            Console.Clear();
            displayGrid(grid);

            Console.Write("\n \n");
            Console.WriteLine("Enter coordinate to place boat (in A1 format, EX: B4, F7): ");

            bool validInput = false;

            while (!validInput)
            {
                var input = Console.ReadLine();

                try
                {
                    var coords = formatToCoordinates(input); // returns a tuple
                    int X = coords.Item2;
                    int Y = coords.Item1;

                    if ((X >= 1 && X <= 8) && (Y >= 1 && Y <= 8) && grid[X, Y] != 'O')
                    {
                        grid[X, Y] = 'O'; // place boat!
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates or already placed a boat there. Try again!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter coordinates in the correct format (e.g., B2).");
                }
            }
        }
    }


    static (int,int) formatToCoordinates(string og) // converts input like "C2" to "3,3"
    {
        og = og.ToUpper(); //fix lowercase
        int letter = charToDigit(Convert.ToChar(og.Substring(0, 1)));
        int number = Convert.ToInt32(og.Substring(1, 1));
        return (letter, number);
    }

    static int charToDigit(char character) // convert from character to digit - for above function
    {
        return character - 64;
    }   
    
    
    // MISC FUNCTIONS
    
    static void Typewrite(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            System.Threading.Thread.Sleep(60);
        }
        Console.Write("\n");

    }

    static void Rematch()
    {
        string answer = Console.ReadLine();
        if (answer.ToUpper() == "YES")
        {
            game();
        }
        else
        {
            return;
        }
    }
    
    
    
    
    
    /// MENU STUFF ///
    
    static void ShowMenu()
    {
        Console.Clear();
        
        cooltext();
        
        Console.WriteLine("ENTER OPTION:");
        Console.WriteLine("1. Play Battleboats");
        Console.WriteLine("2. Resume a game [unimplemented]");
        Console.WriteLine("3. Read the instructions");
        Console.WriteLine("4. Exit");
        Console.Write("Enter number 1-4: \n \n");
        
        int choice;
        
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        }

        // Process the user's choice
        switch (choice)
        {
            case 1:
                game();
                break;
            case 2:
                Typewrite("it dont work... mens...");
                ShowMenu();
                break;
            case 3:
                Instructions();
                break;
            case 4:
                Typewrite("Bye bye!");
                break;
        }
    }

    static void Instructions()
    {
        Console.Clear();
        // i wrote this all in obsidian lmao
        
        Console.WriteLine("\nAhoy there, matey! Ready to try your luck to survive out on the sea? Don't worry, it's easy as pie :^)\n\n1. **Plot your ships:** Drop your ships on the grid strategically. Don't be too random; it's not a lottery.\n\n2. **Call the shots:** Type in your coordinates like a pro. In the format of A4, B7, B4 for example.\n\n3. **Game:** If you end up hitting one of your opponents ships, well done! If you don't, wait for your turn and try again.\n\n4. **Hit:** It's then your opponents turn. Be patient and pray they don't hit you\n\nWhoever sinks all their opponent's ships first wins. Good luck and have fun.");
        Console.WriteLine("\n \n ENTER TO EXIT BACK TO MENU");
        Console.ReadKey();
        ShowMenu();
    }
}