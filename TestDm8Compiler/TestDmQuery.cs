using NLog;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDm8Compiler.Models;

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
            var actName = (await _db.Query("Person.PERSON")
                .Where("Person.PERSON.PersonId", 1)
                .OrderByDesc("PersonId")
                .FirstOrDefaultAsync<Person>()).Name;

    

            var expectedName = "李丽";

            Assert.AreEqual(expectedName, actName);

        }

    }
}
