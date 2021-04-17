using Microsoft.VisualStudio.TestTools.UnitTesting;
using Omegapoint;

namespace ValidityCheckerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNotNull()
        {
            IValidityChecker _checker = ValidityCheckerFactory.GetValididtyChecker();
            Assert.AreEqual(false, _checker.ValidityCheckNotNull(null));
            Assert.AreEqual(true, _checker.ValidityCheckNotNull("not null"));
        }

        [TestMethod]
        public void TestNotEmpty()
        {
            IValidityChecker _checker = ValidityCheckerFactory.GetValididtyChecker();
            Assert.AreEqual(false, _checker.ValidityCheckNotEmpty(""));
            Assert.AreEqual(true, _checker.ValidityCheckNotEmpty("not empty"));
        }

        [TestMethod]
        public void TestSocialSecurityNumber()
        {
            IValidityChecker _checker = ValidityCheckerFactory.GetValididtyChecker();
            Assert.AreEqual(true, _checker.ValidityCheckSocialSecurityNumber("19950215-6814"));
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("199502156814"));      //no "-"
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("19950215-68141"));    //to long
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("19950215-681"));      //to short
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("a19950215-6814"));    //char at start
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("19950a215-6814"));    //char i middle
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("19950215-6814a"));    //char at end
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("19950215a6814"));     //char atinstead of "-"
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("03212031-3212"));     //correct format with random digits
            Assert.AreEqual(false, _checker.ValidityCheckSocialSecurityNumber("11111111-1111"));     //correct format with random digits
        }
    }
}
