using DM8.Models;
using SqlKata.Execution;

namespace TestDm8Compiler
{
    [TestClass]
    public class TestDm8Insert: UnitTestDm8CompilerBase
    {
        [TestMethod]
        public async Task TestDm8_Insert_Update_Delete()
        {
            var name = "ZhangJingchun";
            var _db = CreateDefaultDm8QueryFactory();
            var act = await _db.Query("PERSON.PERSON").InsertAsync(new 
            {
                Name = name,
                Sex = 'M',
                Email ="dddd@qq.com",
                Phone = "44545444444"

            });
            Assert.AreNotEqual(0, act);
            var nameAfter = "ZhangJingchunAfter";


            act = await _db.Query("PERSON.PERSON").Where("NAME", name).UpdateAsync(new
            {
                Name = nameAfter
            });
            Assert.AreNotEqual(0, act);

           act = await _db.Query("PERSON.PERSON").Where("NAME", nameAfter).DeleteAsync();

            Assert.AreNotEqual(0, act);
        }
    }
}
