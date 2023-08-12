using DM8.Models;
using NLog;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDm8Compiler
{
    [TestClass]
    public class TestDmQuery : UnitTestDm8CompilerBase
    {
        [TestMethod]
        public async Task TestQuery_PersonIdOne_ReturnNameLiLi()
        {
            var _db = CreateDefaultDm8QueryFactory();

            Logger logger = LogManager.GetCurrentClassLogger();
            _db.Logger = compiled => {
                logger.Info(compiled.ToString());
            };
            var actName = (await _db.Query("PERSON.PERSON")
                .Where("PERSONID", 1)
                .OrderByDesc("PERSONID")
                .FirstOrDefaultAsync<Person>()).Name;

                var expectedName = "李丽";

            Assert.AreEqual(expectedName, actName);

        }

    }
}
