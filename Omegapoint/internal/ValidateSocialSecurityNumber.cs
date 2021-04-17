using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Omegapoint
{
    internal class ValidateSocialSecurityNumber
    {
        public bool Validate(string s)
        {
            if (s == null) return false;
            //Check length, should be 13
            if (s.Length != 13) return false;

            //Check for "-"
            //If it doen't exist return false
            //If it does remove it.
            if (s[8] != '-') return false;
            StringBuilder _sb = new StringBuilder(s);
            _sb.Remove(8, 1);
            s = _sb.ToString();

            //Check for chars - if it exists return false
            if (CheckForChars(s)) return false;

            //Calculation
            return SocialSecurityNumberAlgorithm(s);
        }

        private bool CheckForChars(string s)
        {
            //"[^0-9]" = regex expression for all char except 0-9
            Regex _reg = new Regex("[^0-9]");
            return _reg.IsMatch(s);
        }

        private bool SocialSecurityNumberAlgorithm(string s)
        {
            int _sum = 0;
            int _multiplier = 2;
            //Do the digit algorithm on all char in s except for the two first and the last char.
            for(int i = 2; i < s.Length - 1; i++)
            {
                _sum += DigitAlgorithm(s[i], _multiplier);
                _multiplier = (_multiplier == 2) ? 1 : 2;
            }

            _sum = _sum % 10;
            _sum = 10 - _sum;
            _sum = _sum % 10;
            if (_sum == (s[11] - '0')) return true;
            return false;
        }

        private int DigitAlgorithm(char n, int multiplier)
        {
            //We know the char is a number
            int _number = n - '0';
            //First step of algorithm
            int _tmp = _number * multiplier;
            //If less than 10 return
            if (_tmp / 10 == 0) return _tmp;
            //If tmp is >= 10
            int _retVal = 0;
            while(_tmp != 0)
            {
                _retVal += _tmp % 10;
                _tmp = _tmp / 10;
            }
            return _retVal;
        }
    }
}
