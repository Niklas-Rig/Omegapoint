using System;
using System.IO;
using Omegapoint;

namespace Interaction
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidityChecker _checker = ValidityCheckerFactory.GetValididtyChecker();
            Console.WriteLine("Enter string to validate : ");
            string _input = Console.ReadLine();
            if (_checker.RunAllValidityChecks(_input))
                Console.WriteLine("All validations passed on " + '"' + _input + '"');
            else
                Console.WriteLine("All validations did NOT pass on " + '"'+ _input + '"');

        }
    }
}
