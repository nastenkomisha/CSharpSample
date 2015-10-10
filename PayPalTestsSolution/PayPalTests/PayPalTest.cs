using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using PayPalTests.Model;

namespace PayPalTests
{
    [TestFixture()]
    public class PayPalTest : TestBase
    {
        [Test, TestCaseSource(nameof(GetCredentials))]
        public void Test(AccountData account)
        {
            ApplicationManager.LoginHelper.Login(account);
            Assert.IsTrue(ApplicationManager.LoginHelper.IsLoggedIn(), "The user is not logged in");
            ApplicationManager.UserProfileHelper.OpenUserProfile();
            Assert.IsTrue(ApplicationManager.UserProfileHelper.IsOnUserProfilePage(), "User profile page is not opened");
            ApplicationManager.UserProfileHelper.ChangeAddress();
            ApplicationManager.UserProfileHelper.ChangePhone();
            ApplicationManager.UserProfileHelper.GetListOfOperations();
        }

        private static IEnumerable<AccountData> GetCredentials()
        {
            return JsonConvert.DeserializeObject<List<AccountData>>(
                File.ReadAllText(@"data\Credentials.json"));
        }
    }
}
