using DM8EfCore;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace DM8.EFCoreTest
{
    [TestClass]
    public class EfCoreQueryTest
    {
        public Logger logger = LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new DM8DbContext())
            {
                var linq = context.Persons.Where(p => p.PersonId == 1);
                var sql = linq.ToQueryString();
                logger.Info("[EFCore] linq转化为的SQL语句为：" + sql);
                var actName = linq.FirstOrDefault().Name;
                var expectedName = "李丽";

                Assert.AreEqual(expectedName, actName);
            }
        }
    }
}