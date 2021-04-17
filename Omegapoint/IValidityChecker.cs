using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omegapoint
{
    public interface IValidityChecker
    {
        bool ValidityCheckNotNull(string s);
        bool ValidityCheckNotEmpty(string s);
        bool ValidityCheckSocialSecurityNumber(string s);

        bool RunAllValidityChecks(string s);
      
    }
}
