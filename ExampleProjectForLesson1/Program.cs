using System;

namespace ConsoleApp1
{
    class Program
    {
        private const int MoreThanByte = 256;

        private static void EvaluateExpression()
        {
            Console.WriteLine("\r\nFUNCTION 1: EXPRESSION EVALUATION:");

            Console.WriteLine("\r\nEnter X");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("\r\nEnter Y");
            int y = int.Parse(Console.ReadLine());

            double result = Math.Pow(x + y, y) * 2 * Math.Sqrt(x) / Math.Cos(45);
            Console.WriteLine("\r\nFUNCTION 1: EXPRESSION EVALUATION: {0}", result);
        }

        private static void DemonstrateOverflowExample()
        {
            Console.WriteLine("\r\nFUNCTION 2: UNCHECKED OVERFLOW EXAMPLE");

            Console.WriteLine("\r\nEnter number in -128..127 range");
            sbyte enteredNumber = sbyte.Parse(Console.ReadLine());

            Console.WriteLine($"\r\nOverflowed variable: {(byte) (enteredNumber + MoreThanByte)}");
        }

        private static void DemonstrateCheckedOverflowExample()
        {
            Console.WriteLine("\r\nFUNCTION 3: CHECKED OVERFLOW EXAMPLE");

            Console.WriteLine("\r\nEnter number in -128..127 range");
            sbyte enteredNumber = sbyte.Parse(Console.ReadLine());

            checked
            {
                try
                {
                    enteredNumber = (sbyte)(enteredNumber + MoreThanByte);
                }
                catch (OverflowException overflowException)
                {
                    Console.WriteLine(overflowException);
                }
            }
        }

        private static void DemonstrateNumberFormatsAndTypesSizes()
        {
            Console.WriteLine("\r\nFUNCTION 4: DIFFERENT FORMATS AND TYPES SIZES IN BYTES");
            Console.WriteLine("\r\nNUMBER FORMATS:\r\n");
            Console.WriteLine("C (Money) format: {0:C}", 99.9);
            Console.WriteLine("F (Fixed) format: {0:##}", 99.935);
            Console.WriteLine("N (Standard number) format: {0:N}", 99999);
            Console.WriteLine("X (HEX) format: {0:X}", 255);
            Console.WriteLine("D (Decimal) format: {0:D}", 0xFF);
            Console.WriteLine("E (Exponential) format: {0:E}", 9999);
            Console.WriteLine("G (Generic) format: {0:G}", 99.9);
            Console.WriteLine("P (Percents) format: {0:P}", 99.9);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("\r\nBYTE SIZES OF TYPES:\r\n");
            Console.WriteLine("Size of bool: {0} byte.", sizeof(bool));
            Console.WriteLine("Size of byte: {0} byte.", sizeof(byte));
            Console.WriteLine("Size of short: {0} byte.", sizeof(short));
            Console.WriteLine("Size of char: {0} byte.", sizeof(char));
            Console.WriteLine("Size of int: {0} byte.", sizeof(int));
            Console.WriteLine("Size of double: {0} byte.", sizeof(double));
            Console.WriteLine("Size of long: {0} byte.", sizeof(long));
        }

        private static void DemonstrateStringOperations()
        {
            Console.WriteLine("\r\nFUNCTION 5: STRING OPERATIONS");

            Console.WriteLine("\r\nEnter first string");
            string firstString = Console.ReadLine();

            Console.WriteLine("\r\nEnter second string");
            string secondString = Console.ReadLine();

            Console.WriteLine("String concatenation: " + firstString + secondString);

            bool isFirstStringContainsSecond = firstString.Contains(secondString);
            Console.WriteLine("\r\nExpression that first string contains second is {0}", isFirstStringContainsSecond);

            Console.WriteLine("\r\nExpression that first string length greater than second is " +
                              $"{firstString.Length > secondString.Length}");
        }

        static void Main(string[] args)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\r\nPlease choose function to test or press Q to exit:" +
                                  "\r\nPress 1: To evaluate following expession: ((X+Y)^Y * 2*SQRT(X))/COS(45)" +
                                  "\r\nPress 2: To overflow signed byte variable" +
                                  "\r\nPress 3: To TRY overflow signed byte variable in checked block" +
                                  "\r\nPress 4: To check different number formats and byte sizes of common types" +
                                  "\r\nPress 5: To check different operations with strings");
                var enteredCharacter = Console.ReadLine();
                if (enteredCharacter.ToUpper() == "Q")
                {
                    break;
                }

                var isNumber = int.TryParse(enteredCharacter, out var chosenFunction);
                if (!isNumber)
                {
                    Console.WriteLine("ERROR: Please enter the correct function number");

                    continue;
                }

                switch (chosenFunction)
                {
                    case 1:
                        EvaluateExpression();
                        break;
                    case 2:
                        DemonstrateOverflowExample();
                        break;
                    case 3:
                        DemonstrateCheckedOverflowExample();
                        break;
                    case 4:
                        DemonstrateNumberFormatsAndTypesSizes();
                        break;
                    case 5:
                        DemonstrateStringOperations();
                        break;
                }
            }
        }
    }
}
