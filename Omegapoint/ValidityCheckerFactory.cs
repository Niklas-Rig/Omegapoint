using System;

namespace Omegapoint
{
    public class ValidityCheckerFactory 
    {
        public static IValidityChecker GetValididtyChecker()
        {
            IValidityChecker _checker = new ValidityChecker();
            return _checker;
        }

    }
}
