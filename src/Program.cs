/*

MIT License

Copyright (c) 2020 Mikail B.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AVAX
{
    internal class Program
    {
        private static String _targetedOrActive;

        private static String _word;

        private static DateTime _time;

        private static char _apostrophe = Convert.ToChar("'");

        private static Boolean _protoColing;

        private static Boolean _hideChars;

        private static StreamWriter _protocol;

        private static char[] _chars =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', '!', '"', '#', '$', '%', '&',
            _apostrophe, '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?',
            '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'
        };

        static void Main(string[] args)
        {
            if (_chars.Length == 0)
                throw new Exception("Value cannot be an empty collection.");

            Console.WriteLine("\n" + "AVAX - BRUTEFORCE ALGORITHM");

            Console.WriteLine("");

            Console.WriteLine("\n" + "ALGORITHM - TARGETED | ACTIVE");

            Console.WriteLine("");

            _targetedOrActive = Console.ReadLine();

            if (_targetedOrActive != null && _targetedOrActive.Equals("TARGETED", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("");

                Console.WriteLine("ALGORITHM - TARGETED");

                Console.WriteLine("");

                Console.WriteLine("AVAX - WORD");

                Console.WriteLine("");

                _word = Console.ReadLine();

                if (_word != null)
                {
                    Console.WriteLine("");

                    Console.WriteLine("AVAX - PROTOCOLING");

                    Console.WriteLine("");

                    _protoColing = Convert.ToBoolean(Console.ReadLine());

                    if (_protoColing)
                    {
                        _protocol = new StreamWriter("AVAX-LOG.txt");
                    }

                    Console.WriteLine("");

                    Console.WriteLine("AVAX - HIDE CHARACTERS");

                    Console.WriteLine("");

                    _hideChars = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine("");

                    var maxPasswordSize = _chars.Length;

                    _time = DateTime.Now;

                    for (int i = 1; i <= maxPasswordSize; i++)
                    {
                        PrintPasswords(_chars, i);
                    }
                }

                else
                {
                    Console.WriteLine("");

                    Console.WriteLine("AVAX - TERMINATION");

                    Environment.Exit(0);
                }
            }

            if (_targetedOrActive != null && _targetedOrActive.Equals("ACTIVE", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("");

                Console.WriteLine("ALGORITHM - ACTIVE");

                Console.WriteLine("");

                Console.WriteLine("AVAX - PROTOCOLING");

                Console.WriteLine("");

                _protoColing = Convert.ToBoolean(Console.ReadLine());

                if (_protoColing)
                {
                    _protocol = new StreamWriter("AVAX-LOG.txt");
                }

                var maxPasswordSize = _chars.Length;

                for (int i = 1; i <= maxPasswordSize; i++)
                {
                    PrintPasswords(_chars, i);
                }
            }

            if (_targetedOrActive != null && (_targetedOrActive == null && !_targetedOrActive.Equals("Active") ||
                                              !_targetedOrActive.Equals("Targeted")))
            {
                Console.WriteLine("");

                Console.WriteLine("AVAX - Termination");

                Environment.Exit(0);
            }
        }

        private static void PrintPasswords(char[] _chars, int passwordSize)
        {
            var charCount = _chars.Length;

            var totalPossibilities = (long) Math.Pow(_chars.Length, passwordSize);

            for (long i = 0; i < totalPossibilities; i++)
            {
                var value = i;

                StringBuilder bruteForceChars = new StringBuilder();

                while (value > 0)
                {
                    bruteForceChars.Append(_chars[value % charCount]);

                    value = value / charCount;
                }

                while (bruteForceChars.Length < passwordSize)
                {
                    bruteForceChars.Append(_chars[0]);
                }

                if (_protoColing)
                {
                    _protocol.WriteLine(bruteForceChars);
                }

                if (bruteForceChars.ToString().Equals(_word))
                {
                    Console.WriteLine("");

                    Console.WriteLine("ALGORITHM - DECRYPTED | " + bruteForceChars);

                    Console.WriteLine("");

                    Console.WriteLine("ALGORITHM - INTERVAL | {0}s", DateTime.Now.Subtract(_time).TotalSeconds);

                    Console.WriteLine();

                    if (_protoColing)
                    {
                        _protocol.WriteLine("");

                        _protocol.WriteLine("ALGORITHM - DECRYPTED | " + bruteForceChars);

                        _protocol.WriteLine("");

                        _protocol.WriteLine("ALGORITHM - INTERVAL | {0}s", DateTime.Now.Subtract(_time).TotalSeconds);

                        _protocol.WriteLine();

                        _protocol.Close();
                    }

                    if (Console.ReadLine() == null || Console.ReadLine() != null)
                    {
                        Console.WriteLine("AVAX - Termination");

                        Thread.Sleep(500);

                        Environment.Exit(0);
                    }
                }

                if (_hideChars)
                {
                }
                else
                {
                    Console.WriteLine(bruteForceChars + " ");
                }
            }
        }
    }
}