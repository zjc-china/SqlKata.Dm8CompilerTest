using Dm;
using Dm8Compilers;
using NLog;
using SqlKata.Compilers;
using System.Data;
using System.Data.Common;

namespace TestDm8Compiler
{
    [TestClass]
    public class UnitTestDm8CompilerBase
    {
        public const string ConnectionString = "Server=127.0.0.1:5236;Database=PERSON;UserId=SYSDBA;Pwd=a1314521@";

        public Dm8QueryFactory CreateDefaultDm8QueryFactory()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            var connection = new DmConnection(ConnectionString);
            var db = new Dm8QueryFactory(
                new DmConnection(ConnectionString), new Dm8Compiler("PERSON"));
                 db.Logger = compiled => {
                     logger.Info(compiled.ToString());
                 };
            return db;
        }

        public DbConnection CreateDefaultDmConnection()
        {
            DmConnection dmConnection = new(ConnectionString);
            DbConnection connection = dmConnection;

            return connection;
        }
    }
}