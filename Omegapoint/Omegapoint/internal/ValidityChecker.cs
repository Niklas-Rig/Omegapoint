using System;

namespace Omegapoint
{
    internal class ValidityChecker : IValidityChecker
    {


        public bool RunAllValidityChecks(string s)
        {
            return ValidityCheckNotNull(s) && ValidityCheckNotEmpty(s) && ValidityCheckSocialSecurityNumber(s);
        }

        public bool ValidityCheckNotEmpty(string s)
        {
            //If validation fails = log
            if (s == "")
            {
                //Log
                Logger _log = new Logger();
                _log.WriteLog(s, "ValidityCheckNotNull");
                return false;
            }
            return true;
        }

        public bool ValidityCheckNotNull(string s)
        {
            //If validation fails = log
            if ( s == null)
            {
                //Log
                Logger _log = new Logger();
                _log.WriteLog(s, "ValidityCheckNotEmpty");
                return false;
            }
            return true;
        }

        public bool ValidityCheckSocialSecurityNumber(string s)
        {
            ValidateSocialSecurityNumber _validator = new ValidateSocialSecurityNumber();
            //If validation fails = log
            if (!_validator.Validate(s))
            {
                //Log
                Logger _log = new Logger();
                _log.WriteLog(s, "ValidityCheckSocialSecurityNumber");
                return false;
            }
            return true;
        }
    }
}


