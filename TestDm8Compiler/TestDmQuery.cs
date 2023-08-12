using DM8.Models;
using SqlKata.Execution;

namespace TestDm8Compiler
{
    [TestClass]
    public class TestDmQuery : UnitTestDm8CompilerBase
    {
        [TestMethod]
        public async Task Test_PersonIdOne_ReturnNameLiLi()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var actName = (await _db.Query("PERSON.PERSON")
                .Where("PERSONID", 1)
                .OrderByDesc("PERSONID")
                .FirstOrDefaultAsync<Person>()).Name;

                var expectedName = "李丽";

            Assert.AreEqual(expectedName, actName);

        }

        [TestMethod]
        public async Task Test_PersonIdOne_CountReturnOne()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = (await _db.Query("PERSON.PERSON")
                .Where("PERSONID", 1)
                .CountAsync<int>());

            var expected =1;

            Assert.AreEqual(expected, act);

        }

        [TestMethod]

        public async Task Test_ForPage()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("PERSON.PERSON")
                .Where("PERSONID","<=", 5)
                .OrderByDesc("PERSONID")
                 .ForPage(1, 5)
                .GetAsync<Person>();

            Assert.AreEqual(5, act.Count());
        }

        [TestMethod]

        public async Task Test_WhereDateCondition()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("RESOURCES.EMPLOYEE")
                .Where("BIRTHDATE", "<=", "1980-08-05 10:00:00")
                .CountAsync<int>();

            Assert.AreNotEqual(0, act);
        }

        [TestMethod]

        public async Task Test_WhereNotNull()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("RESOURCES.EMPLOYEE")
                .WhereNotNull("MANAGERID")
                .CountAsync<int>();

            Assert.AreNotEqual(0, act);
        }

        [TestMethod]

        public async Task Test_Distinct()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("RESOURCES.EMPLOYEE")
                .Distinct()
                .Select("MARITALSTATUS")
                .GetAsync<char>();

            Assert.AreEqual(2, act.Count());
        }

        [TestMethod]

        public async Task Test_OrderByLimit()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("PERSON.PERSON")
               .Where("PERSONID", "<=", 5)
               .OrderByDesc("PERSONID")
                .Limit(5)
               .GetAsync<Person>();

            Assert.AreEqual(5, act.Count());
        }

        [TestMethod]

        public async Task Test_WhereTrue()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("PURCHASING.VENDOR")
               .WhereTrue("ACTIVEFLAG")
               .CountAsync<int>();

            Assert.AreEqual(12, act);
        }

        [TestMethod]

        public async Task Test_SelectRaw()
        {
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("PURCHASING.VENDOR")
               .WhereTrue("ACTIVEFLAG")
               .SelectRaw("COUNT(1) AS CreCount").GroupBy("CREDIT")
               .GetAsync<FakeCreditCount>();

            Assert.AreEqual(2, act.Count());
        }

        [TestMethod]

        public async Task Test_LeftJoin()
        {
            var _db = CreateDefaultDm8QueryFactory();

            var act = await _db.Query("PURCHASING.VENDOR AS C")
                .Select("C.VENDORID", "C.CREDIT AS CreCount")
                .LeftJoin("PURCHASING.VENDOR_ADDRESS AS G", "C.VENDORID", "G.VENDORID")
                .Where("G.ADDRESSID", ">","1")
                .OrderBy("G.ADDRESSID")
                .PaginateAsync<FakeCreditCount>(1, 5);

            Assert.AreNotEqual(1, act.Count);
        }

    }

    public class FakeCreditCount
    {
        public int Credit { get; set; } 

        public int CreCount { get; set; }
    }
}
