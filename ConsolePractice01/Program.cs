/*
All the following code is related to practicing various C# concepts discussed in book "The C# Player's Guide, 2nd Edition" by RB Whitaker.
Chapter and page numbers referenced within are from this book.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpOverloading;    // Refers to a namespace below and allows reference to content without using OverLoading in each case

namespace ConsolePractice01
{

    /* Recommend use following best practice when you define enumeration types.  If you have not defined 
       an enumeration member whose value is 0, consider creating a "None" enumerated constant.  By default, the memory 
       used for enumerations is initialized to 0 by the CLR. Consequently, if you do not define a constant whose 
       value is zero, the enumeration will contain an illegal value when it is created.
       See more at: https://msdn.microsoft.com/en-us/library/system.enum(v=vs.110).aspx
    */
    enum MonthOfYear { None, January, February, March, April, May, June, July, August, September, October, November, December }
    // Realisticlly, for consistancy, may want to adjust the above enum to be Zero based as DayOfWeek and other arrays are.


    /*
    Access Modifiers:
    The "private" keyword attached to a method or instance variable means that only stuff inside the class can use it.
    The "private" keyword is default and is implied if no keyword is used.
    The "public" keyword attached to a method or instance variable means that anything inside or outside the class can use it.
    The "internal" keyword attached to a method or instance variable means that can be used only if part of the current project of assembly.
    The "protected" keyword attached to a class allows anything inside of the class to use it as well as any derived class.
    The "sealed" keyword attached to a class will pervent any other class from being derived from it and my result in a performace boost.
    The "this" keyword allows you to reach outside method to class variable even if inside method with a varible of the same name (p.124).

    A "static" item doesn't belong to a particular object and can be shared among all other objects of a class.  A "static" variable will 
    have the same value for all instances in a class and can be shared by all instances of the class.  A "static" method allows you to use
    the method without making a instance of it in the current class to call it.
    */

    class Program
    {
        // These varibles need to be here and made "static" in order to be available to all methods below.
        // The "static" modifier could be dropped but then would need to access variables via "Program" class.
        const string case01 = "Examine various For loop configurations.";
        const string case02 = "FizzBuzz challenge on page 79 of book.";
        const string case03 = "Calculate area of a circle.";
        const string case04 = "Calculate properties of a cylinder.";
        const string case05 = "Determine if entered number is even or odd.";
        const string case06 = "Simple Calcululator.";
        const string case07 = "Examine some Console Window settings.";
        const string case08 = "Examine Console Window, StringBuilder, and Try-Catch-Finally.";
        const string case09 = "Examine Try-Catch-Finally block use.";
        const string case10 = "Examine Stringbuilder use to parse strings.";
        const string case11 = "Examine various Array Examples";
        const string case12 = "Examine Enumerations.";
        const string case13 = "Examine Recursion Methods.";
        const string case14 = "Examine Properties and Constructors used in Classes and Structs.";
        const string case15 = "Examine Interfaces.";
        const string case16 = "Examine .Net Generics: List, IEnumerable, and Dictionary.";
        const string case17 = "Examine Instant Write/Read of Text Files and Initializing Arrays of Class Types.";
        const string case18 = "Examine Environment Folders and Streaming Write/Read of Text and Binary Files.";
        const string case19 = "Examine Delegates.  Create delgates and use built-in delegates Func and Action.";
        const string case20 = "Examine Events.";
        const string case21 = "Examine Operator Overloading.";
        const string case22 = "Examine Classes and Properties again.";
        const string case23 = "Code Sample 23.";

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetWindowSize(100, 45);
            Console.Title = "ConsolePractice01:  V4.0  2016-01-23  by Paul Ghilino";

            int choice;
            do  // Keep repeating until 0 entered to exit
            {
                Console.Clear();
                Library.ReverseConsoleColors("\nConsolePractice01: Run various C# Code examples\n");
                Console.WriteLine(" 0: Exit");
                Console.WriteLine(" 1: " + case01);
                Console.WriteLine(" 2: " + case02);
                Console.WriteLine(" 3: " + case03);
                Console.WriteLine(" 4: " + case04);
                Console.WriteLine(" 5: " + case05);
                Console.WriteLine(" 6: " + case06);
                Console.WriteLine(" 7: " + case07);
                Console.WriteLine(" 8: " + case08);
                Console.WriteLine(" 9: " + case09);
                Console.WriteLine("10: " + case10);
                Console.WriteLine("11: " + case11);
                Console.WriteLine("12: " + case12);
                Console.WriteLine("13: " + case13);
                Console.WriteLine("14: " + case14);
                Console.WriteLine("15: " + case15);
                Console.WriteLine("16: " + case16);
                Console.WriteLine("17: " + case17);
                Console.WriteLine("18: " + case18);
                Console.WriteLine("19: " + case19);
                Console.WriteLine("20: " + case20);
                Console.WriteLine("21: " + case21);
                Console.WriteLine("22: " + case22);
                Console.WriteLine("23: " + case23);
                Console.Write("\n\nEnter your selection: ");    // Write() does not add LF at end
                choice = Library.ReadLineIntegerMinMax(0, 23);  // Limit input to numbers 0 thru 23
                Console.Clear();
                switch (choice)
                {
                    case 1:  CodeSample01(); break;     // Call a method to run/test each example versus
                    case 2:  CodeSample02(); break;     // making a new program for each one.
                    case 3:  CodeSample03(); break;
                    case 4:  CodeSample04(); break;
                    case 5:  CodeSample05(); break;
                    case 6:  CodeSample06(); break;
                    case 7:  CodeSample07(); break;
                    case 8:  CodeSample08(); break;
                    case 9:  CodeSample09(); break;
                    case 10: CodeSample10(); break;
                    case 11: CodeSample11(); break;
                    case 12: CodeSample12(); break;
                    case 13: CodeSample13(); break;
                    case 14: CodeSample14(); break;
                    case 15: CodeSample15(); break;
                    case 16: CodeSample16(); break;
                    case 17: CodeSample17(); break;
                    case 18: CodeSample18(); break;
                    case 19: CodeSample19(); break;
                    case 20: CodeSample20(); break;
                    case 21: CodeSample21(); break;
                    case 22: CodeSample22(); break;
                    case 23: CodeSample23(); break;
                    default:    // If get this far, then case should be 0, so exit program
                        break;
                }
            } while (choice != 0);  // Exit program if entry was zero, otherwise continue.
        }


        private static void CodeSample01()  // Examine various For loop configurations.
        {
            Library.ReverseConsoleColors(case01);
            int row, col;
            //
            // Note: Parameters in For loops need to be sparated by a semicolons versus a commas

            // Example 1
            Console.WriteLine("\n\nExample 1:\n");
            for (row = 0; row < 5; row++)
            {
                for (col = 0; col < 10; col++)  // Don't need brackets if only 1 line in loop
                    Console.Write("*");         // No Lf's with Write()
                Console.WriteLine();            // Got to have LF to start next row
            }

            // Example 2
            Console.WriteLine("\nExample 2:\n");
            for (row = 0; row < 10; row++)
            {
                for (col = 0; col < row + 1; col++)     // Don't need brackets if only 1 line in loop
                    Console.Write("*");                 // No Lf's with Write()
                Console.WriteLine();                    // Got to have LF to start next row
            }

            // Example 3: Construct a pyramid
            Console.WriteLine("\nExample 3:\n");
            //
            int maxCol = 25;                        // macCol needs to be an odd number to make a symetrical pyramid
                                                    // Adjust maxCol value to make pyramid bigger or smaller
            int peak = (maxCol - 1) / 2 + 1;            // Peak=Peak of pyramid column position from left
            int maxRow = peak;                      // Same as Peak to make a symetrical pyramid
            int step = 0;
            for (row = 1; row <= maxRow; row++)     // Start count at 1 so no adjustment need to be made later
            {
                for (col = 1; col <= maxCol; col++)
                {
                    if ((col < (peak - step)) || (col > (peak + step)))
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
                step++;
                Console.WriteLine();
            }
            Library.ConsolePause();
        }

        private static void CodeSample02()  // FizzBuzz challenge on page 79 of book.
        {
            Library.ReverseConsoleColors(case02);
            Console.WriteLine("\n");    // Add LF
            int mod3, mod5;
            for (int i = 1; i <= 100; i++)
            {
                mod3 = i % 3;   // number divisible by 3 if zero
                mod5 = i % 5;   // number divisible by 5 if zero
                if ((mod3 == 0) && (mod5 == 0))
                    Console.Write("FizzBuzz, ");
                else if (mod3 == 0)
                    Console.Write("Fizz, ");
                else if (mod5 == 0)
                    Console.Write("Buzz, ");
                else
                    Console.Write("{0}, ", i);
                if (i % 10 == 0)
                    Console.WriteLine("\n");   // LF's after 10 numbers
            }
            Library.ConsolePause();
        }

        private static void CodeSample03()  // Calculate area of a circle.
        {
            Library.ReverseConsoleColors(case03);
            do
            {
                Console.Write("\nEnter the radius of the circle: ");
                double radius = Library.ReadLineDouble();
                double area = Math.PI * Math.Pow(radius, 2.0);
                Console.Write($"\nThe area of the circle is {area} square units.\n");
                Console.Write("\nEnter 0 to Exit, or Enter to continue: ");
                if ("0" == Console.ReadLine())
                    break;
                Console.WriteLine();    // Add LF to space problems apart
            } while (true);
        }

        private static void CodeSample04()  // Calculate properties of a cylinder.
        {
            Library.ReverseConsoleColors(case04);

            // Neat search result on geometric properties:
            // http://www.bing.com/search?q=surface+area+of+a+cylinder&src=IE-SearchBox&FORM=IESR02&pc=EUPP_
            //
            do
            {
                Console.Write("\nEnter the radius of the cylinder: ");
                double radius = Library.ReadLineDouble();
                Console.Write("\nEnter the height of the cylinder: ");  // Note: if height is 0, a cylinder still has surface area
                double height = Library.ReadLineDouble();
                double surfaceArea = 2.0 * Math.PI * radius * (radius + height);
                double volume = Math.PI * Math.Pow(radius, 2.0) * height;
                Console.Write($"\nThe surface area of the cylinder is {surfaceArea} square units.\n");
                Console.Write($"\nThe volume of the cylinder is {volume} cubic units.\n");
                Console.Write("\nEnter 0 to Exit, or Enter to continue: ");
                if ("0" == Console.ReadLine())
                    break;
                Console.WriteLine();    // Add LF to space problems apart
            } while (true);
        }

        private static void CodeSample05()  // Determine if entered number is even or odd.
        {
            Library.ReverseConsoleColors(case05);
            int num, leftOver;
            do
            {
                Console.Write("\nEnter an integer: ");
                num = Library.ReadLineInteger();
                leftOver = num % 2;
                if (leftOver == 0)
                    Console.WriteLine($"\nThe number {num} is even since leftover amount after dividing by 2 is {leftOver}.");
                else
                    Console.WriteLine($"\nThe number {num} is odd since leftover amount after dividing by 2 is {leftOver}.");
                Console.Write("\nEnter 0 to Exit, or Enter to continue: ");
                if ("0" == Console.ReadLine())
                    break;
                Console.WriteLine();    // Add LF to space problems apart
            } while (true);
        }

        private static void CodeSample06()  // Simple Calcululator.
        {
            Library.ReverseConsoleColors(case06);

            double first, second;
            string op;
            do  // continue using calculator over and over until 0 entered to exit
            {
                Console.Write("\nEnter 1st number: ");
                first = Library.ReadLineDouble();
                Console.Write("\nEnter 2nd number ");
                second = Library.ReadLineDouble();
                Console.Write("\nOperation ( +, -, *, /, % (Modulus): ");
                bool checkOp;
                do   // Keep looping until correct funtion entered
                {
                    op = Console.ReadLine();
                    switch (op)
                    {
                        case "+":
                            {
                                Console.Write($"\nAnswer: {first} + {second} = {first + second}\n");
                                checkOp = true;
                                break;
                            }
                        case "-":
                            {
                                Console.Write($"\nAnswer: {first} - {second} = {first - second}\n");
                                checkOp = true;
                                break;
                            }
                        case "*":
                            {
                                Console.Write($"\nAnswer: {first} * {second} = {first * second}\n");
                                checkOp = true;
                                break;
                            }
                        case "/":
                            {
                                Console.Write($"\nAnswer: {first} / {second} = {first / second}\n");
                                checkOp = true;
                                break;
                            }
                        case "%":
                            {
                                Console.Write($"\nAnswer: {first} % {second} = {first % second} units left over\n");
                                checkOp = true;
                                break;
                            }
                        default:
                            {
                                Console.Beep();
                                Console.Write("Invalid operator!  Try again: ");
                                checkOp = false;
                                break;
                            }
                    }
                } while (!checkOp);
                //  This code works but is clumsy to use on numeric keypad
                //  if (Library.ReadlineCheckYN("\nDo another calculation?"))  // Returns true if yes
                //      Console.WriteLine();    // Add LF to space problems apart
                //  else
                //      break;
                Console.Write("\nEnter 0 to Exit, or Enter to continue: ");
                if ("0" == Console.ReadLine())
                    break;
                Console.WriteLine();    // Add LF to space problems apart
            } while (true);
        }

        private static void CodeSample07()  // Examine some Console Window settings.
        {
            Library.ReverseConsoleColors(case07);

            int origWidth, width, origHeight, height;  // you can declare mutiple variables on one line.  Have not seen before.

            string m1 = "\nWindow Width={0}, Window Height={1}.";
            string m2 = "\nBuffer Width={0}, Buffer Height={1}.";
            string m3 = "\nWindow Left={0}, Window Top={1}.";
            string m4 = "\nLargest Window Width={0}, Largest Window Height={1}.";

            // Step 1: Get current window dimensions
            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;
            Console.WriteLine(m1, Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine(m2, Console.BufferWidth, Console.BufferHeight);
            Console.WriteLine(m3, Console.WindowLeft, Console.WindowTop);
            Console.WriteLine(m4, Console.LargestWindowWidth, Console.LargestWindowHeight);
            Library.ConsolePause();

            // Step 2: Cut the window to 1/4th original size
            width = origWidth / 2;
            height = origHeight / 2;
            Console.SetWindowSize(width, height);
            Console.WriteLine("\n\n" + m1, Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine(m2, Console.BufferWidth, Console.BufferHeight);
            Console.WriteLine(m3, Console.WindowLeft, Console.WindowTop);
            Console.WriteLine(m4, Console.LargestWindowWidth, Console.LargestWindowHeight);
            Library.ConsolePause();

            // Step 3: Restore the window to original size
            Console.SetWindowSize(origWidth, origHeight);
            Console.WriteLine("\n\n" + m1, Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine(m2, Console.BufferWidth, Console.BufferHeight);
            Console.WriteLine(m3, Console.WindowLeft, Console.WindowTop);
            Console.WriteLine(m4, Console.LargestWindowWidth, Console.LargestWindowHeight);
            Library.ConsolePause();
        }

        private static void CodeSample08()  // Examine Console Window, StringBuilder, and Try-Catch-Finally.
        {
            Library.ReverseConsoleColors(case08);

            if (Console.IsOutputRedirected)     // Catch exception that will cause errors below
            {
                Console.Write("\nOutput has been redirected.  This method can not continue.  Return to main menu: ");
                Console.ReadKey();
                return;
            }

            int y;
            int saveBufferWidth = Console.BufferWidth;
            int saveBufferHeight = Console.BufferHeight;
            int saveWindowHeight = Console.WindowHeight;
            int saveWindowWidth = Console.WindowWidth;
            bool saveCursorVisible = Console.CursorVisible;

            string m1 = "\n\nPress the cursor (arrow) keys to move the console background around.\n" +
                        "\nWhen finished playing around, press the Escape key to exit the test.";

            string g1 = "+----";
            string g2 = "|    ";
            string grid1;
            string grid2;

            StringBuilder sbG1 = new StringBuilder();
            StringBuilder sbG2 = new StringBuilder();
            ConsoleKeyInfo cki;

            // Try block contains "guarded" code that may cause an exception.
            // Try block is executed until exception is thrown or is successfully completed.
            try
            {
                saveBufferWidth = Console.BufferWidth;
                saveBufferHeight = Console.BufferHeight;
                saveWindowHeight = Console.WindowHeight;
                saveWindowWidth = Console.WindowWidth;
                saveCursorVisible = Console.CursorVisible;

                // Display message
                Console.WriteLine(m1);  // Begin the test
                Library.ConsolePause();

                // Set the smallest possible window size before setting the buffer size.
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(80, 80);
                Console.SetWindowSize(40, 20);

                // Create grid lines to fit the buffer. (The buffer width is 80, but
                // this same technique could be used with an arbitrary buffer width.)
                for (y = 0; y < Console.BufferWidth / g1.Length; y++)   // 80x80 bufffer
                {
                    sbG1.Append(g1);    // g1="+----"
                    sbG2.Append(g2);    // g2="|    ";
                }

                sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);    // Calculate remainder spaces to fill in, if any, for
                sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);    // generic problem.  80%5=0 has no spaces left over.
                grid1 = sbG1.ToString();
                grid2 = sbG2.ToString();

                Console.CursorVisible = false;  // Hide the cursor
                Console.Clear();

                // May want to use linefeeds to prevent text wrapping.
                // If you adjust window size, image goes to hell.
                for (y = 0; y < Console.BufferHeight - 1; y++)
                {
                    if (y % 3 == 0)     // Neat way to repeat vertical pattern every 3 lines, which results in square grid
                        Console.Write(grid1);   // Write() does no linefeeds so this is just wrapping image
                    else
                        Console.Write(grid2);
                }
                Console.SetWindowPosition(0, 0);

                do   // Move the cursor around until ESC is entered
                {
                    cki = Console.ReadKey(true);    // Get the key, if "true" option is used, ReadKey() will not display the key.
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (Console.WindowLeft > 0)
                                Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                            break;
                        case ConsoleKey.UpArrow:
                            if (Console.WindowTop > 0)
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                                Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                                Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                            break;
                    }
                } while (cki.Key != ConsoleKey.Escape);
            } // end try

            // When exception is thrown, the CLR looks for catch statement to handle the exception.
            // You can use more than one catch block, but order is important.
            // You should only catch exceptions that you know how and want to recover from. Therefore, 
            // you should always specify an object argument derived from System.Exception.
            // Complex topic, more at: https://msdn.microsoft.com/en-us/library/0yd65esw.aspx
            //
            catch (IOException e)   // Only checking IOException vs ArgumentOutOfRangeException.
            {
                Console.WriteLine(e.Message);
            }

            /* By using a finally block, you can clean up any resources that are allocated in a try block.
               Typically, the statements of a finally block run when control leaves a try statement.
               With a handled exception, finally block is guaranteed to be run. However, if the exception is unhandled,
               execution of the finally block is dependent on how the exception unwind operation is triggered.
               Complex topic, more at: https://msdn.microsoft.com/en-us/library/zwc8s4fz.aspx
            */
            finally
            {
                Console.Clear();                // reset everything back the way it was before leaving
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
                Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
                Console.CursorVisible = saveCursorVisible;
            }
            Library.ReverseConsoleColors(case08);
            Console.WriteLine("\n\nTest complete. Window should be back to orginal size and position now.\n");
            Library.ConsolePause();
        }

        private static void CodeSample09()  // Examine Try-Catch-Finally block use.
        {
            Library.ReverseConsoleColors(case09);
            int i = 123;
            string s = "Some string";
            object obj = s;

            // Try block contains "guarded" code that may cause an exception.  See Chapter 29 at p.191.
            // Try block is executed until exception is thrown or is successfully completed.

            try
            {
                Console.WriteLine("\n\nTop of Try block.");

                Console.Write("\n\tChose exception to create (1 through 5): ");

                bool valid;
                do
                {
                    // Exception: Invalid conversion; obj contains a string, not a numeric type.
                    Int32.TryParse(Console.ReadLine(), out int except);
                    switch (except)
                    {
                        case 1:
                            valid = true;
                            Console.WriteLine("\tCase 1: Attempt to explicity cast an Object" +
                                              "\tthat contains a string into an integer.");
                            i = (int)obj;   // Cause exception
                            break;
                        case 2:
                            // Integer overflow will only be checked if explicitly "checked" or placed in a "checked" block.
                            // Only integral varibles can be checked.  Floats, doubles, and decimals can not be checked.
                            // For additional info see: https://msdn.microsoft.com/en-us/library/74b4xzyw.aspx
                            // So use checked when you don't want accidental overflow or wrap-around to be a problem,
                            // and would rather see an exception.
                            valid = true;
                            int maxInt = Int32.MaxValue;
                            Console.WriteLine($"\tCase 2: Attempt to add maximum integer to itself. MaxValue={maxInt}");
                            Console.WriteLine($"\tInteger overflow checking will only occur if explicitly \"checked\".");
                            int check = checked(maxInt + maxInt);  // This should cause an overflow exception
                            break;
                        case 3:
                            valid = true;
                            Console.WriteLine("\tAttempt to divide a number by 0.");
                            i /= 0;
                            break;
                        case 4:
                            valid = true;
                            Console.WriteLine("\tNo exception created here yet.");
                            break;
                        case 5:
                            valid = true;
                            Console.WriteLine("\tNo exception created here yet.");
                            break;
                        default:
                            valid = false;
                            Console.Beep();
                            Console.Write("\tInvalid selection, try again: "); // No LF
                            break;
                    }
                } while (!valid);
                // If exception triggered, the following statement will not run since exception jumps to Catch block
                Console.WriteLine("\nBottom of Try block.");
            }

            // If exception is thrown, the CLR looks for catch statement to handle the exception.
            // You can use more than one catch block, but order is important.
            // You should only catch exceptions that you know how and want to recover from. Therefore, 
            // you should always specify an object argument derived from a System.Exception.
            // Complex topic, more at: https://msdn.microsoft.com/en-us/library/0yd65esw.aspx

            catch (Exception ex)
            {
                Console.WriteLine("\n\nTop of Catch block.");

                // Place Catch code here
                Console.Beep();
                Console.WriteLine("\n\tException Type: {0}", ex.GetType());
                Console.WriteLine("\tException Message: {0}", ex.Message);
                Console.WriteLine("\tException TargetSite: {0}", ex.TargetSite);

                Console.WriteLine("\nBottom of Catch block.");
                throw;
            }

            // By using a Finally block, you can clean up any resources that are allocated in a try block.
            // Code in a finally block gets run no mattter what.  If it ran through Try block without errors it gets executed.
            // If it ran into a Return statement it still gets executed before returning.  If there was an exception it will get
            // executed.  Finally block always get executed right before jumping up to the calling method.  If exception occured,
            // it will take exception with it.  Complex topic, more at p.196 and https://msdn.microsoft.com/en-us/library/zwc8s4fz.aspx 

            finally
            {
                Console.WriteLine("\n\nTop of Finally block.");

                // Place finally code here...
                Console.WriteLine("\n\tExecution of the Finally block after an unhandled error");
                Console.WriteLine("\tdepends on how the exception unwind operation is triggered.");
                Console.WriteLine("\tPlace rest of \"Guarded\" cleanup code here.");

                Console.WriteLine("\nBottom of Finally block.");
            }

            Console.WriteLine("\n\nContinue with \"Unguarded\" code after Finally block cleans up.\n");
            Library.ConsolePause();
        }

        private static void CodeSample10()  // Examine Stringbuilder use to parse strings.
        {
            Library.ReverseConsoleColors(case10);

            // If you decide to pursue this further websites are https://msdn.microsoft.com/en-us/library/kc12ydtf(v=vs.110).aspx
            // and https://msdn.microsoft.com/en-us/library/2839d5h5(v=vs.110).aspx

            string str = "First;George Washington;1789;1797";
            int index = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int length = str.IndexOf(';', index);
            sb.Append(str, index, length).Append(" President of the United States: ");
            index += length + 1;
            length = str.IndexOf(';', index) - index;
            sb.Append(str, index, length).Append(", from ");
            index += length + 1;
            length = str.IndexOf(';', index) - index;
            sb.Append(str, index, length).Append(" to ");
            index += length + 1;
            sb.Append(str, index, str.Length - index);
            Console.WriteLine("\n" + sb);
            // The example displays the following output:
            //    First President of the United States: George Washington, from 1789 to 1797  

            Library.ConsolePause();
        }

        private static void CodeSample11()  // Examine various Array Examples.
        {
            Library.ReverseConsoleColors(case11);
            Console.WriteLine("\n\nFind properties of array: [216, 201, 99, 65, 49, 305, 245, 91, 153, 72, 102]");

            // See Array tutorial @ https://msdn.microsoft.com/en-us/library/aa288453(v=vs.71).aspx
            // Also many other tutorials are linked there.

            int[] array1 = new int[] { 216, 201, 99, 65, 49, 305, 245, 91, 153, 72, 102 };
            // The "new int[]" part can be omitted if array values are filled in

            int Min1 = int.MaxValue;
            int Sum1 = 0;

            Console.WriteLine("\nExample of a For loop of the above array follows:");
            for (int i = 0; i < array1.Length; i++)
            {
                Sum1 += array1[i];     // Add them all up
                if (array1[i] < Min1)
                    Min1 = array1[i];  // New min value found
            }
            int Sum2 = array1.Sum();     // Different way to sum up the values
            int Min2 = array1.Min();

            Console.WriteLine($"Minimum value in array={Min1}.  Sum of values={Sum2}." +
                              $"\nMin value alternate way={Min2}.  Average value={(float)Sum1 / array1.Length}");


            Console.WriteLine("\nExample of a Foreach loop of the above array follows:");
            Min1 = int.MaxValue;    // reset varibles for next example
            Sum1 = 0;

            foreach (int value in array1)   // Foreach gets the next "value" in the array and continues for the whole array
            {
                Sum1 += value;     // Add them all up
                if (value < Min1)
                    Min1 = value;  // New min value found
            }
            Console.WriteLine($"Minimum value in array={Min1}.  Sum of values={Sum1}.");
            Console.WriteLine($"Zero indexing!  Value of Array1 at 5 should be '305': Value={array1[5]}");   // zero indexing of arrays


            Console.WriteLine("\n\nDisplay values of various mutidimensional arrays: 1, 2, 3, ....");


            // Two dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a two dimensional array [3,3] follows:");

            int[,] array2 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            foreach (int value in array2)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array2 at 1,1 should be '5': Value={array2[1, 1]}");   // zero indexing of arrays


            // Two dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a two dimensional array [3,3] follows:");

            int[,] array3 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };  // Do not need to declare array if specified

            foreach (int value in array3)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array3 at 0,2 should be '3': Value={array3[0, 2]}");   // zero indexing of arrays


            // Three dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a three dimensional array [3,3,3] follows:");

            int[,,] array4 = new int[3, 3, 3] {     { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                                                    { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } },
                                                    { { 9, 20, 21 }, { 22, 23, 24}, { 25, 26, 27 } },
                                              };
            foreach (int value in array4)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array4 at 1,2,0 should be '16': Value={array4[1, 2, 0]}");   // zero indexing of arrays


            // Three dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a three dimensional array [3,3,3] follows:");

            int[,,] array5 = {  // Do not need to declare array if specified
                                { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                                { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } },
                                { { 9, 20, 21 }, { 22, 23, 24}, { 25, 26, 27 } },
                             };
            foreach (int value in array5)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array5 at 0,2,1 should be '8': Value={array5[0, 2, 1]}");   // zero indexing of arrays


            // Three dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a three dimensional array [4,2,2] follows:");

            int[,,] array6 = new int[4, 2, 2]{  // Do not need to declare array if specified
                                   { { 1, 2 }, { 3, 4 } },
                                   { { 5, 6 }, { 7, 8 } },
                                   { { 9, 10 }, { 11, 12 } },
                                   { { 13, 14 }, { 15, 16} },
                             };
            foreach (int value in array6)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array6 at 2,1,1 should be '12': Value={array6[2, 1, 1]}");   // zero indexing of arrays


            // Four dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a four dimensional array [2.2,2,2] follows:");

            int[,,,] array7 = new int[2, 2, 2, 2]   {
                                                        {
                                                            { { 1, 2 }, { 3, 4 } },
                                                            { { 5, 6 }, { 7, 8 } },
                                                        },
                                                        {
                                                            { { 9, 10 }, { 11, 12 } },
                                                            { { 13, 14 }, { 15, 16} },
                                                        },
                                                    };
            foreach (int value in array7)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array7 at 1,1,0,1 should be '14': Value={array7[1, 1, 0, 1]}");   // zero indexing of arrays


            // Four dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a four dimensional array [3.2,2,2] follows:");

            int[,,,] array8 =   {
                                                        {
                                                            { { 1, 2 }, { 3, 4 } },
                                                            { { 5, 6 }, { 7, 8 } },
                                                        },
                                                        {
                                                            { { 9, 10 }, { 11, 12 } },
                                                            { { 13, 14 }, { 15, 16} },
                                                        },
                                                        {
                                                            { { 17, 18 }, { 19, 20 } },
                                                            { { 21, 22 }, { 23, 24} },
                                                        },
                                };
            foreach (int value in array8)
                Console.Write($"{value} ");
            Console.WriteLine($"\nZero indexing!  Value of Array8 at 1,1,0,0 should be '13': Value={array8[1, 1, 0, 0]}");   // zero indexing of arrays


            // Four dimensional array example
            Console.WriteLine("\n\nExample of a Foreach loop on a four dimensional array [3,3,3,3] follows:");

            int[,,,] array9 = new int[3, 3, 3, 3] {
                                                        {
                                                            { { 01, 02, 03 }, { 04, 05, 06 }, { 07, 08 ,09 } },
                                                            { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } },
                                                            { { 19, 20, 21 }, { 22, 23, 24 }, { 25, 26, 27 } },
                                                        },
                                                        {
                                                            { { 28, 29, 30 }, { 31, 32, 33 }, { 34, 35, 36 } },
                                                            { { 37, 38, 39 }, { 40, 41, 42 }, { 43, 44, 45 } },
                                                            { { 46, 47, 48 }, { 49, 50, 51 }, { 52, 53, 54 } },
                                                        },
                                                        {
                                                            { { 55, 56, 57 }, { 58, 59, 60 }, { 61, 62, 63 }},
                                                            { { 64, 65, 66 }, { 67, 68, 69 }, { 70, 71, 72 } },
                                                            { { 73, 74, 75 }, { 76, 77, 78 }, { 79, 80, 81 } },
                                                        },
                                };
            foreach (int value in array9)
            {
                if (value == 30 || value == 56)
                    Console.WriteLine();    // Add LF's to make output nice
                Console.Write($"{value} ");
            }
            Console.WriteLine($"\nZero indexing!  Value of Array9 at 2,1,2,0 should be '70': Value={array9[2, 1, 2, 0]}");   // zero indexing of arrays


            Console.WriteLine();
            Library.ConsolePause();
        }

        private static void CodeSample12()  // Examine Enumerations.
        {
            Library.ReverseConsoleColors(case12);

            // New enumerations are usually declared outside of any classes in the namespace

            Console.WriteLine();
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Sunday, DayOfWeek.Sunday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Monday, DayOfWeek.Monday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Tuesday, DayOfWeek.Tuesday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Wednesday, DayOfWeek.Wednesday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Thursday, DayOfWeek.Thursday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Friday, DayOfWeek.Friday);
            Console.WriteLine("{0}={1}", (int)DayOfWeek.Saturday, DayOfWeek.Saturday);

            // Another way to get a list of the days

            string[] arr = DayOfWeek.GetNames(typeof(DayOfWeek));
            Console.WriteLine();
            foreach (string s in arr)
                Console.WriteLine(s);

            // do again for months!  This is my enumeration since apparently not build in.

            Console.WriteLine();
            Console.WriteLine("{0}={1}", (int)MonthOfYear.January, MonthOfYear.January);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.February, MonthOfYear.February);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.March, MonthOfYear.March);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.April, MonthOfYear.April);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.May, MonthOfYear.May);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.June, MonthOfYear.June);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.July, MonthOfYear.July);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.August, MonthOfYear.August);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.September, MonthOfYear.September);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.October, MonthOfYear.October);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.November, MonthOfYear.November);
            Console.WriteLine("{0}={1}", (int)MonthOfYear.December, MonthOfYear.December);


            // Enter a date and see what day it was.

            int month, day, year;
            DateTime dt;
            do
            {
                Console.WriteLine("\nEnter a past or future date to determine it's day of the week.");
                Console.Write("\nMonth (1-12): ");
                month = Library.ReadLineIntegerMinMax(1, 12);
                Console.Write("Day (1-31): ");
                day = Library.ReadLineIntegerMinMax(1, 31);
                Console.Write("Year: ");
                year = Library.ReadLineIntegerMinMax(1, 10000);
                dt = new DateTime(year, month, day);
                Console.WriteLine("\n{0} {1:d}.", dt.DayOfWeek, dt);
                Console.Write("\nEnter 0 to Exit, or Enter to continue: ");
                if ("0" == Console.ReadLine())
                    break;
                Console.WriteLine();    // Add LF to space problems apart
            } while (true);

            Library.ConsolePause();
        }

        private static void CodeSample13()  // Examine Recursion Methods.
        {
            Library.ReverseConsoleColors(case13);

            // Factorial recursion example

            uint num, total;            // Use unsigned integers for larger values
            uint max = uint.MaxValue;

            Console.WriteLine("\n\nMaximum unsigned integer value is: {0:N0}", max);

            Console.Write("\n\nFactorial Example: Enter a number less than 13: ");
            num = (uint)Library.ReadLineIntegerMinMax(1, 12);
            Console.WriteLine(); // LF
            total = Factorial(num);     // Call recursive method.  Anything over 15 causes overflow.
            Console.WriteLine("\nFactorial of {0:N0} is {1:N0}.", num, total);

            // Fibonacci example.  No recursion involved!

            Console.Write("\n\nFibonacci Example: Enter sequence number less than 40: ");
            num = (uint)Library.ReadLineIntegerMinMax(1, 39);
            total = Fibonacci(num);     // Call recursive method.  Anything over 25 causes overflow.
            Console.WriteLine("\nFibonacci value of {0:N0} is {1:N0}.", num, total);

            Console.WriteLine();  // LF
            Library.ConsolePause();
        }

        private static void CodeSample14()  // Examine Properties and Constructors used in Classes and Structs.
        {
            Library.ReverseConsoleColors(case14);

            // Setup instance variables and set and recall various property values from classes and strcts established below

            // Create a new Person object:  This calls a class!
            Person per = new Person();   // This example uses a constructor which returns a string when "person" is referenced.
            Console.WriteLine("\n\nDefault: \t{0}", per);    // Print out the default name and the age set in the class:
            per.Name = "Paul";   // Set some new values in the person object:
            per.Age = 58;
            Console.WriteLine("Present age: \t{0}", per);
            per.Age += 1;    // Increment the Age property:
            Console.WriteLine("Age next year: \t{0}", per);
            per.Name = "Zach";   // Set some new values in the person object:
            per.Age = 17;
            Console.WriteLine("Present age: \t{0}", per);

            // Create a new Time object:  This calls a class!
            TimeEx tm = new TimeEx();
            // Print out the default time set in the class since no new time has been set yet:
            Console.WriteLine("\n\nTime:\nDefault seconds = {0}", tm.Seconds);
            // Set new value in the time object:
            tm.Seconds = 360;                                             // Set the seconds
            Console.WriteLine("360 seconds = {0} seconds", tm.Seconds);   // And then get it back and display it
            // get the minutes:
            Console.WriteLine("360 seconds = {0} minutes", tm.Minutes);

            // Create a new ScoreBB object:  This calls a class!
            ScoreBB runs = new ScoreBB();    // Create an instance variable!
            // Print out the default value set in the class since no new score has been set yet:
            Console.WriteLine("\n\nBaseball:\nDefault score = {0}", runs.Scorebb);
            // Set new score to 6 in the score object:
            runs.Scorebb = 6;
            Console.WriteLine("New score = {0}", runs.Scorebb);   // And then get it back and display it

            // Create a new ScoreFB object:  This calls a class!
            ScoreFB TD = new ScoreFB();    // Create an instance variable!
            // Print out the default value set in the class since no new score has been set yet:
            Console.WriteLine("\n\nFootball:\nDefault score = {0}", TD.Scorefb);
            // Set new score to 14 in the score object:
            TD.Scorefb = 14;
            Console.WriteLine("New score = {0}", TD.Scorefb);   // And then get it back and display it

            // Create a new ScoreHk object:  This calls a struct!
            ScoreHk goal = new ScoreHk();    // Create an instance variable!
            // Print out the default value set in the class since no new score has been set yet:
            Console.WriteLine("\n\nHockey:\nDefault score = {0}", goal.Scorehk);
            // Set new score to 14 in the score object:
            goal.Scorehk = 4;
            Console.WriteLine("New score = {0}", goal.Scorehk);   // And then get it back and display it

            // Derived classes and inheritance using Polygon and Square classes created below
            Polygon triangle = new Polygon(3);      // Create a triangle
            Square square = new Square(7.25f);      // can specify size in the declaration, cast the double to a float with 'f'
            // Print out the default value set in the class since no new score has been set yet:
            Console.WriteLine("\n\nTriangle:\nNumber of sides = {0}", triangle.NumberOfSides );
            Console.WriteLine("\n\nSquare:\nNumber of sides = {0}\n7.25 is size of each side = {1}", square.NumberOfSides, square.Size);
            // Set new size of Square:
            square.Size = 10.25f;
            Console.WriteLine("New square size 10.25 = {0}", square.Size );   // And then get it back and display it
            if (square is Polygon)  // Example of the "is" keyword
            {
                Console.WriteLine("\n\nDerived classes can be checked and cast with the \"is\" and \"as\" keywords." +
                                   "\nSee manual page 147 for more info if needed.");
            }
            if (square is object)  // Example of the "is" keyword
            {
                Console.WriteLine("\n\nIn C#, the \"object\" class is the base class for everything." +
                                   "\nAll other classes are derived from \"object\"." +
                                   "\nSee manual page 148 for more info if needed.");
            }

            // Polygon array class derived from base Polygon class
            Polygon[] TwoPolygons = new Polygon[2];
            TwoPolygons[0] = new Polygon(3);    // Create a new triangle in the array[0]
            TwoPolygons[1] = new Square(18.625f);  // Create a new square in the array[1] with size 3.5
            Console.WriteLine("\n\nTriangle in Array:\nNumber of sides = {0}", TwoPolygons[0].NumberOfSides );
            Console.WriteLine("\n\nSquare in Array:\nNumber of sides = {0}\n18.625 is size of each side = {1}", TwoPolygons[1].NumberOfSides, TwoPolygons[1].NumberOfSides );
            Console.WriteLine("Line above is wrong since the square size can't be obtained since." +
                              "\nthis instance varibale of a Square was derived from the Polygon class");

            Console.WriteLine();
            Library.ConsolePause();
        }

        private static void CodeSample15()  // Examine Interfaces.
        {
            Library.ReverseConsoleColors(case15);
                        
            TextFileWriter textfilewriter = new TextFileWriter();  // Create an instance of a class that uses an interface
            _ = textfilewriter.Extension;
            textfilewriter.Write("PracticeTxtFile");   // Write out the file

            IFileWriter[] filewriters = new IFileWriter[3];
            filewriters[0] = new TextFileWriter();
            filewriters[1] = new RtfFileWriter();
            filewriters[2] = new DocxFileWriter();
            filewriters[0].Write("TxtFile");
            filewriters[1].Write("RtfFile");
            filewriters[2].Write("DocxFile");


            Library.ConsolePause();
        }

        private static void CodeSample16()  // Examine .Net Generics: List, IEnumerable, and Dictionary.
        {
            Library.ReverseConsoleColors(case16);

            // Generics provide way to create type safe classes without need to commit to any particular type when you create the class.
            /*
            List listOfstrings = new List();  // This doesn't work since List is a generic class and needs to be told what type to use
            */

            List<string> listOfstrings = new List<string>();    // This works now since told generic List to us type <string> in list

            listOfstrings.Insert(0, "Hello ");              // Start new list with this at the beginning
            listOfstrings.Add("Fucking ");                  // Add this to the end of the list
            listOfstrings.Add("World!");                    // Then add this to the end of the List
            string item0 = listOfstrings.ElementAt(0);
            string item1 = listOfstrings.ElementAt(1);
            string item2 = listOfstrings.ElementAt(2);
            string item3 = "Mother ";                       // Initialize for later use
            int itemsInList = listOfstrings.Count();
            string wholeString = item0 + item1 + item2;     // One way to put the whole list of strings together
            Console.WriteLine( "\n\n{0}", wholeString );    //  Displays the whole list of strings
            Console.WriteLine( "Sentence has {3} words, \"{0}\", \"{1}\", \"{2}\"", item0, item1, item2, itemsInList );

            listOfstrings.Insert(1, item3);         // Insert "Mother " into the list
            item0 = listOfstrings.ElementAt(0);
            item1 = listOfstrings.ElementAt(1);
            item2 = listOfstrings.ElementAt(2);
            item3 = listOfstrings.ElementAt(3);
            itemsInList = listOfstrings.Count();
            wholeString = "";                       // Need to reset this before using again
            foreach( string all in listOfstrings )
            {
                wholeString += all;
            }
            Console.WriteLine("\n\n{0}", wholeString);  // displays whole string
            Console.WriteLine("Sentence has {4} words, \"{0}\", \"{1}\", \"{2}\", \"{3}\"", item0, item1, item2, item3, itemsInList );
            
            listOfstrings.RemoveAt(1);  // Remove "Mother " from the list
            item0 = listOfstrings.ElementAt(0);
            item1 = listOfstrings.ElementAt(1);
            item2 = listOfstrings.ElementAt(2);
            itemsInList = listOfstrings.Count();
            wholeString = "";                       // Need to reset this before using again
            foreach (string all in listOfstrings)
            {
                wholeString += all;
            }
            Console.WriteLine("\n\n{0}", wholeString);  // displays whole string
            Console.WriteLine("Sentence has {3} words, \"{0}\", \"{1}\", \"{2}\"", item0, item1, item2, itemsInList);

            // Now do same with generic List class using integers!

            List<int> listOfints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sumOfintList = listOfints.Sum();
            Console.WriteLine("\n\nSum of 1+2+3+4+5+6+7+8+9={0}.  Should equal 45", sumOfintList);

            listOfints.RemoveAt(5); // remove 6 from list, zero indexing
            Console.Write("\n\nSum of ");
            sumOfintList = listOfints.Sum();  // Double check!
            int newSum = 0;
            foreach( int all in listOfints)
            {
                newSum += all;
                Console.Write("{0}+", all);
            }
            Console.WriteLine( "\b={0}.  Should equal {1}", newSum, sumOfintList );      // Backspace char = \b to overwrite last '+'

            // new int list after above is 1, 2, 3, 4, 5, 7, 8, 9
            listOfints.RemoveAt(0);     // remove 1 from the list, zero indexing
            listOfints.Add(100);        // add 100 to the end of the list
                                        // New int list is 2, 3, 4, 5, 7, 8, 9, 100
            Console.Write("\n\nSum of ");
            sumOfintList = listOfints.Sum();  // Double check!
            newSum = 0;
            foreach (int all in listOfints)
            {
                newSum += all;
                Console.Write("{0}+", all);
            }
            Console.WriteLine("\b={0}.  Should equal {1}", newSum, sumOfintList);      // Backspace char = \b to overwrite last '+'

            int[] arrayInts = listOfints.ToArray();  // Copy the List of int's to an array: 2, 3, 4, 5, 7, 8, 9, 100
            Console.WriteLine( "Item at Array[1]={0} should equal 3 and item at Array[6]={1} should equal 9", arrayInts[1], arrayInts[6] );

            // Use primitive version of generic PList{} class below to build a list of ints

            PList<int> plistOfints = new PList<int>();      // Can't initial directly since IEnumerable is not implemented in Plist class
            plistOfints.Add(10);        // Can't initial directly since IEnumerable is not implemented in Plist class
            plistOfints.Add(20);        // So add values on at a time
            plistOfints.Add(30);
            plistOfints.Add(40);
            plistOfints.Add(50);
            plistOfints.Add(60);
            plistOfints.Add(70);
            plistOfints.Add(80);
            plistOfints.Add(90);
            int Length = 9;             // plistOfints.Length; <-- Doesn't work for some reason so manually set
            int sumOfintpList = 0;
            for(int i = 0; i < Length; i++)
                sumOfintpList += plistOfints.GetItem( i );   // Add them up!
            Console.WriteLine("\n\nSum of 10+20+30+40+50+60+70+80+90={0}.  Should equal 450", sumOfintpList);
            Console.Write("Sum of ");
            newSum = 0;
            for( int i = 0; i < Length; i++)
            {
                newSum += plistOfints.GetItem(i);
                Console.Write("{0}+", plistOfints.GetItem(i));
            }
            Console.WriteLine("\b={0}.  Should equal {1}", newSum, sumOfintpList);      // Backspace char = \b to overwrite last '+'


            // IEnumerable interface: Count off each item in a collectrion one by one.  See p.166 but book doesn't explain much yet.
            // I don't understand this other than it is a generic.  Seems to work differently from List() above.

            // Generic declaration used on List() above.
            // List<string> strings = new List<string>();    // This works now since told generic List to us type <string> in list

            _ = new int[] { 1, 2, 3 };   // This works but not same generic format as above

            Dictionary<string, int> phoneBook = new Dictionary<string, int>
            {
                // The Dictionary class uses indexing operators '[' and ']' to get ot set values.  This is odd????
                ["Paul Ghilino"] = 5589844,
                ["Zach Ghilino"] = 5589410
            };
            _ = phoneBook["Paul Ghilino"];

            Console.WriteLine();
            Library.ConsolePause();
        }

        private static void CodeSample17()  // Examine Instant Write/Read of Text Files and Initializing Arrays of Class Types.
        {
            Library.ReverseConsoleColors(case17);

            string   pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); // Get current user Desktop directory path
            string pathNameExt;           // Full path to file including name and file extension
            string stringToWrite;         // string to write to a file
            string[] stringToWriteArray;    // Array of strings to write to a file
            string stringToRead;          // String to read from a file
            string[] stringToReadArray;     // Array of strings to read from a file

            pathNameExt = Library.FileNameBuild(pathDesktop, "Hello_Beautiful_World", "txt");
            stringToWrite = "Hello Beautiful World!";
            Console.WriteLine("\n\nWrote \"" + stringToWrite + "\" to file " + pathNameExt);
            File.WriteAllText(pathNameExt, stringToWrite);    // If existing file exists, this will overwrite it without warning

            stringToWriteArray = new string[] { "Hello", "Really", "Beautiful", "World!" };
            pathNameExt = Library.FileNameBuild(pathDesktop, "Hello_Really_Beautiful_World", "txt");
            Console.WriteLine("\n\nWrote following list to file " + pathNameExt);
            foreach (string item in stringToWriteArray)
                Console.WriteLine(item);
            // WriteAllLines place a "\n" at end of each array item in the file
            File.WriteAllLines(pathNameExt, stringToWriteArray);    // If existing file exists, this will overwrite it without warning

            // This example will not overwite an existing file & will add content to it.
            pathNameExt = Library.FileNameBuild(pathDesktop, "MyTest01", "txt");
            // This text is added only once to the file.
            if (!File.Exists(pathNameExt))         // Check if file already exists!  If not, create new one!
            {
                // Create a file to write to.                                       // Don't want to get into this stuff now.  See links!
                stringToWrite = "Begin MyTest01:" + Environment.NewLine;            // https://msdn.microsoft.com/en-us/library/system.environment.newline(v=vs.110).aspx
                File.WriteAllText(pathNameExt, stringToWrite, Encoding.UTF8);       // https://msdn.microsoft.com/en-us/library/system.text.encoding(v=vs.110).aspx
            }
            // This text is always added, making the file longer over time, if the files isn't deleted first
            stringToWrite = "This text is added to file each time it is opened." + Environment.NewLine;
            File.AppendAllText(pathNameExt, stringToWrite, Encoding.UTF8);
            // Open the file and save it to a string
            stringToRead = File.ReadAllText(pathNameExt);   // Open the file and read it into one long string, LF's and all!
            Console.WriteLine($"\n\nRead file {pathNameExt} into a string via ReadAllText method:");
            Console.Write(stringToRead);
            //
            // Alternate way to open the file and save it to an array of strings separated by LF's
            stringToReadArray = File.ReadAllLines(pathNameExt);
            Console.WriteLine($"\n\nRead file {pathNameExt} into an array of strings via ReadAllLines method:");
            foreach (string member in stringToReadArray)
                Console.WriteLine(member);
            //
            // Create some CSV files using and initializing arrays of HighScore class
            HighScore[] hS1 = new HighScore[6];
            // Initialize the array.  Each item is "new"
            hS1[0] = new HighScore("Paul", 9600);
            hS1[1] = new HighScore("Zach", 8950);
            hS1[2] = new HighScore("Beth", 7620);
            hS1[3] = new HighScore("John", 6800);
            hS1[4] = new HighScore("Dave", 6650);
            hS1[5] = new HighScore("Cody", 5970);
            //
            HighScore[] hS2 = new HighScore[]   // Alternative way to initalize array of a class but need a constuctor
            {                                   // method to enter the values like this
                new HighScore( "Mike", 5825 ),
                new HighScore( "Pete", 4960 ),
                new HighScore( "Luke", 4925 ),
                new HighScore( "Gina", 4630 ),
                new HighScore( "Rick", 3940 ),
                new HighScore( "Fran", 3630 )    // no comma at end
            };
            //
            var hS3 = new HighScore[6];     // Alternative way to create new instance is use "var" keyword, https://msdn.microsoft.com/en-us/library/bb383973.aspx
            // Initialize the array.  Each item is "new"
            hS3[0] = new HighScore("Paul", 9600);
            hS3[1] = new HighScore("Zach", 8950);
            hS3[2] = new HighScore("Beth", 7620);
            hS3[3] = new HighScore("John", 6800);
            hS3[4] = new HighScore("Dave", 6650);
            hS3[5] = new HighScore("Cody", 5970);
            //
            HighScore2[] highScore = new HighScore2[2];  // This method doesn't use a constructor method to set values.
            // Initialize the array.                     // If constructor method is present, then this will not work and
            highScore[0] = new HighScore2() {Name = "Paul", Score = 2000};  // Use constructor method similar to above examples;
            highScore[1] = new HighScore2() {Name = "Zach", Score = 1500};
            Console.WriteLine("\n\nAlternate way to initialize array of a class type with get/set.");
            foreach (HighScore2 member in highScore)
                Console.WriteLine($"{member.Name}, {member.Score}");
            //
            _ = hS2[3].Score.ToString();     // Example of way to convert a number to a string
            //
            stringToWrite = "";     // Reset to empty 
            pathNameExt = Library.FileNameBuild(pathDesktop, "HighScore1", "cvs");
            for (int i = 0; i < hS1.Length; i++)
            {
                stringToWrite += $"{hS1[i].Name},{hS1[i].Score}" + Environment.NewLine;  // String interpolation, smart enough to conver an in to a string for me
            }   
            Library.WriteStringToFile( pathNameExt, stringToWrite );
            stringToRead = Library.ReadFileToString( pathNameExt );
            Console.WriteLine($"\n\nRead file {pathNameExt} into a string via ReadAllText method:");
            Console.Write(stringToRead);
            //
            // Better way to do this is use foreach loop vs. for loop
            //
            stringToWrite = "";     // Reset to empty 
            pathNameExt = Library.FileNameBuild(pathDesktop, "HighScore2", "cvs");
            foreach (HighScore member in hS2)
            {
                stringToWrite += $"{ member.Name},{member.Score}\r\n";  // "\n" by itself doesn't seem to appear in written file but is there
            }
            Library.WriteStringToFile( pathNameExt, stringToWrite );
            stringToRead = Library.ReadFileToString( pathNameExt );
            Console.WriteLine($"\n\nRead file {pathNameExt} into a string via ReadAllText method");
            Console.Write(stringToRead);
            //
            // Read file just created and parse it back into a new HighScore[]
            //
            stringToReadArray = Library.ReadFileToStringArray( pathNameExt );
            Console.WriteLine("\n\nRead file {0} into an array of strings.  This is output:", pathNameExt );  // no $ before string if formating!
            foreach (string member in stringToReadArray)
                Console.WriteLine( member );
            //
            _ = new HighScore[stringToReadArray.Length];
            _ = LoadHighScores(stringToReadArray);    // Call method below!!!
            Console.WriteLine("\n\nAbove array of strings has been parsed back into an array of HighScore");
            Console.WriteLine("via method LoadHighScores.  Output here should match output directly above.");
            foreach (string member in stringToReadArray)
                Console.WriteLine(member);
            
            Console.WriteLine();  //LF
            Library.ConsolePause();
        }

        private static void CodeSample18()  // Examine Environment Folders and Streaming Write/Read of Text and Binary Files.
        {
            Library.ReverseConsoleColors(case18);
            
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); // Get current user Desktop directory path
            string pathNameExt;            // Full path to file including name and file extension
            string stringToRead1;          // String to read from a file
            string stringToRead2;          // String to read from a file
            char nChar1, nChar2;
            char[] buf;

            // This is some real handy stuff I stumbled on!
            // https://msdn.microsoft.com/en-us/library/system.environment.specialfolder.aspx?f=255&MSPPError=-2147217396
            //
            stringToRead1 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            stringToRead2 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Console.WriteLine("\n\nC# Environment SpecialFolder Enumerations:");
            Console.WriteLine("UserProfile=" + stringToRead1);
            Console.WriteLine("DesktopDirectory=" + stringToRead2);

            // Write & Read a text file piece-by-piece
            //
            pathNameExt = Library.FileNameBuild(pathDesktop, "Hello_There", "txt");
            Console.WriteLine("\n\nWrite text file piece-by-piece:\nWrite \"Hello There!\" to file " + pathNameExt);
            FileStream fileStream = File.OpenWrite(pathNameExt);
            StreamWriter sWriter = new StreamWriter(fileStream);
            sWriter.Write("Hello");
            sWriter.Write(" ");
            sWriter.Write("There!");
            sWriter.Close();         // close the file
            // Read the text file piece by piece
            fileStream = File.OpenRead(pathNameExt);
            StreamReader sReader = new StreamReader(fileStream);
            // Read a single character at a time
            nChar1 = (char)sReader.Read();           // Read() returns int so need to cast to (char) or end up with a number
            nChar2 = (char)sReader.Read();
            // Read mutiple characters at a time
            buf = new char[3];
            sReader.Read(buf, 0, 3);
            // Read a full line at a time
            stringToRead1 = sReader.ReadLine();
            sReader.Close();         // close the file
            Console.WriteLine("\nNow reading text file back piece-by-piece:");
            Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}", nChar1, nChar2, buf[0], buf[1], buf[2], stringToRead1);

            // Write & Read a binary file piece-by-piece
            //
            pathNameExt = Library.FileNameBuild(pathDesktop, "This_is_a_binary_file", "dat");
            Console.WriteLine("\n\nWrite binary file piece-by-piece:\nWrite \"This is a binary file!\" to file " + pathNameExt);
            fileStream = File.OpenWrite(pathNameExt);   // not very good -> See procedure below with "using" keywords!!!
            BinaryWriter bWriter = new BinaryWriter(fileStream);
            bWriter.Write("This is a ");
            bWriter.Write("binary file!");
            bWriter.Close();         // close the file
            // Read the binary file
            fileStream = File.OpenRead(pathNameExt);
            BinaryReader bReader = new BinaryReader(fileStream);
            stringToRead1 = bReader.ReadString();       // Apparently same number of reads are required as writes
            stringToRead2 = bReader.ReadString();
            bReader.Close();         // close the file
            Console.WriteLine("\nNow reading binary file back piece-by-piece:");
            Console.WriteLine( stringToRead1 + stringToRead2 );

            // Better method to work with binary files.  The keyword "using" closes file and cleans up afterwards nicely using IDisposable
            // Keyword "using": https://msdn.microsoft.com/en-us/library/yh598w02.aspx
            // When compiler sees keyword "using" it internally sets up try/finnally block and does cleanup automatically for you.
            // No need to close the file since "using" takes care of all that for you.
            //
            pathNameExt = Library.FileNameBuild(pathDesktop, "BinaryTest01", "dat");
            Console.WriteLine("\n\nWrite items to file {0}", pathNameExt);
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathNameExt, FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write(@"C:\Temp");
                writer.Write(10);
                writer.Write(true);
                //writer.Write("Check overwrite behavior.");
            }

            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;
            //string overwrite;

            if (File.Exists(pathNameExt))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(pathNameExt, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                    //overwrite = reader.ReadString();
                }
                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
                //Console.WriteLine("Overwrite: " + overwrite);
            }

            Console.WriteLine();
            Library.ConsolePause();
        }

        private static void CodeSample19()  // Examine Delegates.  Create delgates and use built-in delegates Func and Action.
        {
            Library.ReverseConsoleColors(case19);

            /*
            A delegate is essentially a way to treat a method like an object allowing you to store it in a variable,
            pass it as a parameter, or return it from another method.  See Chapter 30 on p.199.
            Delegates are normally set up in their own file and namespace.  But here, I am just going to create a new namespace.
            Create a MathDelegate which can be used to keep track of any method that can take two int's as input and 
            return an int.
            */

            int a, b, result;

            DelegateExp1.MathDelegate mathOp;    // Setup the Delegate and use it mutiple times.  Pretty cool stuff!
            
            Console.Write("\n\nEnter first integer: ");
            a=Library.ReadLineInteger();
            Console.Write("Enter second integer: ");
            b = Library.ReadLineInteger();
            //
            mathOp = Add;               // Use the Add method below as the variable in this case
            result = mathOp(a, b);
            Console.WriteLine("\n\nMathDelegate delegate example MathOp: Result of Delegate Add method: {0}+{1}={2}", a, b, result);
            //
            mathOp = Subtract;          // Use the Subtract method below as the variable in this case
            result = mathOp(a, b);
            Console.WriteLine("\n\nMathDelegate delegate example MathOp: Result of Delegate Subtract method: {0}-{1}={2}", a, b, result);
            //
            mathOp = Power;             // Use the Power method below as the variable in this case
            result = mathOp(a, b);
            Console.WriteLine("\n\nMathDelegate delegate example MathOp: Result of Delegate Power method: {0}exp{1}={2}", a, b, result);
            
            // Delegates can be combined or subtracted as demonstrated below
            //
            DelegateExp2.LogEventHandler logData;   // Setup the Delegate and use it mutiple times.  Pretty cool stuff!
            logData = LogToConsole;
            Console.WriteLine("\n\nLogEventHandler delegate example LogData: Output to Console only.");
            logData(new DelegateExp2.LogEvent("\"To boldly go where no man has gone before.\""));  // Adding the "new" keyword is the essential key!!!!
            //
            logData += LogToFile;       // By using += you can add a delegate method to another.  Output goes to both methods now
            Console.WriteLine("\n\nLogEventHandler delegate example LogData: Output to Console and file now.");
            logData(new DelegateExp2.LogEvent("\"Beam me up, Scotty.\""));  // Adding the "new" keyword is the essential key!!!!
            //
            logData -= LogToFile;       // By using -= you can delete a previously added delegate method.  Output goes to only console now
            Console.WriteLine("\n\nLogEventHandler delegate example LogData: Output back to Console now.");
            logData(new DelegateExp2.LogEvent("\"Make it so!\""));  // Adding the "new" keyword is the essential key since new instance!
            // return value in this example is void.  But if methods were returning values, only last method called would retun a value.

            /*
            C# has generic built-in delegates so usually no need to create your own.  Exception is if you need a class in the Delegate,
            see DelegateExp2 below.  "Action" has void return values.  "Func" has return values.
            So do all of the above again using built-in generic delegates "Action" and "Func".
            */

            // Example using generic Func delegate, which returns a value, int in this case.
            Console.Write("\n\nEnter first integer: ");
            a = Library.ReadLineInteger();
            Console.Write("Enter second integer: ");
            b = Library.ReadLineInteger();
            //
            Func<int, int, int> mathOp2;        // Last declaration in Func is return type.  Very Simple!!!!!!
            //            
            mathOp2 = Add;
            result = mathOp2(a, b);
            Console.WriteLine("\n\nFunc delegate example MathOp2: Result of Delegate Add method: {0}+{1}={2}", a, b, result);
            //
            mathOp2 = Subtract;          // Use the Subtract method below as the variable in this case
            result = mathOp2(a, b);
            Console.WriteLine("\n\nFunc delegate example MathOp2: Result of Delegate Subtract method: {0}-{1}={2}", a, b, result);
            //
            mathOp2 = Power;             // Use the Power method below as the variable in this case
            result = mathOp2(a, b);
            Console.WriteLine("\n\nFunc delegate example MathOp2: Result of Delegate Power method: {0}exp{1}={2}", a, b, result);




            // Delegates can be combined or subtracted as demonstrated below
            // Example using generic Action delegate, which does not return a value.  This delegate uses class LogEvent below.
            Action<DelegateExp2.LogEvent> logData2;     // Setup the Delegate and use it mutiple times.  Pretty cool stuff!
                                                        // This uses class created in previous example
            logData2 = LogToConsole;
            Console.WriteLine("\n\nAction delegate example LogData2: Output to Console only.");
            logData2(new DelegateExp2.LogEvent("\"To boldly go where no man has gone before.\""));  // Adding the "new" keyword is the essential key!!!!
            //
            logData2 += LogToFile;       // By using += you can add a delegate method to another.  Output goes to both methods now
            Console.WriteLine("\n\nAction delegate example LogData2: Output to Console and file now.");
            logData2(new DelegateExp2.LogEvent("\"Beam me up, Scotty.\""));  // Adding the "new" keyword is the essential key!!!!
            //
            logData2 -= LogToFile;       // By using -= you can delete a previously added delegate method.  Output goes to only console now
            Console.WriteLine("\n\nAction delegate example LogData2: Output back to Console now.");
            logData2(new DelegateExp2.LogEvent("\"Make it so!\""));  // Adding the "new" keyword is the essential key since new instance!
            // return value in this example is void.  But if methods were returning values, only last method called would retun a value.



            Console.WriteLine();
            Library.ConsolePause();
        }

        private static void CodeSample20()  // Examine Events.
        {
            Library.ReverseConsoleColors(case20);

            /*
            Events:  See Chapter 31 in book on p206.  Events are way for one section of code to notify other sections that
            something has happend.  Events rely on delegates to do their work.  Attach and remove methods to events with
            the '+=' and '-=' operators as done in Code Sample 19 above.  Code to raise an event can go anywhere but usually
            best to place it in it's own method.  Typically best practice is to add "On" to the name of the event for the
            method name.  In this case "OnPointChanged" for event "PointChanged" setup below in Events namespace.
            You can attach as many handlers to an event as you want and they all will be called unless one throws an exception, 
            in which case none ot the following handlers will be called.
            
            Events (C# Programming Guide): https://msdn.microsoft.com/en-us/library/awbftdfh.aspx
            Handle and raise events: https://msdn.microsoft.com/en-us/library/edzehd2t.aspx
            Event Tutorial: https://msdn.microsoft.com/en-us/library/aa645739%28v=vs.71%29.aspx?f=255&MSPPError=-

            */
            // Step #1: Define the event.  See notes above this namespace for additional details (See in Events class below).
            // Step #2: Create method  raise the event.  This is considered the "Sender" (See in Events class below).
            // Step #3: Locate and create calls to the method that will raise the event (See in Events class below).
            // Step #4: Create one or more event handlers to accomplish needed task once the event is raised (see at bottom of this class).

            // Step #5: Attach one or more event handlers to the event.
            Events.Point point = new Events.Point();        // Create new instance to Point class below
            point.PointChanged += HandlePointChanged01;     // Attach handler to event
            Console.WriteLine("\n\nFirst Example:");
            Console.WriteLine("\nAdded handler HandlePointChanged01 to event PointChanged.");

            // Step #6: Change value of X or Y in Point class below to set everything in motion.
            Console.Write("Enter Point value X to trigger event PointChanged: ");
            double pValue = Library.ReadLineDouble();
            point.X = pValue;

            point.PointChanged += HandlePointChanged02;     // Attach another handler to event
            Console.WriteLine("\n\nAdded handler HandlePointChanged02 to event PointChanged.");
            Console.Write("Enter Point value Y to trigger event PointChanged: ");
            pValue = Library.ReadLineDouble();
            point.Y = pValue;

            point.PointChanged -= HandlePointChanged01;     // Remove handler from event
            Console.WriteLine("\n\nRemoved handler HandlePointChanged01 from event PointChanged.");
            Console.Write("Enter Point value X to trigger event PointChanged: ");
            pValue = Library.ReadLineDouble();
            point.X = pValue;
            
            Console.WriteLine();  //LF
            Library.ConsolePause();
        }

        private static void CodeSample21()  // Examine Operator Overloading.
        {
            Library.ReverseConsoleColors(case21);

            /*
            Operator Overloading:  See Chapter 32, P.214.  Have experienced and used operator overloading when dealing with strings
            using various methods to build the strings.  All Operators must be public and static.  Use keyword "operator" when
            overloading.

            */

            Vector a = new Vector(5,2);  // Create new instance Vector 'a'
            Vector b = new Vector(-3, 4);  // Create new instance Vector 'b'
            _ = a + b;





            Library.ConsolePause();
        }

        private static void CodeSample22()  // Examine Classes and Properties again.
        {
            Library.ReverseConsoleColors(case22);
            
            string bookText1 = "This is the text of my new book on how to learn C# programming.";  // 14 words
            string bookText2 = "This is the text of my new book on how to learn advanced C# programming.";  // 15 words
            int newPubYear1;
            int newPubYear2;

            Pract01 pInstance1 = new Pract01("MyBook1", "Me1", 2, 10);  // to use constructors to inialize instance vaules place terms in the () versus outside in {}
            Pract01 pInstance2 = new Pract01("MyBook2", "Me2", 3, 12);

            Console.WriteLine("\n\nInitialized values of pInstance1: Title={0}, Author={1}, Pages={2}, Word Count={3}",
                                pInstance1.GetTitle(), pInstance1.GetAuthor(), pInstance1.GetPages(), pInstance1.GetWordCount());

            Console.WriteLine("Initialized values of pInstance2: Title={0}, Author={1}, Pages={2}, Word Count={3}",
                                pInstance2.GetTitle(), pInstance2.GetAuthor(), pInstance2.GetPages(), pInstance2.GetWordCount());
            
            pInstance1.SetPublisher("MyPublisher");  // This is a private static variable so initialized via method and should be same across both intances

            Console.WriteLine("\n\nSet Private Static variable Publisher:  Following results should be the same.\npInstance1={0}\npInstance2={1}",
                                pInstance1.GetPublisher(), pInstance2.GetPublisher() );

            // Pract01.pubYear is a public static variable and is only accessible via the base class versus an instance of it.  Apparently an
            // instance of the base class can not call static directly via pInstance1.pubDate.  Good to know!  But an instance should be able to
            // use it for various calculations inthernally.
            // pInstance1.pubDate = pubYear; results in an error!
            Pract01.pubYear = 2010;
            Console.WriteLine($"\n\nSet public static pubYear to {Pract01.pubYear}");

            newPubYear1 = pInstance1.NewPublishDate(2);  // 2010+2=2012
            newPubYear2 = pInstance2.NewPublishDate(4);  // 2010+4=2014
            Console.WriteLine($"Added 2 to pInstance1, newPubYear1={newPubYear1}, Added 4 to pInstance2, newPubYear2={newPubYear2}");

            pInstance1.CalcWordCount(bookText1);   // Calcualte new wordCount based on text string bookText1 and bookText2 above 
            Console.WriteLine("Word count of \"{0}\"={1}", bookText1, pInstance1.GetWordCount());     // GetWordCount is a method so need to use ()

            pInstance2.CalcWordCount(bookText2);
            Console.WriteLine("Word count of \"{0}\"={1}", bookText2, pInstance2.GetWordCount());



            Pract02 vector2 = new Pract02(13.0, 23.0)
            {
                Score = 1250       // Set via settter
            };
            Console.WriteLine($"\n\nShould be 1250.  Instance vector2.Score={vector2.Score}");
            vector2.SetScore(1500);     // Set via method
            Console.WriteLine($"Should be 1500.  Instance vector2.GetScore()={vector2.GetScore()}");
            vector2.Seconds = 360;
            Console.WriteLine($"Should be 360.   Instance vector2.Seconds={vector2.Seconds}");
            Console.WriteLine($"Should be 6.     Instance vector2.Minutes={vector2.Minutes}");
            //vector2.Seconds2 = 180;           // This doesn't work since setter is private!!!
            _ = vector2.Seconds2;     // This works since getter is public
            Console.WriteLine($"Should be 13,23. Instance vector2.X={vector2.X}, vector2.Y={vector2.Y}");
            
            Console.WriteLine(); // LF
            Library.ConsolePause();
        }

        private static void CodeSample23()  // Code Sample 23 (don't use before copying).
        {
            Library.ReverseConsoleColors(case23);
            Library.ConsolePause();
        }


        // Specific methods used in this class follow

        private static uint Factorial(uint num)    // Method called from recursion Code Sample 13 above
        {
            // Can't check for overflow since using recursion, num > 12 causes uint overflow

            if (num == 1)   // Need to set a way to exit or we go on forever
                return num;
            num *= Factorial(num - 1);     // Method calls itself, hence recursion happens
            Console.WriteLine($"{num,16:N0}");     // Right align number with no decimal in 16 digit field
            return num;
        }

        private static uint Fibonacci(uint seq)    // Method called from recursion Code Sample 13 above
        {
            uint v1 = 1; uint v2 = 1;
            uint sum = 0;
            Console.WriteLine("\n              V1              V2             Sum\n");
            for (int i = 0; i < seq; i++)   // For loops use semicolons versus commas.
            {
                uint v3 = v1 + v2;
                sum += v3;
                Console.WriteLine($"  {v1,14:N0}  {v2,14:N0}  {sum,14:N0}");   // Right align number with no decimal in 10 digit field
                v1 = v2;
                v2 = v3;
            }
            return sum;
        }

        /// <summary>
        /// Parse an array of strings back into an array of class HighScore
        /// </summary>
        /// <param name="arrayOfStrings">An array of CSV strings</param>
        /// <returns>Pointer to newly constucted array of class HighScore</returns>
        private static HighScore[] LoadHighScores( string[] arrayOfStrings )   // Method called from Code Sample 17 above
        {
            string[] member;
            string name;
            int score;
            HighScore[] highS1 = new HighScore[arrayOfStrings.Length];     // Constructor method sets both values at once, Name & Score
            HighScore2[] highS2 = new HighScore2[arrayOfStrings.Length];   // Alternate (not used): Uses get/set to set Name & Score

            for ( int i = 0; i < arrayOfStrings.Length; i++)
            {
                member = arrayOfStrings[i].Split(',');      // Example of "Split" method to break up strings
                name = member[0];
                score = Convert.ToInt32( member[1] );       // Way to convert a string to a int
                // Two methods follow to acomplish same thing.  Syntax is different if constructor to set both values at once is present
                highS1[i] = new HighScore( name, score );                  // Constructor method sets both values at once, Name & Score
                highS2[i] = new HighScore2() { Name=name, Score=score };   // Alternate (not used): Uses get/set to set Name & Score
            }
            return highS1;  // Return pointer to outside instance of HighScore so it now points to this instance.
                            // HighScore2 not returned and only used to show alternate method to intialize using get/set vs. constructor method
        }


        private static int Add(int a, int b)     // Delegate method used in Code Sample 19 above
        {
            return a + b;
        }

        private static int Subtract(int a, int b)     // Delegate method used in Code Sample 19 above
        {
            return a - b;
        }

        private static int Power(int baseNumber, int exponent)     // Delegate method used in Code Sample 19 above
        {
            return (int)Math.Pow(baseNumber, exponent);
        }

        private static void LogToConsole(DelegateExp2.LogEvent logEvent)    // Delegate method used in Code Sample 19 above
        {
            Console.WriteLine("Inside of the LogToConsole method.  Log message= " + logEvent.LogMsg);
        }

        private static void LogToFile(DelegateExp2.LogEvent logEvent)    // Delegate method used in Code Sample 19 above
        {

            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); // Get current user Desktop directory path
            _ = Library.FileNameBuild(pathDesktop, "LogEvent", "txt");
            /*
            File.AppendAllText(pathNameExt, logEvent.Text + "\n");
            */
            Console.WriteLine("Inside of the LogToFile method.     Log message= " + logEvent.LogMsg);
            Console.WriteLine("Normally this method would write to file but skipping that effort here.");
        }

        private static void HandlePointChanged01(object sender, EventArgs eventArgs)    // This is event handler used in Code Sample 20 above
        {
            // Step #4: Create one or more event handlers to accomplish needed task once the event is raised.
            Console.WriteLine("Inside HandlePointChanged01 method: The point has changed!");
        }

        private static void HandlePointChanged02(object sender, EventArgs eventArgs)    // This is event handler used in Code Sample 20 above
        {
            // Step #4: Create one or more event handlers to accomplish needed task once the event is raised.
            Console.WriteLine("Inside HandlePointChanged02 method: The point has changed!");
        }
        

    }   // End of class=Program

    /*
    Class vs. Struct: Classes are reference types and Structs are value types.  Classes use reference semantics.
    Structs use value semantics.  In fact, all the primitive types are created from Structs.  Classes can be assigned "null"
    but structs can't.  In practice, classes are far more common.  Structs can't be derived so don't support inheritance (p.141).
    Derived classes inherit all variables, properties, and methods from base class; but constructors are not inherited.
    To use a different constructor in a derived class, use the "base" keyword (see p.148).  
    See Chapter 22 (p.151) for advanced Class topics of Polymorphism, Veirtual Methods, and Abstract Classes via keywords "virtual",
    override", "abstract", "new", and "base".
    */

    // Class example of Prperty #1.    Used in Code Sample 14 above.
    internal class Person
    {
        private string myName = "N/A";  // Default values.  Since "private" only can use in this class.
        private int myAge = 0;          // Since not "static" doesn't apply to all instances

        // Declare a Name property of type string:
        public string Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        // Declare an Age property of type int:
        public int Age
        {
            get
            {
                return myAge;
            }
            set
            {
                myAge = value;
            }
        }

        // This is a constructor.  if you reference "person" you will get the following string back.
        // Constructors are like methods but don't have a name since they use the class name.
        // If you do not set any new values you will get the defaults above back.
        // Note: You can set new values and also recall them since there is a "get".

        public override string ToString()
        {
            return "Name = " + Name + ",\tAge = " + Age;
        }
    }

    /// <summary>
    /// Save and recall seconds.  Also convert to Minute but truncations happens
    /// </summary>
    public class TimeEx  // Class example of Property #2.  Used in Code Sample 14 above.
    {
        // A Property can't list parameters.  The "value" keyword is default and takes on same type as the Property that is being set too.
        // Lower case for instance variables and upper case for matching property are very common and good practice.

        private int seconds = 0;
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;    // "value" keyword takes on same type as the Property that is being set.
            }
        }

        public int Minutes
        {
            get
            {
                return seconds / 60;    // Does this need to be float since truncating/rounding will occur????
            }
        }
    }

    // Class example of Property #3.  Score Baseball. Used in Code Sample 14 above.
    class ScoreBB
    {
        private int score = 0;
        public int Scorebb
        {
            get
            {
                return score;
            }
            set
            {
                score = value;     // "value" keyword takes on same type as the Property that is being set.
            }
        }
    }

    // Class example of Property #4.  Score Football; Used in Code Sample 14 above.  This is shorthand for the ScoreBB code above.  
    class ScoreFB
    {
        public int Scorefb { get; set; }
    }

    // Struct example of Property #5.  Score Hockey; Used in Code Sample 14 above.  This is shorthand method.  
    struct ScoreHk
    {
        public int Scorehk { get; set; }
    }

    /* Structs can not be derived from another Struct.  Thus do not support inheritance.
    struct ScoreBk : ScoreHk    // Try to derive a Struct and you get a compiler error.
    {
        public int Scorebk { get; set; }
    }  */

    class Polygon   // Class example showing inheritance #1
    {
        // This will be used as a base class to build specific shapes

        public int NumberOfSides { get; set; }  // Shorthand declaration.  Needs to be Public to be accessed externally
        public Polygon()    // Constructors have exact same name as the class they are in.  Constructors can not return values.
        {
            NumberOfSides = 0;
        }
        public Polygon(int numberOfSides)
        {
            NumberOfSides = numberOfSides;  // Note capital 'N' which references variable outside of constructor
        }
    }

    class Square : Polygon  // This class is derived from the Polygon class above and inherits the properties of the Polygon class
    {
        public float Size { get; set; } // Size of square
        public Square( float size ) : base( 4 )
        // Keyword "base" forces this derived class to use Polygon(int numberOfSides) constructor in base class
        {
            Size = size;
            // NumberOfSides = 4;  // No longer needed since used "base" keyword above
        }
    }

    public class HighScore // Used in Code Sample 17 above
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public HighScore( string name, int score)   // Constructor method to enter mutiple values at once
        {                                           // This is best way to initialize values
            Name = name;
            Score = score;
        }
    }

    public class HighScore2 // Used in Code Sample 17 above
    {
        public string Name { get; set; } 
        public int Score { get; set; }
        // If the following constructor is set up, then the get/set initialization used in Code Sample 17 above won't work
        //public HighScore2(string name, int score)   // Constructor method to enter mutiple values at once
        //{
        //    Name = name;
        //    Score = score;
        //}
    }
        

    /*
    Examine Interfaces (p.158).  Example: Want to use same calling code to write out files in many different formats.
    Don't need to know what happens inside Interface and contents inside can change over time without any modification to calling code.
    All members in are "public" and "virtual" by default and cannot be changed into anything else.
    Common practice is to name all interfaces starting with a capital 'I' to denote it as an interface.
    A class that calls an interface must implement everything in the interface, "Extension" variable and "Write()" method in IFileWriter
    case below.  The class can do more but needs to implement the minimum members specified in the interface.  C# doesn't allow you to
    derive/inherit from more than one class, but you can implement more than one interface in a class.  You just need to implement all
    of the minimums from each interface.  See bottom of p.159 how to derive a class that implements more than one interface.
    */

    public interface IFileWriter
    {
        string Extension { get; }       // Calling classes will need to implement this
        void Write(string filename);    // Calling classes will need to implement this
    }

    public class TextFileWriter : IFileWriter   // Note this class is derived from interface above
    {
        public string Extension { get { return ".txt"; } }
        public void Write(string filename)
        {
            // Do the actual file writing here....
            Console.WriteLine("\nInside Class TextFileWriter, method Write():" +
                              "\nWrite out .txt file here:  Filename={0}{1}", filename, Extension );
        }
    }

    public class RtfFileWriter : IFileWriter   // Note this class is derived from interface above
    {
        public string Extension { get { return ".rtf"; } }
        public void Write(string filename)
        {
            // Do the actual file writing here....
            Console.WriteLine("\nInside Class RtfFileWriter, method Write():" +
                              "\nWrite out .rtf file here:  Filename={0}{1}", filename, Extension);
        }
    }

    public class DocxFileWriter : IFileWriter   // Note this class is derived from interface above
    {
        public string Extension { get { return ".docx"; } }
        public void Write(string filename)
        {
            // Do the actual file writing here....
            Console.WriteLine("\nInside Class DocxFileWriter, method Write():" +
                              "\nWrite out .docx file here:  Filename={0}{1}", filename, Extension);
        }
    }

    /*
    Create a generic class similar to the .Net List class, PracticeList is abreviated to PList{} .  It is common practice to use single capital
    letter for generic type parameters, 'T' and 'K' and 'V' are very common.  Use angle brackets < T >, or for two generic variables
    use < K, V >.  This is a constraint on type of generics that can be used for this class: "where T : IComparable", see P.171 for much more
    regarding constraints, or using mutiple constraints.  Can also make generic methods (p.172).  The generic methods can be part of any class
    or struct, generic or otherwise.  Like with generic classes you can use as many generic parameters and constraints as you want.  From what I
    can determine, you cannot do any math inside generics without compiler error!
    */

    // This generic class is used in Code Sample 16 above
    public class PList< T > where T : IComparable   // Generic 'T' must now use the IComparable interface
    {
        private T[] items;  // T=generic type array since we are creating a List class.
        public PList()      // Constructor to set up array to have 0 items at start
        {
            items = Array.Empty<T>();
        }
        public T GetItem( int index )   // Method that returns a particular generic item from the PList.
        {
            return items[index];
        }
        public void Add( T newItem )    // Method that adds another generic item to the end of the Plist
        {
            T[] newItems = new T[items.Length + 1];     // Arrays can't grow in size so need to copy Plist to new array 1 spot larger

            for (int index = 0; index < items.Length; index++)
                newItems[index] = items[index];         // Copy the current generic atems to the new array

            newItems[newItems.Length - 1] = newItem;
            items = newItems;   // copy the instance pointer of the new arrary to the old array
        }
        //public int Length()     // Not working for some reason!!!!!!!
        //{
        //    return count;
        //}
    }

        
    // Setting up my personal Library of methods to use.  Declaring this class as "internal" means it can only be used in
    // this project or assembly even if it's methods in it are declared "public".

    internal class Library
    {
        /// <summary>
        /// Gets a valid user entered integer from Console between min and max parameters.
        /// </summary>
        /// <param name="min">Minumum integer.</param>
        /// <param name="max">Maximum integer.</param>
        /// <returns>Returns valid integer between min and max parameters.</returns>
        public static int ReadLineIntegerMinMax(int min, int max)
        {
            int isInt;
            while (true)
            {
                isInt = ReadLineInteger();   // Get the integer from the console
                if (isInt >= min && isInt <= max)
                    break;    // Good number so end the loop
                else
                {
                    Console.Beep();
                    Console.Write("Invalid range!   Try again: ");
                }
            }
            return isInt;
        }

        /// <summary>
        /// Gets a valid user entered integer from Console.
        /// </summary>
        /// <returns>Returns valid integer.</returns>
        public static int ReadLineInteger()
        {
            int isInt;  // Do not need to initailize variable since "out" keyword is used below and does it for me
            do
            {   // Could have used try/catch block here but TryParse method does it for me
                string Number = Console.ReadLine();
                if (Int32.TryParse(Number, out isInt))          // Returns "True" if the string was converted into a number
                    break;  // Good number so end the loop      // "out" keyword passes actual variable to method similar
                else                                            // to "ref" keyword (p.184).
                {
                    Console.Beep();
                    Console.Write("Invalid number!  Try again: ");
                }
            } while (true);    // Don't quit the loop until a valid number is entered 
            return isInt;
        }

        /// <summary>
        /// Gets a valid user entered double from Console between min and max parameters.
        /// </summary>
        /// <param name="min">Minumum double.</param>
        /// <param name="max">Maximum double.</param>
        /// <returns>Returns valid double between min and max parameters.</returns>
        public static double ReadLineDoubleMinMax(double min, double max)
        {
            double isDouble;
            while (true)
            {
                isDouble = ReadLineDouble();    // Get the double from the console
                if (isDouble >= min && isDouble <= max)
                    break;  // Good number so end the loop
                else
                {
                    Console.Beep();
                    Console.Write("Invalid range!   Try again: ");
                }
            }
            return isDouble;
        }

        /// <summary>
        /// Gets a valid user entered double from Console.
        /// </summary>
        /// <returns>Returns valid double.</returns>
        public static double ReadLineDouble()
        {
            double isDouble;  // Do not need to initailize variable since "out" keyword is used below and does it for me
            do
            {   // Could have used try/catch block here but TryParse method does it for me
                string Number = Console.ReadLine();
                if (Double.TryParse(Number, out isDouble))      // Returns "True" if the string was converted into a number
                    break;  // Good number so end the loop      // "out" keyword passes actual variable to method similar
                else                                            // to "ref" keyword (p.184).
                {
                    Console.Beep();
                    Console.Write("Invalid number!  Try again: ");
                }
            } while (true);     // Don't quit the loop until a valid number is entered 
            return isDouble;
        }

        /// <summary>
        /// Displays a question and chacks if response is Y, y, N, or n.
        /// </summary>
        /// <param name="question">Question to ask.</param>
        /// <returns>True if answer was Y or y.  Returns false if answer was N or n.</returns>
        public static bool ReadlineCheckYN(string question)
        {
            string response;
            bool answer;
            do
            {
                Console.Write($"{question} (y/n): ");
                response = Console.ReadLine();
                if ((response == "y") || (response == "Y"))
                {
                    answer = true;      // Entry was Y or y so do another calculation
                    break;
                }
                else if ((response == "n") || (response == "N"))
                {
                    answer = false;     // Response was N or n
                    break;
                }
                else
                {                       // Invalid response so keep asking
                    Console.Beep();
                    Console.Write("Invalid answer!  Try again: ");
                }
            } while (true);
            return answer;
        }

        /// <summary>
        /// For Console use. Display pause message and pause until a key is pressed
        /// </summary>
        public static void ConsolePause()
        {
            Console.Write("\nPress any key to continue: ");
            Console.ReadKey(true);  // ReadKey will not display the key pressed if "true" option included
        }

        /// <summary>
        /// Displays parameter text to console in reverse colors.
        /// </summary>
        /// <param name="header">Text to display in reverse colors.  No linefeeds added.</param>
        public static void ReverseConsoleColors(string header)
        {
            ConsoleColor curFGColor = Console.ForegroundColor;  // save the current colors
            ConsoleColor curBGColor = Console.BackgroundColor;
            Console.ForegroundColor = curBGColor;   // Swap the colors to print out header
            Console.BackgroundColor = curFGColor;
            Console.Write("\n" + header + "\n");    // write the header line to the console
            Console.ForegroundColor = curFGColor;   // Restore the original colors
            Console.BackgroundColor = curBGColor;
        }

        /// <summary>
        /// Construct a valid filename from strings consiting of path, filename, and file extension
        /// </summary>
        /// <param name="pathToFile">Valid path to file. Example="C:\Users\Me\Desktop"</param>
        /// <param name="fileName">Valid file name with no extension.  Example="MyText"</param>
        /// <param name="extendType">Valid file extension. Example="txt"</param>
        /// <returns>Valid file name. Example="C:\Users\Me\Desktop\MyText.txt"</returns>
        public static string FileNameBuild( string pathToFile, string fileName, string extendType )
        {
            // This function is eventually going to need a bunch of error checking
            return pathToFile + @"\" + fileName + "." + extendType;
        }

        /// <summary>
        /// Write a string into a text file.
        /// </summary>
        /// <param name="pathNameExt">Valid path, name, and extension to file. Example="C:\Users\Me\Desktop\MyText.txt"</param>
        /// <param name="stringToFile">String containing contents to write to text file</param>
        public static void WriteStringToFile( string pathNameExt, string stringToFile )
        {
            // This method is eventually going to need a bunch of error checking
            // Before writing file check if it already exist?  Do I want to put this here?
            File.WriteAllText( pathNameExt, stringToFile );
            //
            // File.WriteAllText( fileName, stringToFile, Encoding.UTF8);  // Use this method to enforce encoding and include a BOM
            // https://msdn.microsoft.com/en-us/library/system.text.encoding(v=vs.110).aspx
            // https://en.wikipedia.org/wiki/Byte_order_mark
            //
            // May want to return "true" if write was sucessful
        }

        /// <summary>
        /// Read a text file into a string.
        /// </summary>
        /// <param name="pathNameExt">Valid path, name, and extension to file. Example="C:\Users\Me\Desktop\MyText.txt"</param>
        /// <returns>String containing contents of file that was read</returns>
        public static string ReadFileToString( string pathNameExt )
        {
            // This function is eventually going to need a bunch of error checking
            return File.ReadAllText( pathNameExt );   // Open the file and read it into the return string
        }

        /// <summary>
        /// Read a text file into an array of strings
        /// </summary>
        /// <param name="pathNameExt">Valid path, name, and extension to file. Example="C:\Users\Me\Desktop\MyText.txt"</param>
        /// <returns>Array of strings containing contents of file that was read</returns>
        public static string[] ReadFileToStringArray( string pathNameExt )
        {
            // This function is eventually going to need a bunch of error checking
            return File.ReadAllLines( pathNameExt );   // Open the file and read it into the array of strings
        }

    }   // End of class=Library

}  // End of namespace=ConsolePractice01

namespace DelegateExp1     // Delegate Example1: For reference, see details in Code Sample 19 above
{
    public delegate int MathDelegate(int a, int b);
}

namespace DelegateExp2     // Delegate Example2: For reference, see details in Code Sample 19 above
{
    public delegate void LogEventHandler(LogEvent logEvent);  // Delegates usually declared in separate namespace

    public class LogEvent   // Used in Code Sample 19 above.  // Without indirect referencing, Delegate classes should be in same namespace
    {
        public string LogMsg { get; }
        public LogEvent(string text)    // Constuctor
        {
            LogMsg = text;
        }
    }
}


/*
The event keyword makes this member something that others can attach too!  Public, internal, protected, can be used but
typically is public or internal.  EventHandler is a delegate.  Technically, any delegate can be used but .Net events has 
stricter guidelines. .Net requires events to have two parameters, the source/sender object, and 'e' parameter that
encapsulates any addition information about the event.

*/

namespace Events    // Event examples, step-by-step:  For reference, see details in Code Sample 20 above
{
    public class Point  // Create an event used in Code Sample 20 above
    {
        // Step #1: Define the event.  See notes above this namespace for additional details.
        public event EventHandler PointChanged;     //EventHandler is a delegate.

        // Step #2: Create method to raise the event.  This is considered the "Sender".
        private void OnPointChanged()
        {
            PointChanged?.Invoke(this, EventArgs.Empty);  // Keyword "this" sends object of this sender
                                                          // the 'e' parameter is .Empty in this case since no addition information
        }
        
        private double x;
        private double y;
        
        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPointChanged();   // Step #3: Locate and create calls to the method that will raise the event.
                                      // In this case, if point is changed, event will be raised. 
            }
        } 

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPointChanged();   // Step #3: Locate and create calls to the method that will raise the event.
                                      // In this case, if point is changed, event will be raised.
            }
        }
    }
}


namespace OpOverloading
{
    
    // Operators must be overloaded in pairs.  For example, if you overload '+' you must also overload '-'.
    
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class Vector
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        public double X; // { get; set; }
        public double Y; // { get; set; }

        public Vector( double x, double y )
        {
            X = x;
            Y = y;
        }

        public static Vector operator +( Vector v1, Vector v2 )
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator +( Vector v, double scalar )
        {
            return new Vector(v.X + scalar, v.Y + scalar);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return ( (v1.X == v2.X) && (v1.Y == v2.Y) );
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }
    }
}

