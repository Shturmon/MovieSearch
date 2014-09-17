using System.Transactions;
using NUnit.Framework;

namespace Tests
{
    public class TestsBase
    {
        private TransactionScope scope;

        [SetUp]
        public void Initialize()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TestCleanup()
        {
            scope.Dispose();
        }
    }
}
